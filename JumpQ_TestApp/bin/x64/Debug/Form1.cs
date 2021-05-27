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
using System.Data.SQLite;
using System.IO;

namespace JumpQ_Task
{
    public partial class Form1 : Form
    {
        private OdbcConnection _cn;
       // string myToken;
        APIRoute apiroute = new APIRoute();
        SQLiteConnection con = new SQLiteConnection(@"Data Source=|DataDirectory|\JumpQ_Dump.db; Version= 3;");
        //"Data Source=|DataDirectory|\Database.sqlite;"
       // string applicationFolderPath = System.IO.Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal));

          
       
            //System.Data.SQLite.SQLite3.Config(SQLite.SQLite3.ConfigOption.Serialized);
      //  SQLiteConnection con;

       
        //SQLiteConnection con = new SQLiteConnection(@"Data Source=C:\db\JumpQ_Dump.db; Version= Version= 3;");
        //sqlite_conn = new SQLiteConnection("Data Source=
        //    database.db;Version=3;New=True;Compress=True;");
       // sql_con = new SQLiteConnection(a, true);
        //SQLiteConnection con = new SQLiteConnection(@"Data Source= C:\Users\piedTech\Documents\Visual Studio 2013\Projects\JumpQ_Task\JumpQ_Dump.db; Version= 3;");
        int ItemSyncNo = 0;
        // commented uncomment later
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
            if (_cn != null && _cn.State != ConnectionState.Closed)
            {
                _cn.Close();
            }
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
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
                

               // commented uncomment later

               //// this.WindowState = FormWindowState.Minimized;
               // if(Properties.Settings.Default.IsSynch != false)
               // {
               //     ChkSync.Checked = true;
               //        sync();
               //        Hide();
               // }
               // else
               // {
               //     ChkSync.Checked = false;
               // }
             
                notifyIcon1.Visible = true;
                notifyIcon1.ShowBalloonTip(1000);
                //MinimizeToTray();
              
                //Hide();
               //ended here
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



        public void sync()
        {
           
            if (System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable() == true)
            {
                if (Properties.Settings.Default.Username != string.Empty && Properties.Settings.Default.Password != string.Empty)
                {
                    //MessageBox.Show(Properties.Settings.Default.Username.ToString());
                    //MessageBox.Show(Properties.Settings.Default.Password.ToString());
                        //var thread = new Thread(() =>
                    //    //    {
                    //if (BtnSynInventory.Text == "Pause Inventory")
                    //{
                    //    //POSTreq();
                    //    PostPauseReq();
                    //}
                    //else
                    ////{
                    //    BtnSynInventory.Text = "Pause Inventory";
                        LoginApiCall();
                        POSTreq();
                    //}
                   
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

        public async void PostPauseReq()
        {
            int i;
            Root2 proDucts = new Root2();

            Product Products = new Product();

            proDucts.products = new List<Product>();


            //jksffjkfkksfjsfj stopped here
            string query = string.Format("SELECT Desc1,Price1,OrderCost,ALU,Desc2, QuantityOnHand FROM ItemInventory");
            InventoryTable = SelctQuery(query);
            //MessageBox.Show(InventoryTable.Rows.Count.ToString());
            int Pnam = 0; int Pbar = 0; int Pdes = 0; int countInventory = 0; int count2 = 1;
            timer1.Start();

            for (i = ItemSyncNo; i < InventoryTable.Rows.Count; i++)
            {
                try
                {
          


                    Products.name = InventoryTable.Rows[0][0].ToString();
                    Products.price = Convert.ToDouble(InventoryTable.Rows[0][1].ToString());
                    Products.cost_price = Convert.ToDouble(InventoryTable.Rows[0][2].ToString());
                    Products.barcode = InventoryTable.Rows[0][3].ToString();
                    Products.description = InventoryTable.Rows[0][4].ToString();
                    Products.quantity = Convert.ToInt32(InventoryTable.Rows[0][5].ToString());
                    proDucts.products.Add(Products);
                    #region
                    Uri requestUri = new Uri("https://myjumpq.net/api/staff/add_products"); //replace your Url HttpClient client = 
                    var objClint = new HttpClient();
                    // objClint.Timeout = TimeSpan.FromMinutes(3600);
                    // objClint.Timeout= TimeSpan.FromMilliseconds(Configuration.HttpTimeout);
                    objClint.DefaultRequestHeaders.Accept.Clear();
                    objClint.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    objClint.DefaultRequestHeaders.Add("api_token", Properties.Settings.Default.Api_Token);
                    // MessageBox.Show(Properties.Settings.Default.Api_Token);
                    var output = JsonConvert.SerializeObject(proDucts);


                    // timer1.Start();
                    System.Net.Http.HttpResponseMessage response = await objClint.PostAsync(requestUri, new StringContent(output, System.Text.Encoding.UTF8, "application/json"));
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        if (countInventory == InventoryTable.Rows.Count)
                        {
                            timer1.Stop();
                            notifyIcon1.Visible = true;
                            notifyIcon1.BalloonTipTitle = "JumpQ Konnect Update";
                            notifyIcon1.BalloonTipText = countInventory.ToString() + " items has successfully updated";
                            notifyIcon1.ShowBalloonTip(1000);
                        }
                        else
                        {
                            ItemSyncNo = i;
                            if (notifyIcon1.Visible == true)
                            {

                            }
                            else
                            {
                                notifyIcon1.Visible = true;
                                notifyIcon1.BalloonTipTitle = "JumpQ Konnect Update";
                                notifyIcon1.BalloonTipText = "Syncing in progress......";
                                notifyIcon1.ShowBalloonTip(5000);
                            }

                        }

                    }
                    else
                    {
                        // MessageBox.Show(response.StatusCode.ToString());
                        string responJsonText = await response.Content.ReadAsStringAsync();
                        MessageBox.Show("Satus Error Trace: Didn't post " + response.StatusCode.ToString() + "\n" + responJsonText, "QuickBooks Inventory Update Status!");
                        ItemSyncNo = i;
                        continue;
                    }
                    #endregion
                }
                catch (Exception)
                {
                    ItemSyncNo = i;
                    continue;
                }

                //    var items = proDucts.products.Skip(i).Take(20);
                //    proDucts.products.Add(Products);
                //    proDtx2.products.Add();
                //    // Do something with 100 or remaining items
            }
        }
        public async void POSTreq()
        {
            try
            {
                if (ItemSyncNo != 0)
                {
                    #region
                    Root2 proDucts = new Root2();

                    Product Products = new Product();

                    proDucts.products = new List<Product>();


                    //jksffjkfkksfjsfj stopped here
                    string query = string.Format("SELECT Desc1,Price1,OrderCost,UPC,Desc2, QuantityOnHand FROM ItemInventory");
                    InventoryTable = SelctQuery(query);
                    //MessageBox.Show(InventoryTable.Rows.Count.ToString());
                    int Pnam = 0; int Pbar = 0; int Pdes = 0; int countInventory = 0; int count2 = 1;
                    timer1.Start();


                    foreach (DataRow item in InventoryTable.Rows)
                    {
                        try
                        {
                            #region
                            countInventory++;
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
                                Products.price = 0;
                            }
                            else
                            {
                                //Products.price = Convert.ToInt32(item[1].ToString()); 
                                Products.price = Convert.ToDouble(item[1].ToString());
                            }


                            // Chk if product cost_price field is empty and give a default value if true
                            //  MessageBox.Show(item[2].ToString());
                            if (item[2].ToString() == string.Empty || item[2].ToString() == "0.00" || item[2].ToString() == "0")
                            {
                                Products.cost_price = 0;
                            }
                            else
                            {
                                //Products.cost_price = Convert.ToInt32(item[2].ToString());
                                Products.cost_price = Convert.ToDouble(item[2].ToString());
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

                                // Products.quantity = Convert.ToInt32(item[5].ToString());
                                Products.quantity = Convert.ToInt32(item[5].ToString());
                            }

                            #endregion
                            proDucts.products.Add(Products);

                            if (countInventory == 50)
                            {
                                #region
                                Uri requestUri = new Uri("https://myjumpq.net/api/staff/add_products"); //replace your Url HttpClient client = 
                                var objClint = new HttpClient();
                                // objClint.Timeout = TimeSpan.FromMinutes(3600);
                                // objClint.Timeout= TimeSpan.FromMilliseconds(Configuration.HttpTimeout);
                                objClint.DefaultRequestHeaders.Accept.Clear();
                                objClint.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                                objClint.DefaultRequestHeaders.Add("api_token", Properties.Settings.Default.Api_Token);
                                // MessageBox.Show(Properties.Settings.Default.Api_Token);
                                var output = JsonConvert.SerializeObject(proDucts);


                                // timer1.Start();
                                System.Net.Http.HttpResponseMessage response = await objClint.PostAsync(requestUri, new StringContent(output, System.Text.Encoding.UTF8, "application/json"));
                                if (response.StatusCode == HttpStatusCode.OK)
                                {
                                    if (countInventory == InventoryTable.Rows.Count)
                                    {
                                        timer1.Stop();
                                        notifyIcon1.Visible = true;
                                        notifyIcon1.BalloonTipTitle = "JumpQ Konnect Update";
                                        notifyIcon1.BalloonTipText = countInventory.ToString() + " items has successfully updated";
                                        notifyIcon1.ShowBalloonTip(1000);
                                    }
                                    else
                                    {
                                        //ItemSyncNo = i;
                                        if (notifyIcon1.Visible == true)
                                        {

                                        }
                                        else
                                        {
                                            notifyIcon1.Visible = true;
                                            notifyIcon1.BalloonTipTitle = "JumpQ Konnect Update";
                                            notifyIcon1.BalloonTipText = "Syncing in progress......";
                                            notifyIcon1.ShowBalloonTip(5000);
                                        }

                                    }

                                }
                                else
                                {
                                    // MessageBox.Show(response.StatusCode.ToString());
                                    string responJsonText = await response.Content.ReadAsStringAsync();
                                    MessageBox.Show("Satus Error Trace: Didn't post " + response.StatusCode.ToString() + "\n" + responJsonText, "QuickBooks Inventory Update Status!");
                                    // ItemSyncNo = i;
                                    continue;
                                }
                                #endregion
                            }
                        }
                        catch (Exception)
                        {
                            continue;
                        }
                          

                    }
                    #endregion
                }
               
            }
            catch (Exception ex)
            {

                MessageBox.Show("Satus Error Trace: " + ex.Message, "QuickBooks Inventory Update Status!");
                //PostPauseReq();
            }
          
          
        }

        public DataTable InventoryTable;
        private void FinalPost()
        {
            #region //Post one by one
            //Uri requestUri = new Uri("https://myjumpq.net/api/staff/add_products"); //replace your Url HttpClient client = 
            //var objClint = new HttpClient();
            ////objClint.Timeout = TimeSpan.FromMinutes(3600
            //// objClint.Timeout= TimeSpan.FromMilliseconds(Configuration.HttpTimeout);
            //objClint.DefaultRequestHeaders.Accept.Clear();
            //objClint.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //objClint.DefaultRequestHeaders.Add("api_token", Properties.Settings.Default.Api_Token);
            //// MessageBox.Show(Properties.Settings.Default.Api_Token);
            //var output = JsonConvert.SerializeObject(proDucts);


            //System.Net.Http.HttpResponseMessage response = await objClint.PostAsync(requestUri, new StringContent(output, System.Text.Encoding.UTF8, "application/json"));
            //if (response.StatusCode == HttpStatusCode.OK)
            //{
            //    notifyIcon1.Visible = true;
            //    notifyIcon1.BalloonTipTitle = "JumpQ Konnect Update";
            //    notifyIcon1.BalloonTipText = countInventory++.ToString() + " Items has successfully updated";
            //    notifyIcon1.ShowBalloonTip(1000);
            //}
            //else
            //{
            //    // MessageBox.Show(response.StatusCode.ToString());
            //    string responJsonText = await response.Content.ReadAsStringAsync();
            //    MessageBox.Show("Satus Error Trace:  Didn't post " + response.StatusCode.ToString() + "\n" + responJsonText, "QuickBooks Inventory Update Status!");
            //    return;
            //}

            #endregion
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
                        MessageBox.Show("can't login. Check your internet" );
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show( "Error posting :" + ex.Message, "JumpQ Alert");
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
            MessageBox.Show("Changed Successfully");
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
        int timeCt = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = true;
           txtTimer.Text= timeCt++.ToString() + 
               " secs.";
        }

        private void btnBkup_Click(object sender, EventArgs e)
        {
              // Create the folder path.
            // Create the folder path.
           

            if (_cn == null || _cn.State == ConnectionState.Closed)
            {
                btnConnect_Click(null, null);
            }
            string query = string.Format("SELECT Desc1,Price1,OrderCost,UPC,Desc2, QuantityOnHand FROM ItemInventory");
            InventoryTable = SelctQuery(query);
            //MessageBox.Show(InventoryTable.Rows.Count.ToString());
            int Pnam = 0; int Pbar = 0; int Pdes = 0; int countInventory = 0; int count2 = 1;
            timer1.Start();


            foreach (DataRow item in InventoryTable.Rows)
            {
                String insertInvQuery = @"INSERT into Inventory(desc,price,ordercost,upc,desc2,qty) VALUES(@desc, @pr, @order, @upc, @desc2, @qty)";

//'"// + item[0].ToString() +"','" + item[1].ToString() + "', '" + item[2].ToString() + "','" + item[3].ToString() + "','"+@item[4].ToString() +"', '" + item[5].ToString//() + "')";
                SQLiteCommand Cmd = con.CreateCommand();
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = insertInvQuery;
                SQLiteParameter sqp = Cmd.Parameters.AddWithValue("@desc", item[0].ToString());
                SQLiteParameter sqp1 = Cmd.Parameters.AddWithValue("@pr", item[1].ToString());
                SQLiteParameter sqp2 = Cmd.Parameters.AddWithValue("@order", item[2].ToString());
                SQLiteParameter sqp3 = Cmd.Parameters.AddWithValue("@upc", item[3].ToString());
                SQLiteParameter sqp4 = Cmd.Parameters.AddWithValue("@desc2", item[4].ToString());
                SQLiteParameter sqp5 = Cmd.Parameters.AddWithValue("@qty", item[5].ToString());
                Cmd.ExecuteNonQuery();
                if (Cmd.ExecuteNonQuery() == 1)
                {
                    count2++;
                    
                }
            }
            MessageBox.Show("Inventory backed up sucessfully!, JumpQ Konnect");
        }
    }
}
