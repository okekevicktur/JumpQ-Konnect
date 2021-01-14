using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JumpQ_TestApp
{
    public partial class TestClient : Form
    {
        public TestClient()
        {
            InitializeComponent();
     
        }
        public event System.Windows.Forms.WebBrowserNavigatingEventHandler Navigating;
        //string postData = "user_id=james&passwd=polinium";
        string URL = "https://myjumpq.net/api/staff/login";
        void ClientS()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
            request.Method = "Get";
            request.KeepAlive = true;
            request.Proxy.Credentials = System.Net.CredentialCache.DefaultCredentials;
           
            request.UseDefaultCredentials = true;
          //  NetworkCredential myCredentials = new NetworkCredential("", "", "");
      
            request.Credentials = new NetworkCredential("james", "polinium", URL);
            request.ContentType = "application/json";
            //request.ContentType = "application/x-www-form-urlencoded";

            //get cookie from Web API
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            foreach (Cookie cookieValue in response.Cookies)
            {
                MessageBox.Show("Cookie: " + cookieValue.ToString());
                //store in your winform application
            }
            //get content
            string myResponse = "";
            using (System.IO.StreamReader sr = new System.IO.StreamReader(response.GetResponseStream()))
            {
                myResponse = sr.ReadToEnd();
                textBox1.Text = myResponse;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClientS();
        }


  /**
 * Authenticate user with Web Api Endpoint
 * @param string username
 * @param string password
 */
//     var client = new RestClient("{{BASE_URL}}/staff/login");
//client.Timeout = -1;
//var request = new RestRequest(Method.POST);
//request.AddParameter("text/plain", "{\n    \"username\": \"joel12\",\n    \"password\": \"polinium12\"\n}",  ParameterType.RequestBody);
//IRestResponse response = client.Execute(request);
//Console.WriteLine(response.Content);
        private void button2_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string firstname = txtFirstName.Text;
            string lastname = txtLastname.Text;
            string email = txtemail.Text;
            //int age = int.Parse(tbxAge.Text);

            ApiOperations ops = new ApiOperations();
            winformClient user =ops.RegisterUser(username, password, firstname, lastname, email);
            if (user == null)
            {
                MessageBox.Show("Username already exists");
                return;
            }

           // Globals.LoggedInUser = user;
            MessageBox.Show("Registration successful");
         //   NavigationService.Navigate(new DetailsPage());
        }
        string baseUrl = "https://myjumpq.net/api/staff/login";
        private void button3_Click(object sender, EventArgs e)
        {

            string username = txtUsername.Text;
            string password = txtPassword.Text;

            ApiOperations ops = new ApiOperations();
            winformClient user = ops.AuthenticateUser(username, password);
            if (user == null)
            {
                MessageBox.Show("Invalid username or password");
                return;
            }
            MessageBox.Show(user.api_token);
            // Globals.LoggedInUser = user;
            MessageBox.Show("Login successful"); 
          
            //  NavigationService.Navigate(new DetailsPage());



             return;   RestClient client = new RestClient();
            client.endPoint = baseUrl;

            var request = new RestRequest(Method.POST);
            request.AddParameter("text/plain", "{\n    \"username\": \"joel\",\n    \"password\": \"polinium\"\n}", ParameterType.RequestBody);
          //  IRestResponse response = client.makeRequest(request);
            //Console.WriteLine(response.Content);

            //var client = new RestClient("{{BASE_URL}}/staff/login");
            //client.Timeout = -1;
            //var request = new RestRequest(Method.POST);
            //IRestResponse response = client.Execute(request);
            //Console.WriteLine(response.Content);


         //   return;
          
        }



    }
}
