using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JumpQ_TestApp
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            if (jumpQ == null)
                jumpQ = new JumpQ_Task.Form1();
           // 
           // Thread.Sleep(3000);
        }
        SettingsModel settingsModel = new SettingsModel();
        APIRoute apiroute = new APIRoute();
        public JumpQ_Task.Form1 jumpQ = new JumpQ_Task.Form1();
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
            catch 
            {

                MessageBox.Show("Error Logging in", "JumpQ Konnect!"); 
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
            Properties.Settings.Default.Cashier = settingsModel.Username;
            Properties.Settings.Default.Save();
        }

        #endregion

        private void ChkRemember_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkRemember.Checked == true)
            {
                Properties.Settings.Default.Password = TxtPassword.Text;
                Properties.Settings.Default.Username = TxtUsername.Text;
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.Password = string.Empty;
                Properties.Settings.Default.Username = string.Empty;
                Properties.Settings.Default.Save();
            }
        }
     
        private void Login_Load(object sender, EventArgs e)
        {
          
            

            TxtPassword.Text= Properties.Settings.Default.Password ;
            TxtUsername.Text= Properties.Settings.Default.Username ;
            if (TxtPassword.Text != string.Empty && TxtUsername.Text != string.Empty)
            {
                ChkRemember.Checked = true;
            }
            else
            {
                ChkRemember.Checked = false;
            }
             // Process.Start(jumpQ.returnPath() + "\\JumpQ_Task.exe");
            //Process.Start()

            //var thread = new Thread(() =>
            //{
            Thread.Sleep(1000);
            jumpQ.Show();

            //});
            //thread.Start();
          
        }

        public void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (jumpQ != null)
            jumpQ.Close();
        }

    
    }
}
