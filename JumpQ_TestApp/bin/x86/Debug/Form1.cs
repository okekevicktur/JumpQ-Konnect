using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Odbc;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading;

namespace JumpQ_Task
{
    public partial class Form1 : Form
    {
        private OdbcConnection _cn;
       // string myToken;
        APIRoute apiroute = new APIRoute();
        public Form1()
        {
            InitializeComponent();
           // WindowsManager.ClosingWindows += WindowManager_ClosingWindows;
        }
        public string returnPath()
        {
            string folder = Environment.CurrentDirectory;
            return folder;
        }
 

        private void Form1_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.Username != string.Empty && Properties.Settings.Default.Password != string.Empty)
            {
                int defaultTimer = Properties.Settings.Default.SCheduletimer; 
                ListOutDSN(); comTimer.SelectedIndex = 0;
                if (_cn == null || _cn.State == ConnectionState.Closed)
                {
                    btnConnect_Click(null, null);
                }
                //
                System.Windows.Forms.Timer myTimer = new System.Windows.Forms.Timer();
                myTimer.Interval = (defaultTimer * 60 * 60 * 1000); //45 mins
                myTimer.Tick += new EventHandler(myTimer_Tick);
                myTimer.Start();
                
               // this.WindowState = FormWindowState.Minimized;
                if(Properties.Settings.Default.IsSynch != false)
                {
                    ChkSync.Checked = true;
                       sync();
                       Hide();
                }
                else
                {
                    ChkSync.Checked = false;
                }
             
                notifyIcon1.Visible = true;
                notifyIcon1.ShowBalloonTip(1000);
                //MinimizeToTray();
              
                //Hide();
               
            }
            else
            {
               this.WindowState= FormWindowState.Normal;
              
               PlaceLowerRight();
               MessageBox.Show("Set up your login details and click Save Logs button");
              // base.OnLoad(e);
            }
            
        }
      
	
        private void myTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                if (_cn == null || _cn.State == ConnectionState.Closed)
                {


                    _cn = new OdbcConnection(string.Format("DSN={0}", cboListOfDSN.Text));
                    _cn.ConnectionTimeout = 60;
                    _cn.Open();
                    btnConnect.Text = "Connected";
                    btnConnect.ForeColor = Color.Green;
                    sync();
                }
                else
                {
                    sync();
                    // MessageBox.Show("Test");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(" Error syncing company data ");
                 //sync();
            }
           // MessageBox.Show("Test");
         
           // this.Close();
        }
        private void ListOutDSN()
        {
            cboListOfDSN.Items.Clear();

            var myODBCKeys = Registry.LocalMachine.OpenSubKey("SOFTWARE\\ODBC\\ODBC.INI\\ODBC Data Sources", false).GetValueNames();
            if (myODBCKeys != null)
            {
                foreach (var item in myODBCKeys)
                {
                    cboListOfDSN.Items.Add(item);
                    // MessageBox.Show(item);
                }

                myODBCKeys = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\\ODBC\\ODBC.INI\\ODBC Data Sources", false).GetValueNames();
                foreach (var item in myODBCKeys)
                {
                    cboListOfDSN.Items.Add(item);
                }
                //end of adding DSN to list

                if (cboListOfDSN.Items.Count > 0)
                {
                    if (cboListOfDSN.Items.Contains("QuickBooks POS Data"))
                    {
                        int index = cboListOfDSN.Items.IndexOf("QuickBooks POS Data");
                        cboListOfDSN.SelectedIndex = index;
                    }
                    else
                    {
                        cboListOfDSN.SelectedIndex = 0;

                    }
                  
                }
            }




        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboListOfDSN.SelectedIndex > -1 )
                {
                    //if (cboListOfDSN.Text == "QuickBooks Data POS")
                    //{
                    Application.DoEvents();
                   
                        if (_cn != null)
                        {
                            
                            _cn.Close();
                            _cn.Dispose();
                            _cn = null;
                           
                        }
                    
                    else if (_cn == null || _cn.State == ConnectionState.Closed)
                        {


                            _cn = new OdbcConnection(string.Format("DSN={0}", cboListOfDSN.Text));
                                   _cn.ConnectionTimeout = 60;
                            _cn.Open();
                            btnConnect.Text = "Connected";
                            btnConnect.ForeColor = Color.Green;
       
                        }

                    
                    Application.DoEvents();
                 
                }


            }
            catch (Exception )
            {
                Application.DoEvents();
                btnConnect.Text = "Error";
                btnConnect.ForeColor = Color.Red;
                return;
               // MessageBox.Show(string.Format("Error - {0}, Stack Trace {1}", ex.Message, ex.StackTrace));
            }
        }

        private void BtnSynInventory_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.Username != string.Empty || Properties.Settings.Default.Password != string.Empty)
            {

                if (_cn == null || _cn.State == ConnectionState.Closed)
                {
                    _cn = new OdbcConnection(string.Format("DSN={0}", cboListOfDSN.Text));
                    _cn.ConnectionTimeout = 60;
                    _cn.Open();
                    btnConnect.Text = "Connected";
                    btnConnect.ForeColor = Color.Green;
                    sync();
                    MinimizeToTray();
                }
                else
                {
                    sync();
                    MinimizeToTray();
                }


            }
            else
            {
                this.WindowState = FormWindowState.Normal;
                //Show();
                //MessageBox.Show("Set up your login details and click Save Logs button");
                //notifyIcon1.Visible = false;
                //PlaceLowerRight();
                //return;
            }
           
               
        

           
        }

  

        void sync()
        {
            BtnSynInventory.Text = "Sync Inventory";
            if (System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable() == true)
            {
                if (Properties.Settings.Default.Username != string.Empty && Properties.Settings.Default.Password != string.Empty)
                {
                    //MessageBox.Show(Properties.Settings.Default.Username.ToString());
                    //MessageBox.Show(Properties.Settings.Default.Password.ToString());
                        //var thread = new Thread(() =>
                        //    {
                                    LoginApiCall();
                                    FinalPost();
                        //            Thread.Sleep(5000);
						        
                        //    });
                        //thread.Start();
		
                   
                   // return;
                }
                else
                {
                    MessageBox.Show("Set up login ", "JumpQ Alert!");
                }
                return;


            }
            else
            {
              //  BtnSynInventory.Text = "No Internet connection";
                notifyIcon1.Visible = true;
                notifyIcon1.BalloonTipTitle = "JumpQ Konnect";
                notifyIcon1.BalloonTipText = "Check your internet connection";
                notifyIcon1.ShowBalloonTip(2000);
                return;
                // MessageBox.Show("Make sure you have an active internet access", "JumpQ Konnect Alert");
            }

        }
        //error here
        public async void POSTreq()
        {
            try
            {
                Root2 products = new Root2();
                Product Products = new Product();
                products.products = new List<Product>();
                string query = string.Format("SELECT Desc1,Price1,OrderCost,ALU,Desc2, QuantityOnHand FROM ItemInventory");
                InventoryTable = SelctQuery(query);
                // MessageBox.Show(InventoryTable.Rows.Count.ToString());
                int Pnam = 0; int Pbar = 0; int Pdes = 0;
                foreach (DataRow item in InventoryTable.Rows)
                {
                    // Chk if product name field is empty and give a default value if true
                    if (item[0].ToString() == string.Empty || item[0].ToString() == "" || item[0].ToString() == null)
                    {
                        Products.name = "nullName" + Pnam++;
                    }
                    else
                    {
                        Products.name = item[0].ToString();
                    }
                    
                    // Chk if product price field is empty and give a default value if true
                    if (item[1].ToString() == string.Empty || item[1].ToString() == "0.00" || item[1].ToString() == "0")
                    {
                        Products.price = 1;
                    }
                    else
                    {
                        Products.price = Convert.ToInt32(item[1].ToString());  
                    }


                    // Chk if product cost_price field is empty and give a default value if true
                    //  MessageBox.Show(item[2].ToString());
                    if (item[2].ToString() == string.Empty || item[2].ToString() == "0.00" || item[2].ToString() == "0")
                    {
                        Products.cost_price = 1;
                    }
                    else
                    {
                        Products.cost_price = Convert.ToInt32(item[2].ToString());
                    }

                    // Chk if product barcode field is empty and give a default value if true
                    if (item[3].ToString() == string.Empty || item[3].ToString() == " " || item[3].ToString() == null)
                    {
                        Products.barcode = "nullBarcode" + Pbar++;
                    }
                    else
                    {
                        Products.barcode = item[3].ToString();
                    }

                    // Chk if product description field is empty and give a default value if true
                    if (item[4].ToString() == string.Empty || item[4].ToString() == " " || item[4].ToString() == null)
                    {
                        Products.description = "nulldescriptn" + Pdes++;
                    }
                    else
                    {
                        Products.description = item[4].ToString();
                    }

                    // Chk if product quantity field is empty and give a default value if true
                    if (item[5].ToString() == string.Empty || item[5].ToString() == null)
                    {
                        Products.quantity = 0;
                    }
                    else
                    {
                        Products.quantity = Convert.ToInt32(item[5].ToString());
                    }
                   

                    products.products.Add(Products);
                }
                Uri requestUri = new Uri("https://myjumpq.net/api/staff/add_products"); //replace your Url HttpClient client = 
                var objClint = new HttpClient();
                objClint.DefaultRequestHeaders.Accept.Clear();
                objClint.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                objClint.DefaultRequestHeaders.Add("api_token", Properties.Settings.Default.Api_Token);
                // MessageBox.Show(Properties.Settings.Default.Api_Token);
                var output = JsonConvert.SerializeObject(products);


                System.Net.Http.HttpResponseMessage response = await objClint.PostAsync(requestUri, new StringContent(output, System.Text.Encoding.UTF8, "application/json"));
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    notifyIcon1.Visible = true;
                    notifyIcon1.BalloonTipTitle = "JumpQ Konnect Update";
                    notifyIcon1.BalloonTipText = "Inventory has successfully updated";
                    notifyIcon1.ShowBalloonTip(1000);
                }
                else
                {
                    // MessageBox.Show(response.StatusCode.ToString());
                    string responJsonText = await response.Content.ReadAsStringAsync();
                    MessageBox.Show("Satus Error Trace: " + response.StatusCode.ToString() + "\n" + responJsonText, "QuickBooks Inventory Update Status!");
                    return;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
          
          
        }

        public DataTable InventoryTable;
        private void FinalPost()
        {
            POSTreq();
        }

        private DataTable SelctQuery(string query)
        {
            var cmd = new OdbcCommand(query, _cn);
            DataSet dataSet = new DataSet();
            OdbcDataReader reader = cmd.ExecuteReader();
            DataTable myTable = new DataTable();
            myTable.Load(reader);
            return myTable;
            //grvData.AutoGenerateColumns = true;
            //grvData.DataSource = myTable;
            //grvData.BorderStyle = BorderStyle.FixedSingle;
        }

        private void LoginApiCall()
        {
        
                string method = "POST";
                string json = JsonConvert.SerializeObject(new
                {
                    username = Properties.Settings.Default.Username,
                    password = Properties.Settings.Default.Password
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

                        Properties.Settings.Default.Api_Token = myDeserializedClass.user.api_token;
                        Properties.Settings.Default.Save();
                    }
                    else
                    {
                        //Check for internet connectivity
                        MessageBox.Show("can't login");
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
          
         
           
        }

        private void BtnSaveLogs_Click(object sender, EventArgs e)
        {
            if (TxtPassword.Text != string.Empty && TxtPassword.Text != string.Empty)
            {
                saveSettings();
                BtnSaveLogs.Text = "saved";
                TxtPassword.Text = string.Empty;
                TxtUsername.Text = string.Empty;
                Application.Restart();
            }
            else
            {
                //BtnSaveLogs.Text = "can't save";
                MessageBox.Show("Input login detail", "JumpQ Konnect Alert!");
                BtnSaveLogs.Text = "Save Logs";
            }
        }
        public void saveSettings()
        {
            Properties.Settings.Default.Username = TxtUsername.Text;
            Properties.Settings.Default.Password = TxtPassword.Text;
            Properties.Settings.Default.Save();
        }

        private void TxtUsername_TextChanged(object sender, EventArgs e)
        { 
           BtnSaveLogs.Text = "Save Logs";
        }

        private void TxtPassword_TextChanged(object sender, EventArgs e)
        {
            BtnSaveLogs.Text = "Save Logs";
        }

   
        private void btnChangeTime_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.SCheduletimer = int.Parse( comTimer.Text);
            Properties.Settings.Default.Save();
        }
    

   

        public void MinimizeToTray()
        {
            try
            {
                notifyIcon1.BalloonTipTitle = "JumpQ Konnect is connected";
                notifyIcon1.BalloonTipText = "JumpQ Konnect is running in backGround";

                this.WindowState=FormWindowState.Minimized;            
                    // this.Hide();
                    //notifyIcon1.Visible = true;
                    //notifyIcon1.ShowBalloonTip(1000);
                
              
               
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void PlaceLowerRight()
        {
            //Determine "rightmost" screen
            //Screen rightmost = Screen.AllScreens[0];

            var screen = Screen.FromPoint(this.Location);
            this.Location = new Point(screen.WorkingArea.Right - this.Width, screen.WorkingArea.Bottom - this.Height);
          
            this.Left = screen.WorkingArea.Right - this.Width;
            this.Top = screen.WorkingArea.Bottom - this.Height;
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
            PlaceLowerRight(); 
            notifyIcon1.Visible = false; 
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            //if the form is minimized  
            //hide it from the task bar  
            //and show the system tray icon (represented by the NotifyIcon control)  
            if (this.WindowState == FormWindowState.Minimized)
            {
                Hide();
                notifyIcon1.Visible = true;
                notifyIcon1.ShowBalloonTip(1000);
            }
            else
            {
               Show();
               this.WindowState = FormWindowState.Normal;
               PlaceLowerRight();
               notifyIcon1.Visible = false; 
               
            }
        }

        private void btnMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            Hide();
        }

        private void ChkSync_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkSync.Checked == true)
            {
                Properties.Settings.Default.IsSynch = true;
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.IsSynch = false;
                Properties.Settings.Default.Save();
            }
        }
    }
}
