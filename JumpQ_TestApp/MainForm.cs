using System;
using AForge.Video.DirectShow;
using AForge.Video;
using ZXing;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Odbc;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Data.SQLite;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Net.Http;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using System.Security.Claims;
using Owin;
using System.Web.Http;
using System.Net.Http.Headers;
using System.Collections;
using RestSharp;
using RestSharp.Serializers.Newtonsoft;
using RestSharp.Authenticators;
using WIA;
using System.Drawing.Printing;




namespace JumpQ_TestApp
{
    public partial class MainForm : Form
    {
        #region
        private int maxNumber = 0;
        private int correctNumber = 0;
        private OdbcConnection _cn;
        public MainForm()
        {
            InitializeComponent();
        
        
        }

  
        async static void Getrequest( string url)
        {
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage response = await client.GetAsync(url))
                {
                    using (HttpContent content = response.Content)
                    {
                       // string mycontent = await content.ReadAsStringAsync();
                       // richTextBox1.Text = mycontent;
                        HttpContentHeaders headers = content.Headers;

                        MessageBox.Show(headers.ToString());
                    }
                }
            }
        }


        async static void Postrequest(string url)
        {
            System.Collections.Generic.IEnumerable<KeyValuePair<string, string> > queries = new List<KeyValuePair<string, string >>()
            {
                new KeyValuePair<string, string>("quer1","james"),
                new KeyValuePair<string, string>("quer2","polinium"),
            }  ;

            HttpContent q = new FormUrlEncodedContent(queries);
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage response = await client.PostAsync(url,q))
                {
                    using (HttpContent content = response.Content)
                    {
                        string mycontent = await content.ReadAsStringAsync();
                        // richTextBox1.Text = mycontent;
                        HttpContentHeaders headers = content.Headers;

                        MessageBox.Show(mycontent);
                    }
                }
            }
        }





       #endregion

        #region  //BArcodeJob Encapsulation
        SQLiteConnection con = new SQLiteConnection(@"Data Source=.\JumpQKonnect.db; Version= 3;");
        FilterInfoCollection filterInfoCollection;
        VideoCaptureDevice captureDevice;

        SettingsModel settingsModel = new SettingsModel();
        SalesRecieptModel salesRecieptModel = new SalesRecieptModel();

        List<string> ContainRfid = new List<string>();
        List<string> NoRfid = new List<string>();
        List<string> BlockContent = new List<string>();
        List<string> jstRfid = new List<string>();
     
        private ArrayList scannerList;
        private Scanner activeScanner;


        //cONSIDER ADDING THIS PARAMETER TO DEFAULT SETTING
        //string comments = "Sales Transaction Successful";
       
      //  string cashier = "OMO";
       //= "Sales";
      //  string itemName = "6015319814099075329";
        //fgghfg
        //
        private void ListOutDSN()
        {
            cboListOfDSN.Items.Clear();

            var myODBCKeys = Registry.LocalMachine.OpenSubKey("SOFTWARE\\ODBC\\ODBC.INI\\ODBC Data Sources", false).GetValueNames();
            if (myODBCKeys != null)
            {
                foreach (var item in myODBCKeys)
                {
                    cboListOfDSN.Items.Add(item);
                    //  MessageBox.Show(item);
                }

                myODBCKeys = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\\ODBC\\ODBC.INI\\ODBC Data Sources", false).GetValueNames();
                foreach (var item in myODBCKeys)
                {
                    cboListOfDSN.Items.Add(item);
                }
                //end of adding DSN to list

                if (cboListOfDSN.Items.Count > 0)
                {
                    foreach (string item in cboListOfDSN.Items)
                    {
                        if (item == "QuickBooks Data")
                        {
                            cboListOfDSN.Text = item;
                            return;
                        }
                        if (item == "QuickBooks Data POS")
                        {
                            cboListOfDSN.Text = item;
                            return;
                        }
                        if (item == "QuickBooks Data Online")
                        {
                            cboListOfDSN.Text = item;
                            return;
                        }
                    }
                    cboListOfDSN.SelectedIndex = 0;
                }
            }




        }
        private void ListOutCameras()
        {
           
            var deviceManager = new DeviceManager();

            // Loop through the list of devices and add the name to the listbox
            for (int i = 1; i <= deviceManager.DeviceInfos.Count; i++)
            {
                var deviceName = deviceManager.DeviceInfos[i].Properties["Name"].get_Value().ToString();
                cameraTypes.Items.Add(deviceName);
            }
            filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (AForge.Video.DirectShow.FilterInfo filterInfo in filterInfoCollection)
            {
                cameraTypes.Items.Add(filterInfo.Name);
                cameraTypes.SelectedIndex = 0;
            }

        }
        void getSettings()
        {

            salesRecieptModel.CustomerID = Properties.Settings.Default.CustomerID;
            salesRecieptModel.SalesRecieptType = Properties.Settings.Default.SalesRecieptType;
            salesRecieptModel.Comments = Properties.Settings.Default.Comments;
            salesRecieptModel.CashierName = Properties.Settings.Default.Cashier;
            if (salesRecieptModel.CustomerID == string.Empty)
            {
                btnSet_Click(null, null);
            }
            //  MessageBox.Show(CustomerID);

        }
        private void AddSalesItem_Load(object sender, EventArgs e)
        {
            try
            {
                ListOutDSN();

                ListOutCameras(); getSettings();
                TextBoxOrder.Add(BarcodeInput1, BarcodeInput2);
                TextBoxOrder.Add(BarcodeInput2, BarcodeInput1);

                BarcodeInput1.Tag = 1;
                BarcodeInput2.Tag = 2;



                BarcodeInput1.KeyDown += BarcodeInputKeyDown;
                BarcodeInput2.KeyDown += BarcodeInputKeyDown;

                BarcodeInput1.Leave += BarcodeInputLeave;
                BarcodeInput2.Leave += BarcodeInputLeave;
                //loadsfirst to check if customer exist

                if (_cn != null && _cn.State != ConnectionState.Closed)
                {
                    _cn.Close();
                }
               // _cn.Open();
                Application.DoEvents();
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Error - {0}, Stack Trace {1}", ex.Message, ex.StackTrace));
            }
        }
        //This acceesses the Quick Books Pos root database, so make sure to choose the right db on the combobox

           
      

        //tHIS SHOULD ONLY INITIATE WHEN PRODUCTS HAVE BEEN VERIFIED
       

        private void InsertSalesReceiptLineItem(string customerName, string comments, string cashierName, string salesReceiptType, string itemName, int quanity, int rate, int tenderAmount)
        {
            string query =
                    string.Format("Insert Into SalesReceiptItem (CustomerListId, Comments, Cashier, SalesReceiptType, SalesReceiptItemListId,  SalesReceiptItemQty, SalesReceiptItemPrice, TenderCash01TenderAmount) Values ('{0}','{1}','{2}','{3}','{4}',{5},{6},{7})", customerName, comments, cashierName, salesReceiptType, itemName, quanity, rate, tenderAmount);
             
            //query = string.Format("Insert into invoiceline(txnid,InvoiceLineItemRefFullName, InvoiceLineQuantity, InvoiceLineRate, InvoiceLineDesc) values('{0}','{1}',{2},{3},'{4}') ", txnID, itemFullName, quanity, rate, description);
            //MessageBox.Show(query);
            using (OdbcCommand QBEmployeecmd = new OdbcCommand(query, _cn))
            {
                //MessageBox.Show("" + QBEmployeecmd.Connection.State.ToString());
                QBEmployeecmd.CommandType = CommandType.Text;
                //MessageBox.Show("" + QBEmployeecmd.CommandType.ToString());
                QBEmployeecmd.ExecuteNonQuery();
                //MessageBox.Show("Execute Success");

            }
        }
        
        private void DisplaySalesReceiptGrid(string customerListID)
        {
            string query = string.Format("SELECT CustomerListId, Comments, Cashier, SalesReceiptType, SalesReceiptItemListId,  SalesReceiptItemQty as ItemQuantity, SalesReceiptItemPrice As ItemPrice, TenderCash01TenderAmount As TotalTenderAmount FROM SalesReceiptItem where TxnID='{0}'", customerListID);
            ProcessQuery(query);
        }
        #region QuickBook POS Handlers

        #endregion

        private string GetLastInsertedId(string query)
        {
            string lastInsertedId = "";
            using (OdbcCommand QBEmployeecmd = new OdbcCommand(query, _cn))
            {
                QBEmployeecmd.CommandType = CommandType.Text;
                var executedResult = QBEmployeecmd.ExecuteScalar();
                lastInsertedId = executedResult.ToString();
            }
            return lastInsertedId;
        }

       

        private void ProcessQuery(string query)
        {
            var cmd = new OdbcCommand(query, _cn);
            DataSet dataSet = new DataSet();
            OdbcDataReader reader = cmd.ExecuteReader();
            DataTable myTable = new DataTable();
            myTable.Load(reader);
            //sfDataGrid1.AutoGenerateColumns = true;
            //sfDataGrid1.DataSource = myTable;
          //  sfDataGrid1.Style = StyleChanged; BorderStyle.FixedSingle;  
                return;
            grvData.AutoGenerateColumns = true;
            grvData.DataSource = myTable;
            grvData.BorderStyle = BorderStyle.FixedSingle;        
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
        public DataTable InventoryTable;
        //This selects item from the ItemInventory
        private void DisplayItemInGrid( string ItemBarcode)
        {
            string query = string.Format("SELECT ListId, Desc1,Desc2, Price1, Size, ItemNumber FROM ItemInventory WHERE ALU= '{0}'", ItemBarcode);
            ProcessQuery(query);
            //DataTable newDt;
            //newDt = SelctQuery(query);
            //foreach (string item in newDt.Rows)
            //{
                
            //}
        }
        void TimelyInventoryUpdate()
        {
            string query = string.Format("SELECT Desc1,Price1,OrderCost,ALU,Desc2, QuantityOnHand FROM ItemInventory");
            InventoryTable= SelctQuery( query);
            //ProcessQuery(query);
          //  DataTable newDt;
        }
        
        void chkifPriceexitInQuickBook(string QRcode, int price)
        {
            string query = string.Format("SELECT  ListId, Desc1, Desc2,Price1, Size, ItemNumber FROM ItemInventory WHERE ALU= '{0}'", QRcode);
             DataTable newDt;
                newDt=    SelctQuery(query);
            if(newDt.Rows.Count > 0)
            {
               // MessageBox.Show(newDt.Rows[0][0].ToString());
                  int QuickPrice= Convert.ToInt32(newDt.Rows[0][3]);
                  if (price == QuickPrice)
                  {
                      ticket = true;
                      if (jstRfid.Count > 0)
                      {


                          foreach (var item in jstRfid)
                          {
                          
                              string[] splitblockCont = item.Split('*');
                              foreach (string blockCont in splitblockCont)
                              {
                               
                                 
                                      String insertQuery = "INSERT INTO RfidTable(TransactDate,RfidCode,QuickBookID,ItemName,Description,Price,Size, QuickBookItemNo) VALUES('" + DateTime.Now + "', '" + blockCont + "','" + newDt.Rows[0][0] + "','" + newDt.Rows[0][1] + "','" + newDt.Rows[0][2] + "','" + newDt.Rows[0][3] + "','" + newDt.Rows[0][4] + "',   )";

                                      SQLiteCommand cmd = con.CreateCommand();
                                      cmd.CommandType = CommandType.Text;
                                      cmd.CommandText = insertQuery;
                                      cmd.ExecuteNonQuery();
                          

                              }
                              //string result = splitblockCont[0].Trim();
                              //int ItmQty = Convert.ToInt32(splitblockCont[1].Trim());



                          }
                      }




                     SQLiteRFIDInsertQuery();
                      //string lastInsertedId1 = GetLastInsertedId("sp_lastInsertID SalesReceiptItem");
                      //DisplaySalesReceiptGrid(lastInsertedId1);

               
                  }
                  else
                  {
                      ticket = false;
                      MessageBox.Show("There is a mismatch with price from JumpQ and Quickbook \nPlease Check the Quickbooks and Update Price","JumpQ Konnect Error!");
                      return;
                  }
            }
            else
            {
                ticket = false;
                MessageBox.Show("The QRcode of this item can't be found in the quickbook. \nPlease make sure the barcode has been  added to Quickbooks", "JumpQ Konnect Error!");
                return;
            }
       
            //if(new)
        }
        private void SQLiteRFIDInsertQuery( )
        {


            if (jstRfid.Count > 0)
            {
               

                foreach (var item in jstRfid)
                {
                  //   foreach (string blockCont in BlockContent)
                  //{
                      string[] splitblockCont = item.Split('*');
                      foreach (string blockCont in splitblockCont)
                      {
                          string query = string.Format("SELECT ListId, Desc1, Desc2,Price1, Size, ItemNumber FROM ItemInventory WHERE ALU= '{0}'", item);
                          DataTable newDt;
                          newDt = SelctQuery(query);
                          foreach (string QuickItem in newDt.Rows)
                          {
                              String insertQuery = "INSERT INTO RfidTable(TransactDate,RfidCode,QuickBookID,ItemName,Description,Price,Size, QuickBookItemNo) VALUES('" + DateTime.Now + "', '" + blockCont + "','" + newDt.Rows[0][0] + "','" + newDt.Rows[0][1] + "','" + newDt.Rows[0][2] + "','" + newDt.Rows[0][3] + "','" + newDt.Rows[0][4] + "',   )";

                              SQLiteCommand cmd = con.CreateCommand();
                              cmd.CommandType = CommandType.Text;
                              cmd.CommandText = insertQuery;
                              cmd.ExecuteNonQuery();
                          }

                      }
                      //string result = splitblockCont[0].Trim();
                      //int ItmQty = Convert.ToInt32(splitblockCont[1].Trim());

                   

                }
            }


        }
        void captureDevice_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            pictureBox.Image = (Bitmap)eventArgs.Frame.Clone();
        }
       
        public string decryptedString;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (pictureBox.Image != null)
            {
                BarcodeReader barcodeReader = new BarcodeReader();
                Result result = barcodeReader.Decode((Bitmap)(pictureBox.Image));
              
                if (result != null)
                {
                    decryptedString = Encoding.UTF8.GetString(Convert.FromBase64String(result.ToString()));
                    timer1.Stop();
                   
                  
                   // MessageBox.Show(decryptedString);
                    if (captureDevice.IsRunning)
                        captureDevice.Stop();
                    BarcodeLogic();
                   
                }
            }
        }
        bool ticket = false;
        public void BarcodeLogic()
        {
            jstRfid.Clear();
            NoRfid.Clear();
            BlockContent.Clear();
            ContainRfid.Clear();
            string decryptedQRcode = decryptedString;
            grvData.Rows.Clear();
            ScannedBarcode.Clear();
            try
            {
                if (_cn == null || _cn.State == ConnectionState.Closed)
                {
                    btnConnect_Click(null, null);
                }
                #region


                List<string> rfid = new List<string>();

                string[] splitString = decryptedQRcode.Split(']');
               

                if (splitString.Length > 1)
                {
                    foreach (string match in splitString)
                    {

                        if (match == string.Empty)
                        {
                            //  MessageBox.Show("empty");
                        }
                        else
                        {
                            rfid.Add(match);
                        }

                    }


                    foreach (string rf in rfid)
                    {
                        string[] splitRem = rf.Split('[');
                        string result = splitRem[0].Trim();
                        string result1 = splitRem[1].Trim();
                        BlockContent.Add(result1);

                        //where result contains the rfid
                        if (result == string.Empty)
                        {
                            // since there is no rfid please store this block inside a seperate list "NoRfid"
                            NoRfid.Add(result1);
                        }
                        else
                        {
                            //  there is rfid then, please store this block inside a seperate list "ContainRfid"
                            ContainRfid.Add(result1);
                            jstRfid.Add(result);

                        }
                    }
                    decimal totalAmount = 0;
                  //int tenderAmt = 0;
                  foreach (string blockCont in BlockContent)
                  {
                      string[] splitblockCont = blockCont.Split('*');
                  salesRecieptModel.ItemQRcode = splitblockCont[0].Trim();
                      salesRecieptModel.ItemQuantity = Convert.ToInt32(splitblockCont[1].Trim());

                      ///
                      ///summary
                      ///Make sure you change this Price number to actual arrayIndex
                     double pri = Convert.ToDouble (splitblockCont[2].Trim());//("1000");
                     salesRecieptModel.ItemPrice = (int)pri;
                     //int priceResult2 = Convert.ToInt32("1000");//("1000");

                      salesRecieptModel.AmountTendered = (salesRecieptModel.ItemQuantity * salesRecieptModel.ItemPrice);
                      totalAmount += salesRecieptModel.ItemQuantity * salesRecieptModel.ItemPrice ;
                      chkifPriceexitInQuickBook(salesRecieptModel.ItemQRcode, salesRecieptModel.ItemPrice);
                      if (ticket == true)
                      {
                         
                          //InsertSalesReceiptItem(CustomerID, comments, cashier, salesReceiptType, itemName, int.Parse(ItmQty.ToString()), int.Parse(priceResult2.ToString()), int.Parse(tenderAmt.ToString()));
                          displayScannedItems(salesRecieptModel.ItemQRcode, salesRecieptModel.ItemQuantity.ToString(), salesRecieptModel.AmountTendered.ToString());
                      }
                      else
                      {
                         // MessageBox.Show("Resolve the error", "JumpQ Konnect Error!");
                          break;
                        
                      }
                    

                  }

                  if (ticket == true)
                  {
                      StringBuilder popMssg = new StringBuilder();
                      popMssg.AppendFormat("\r\nTotal Number of Items: {0}", BlockContent.Count);
                      popMssg.AppendFormat("\r\nNumber of rfid Items: {0}", ContainRfid.Count);
                      popMssg.AppendFormat("\r\nTotal Amount: {0}", totalAmount);
                      ticket = false;
                      MessageBox.Show("Transaction Summary" + popMssg.ToString(), "JumpQ Konnect Reciept!");
                      txtQRCode.Text = "Scan Successful";
                      txtQRCode.ForeColor = Color.Green;
                  }
                  

                }
                else
                {
                    MessageBox.Show("Barcode Error", "JumpQ Konnect Alert!");
                }
                #endregion
            }
            catch (Exception ex)
            {

                MessageBox.Show(string.Format("Error - {0}, Stack Trace {1}", ex.Message, ex.StackTrace));
            }

          
        }

        public void displayScannedItems( string qrCode, string quantity, string total)
        {

            string query = string.Format("SELECT ListID, Desc1 as ItemName,Price1 as Price, QuantityOnHand as Quantity, ALU as QRCode, Desc2 as Description FROM ItemInventory where ALU='{0}'", qrCode);
            var cmd = new OdbcCommand(query, _cn);
            DataSet dataSet = new DataSet();
            OdbcDataReader reader = cmd.ExecuteReader();
            DataTable myTable = new DataTable();
            myTable.Load(reader);
            foreach (DataRow item in myTable.Rows)
            {
                int n = grvData.Rows.Add();
                
                grvData.Rows[n].Cells[0].Value = (n + 1).ToString();
                grvData.Rows[n].Cells[1].Value   = "0";
                grvData.Rows[n].Cells[2].Value = item["ItemName"].ToString();
                grvData.Rows[n].Cells[3].Value = item["Price"].ToString();
                grvData.Rows[n].Cells[4].Value = quantity;
                grvData.Rows[n].Cells[5].Value = item["QRCode"].ToString();
                grvData.Rows[n].Cells[6].Value = item["Description"].ToString();
                grvData.Rows[n].Cells[7].Value = total;
                grvData.Rows[n].Cells[8].Value = item["ListID"].ToString();
                //grvData.Rows[n].Cells[6].Value = item["Desc2"].ToString();
              //  grvData.Rows[n].Cells[3].Style.ForeColor = Color.ForestGreen;
                //salesRecieptModel.SalesRecieptType = "Sales";
                //salesRecieptModel.Comments = Properties.Settings.Default.Comments;
                //salesRecieptModel.CashierName = Properties.Settings.Default.Cashier;



            //    InsertSalesReceiptItem(CustomerID, salesRecieptModel.Comments, salesRecieptModel.CashierName, salesRecieptModel.SalesRecieptType, int.Parse(quantity.ToString()), int.Parse(item["Price"].ToString()), int.Parse(salesRecieptModel.AmountTendered.ToString()));
            }
            grvData.ClearSelection();
        }

        


       

        #endregion
         string myToken;
         public List<string> ScannedBarcode = new List<string>();
       

        #region

       
         void apiPost(string Pname, int Pprice, int Pcostprice, string Pbarcode, string Pdesc, int Pqty, string token)
         {
             
            string endpoint = "https://myjumpq.net/api/staff/add_products";
            string method = "POST";
            Root2 products = new Root2();
            Product Products = new Product();
            
            //
            Products.name = Pname;
            Products.price = Pprice;
            Products.cost_price = Pcostprice;
            Products.barcode = Pbarcode;
            Products.description = Pdesc;
            Products.quantity = Pqty;

            products.products = new List<Product>();
            products.products.Add(Products);


            /////System.Windows.Forms.MessageBox.Show(products.products.Count.ToString());


          
           var output = JsonConvert.SerializeObject(products);
           //System.Windows.Forms.MessageBox.Show(output);
            WebClient wc = new WebClient();
            

            //Adding authorization token to header
            wc.Headers.Add(HttpRequestHeader.Authorization, token);
            //Resetting content type to be sent if we wanted to POST JSON
            wc.Headers[HttpRequestHeader.ContentType] = "application/json; charset=utf-8";
            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                string  response = wc.UploadString(endpoint, method, output);

                //var result = JsonConvert.DeserializeObject<Root2>(response);
                //System.Windows.Forms.MessageBox.Show(result.ToString());
                if (response != null)
                {
                    var myDeserializedClass = JsonConvert.DeserializeObject<Root2>(response);
                   // string myToken = myDeserializedClass.user.api_token;
                    System.Windows.Forms.MessageBox.Show(myDeserializedClass.ToString());

                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Please check internet connectivity");
                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show( ex.Message);
            }
        }

      
      
      
        #endregion
        
        
        #region PostSales to QuickBook
         public void InsertScannedItems()
         {
             if (grvData.Rows.Count > 0)
             {
                 foreach (DataGridViewRow Row in grvData.Rows)
                 {

                     string price = (Row.Cells[3].Value.ToString());

                     int qty = Convert.ToInt32(Row.Cells[4].Value);

                     string amt = (Row.Cells[7].Value.ToString());

                     string listid = (Row.Cells[8].Value.ToString());


                     InsertSalesReceiptLineItem(salesRecieptModel.CustomerID, salesRecieptModel.Comments, salesRecieptModel.CashierName, salesRecieptModel.SalesRecieptType, listid, qty, int.Parse(price), int.Parse(amt));


                 }
                 MessageBox.Show("Sales sucessfully posted!, JumpQ Konmect ");
                 return;


             }
             MessageBox.Show("There are no verified products to post");



         }
#endregion

         #region Post To WEb API
       
        
        //fOOR postig pRODUCTS TO JUMPQ DATABSE ON;INE
         public async void POSTreq(string Pname, int Pprice, int Pcostprice, string Pbarcode, string Pdesc, int Pqty, string token)
         {
             Root2 products = new Root2();
             Product Products = new Product();

             //
             Products.name = Pname;
             Products.price = Pprice;
             Products.cost_price = Pcostprice;
             Products.barcode = Pbarcode;
             Products.description = Pdesc;
             Products.quantity = Pqty;

             products.products = new List<Product>();
             products.products.Add(Products);
             Uri requestUri = new Uri("https://myjumpq.net/api/staff/add_products"); //replace your Url HttpClient client = 
             var objClint = new System.Net.Http.HttpClient();
             objClint.DefaultRequestHeaders.Accept.Clear();
             objClint.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
             objClint.DefaultRequestHeaders.Add("api_token", token);

             var output = JsonConvert.SerializeObject(products);


             System.Net.Http.HttpResponseMessage response = await objClint.PostAsync(requestUri, new StringContent(output, System.Text.Encoding.UTF8, "application/json"));


             string responJsonText = await response.Content.ReadAsStringAsync();
             MessageBox.Show(responJsonText);
         }  


         //sELECT EVERY PRODUCTS FROM QUUICK BOOKS POS AND POST TO WEB API
         private void FinalPost()
         {
               string query = string.Format("SELECT Desc1,Price1,OrderCost,ALU,Desc2, QuantityOnHand FROM ItemInventory");
             InventoryTable = SelctQuery(query);
             foreach (DataRow item in InventoryTable.Rows)
             {
               
                 POSTreq(item[0].ToString(), Convert.ToInt32(item[1].ToString()), Convert.ToInt32(item[2].ToString()), item[3].ToString(), item[4].ToString(), Convert.ToInt32(item[5].ToString()), myToken);      
             }
               
         }

       
      

#endregion

        #region QRScanner Handler
        private Dictionary<TextBox, TextBox> TextBoxOrder = new Dictionary<TextBox, TextBox>();

       

        private void BarcodeInputKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && ActiveControl.GetType() == typeof(TextBox))
            {
                TextBox nextTextBox;
                if (TextBoxOrder.TryGetValue((TextBox)ActiveControl, out nextTextBox))
                {
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                    nextTextBox.Text = string.Empty;
                    nextTextBox.Focus();
                }
               ////BarcodeInput1.Text= string.Empty;
               // BarcodeInput1.ForeColor = Color.Red;
               // BarcodeInput1.Focus();
            }
        }

   

        private void BarcodeInputLeave(object sender, EventArgs e)
        {
            if (sender.GetType() == typeof(TextBox))
            {
                TextBox textBox = (TextBox)sender;
                if (textBox.Tag.GetType() == typeof(int))
                {
                    BarcodeScanned(textBox.Text, (int)textBox.Tag);
                }
            }
        }

        private void BarcodeScanned(string barcode, int order)
        {
            ScanVerifyItem(barcode);
            //BarcodeInput1.Text = string.Empty;
        }

        void ScanVerifyItem(string ObtainedQRcode)
        {
            grvData.ClearSelection();
            //string ObtainedQRcode = "X002C4UXJB";
            // = "";
            foreach (DataGridViewRow Row in grvData.Rows)
            {

                int VerifiedQty = Convert.ToInt32(Row.Cells[1].Value);
                int quant = Convert.ToInt32(Row.Cells[4].Value);
                string barcode = (Row.Cells[5].Value.ToString());

                if (barcode == ObtainedQRcode)
                {
                    labNotFound.Visible = false;
                    grvData.BackgroundColor = Color.White;
                    #region
                   // MessageBox.Show("eXIST");
                    if (ScannedBarcode.Count < 1)
                    {
                        ScannedBarcode.Add(ObtainedQRcode);
                        VerifiedQty++;
                        Row.Cells[1].Value = VerifiedQty.ToString();
                        Row.DefaultCellStyle.BackColor = Color.ForestGreen;
                        Row.DefaultCellStyle.ForeColor = Color.White;
                    }
                    else
                    {
                        if (!ScannedBarcode.Contains(ObtainedQRcode))// IF THE LIST DOESN'T CONTAIN THE BARCODE, PLEASE ADD TO THE LIST
                        {
                            ScannedBarcode.Add(ObtainedQRcode);
                            VerifiedQty++;
                            Row.Cells[1].Value = VerifiedQty.ToString();
                            Row.DefaultCellStyle.BackColor = Color.ForestGreen;
                            Row.DefaultCellStyle.ForeColor = Color.White;
                        }
                        else
                        {
                            //ELSE IF IT CONTAINS, PLEASE COUNT THE DUPLICATE OF THAT BARCODE AND COMPARE TO ACTUAL QUANTITY ORDERED
                            var numberOfhDuplicates = ScannedBarcode.GroupBy(x => ObtainedQRcode).Count(x => x.Count() > 0);
                            int verified = Convert.ToInt32(Row.Cells[1].Value);
                            if (verified < quant)
                            {
                                ScannedBarcode.Add(ObtainedQRcode);
                                VerifiedQty++;
                                Row.Cells[1].Value = VerifiedQty.ToString();
                                Row.DefaultCellStyle.BackColor = Color.ForestGreen;
                                Row.DefaultCellStyle.ForeColor = Color.White;
                            }
                            else
                            {
                                Row.DefaultCellStyle.BackColor = Color.Red;
                                Row.DefaultCellStyle.ForeColor = Color.White;
                               // MessageBox.Show("Item Exceeded, Please return the item");
                                labNotFound.Text = "Item Exceeded, Please return the item";
                                labNotFound.Visible = true;

                            }
                            // MessageBox.Show(numberOfhDuplicates.ToString());
                        }
                    }
                    //               if (!myList.Contains(s))
                    #endregion //myList.Add(s);
                }
                else
                {
                    labNotFound.Text = "This item is not part of the transaction";
                    labNotFound.Visible = true;
                    grvData.BackgroundColor = Color.Red;
                    // MessageBox.Show("This item is not part of the transaction");
                }

            }
        }
        #endregion

        #region Print Handler
        public void PrintReceiptForTransaction()
        {
            try
            {
                DialogResult dlg = MessageBox.Show("Do you want to Print Reciept?", "JumpQ Konnect Alert!", MessageBoxButtons.YesNo);

                if (dlg == DialogResult.Yes)
                {


                    PrinterSettings ps = new PrinterSettings();
                    // ps.PrinterName = "EPSON TM-T20II Receipt";
                    string prnAM = ps.PrinterName;
                    ps.PrinterName = prnAM;

                    Print(ps.PrinterName);
                    return;
                }
                else
                {

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


        private PrintDocument PrintDocument;
        private Graphics graphics;
                  
        public void Print(string printername)
        {
            PrintDocument = new PrintDocument();
            PrintDocument.PrinterSettings.PrinterName = printername;

            PrintDocument.PrintPage += new PrintPageEventHandler(FormatPage);
            PrintDocument.Print();
        }
        void DrawAtStart(string text, int Offset)
        {
            int startX = 10;
            int startY = 5;
            Font minifont = new Font("Arial", 5);

            graphics.DrawString(text, minifont,
                        new SolidBrush(Color.Black), startX + 5, startY + Offset);
        }
        void InsertItem(string key, string value, int Offset)
        {
            Font minifont = new Font("Arial", 5);
            int startX = 10;
            int startY = 5;

            graphics.DrawString(key, minifont,
                            new SolidBrush(Color.Black), startX + 5, startY + Offset);

            graphics.DrawString(value, minifont,
                        new SolidBrush(Color.Black), startX + 130, startY + Offset);
        }
        void InsertHeaderStyleItem(string key, string value, int Offset)
        {
            int startX = 10;
            int startY = 5;
            Font itemfont = new Font("Arial", 6, FontStyle.Bold);

            graphics.DrawString(key, itemfont,
                            new SolidBrush(Color.Black), startX + 5, startY + Offset);

            graphics.DrawString(value, itemfont,
                        new SolidBrush(Color.Black), startX + 130, startY + Offset);
        }
        void DrawLine(string text, Font font, int Offset, int xOffset)
        {
            int startX = 10;
            int startY = 5;
            graphics.DrawString(text, font,
                        new SolidBrush(Color.Black), startX + xOffset, startY + Offset);
        }
        void DrawSimpleString(string text, Font font, int Offset, int xOffset)
        {
            int startX = 10;
            int startY = 5;
            graphics.DrawString(text, font,
                        new SolidBrush(Color.Black), startX + xOffset, startY + Offset);
        }
        private void FormatPage(object sender, PrintPageEventArgs e)
        {
            int startX = 10;
            int startY = 5;
            graphics = e.Graphics;
            Font minifont = new Font("Arial", 5);
            Font itemfont = new Font("Arial", 6);
            Font smallfont = new Font("Arial", 8);
            Font mediumfont = new Font("Arial", 10);
            Font largefont = new Font("Arial", 12);
            int Offset = 10;
            int smallinc = 10, mediuminc = 12, largeinc = 15;

            //Image image = Resources.logo;
            //e.Graphics.DrawImage(image, startX + 50, startY + Offset, 100, 30);

            graphics.DrawString("Welcome to "+ Properties.Settings.Default.QbComputerName, smallfont,
                    new SolidBrush(Color.Black), startX + 22, startY + Offset);

            Offset = Offset + largeinc + 10;

            String underLine = "-------------------------------------";
            DrawLine(underLine, largefont, Offset, 0);

            //Reciept Number
            Offset = Offset + mediuminc;
            DrawAtStart("Receipt Number: " + "xxx", Offset);

            //Address
            Offset = Offset + mediuminc;
            DrawAtStart("Address: xxxxxxxxx", Offset);
            //Date
            Offset = Offset + mediuminc;
            DrawAtStart("Date: " + DateTime.Now, Offset);

            Offset = Offset + smallinc;
            underLine = "-------------------------";
            DrawLine(underLine, largefont, Offset, 30);

            Offset = Offset + largeinc;

            InsertHeaderStyleItem("Name. ", "Price. ", Offset);

            Offset = Offset + largeinc;
                int Total = 0;
                foreach (DataGridViewRow Row in grvData.Rows)
                {
                     
                    string itemName = Row.Cells[2].Value.ToString();

                    int price = Convert.ToInt32(Row.Cells[3].Value);

                    int qty = Convert.ToInt32(Row.Cells[1].Value);

                    int amount = price *qty;
                    
                    InsertItem(itemName + " x " + qty.ToString(), amount.ToString(), Offset);
                    Offset = Offset + smallinc;
                //   text = itemName + "      " + qty.ToString() + "      " + price.ToString() + "      " + amount.ToString();
                    Total += amount;
                }
            underLine = "-------------------------";
            DrawLine(underLine, largefont, Offset, 30);

            Offset = Offset + smallinc;
            InsertHeaderStyleItem(" Total Amount: ",  Total.ToString(), Offset);

            Offset = Offset + largeinc;
            String address = "Address";
            DrawSimpleString("Address: " + address, minifont, Offset, 15);

            Offset = Offset + smallinc;
            String number = "Tel: " + "shop.Phone1" + " - OR - " + "shop.Phone2";
            DrawSimpleString(number, minifont, Offset, 35);

            Offset = Offset + 7;
            underLine = "-------------------------------------";
            DrawLine(underLine, largefont, Offset, 0);

            Offset = Offset + mediuminc;
            String greetings = "Thanks for visiting us.";
            DrawSimpleString(greetings, mediumfont, Offset, 28);

            Offset = Offset + mediuminc;
            underLine = "-------------------------------------";
            DrawLine(underLine, largefont, Offset, 0);

            //Offset += (2 * mediuminc);
            //string tip = "TIP: -----------------------------";
            //InsertItem(tip, "", Offset);

            Offset = Offset + largeinc;
            string DrawnBy = "PiedTech Solutions: +234 8165583699";
            DrawSimpleString(DrawnBy, minifont, Offset, 15);
        }
        
        #endregion



        #region Form Event Handlers
        public void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {

                Application.DoEvents();
                if (ConnectBtn.Text == "Disconnect")
                {
                    if (_cn != null)
                    {
                        lblConnectionStatus.Text = "Disconnecting....";
                        _cn.Close();
                        _cn.Dispose();
                        _cn = null;
                        ConnectBtn.Text = "Connect";
                        lblConnectionStatus.Text = "Not Connected";
                        lblConnectionStatus.ForeColor = Color.DarkRed;
                    }
                }
                else
                {
                    if (_cn == null || _cn.State == ConnectionState.Closed)
                    {
                        lblConnectionStatus.Text = "Connecting....";

                        _cn = new OdbcConnection(string.Format("DSN={0}", cboListOfDSN.Text));
                        _cn.ConnectionTimeout = 60;
                        _cn.Open();
                        ConnectBtn.Text = "Disconnect";
                        lblConnectionStatus.Text = "Connected";
                        lblConnectionStatus.ForeColor = Color.Green;
                    }

                }
                Application.DoEvents();
            }
            catch (Exception ex)
            {
                Application.DoEvents();
                ConnectBtn.Text = "Errorred";
                MessageBox.Show(string.Format("Error - {0}, Stack Trace {1}", ex.Message, ex.StackTrace));
            }

        }
        private void btnSet_Click(object sender, EventArgs e)
        {
            Settings setts = new Settings();
            setts.ShowDialog();
        }
        //private void BtnSettings_Click(object sender, EventArgs e)
        //{
        //    Settings setts = new Settings();
        //    setts.ShowDialog();
        //}
        private void ConnectBtn_Click(object sender, EventArgs e)
        {

            try
            {
                if (cboListOfDSN.SelectedIndex > -1 && cameraTypes.SelectedIndex > -1)
                {
                    //if (cboListOfDSN.Text == "QuickBooks Data POS")
                    //{
                    Application.DoEvents();
                    if (ConnectBtn.Text == "Disconnect")
                    {
                        if (_cn != null)
                        {
                            lblConnectionStatus.Text = "Disconnecting....";
                            _cn.Close();
                            _cn.Dispose();
                            _cn = null;
                            ConnectBtn.Text = "Connect";
                            lblConnectionStatus.Text = "Not Connected";
                            lblConnectionStatus.ForeColor = Color.DarkRed;
                        }
                    }
                    else
                    {
                        if (_cn == null || _cn.State == ConnectionState.Closed)
                        {
                            lblConnectionStatus.Text = "Connecting....";

                            _cn = new OdbcConnection(string.Format("DSN={0}", cboListOfDSN.Text));
                            _cn.ConnectionTimeout = 60;
                            _cn.Open();
                            ConnectBtn.Text = "Disconnect";
                            lblConnectionStatus.Text = "Connected";
                            lblConnectionStatus.ForeColor = Color.Green;
                        }

                        //DisplayItemInGrid("RUKEWE");
                    }
                    Application.DoEvents();
                    //}
                    //else
                    //{
                    //    MessageBox.Show("Please select QuickBooks Data POS");
                    //}
                }


            }
            catch (Exception ex)
            {
                Application.DoEvents();
                ConnectBtn.Text = "Errorr";
                MessageBox.Show(string.Format("Error - {0}, Stack Trace {1}", ex.Message, ex.StackTrace));
            }
        }
        private void scanBtn_Click(object sender, EventArgs e)
        {
            try
            {

                if (_cn == null || _cn.State == ConnectionState.Closed)
                {
                    btnConnect_Click(null, null);
                }

                if (grvData.Rows.Count >0)
                {
                    grvData.Rows.Clear();
                }
               

                if (captureDevice == null)
                {

                    txtQRCode.Text = string.Empty;
                    pictureBox.Image = null;
                    captureDevice = new VideoCaptureDevice(filterInfoCollection[cameraTypes.SelectedIndex].MonikerString);
                    captureDevice.NewFrame += captureDevice_NewFrame;
                    captureDevice.Start();
                    timer1.Start();
                }
                else
                {
                    pictureBox.Image = null;
                    captureDevice.Stop();
                    txtQRCode.Text = string.Empty;
                    captureDevice = new VideoCaptureDevice(filterInfoCollection[cameraTypes.SelectedIndex].MonikerString);
                    captureDevice.NewFrame += captureDevice_NewFrame;
                    captureDevice.Start();
                    timer1.Start();

                }
                //}

            }
            catch (Exception ex)
            {

                MessageBox.Show(string.Format("Error - {0}, Stack Trace {1}", ex.Message, ex.StackTrace));
            }



        }
        private void scANvERITFY_Click(object sender, EventArgs e)
        {
            if (grvData.Rows.Count > 0)
            {



                BarcodeInput2.Text = string.Empty;
                BarcodeInput1.Text = string.Empty;
                BarcodeInput1.Focus();
                //if (BarcodeInput1.Text != string.Empty)
                //{
                //    ScanVerifyItem(BarcodeInput1.Text);
                //}

            }
            else
            {
                MessageBox.Show("No transaction to verify, JumpQ Konnect");
            }

        }
        private void BtnPostSales_Click(object sender, EventArgs e)
        {
            try
            {
                InsertScannedItems();


            }
            catch (Exception ex)
            {

                MessageBox.Show(string.Format("Error - {0}, Stack Trace {1}", ex.Message, ex.StackTrace));
            }
        }
       
     
        private void AddSalesItem_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (captureDevice == null) return;

                if (captureDevice.IsRunning)
                    captureDevice.Stop();

                if (_cn != null && _cn.State != ConnectionState.Closed)
                {
                    _cn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

        }
        private void btnClose_Click(object sender, EventArgs e)
        {

            Application.Exit();
        }
#endregion

        private void Printbtn_Click(object sender, EventArgs e)
        {
            if (grvData.Rows.Count > 0)
            {
                PrintReceiptForTransaction();
            }
        }
    }
}
