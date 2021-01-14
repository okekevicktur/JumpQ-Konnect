using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.IO;            //Needs to be added
using System.Net;           //Needs to be added

namespace JumpQ_TestApp
{
    public enum  httpVerb
    {
       GET,
        POST,
        PUT,
        DELETE
    }

    public enum authenticationType
    {
        Basic,
        NTLM
    }

    public enum autheticationTechnique
    {
        RollYourOwn,
        NetworkCredential
    }


    class RestClient
    {
        public string endPoint { get; set; }
        public httpVerb httpMethod { get; set; }
        public authenticationType authType { get; set; }
        public autheticationTechnique authTech { get; set; }
        public string userName { get; set; }
        public string userPassword { get; set; }
        public string postJSON { get; set; } 

    //     "username": "joel12",
    //"password": "polinium12"


        //Default  Constructor
        public RestClient()
        {
            endPoint = "";
          //  httpMethod = httpVerb.GET;
            
        }

        public string makeRequest()
        {

            //var client = new RestClient("{{BASE_URL}}/staff/add_products");
            //client.Timeout = -1;
            //var request = new RestRequest(Method.POST);
            //request.AddParameter("text/plain", "{\n    \"products\": [\n        {\n            \"name\": \"Eva Soap\",\n            \"price\": 150,\n            \"cost_price\": 100,\n            \"barcode\": \"55S5D25EERA\",\n            \"description\": \"A sample description of the product\",\n            \"quantity\": 50\n        }\n    ]\n}", ParameterType.RequestBody);
            //IRestResponse response = client.Execute(request);
            //Console.WriteLine(response.Content);


            string strResponseValue = string.Empty;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(endPoint);

            request.Method = httpMethod.ToString();

            //if (authTech == autheticationTechnique.RollYourOwn)
            //{
            //    //We'll only do Basic Authentication if we roll our own
            //    String authHeaer = System.Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(userName + ":" + userPassword));
            //    request.Headers.Add("Authorization", "Basic " + authHeaer);
            //}
            //else
            //{
                NetworkCredential netCred = new NetworkCredential(userName, userPassword);
                request.Credentials = netCred;
            //}
            
            HttpWebResponse response = null;

            //********* NEW CODE TO SUPPORT POSTING *********
            if (request.Method == "POST" && postJSON != string.Empty)
            {
                request.ContentType = "application/json"; //Really Important
                using (StreamWriter swJSONPayload = new StreamWriter(request.GetRequestStream()))
                {
                    swJSONPayload.Write(postJSON);
                    swJSONPayload.Close();
                }
            }











            try 
            {
                response = (HttpWebResponse)request.GetResponse();
                

                //Proecess the resppnse stream... (could be JSON, XML or HTML etc..._

                using (Stream responseStream = response.GetResponseStream())
                {
                    if(responseStream != null)
                    {
                        using (StreamReader reader = new StreamReader(responseStream))
                        {
                            strResponseValue = reader.ReadToEnd();
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                //We catch non Http 200 responses here.
                strResponseValue = "{\"errorMessages\":[\"" + ex.Message.ToString() + "\"],\"errors\":{}}";
            }
            finally
            {
                if(response != null)
                {
                    ((IDisposable)response).Dispose();
                }
            }

            return strResponseValue;

        }//End of makeRequest
       
        
    }//End of Class
   
   
}
