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
using Microsoft.Owin.Security.OAuth;
using Microsoft.Owin;
using Microsoft.Owin.Infrastructure;
using System.Web.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json.Linq;
using RestSharp;



namespace JumpQ_TestApp
{
    public partial class AddSalesItem : Form
    {
        private int maxNumber = 0;
        private int correctNumber = 0;
        private OdbcConnection _cn;
        public AddSalesItem()
        {
            InitializeComponent();
          //  ApiHelper".InitializeClient();
          //  Getrequest("http: //www.google.com.pk");
           // Postrequest("https:// posttestserver.com");
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





        private async Task LoadImage(int imageNumber = 0)
        {
          //  var comic = await QickBookDataProcessor.LoadComic(imageNumber);
          //  if (imageNumber == 0)
          //  {
          //      maxNumber = comic.Num;


          //  }
          //  correctNumber = comic.Num;
          //  var urlSource = new Uri(comic.Img, UriKind.Absolute);
          ////  pictureBox.Image = new BitmapImage(urlSource);
        }


        #region  //BArcodeJob Encapsulation
        SQLiteConnection con = new SQLiteConnection(@"Data Source=.\JumpQKonnect.db; Version= 3;");
        FilterInfoCollection filterInfoCollection;
        VideoCaptureDevice captureDevice;

        List<string> ContainRfid = new List<string>();
        List<string> NoRfid = new List<string>();
        List<string> BlockContent = new List<string>();
        List<string> jstRfid = new List<string>();


        private void AddSalesItem_Load(object sender, EventArgs e)
        {
            try
            {
                ListOutDSN();

                ListOutCameras(); getSettings(); //loadsfirst to check if customer exist

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
        private void ListOutDSN()
        {
            cboListOfDSN.Items.Clear();
           
            var myODBCKeys =  Registry.LocalMachine.OpenSubKey("SOFTWARE\\ODBC\\ODBC.INI\\ODBC Data Sources", false).GetValueNames();
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
                    cboListOfDSN.SelectedIndex = 1;
                }
            }
           



        }
        private void ListOutCameras()
        {
            filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo filterInfo in filterInfoCollection)
            {
                cameraTypes.Items.Add(filterInfo.Name);
                cameraTypes.SelectedIndex = 0;
            }

        }
        

        void connect()
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
        string comments = "Sales Transaction Success";
        string cashier = "OMO";
        string salesReceiptType="Sales";
        string itemName="6015319814099075329";



        //int tenderAmt; string taxcode;
        private void SelectCustomer()
        {
            //string query = string.Format("SELECT ListID, FullName FROM Customer ");
            //ProcessQuery(query);
        }
      //  String selectSql = "SELECT * FROM Customers C INNER JOIN Orders O ON C.CustomerId= o.CustomerId";
        //OdbcCommand cmd = new OdbcCommand(selectSql, conn);

        private void InsertSalesReceiptItem(string customerName, string comments, string cashierName, string salesReceiptType, string itemName, int quanity, int rate, int tenderAmount)
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
        private void btnSalesReceiptItem_Click(object sender, EventArgs e)
        {
           //  callWebServices();
           //// DisplayItemInGrid("RUKEWE");
           //// DisplayItemInGrid();
           //// return;

           // InsertSalesReceiptItem(txtcustomerName.Text, txtComments.Text, txtCashierName.Text, txtSalesReceiptType.Text, txtItemName.Text, int.Parse(txtQuantity.Text), int.Parse(txtItemPrice.Text), int.Parse(txtTenderAmount.Text));
           // string lastInsertedId1 = GetLastInsertedId("sp_lastInsertID SalesReceiptItem");
           // DisplaySalesReceiptGrid(lastInsertedId1);

           // InsertCustomer( "General", "Customer");
          
            // SelectCustomer();

            //DisplaySalesReceiptInGrid();
            //return;
            //try
            //{
            //    if (_cn == null || _cn.State == ConnectionState.Closed)
            //    {
            //        btnConnect_Click(null, null);
            //    }
            //    //if (string.IsNullOrEmpty(txtcustomerName.Text))
            //    //{
            //    //    MessageBox.Show("Customer Name is Required.");
            //    //    return;
            //    //}
            //    if (string.IsNullOrEmpty(txtComments.Text))
            //    {
            //        MessageBox.Show("Comments is required.");
            //        return;
            //    }
            //    if (string.IsNullOrEmpty(txtCashierName.Text))
            //    {
            //        MessageBox.Show("Cashier Name is required.");
            //        return;
            //    }
            //    if (string.IsNullOrEmpty(txtSalesReceiptType.Text))
            //    {
            //        MessageBox.Show("Sales Receipt Type is required.");
            //        return;
            //    }
            //    if (string.IsNullOrEmpty(txtItemName.Text))
            //    {
            //        MessageBox.Show("Item Name is required.");
            //        return;
            //    }
            //    if (string.IsNullOrEmpty(txtQuantity.Text))
            //    {
            //        MessageBox.Show("Quantity is required.");
            //        return;
            //    }
            //    if (string.IsNullOrEmpty(txtItemPrice.Text))
            //    {
            //        MessageBox.Show("Item Price is required.");
            //        return;
            //    }
            //    if (string.IsNullOrEmpty(txtTenderAmount.Text))
            //    {
            //        MessageBox.Show("Tender Amount is required.");
            //        return;
            //    }
            //    // <----- I tried avoiding the customer Id 
                //InsertSalesReceiptLineItem(txtComments.Text, txtCashierName.Text, txtSalesReceiptType.Text, txtItemName.Text, int.Parse(txtQuantity.Text), int.Parse(txtItemPrice.Text), int.Parse(txtTenderAmount.Text));

                //InsertSalesReceiptLineItem(txtcustomerName.Text, txtComments.Text, txtCashierName.Text, txtSalesReceiptType.Text, txtItemName.Text, int.Parse(txtQuantity.Text), int.Parse(txtItemPrice.Text), int.Parse(txtTenderAmount.Text));
            //    string lastInsertedId = GetLastInsertedId("sp_lastInsertID SalesReceiptItem");
            //    MessageBox.Show(lastInsertedId);
            //   // DisplaySalesReceiptInGrid(lastInsertedId);
            //    //string lastInsertedId = GetLastInsertedId("sp_lastInsertID SalesReceiptItem");
            //    //DisplaySalesReceiptInGrid(lastInsertedId);
            //}
            //catch (Exception ex)
            //{

            //    MessageBox.Show(string.Format("Error - {0}, Stack Trace {1}", ex.Message, ex.StackTrace));
            //}
        }

   
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

        private void ProcessQuery(string query)
        {
            var cmd = new OdbcCommand(query, _cn);
            DataSet dataSet = new DataSet();
            OdbcDataReader reader = cmd.ExecuteReader();
            DataTable myTable = new DataTable();
            myTable.Load(reader);
            sfDataGrid1.AutoGenerateColumns = true;
            sfDataGrid1.DataSource = myTable;
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
            grvData.AutoGenerateColumns = true;
            grvData.DataSource = myTable;
            grvData.BorderStyle = BorderStyle.FixedSingle;
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
                              //   foreach (string blockCont in BlockContent)
                              //{
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




                     // SQLiteRFIDInsertQuery();
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
        private void scanBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (_cn == null || _cn.State == ConnectionState.Closed)
                {
                    btnConnect_Click(null, null);
                }

                //if (true)
                //{
                    
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
                    txtQRCode.Text = decryptedString;
                  
                   // MessageBox.Show(decryptedString);
                    if (captureDevice.IsRunning)
                        captureDevice.Stop();
                    BarcodeLogic();
                   // apiCall();
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
                  int tenderAmt = 0;
                  foreach (string blockCont in BlockContent)
                  {
                      string[] splitblockCont = blockCont.Split('*');
                      string result = splitblockCont[0].Trim();
                      int ItmQty = Convert.ToInt32(splitblockCont[1].Trim());

                      ///
                      ///summary
                      ///Make sure you change this Price number to actual arrayIndex
                     double pri = Convert.ToDouble (splitblockCont[2].Trim());//("1000");
                     int priceResult2 = (int)pri;
                     //int priceResult2 = Convert.ToInt32("1000");//("1000");

                      tenderAmt = (ItmQty * priceResult2);
                      totalAmount += ItmQty * priceResult2;
                      chkifPriceexitInQuickBook(result, priceResult2);
                      if (ticket == true)
                      {
                          InsertSalesReceiptItem(CustomerID, comments, cashier, salesReceiptType, itemName, int.Parse(ItmQty.ToString()), int.Parse(priceResult2.ToString()), int.Parse(tenderAmt.ToString()));
                          displayScannedItems(result, ItmQty.ToString(), tenderAmt.ToString());
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

            string query = string.Format("SELECT Desc1 as ItemName,Price1 as Price, QuantityOnHand as Quantity, ALU as QRCode, Desc2 as Description FROM ItemInventory where ALU='{0}'", qrCode);
            var cmd = new OdbcCommand(query, _cn);
            DataSet dataSet = new DataSet();
            OdbcDataReader reader = cmd.ExecuteReader();
            DataTable myTable = new DataTable();
            myTable.Load(reader);
            foreach (DataRow item in myTable.Rows)
            {
                int n = grvData.Rows.Add();
                
                grvData.Rows[n].Cells[0].Value = (n + 1).ToString();
                grvData.Rows[n].Cells[1].Value = item["ItemName"].ToString();
                grvData.Rows[n].Cells[2].Value = item["Price"].ToString();
                grvData.Rows[n].Cells[3].Value = quantity;
                grvData.Rows[n].Cells[4].Value = item["QRCode"].ToString();
                grvData.Rows[n].Cells[5].Value = item["Description"].ToString();
                grvData.Rows[n].Cells[6].Value = total;
                //grvData.Rows[n].Cells[6].Value = item["Desc2"].ToString();
              //  grvData.Rows[n].Cells[3].Style.ForeColor = Color.ForestGreen;

            }
        
        }

        private void BtnSettings_Click(object sender, EventArgs e)
        {
            Settings setts = new Settings();
            setts.ShowDialog();
        }

        void getSettings()
        {
            
            CustomerID = Properties.Settings.Default.CustomerID;
            if (CustomerID == string.Empty)
            {
                BtnSettings_Click(null, null);
            }
          //  MessageBox.Show(CustomerID);

        }
         double totalAmount { get; set; }
         public string CustomerID { get; set; }

        #endregion
         string myToken;
        void apiCall()
        {
             string endpoint = "https://myjumpq.net/api/staff/login";
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
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                var response1 = wc.UploadString(endpoint, method, json);
              //  var user= JsonConvert.DeserializeObject<winformClient>(response1); //This line might not be needed
                if (response1 != null)
                {
                    Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(response1);
                    myToken = myDeserializedClass.user.api_token;
                    txtQRCode.Text = myToken;
                  // MessageBox.Show(myToken);
                   //PostRequest();
                }
                else
                {
                    MessageBox.Show("Please check internet connectivity");
                }
                
            }     
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public async Task<string> PostGetAsync()
        {
            var uri = new Uri("https://myjumpq.net/api/staff/add_products");

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization =
     new AuthenticationHeaderValue("api_token", myToken);
                var pairs = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("Key", "Value"),
                     new KeyValuePair<string, string>("Key", "Value"),
                      new KeyValuePair<string, string>("Key", "Value"),
                       new KeyValuePair<string, string>("Key", "Value"),
                        new KeyValuePair<string, string>("Key", "Value")
                };

                var content = new FormUrlEncodedContent(pairs);
                var response = await client.PostAsync(uri, content);

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    return "Error posting KeyValue";
                }

                string responseString = response.Content.ReadAsStringAsync().Result;

                JArray json = JArray.Parse(responseString);

                try
                {
                    var returnedJson = json;
                    return returnedJson.ToString();
                }
                catch (Exception e)
                {
                    return "Index is out of bounds";
                }
            }
        }

        void post()
        {

                    Product pro= new Product();
            string endpoint = "https://myjumpq.net/api/staff/login";
            string method = "POST";
            RootProduct rtp = new RootProduct();
           
            pro.name=""; pro.price= 0; pro.cost_price=0; pro.barcode= "";
            pro.description=""; pro.quantity= 0; 



            string json = JsonConvert.SerializeObject(  new
            {
              
                username = "james",
                password = "polinium"
            });

            WebClient wc = new WebClient();
            wc.Headers["Content-Type"] = "application/json";
            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                var response1 = wc.UploadString(endpoint, method, json);
                //  var user= JsonConvert.DeserializeObject<winformClient>(response1); //This line might not be needed
                if (response1 != null)
                {
                    Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(response1);
                    string myToken = myDeserializedClass.user.api_token;
                    MessageBox.Show(myToken);

                }
                else
                {
                    MessageBox.Show("Please check internet connectivity");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }






     
       private void btnGo_Click(object sender, EventArgs e)
         {


             PostReqst();
             
             
           










         }

         private void cmdCopy_Click(object sender, EventArgs e)
         {
            // System.Windows.Forms.Clipboard.SetText(txtResponse.Text);
         }

         private void cmdClear_Click(object sender, EventArgs e)
         {
             TimelyInventoryUpdate();
             return;
             apiCall();
          
         }
         async  void PostRequest()
        {
            string url = "https://myjumpq.net/api/staff/add_products";
            var formData = new List<KeyValuePair<string, string>>();
            TimelyInventoryUpdate();
            foreach (DataRow item in InventoryTable.Rows)
            {
                formData.Add(new KeyValuePair<string, string>("name", item[0].ToString()));
                formData.Add(new KeyValuePair<string, string>("price", item[1].ToString()));
                formData.Add(new KeyValuePair<string, string>("cost_price", item[2].ToString()));
                formData.Add(new KeyValuePair<string, string>("barcode", item[3].ToString()));
                formData.Add(new KeyValuePair<string, string>("description", item[4].ToString()));
                formData.Add(new KeyValuePair<string, string>("quantity", item[5].ToString()));
               
                HttpContent q = new FormUrlEncodedContent(formData);

                // where do I put my api key?
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));//ACCEPT header
                    client.BaseAddress = new Uri(url);

                    client.DefaultRequestHeaders.Add("api_token", myToken);

                    using (HttpResponseMessage response = await client.PostAsync(url, q))
                    {
                        using (HttpContent content = response.Content)
                        {
                            string mycontent = await content.ReadAsStringAsync();

                            MessageBox.Show(mycontent);
                        }
                    }
                }
            }
           

        }


    
         async static  void PostReqst()
         {
             string endpoint = "http://myjumpq.net/api/staff/login";
             string url = "http://myjumpq.net/api/staff/login";
             var formData = new List<KeyValuePair<string, string>>();
             formData.Add(new KeyValuePair<string, string>("username", "joel"));
             formData.Add(new KeyValuePair<string, string>("password", "polinium"));
             HttpContent q = new FormUrlEncodedContent(formData);
             using (var httpClient = new HttpClient())
             {
             //    httpClient.BaseAddress = new Uri(url);
             //    httpClient.DefaultRequestHeaders.Accept.Clear();
             //    q.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
             //   // httpClient.DefaultRequestHeaders.Authorization = new
             //     //   System.Net.Http.Headers.AuthenticationHeaderValue("RvtYjd9jUpB5oU5VJLntVYz125njSJnqivZpnwNqyNUyGAlJo4oa6hZN7SCP");
             ////    httpClient.DefaultRequestHeaders.Add("api_token", "RvtYjd9jUpB5oU5VJLntVYz125njSJnqivZpnwNqyNUyGAlJo4oa6hZN7SCP");
              
                 HttpResponseMessage response = await httpClient.GetAsync(endpoint);
                 if (response.StatusCode == HttpStatusCode.OK)
                 {
                     string result = await response.Content.ReadAsStringAsync();
                     if (string.IsNullOrEmpty(result))
                         MessageBox.Show("Success"); 
                     else
                          MessageBox.Show( result);
                 }
                 else if (response.StatusCode == HttpStatusCode.Unauthorized)
                 {
                     throw new UnauthorizedAccessException();
                 }
                 else
                 {
                     throw new Exception(await response.Content.ReadAsStringAsync());
                 }
             }
         }

         private void btnSet_Click(object sender, EventArgs e)
         {
             Settings setts = new Settings();
             setts.ShowDialog();
         }

         private void ConnectBtn_Click(object sender, EventArgs e)
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
                     apiCall();
                     //DisplayItemInGrid("RUKEWE");
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

         private void btnClose_Click(object sender, EventArgs e)
         {
             Application.Exit();
         }
    }
}
