using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace JumpQ_TestApp
{
    class ApiOperations
    {
        string baseUrl = "https://myjumpq.net";
        public winformClient AuthenticateUser(string username, string password)
        {
            
            string endpoint = this.baseUrl + "/api/staff/login";
            string method = "POST";
            string json = JsonConvert.SerializeObject(new
            {
                username = "james",
                password = "polinium"
            });

            WebClient wc = new WebClient();
            wc.Headers["Content-Type"] = "application/json";
            try
            {
                string response = wc.UploadString(endpoint, method, json);
                return JsonConvert.DeserializeObject<winformClient>(response);
             
            }
            catch (Exception)
            {
                return null;
            }
        }


        public winformClient RegisterUser(string username, string password, string firstname,
            string lastname, string email)
        {
            string endpoint = this.baseUrl + "/staff/sign_up";
            string method = "POST";
            string json = JsonConvert.SerializeObject(new
            {
                username = username,
                password = password,
                firstname = firstname,
                lastname = lastname,
                email = email

            });

            WebClient wc = new WebClient();
            wc.Headers["Content-Type"] = "application/json";
            try
            {
                string response = wc.UploadString(endpoint, method, json);
                return JsonConvert.DeserializeObject<winformClient>(response);
            }
            catch (Exception)
            {
                return null;
            }
        }


      

    }
}
