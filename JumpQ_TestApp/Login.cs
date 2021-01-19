using Newtonsoft.Json;
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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        SettingsModel settingsModel = new SettingsModel();
        APIRoute apiroute = new APIRoute();
        private void BtnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if ((TxtUsername.Text != string.Empty) && TxtPassword.Text != string.Empty)
                {
                    if (System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable() == true)
                    {
                        LoginApiCall();

                        return;
                    }
                    else
                    {
                        MessageBox.Show("Make sure you have an active internet access", "JumpQ Konnect Alert");
                    }
                   
                }
                else if ((TxtUsername.Text != string.Empty) || TxtPassword.Text != string.Empty) 
                {
                    MessageBox.Show("Your login details is needed", "JumpQ Konnect!");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message); ;
            }
        }

        #region Methods
        void LoginApiCall()
        {
            settingsModel.Username= TxtUsername.Text;
            settingsModel.Password = TxtPassword.Text;
            string method = "POST";
            string json = JsonConvert.SerializeObject(new
            {
                username = settingsModel.Username,
                password = settingsModel.Password 
            });

            WebClient wc = new WebClient();
            wc.Headers["Content-Type"] = "application/json";
            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                var Response = wc.UploadString(apiroute.LoginEndpoint, method, json);
                //  var user= JsonConvert.DeserializeObject<winformClient>(response1); //This line might not be needed
                if (Response != null)
                {
                   Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(Response);
                   settingsModel.Token  = myDeserializedClass.user.api_token;
                   saveSettings();
                   MainForm Mainform = new MainForm();
                   Mainform.Show();
                   this.Hide();
                }
                else
                {
                    //Check for internet connectivity
                    MessageBox.Show("Please check internet connectivity");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void saveSettings()
        {
         
            Properties.Settings.Default.ApiToken = settingsModel.Token;
            Properties.Settings.Default.Username = settingsModel.Username;
            Properties.Settings.Default.Password = settingsModel.Password;
            Properties.Settings.Default.Save();
        }

        #endregion
    }
}
