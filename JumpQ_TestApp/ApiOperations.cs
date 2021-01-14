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
            //this.baseUrl + "/users/login";
            string endpoint = this.baseUrl + "/api/staff/login";//"https: //www.myjumpq.net/staff/login";
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



        /**
 * Get User Details from Web Api
 * @param  User Model
 */
        public winformClient GetUserDetails(winformClient user)
        {
            // user.Id=1;
            //  string endpoint = "https: //www.myjumpq.net/staff/" + 1;
            string endpoint = this.baseUrl + "/api/staff/";// +user.Id;
            string access_token = user.api_token;

            WebClient wc = new WebClient();
            wc.Headers["Content-Type"] = "application/json";
            wc.Headers["Authorization"] = access_token;
            try
            {
                string response = wc.DownloadString(endpoint);
                user = JsonConvert.DeserializeObject<winformClient>(response);
                user.api_token = access_token;
                return user;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /**
 * Register User
 * @param  string username
 * @param  string password
 * @param  string firstname
 * @param  string lastname
 * @param  string middlename
 * @param  int    age
*/
        //  String baseUrl=
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
