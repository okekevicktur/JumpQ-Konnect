using AForge.Video.DirectShow;
using AForge.Video;
using ZXing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//using Interop.QBPOSXMLRPLIB;
using System.IO;
using System.Xml;
using System.Data.Odbc;
//using Interop.qbposfc4;
using QBPOSFC4Lib;
using System.Text.RegularExpressions;
using System.Data.SQLite;


namespace JumpQ_TestApp
{
    public  partial class Form1 : Form
    {
       
        public string requestXML = "";

     
        public string connString = "";
   
     //   public RequestProcessor rp = null;
        string QbComputer ;
        string QbCompanyDt ;
        string QbVersion;
        List<string> ContainRfid = new List<string>();
        List<string> NoRfid = new List<string>();
        List<string> BlockContent = new List<string>();
        List<string> jstRfid = new List<string>();
        public string responseXML = "";
        string rfidTransactDate = "";
        double totalAmount = 0.0;
         FilterInfoCollection filterInfoCollection;
        VideoCaptureDevice captureDevice;
        SQLiteConnection con = new SQLiteConnection(@"Data Source=.\JumpQKonnect.db; Version= 3;");

        public Form1()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            //
            // TODO: Add any constructor code after InitializeComponent call
            //

           // rp = new RequestProcessor();
        }
         //I created a txt file where  i added some details about the quickbook;
        //this is content of the text Format: Computer Name=DESKTOP-B2QR973;Company Data=Grace;Version=19
        //Where Computer name represents server/Workstation and Company Data represents the Company name on the quickBooks POS and Version being te version of the quickBooks PoS being used.
        //This method reads the text from the file Named cstr.txt
      
        void checkSettings()
        {
            if (QbCompanyDt == string.Empty || QbComputer == string.Empty || QbVersion == string.Empty)
            {
                Custom_Settings CSETT = new Custom_Settings();
                CSETT.ShowDialog();
              
            }
            else
            {
                connString = "Computer Name=" + QbComputer + ";Company Data=" + QbCompanyDt + ";Version="+ QbVersion;
            }
        }
       
        
        // Step-2: When the button is clicked, sample will check the
				// connection string to try to determine if this is the first time
				// it is connecting to QBPOS, or not.
			
					// Step-2a: First time connected			
        void getSettings()
        {
             QbComputer = Properties.Settings.Default.QbComputerName;
             QbCompanyDt = Properties.Settings.Default.QbCompanyData;
             QbVersion = Properties.Settings.Default.QbVersion;
            // MessageBox.Show(QbComputer + QbCompanyDt + QbVersion);
        }
       
        public string isTaxable = null;
        private void Form1_Load(object sender, EventArgs e)
        {
            // Step-1: When the form is loaded, reading from app settings 
            // to get the last stored connection string
            // Step-1a: Connection string has been found.
            // Parsing the connection string to get
            getSettings();
            checkSettings();         
            filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo filterInfo in filterInfoCollection)
            {
                cameraTypes.Items.Add(filterInfo.Name);
                cameraTypes.SelectedIndex = 0;
            }

            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
        } 
       
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>


        #region This part decrypts the barcode and not the logic of the decryted barcode
        private void startBtn_Click(object sender, EventArgs e)
        {
            //if (captureDevice.IsRunning)
            //    captureDevice.Stop();
            if (captureDevice == null)
            {
               // MessageBox.Show("null");
                txtQRCode.Text = string.Empty;
                pictureBox.Image = null;
                captureDevice = new VideoCaptureDevice(filterInfoCollection[cameraTypes.SelectedIndex].MonikerString);
                captureDevice.NewFrame += captureDevice_NewFrame;
                captureDevice.Start();
                timer1.Start();
            }
            else
            {
               // MessageBox.Show("not null");
                //if (captureDevice.IsRunning)
                //{
                    pictureBox.Image = null;
                    captureDevice.Stop();
                    txtQRCode.Text = string.Empty;
                    captureDevice = new VideoCaptureDevice(filterInfoCollection[cameraTypes.SelectedIndex].MonikerString);
                    captureDevice.NewFrame += captureDevice_NewFrame;
                    captureDevice.Start();
                    timer1.Start();
                //}
            }
           
        }

        void captureDevice_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            pictureBox.Image = (Bitmap)eventArgs.Frame.Clone();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (captureDevice == null) return;
               
                if (captureDevice.IsRunning)
                    captureDevice.Stop();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                
            }
          
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (pictureBox.Image != null)
            {
               // MessageBox.Show("picture available");
                BarcodeReader barcodeReader = new BarcodeReader();
                Result result = barcodeReader.Decode((Bitmap)(pictureBox.Image));
                if (result != null)
	            {
                   // MessageBox.Show("Test");
                    timer1.Stop();
		             txtQRCode.Text= result.ToString();
                     BarcodeLogic();
          
                    if (captureDevice.IsRunning)
                        captureDevice.Stop();
	            }
            }
        }

        public void processRequest()
        {
            //try{
            //    // step1: verify that a valid vendor code is entered
            //    String vcode=txtVCode.Text.Trim();
            //    if (vcode.Length<=0 || vcode.Length>3){
            //        MessageBox.Show("Please enter a valid value for Vendor code (maximum 3 characters)", "Input Validation");
            //        return;
            //    }
            //    String fname = txtFN.Text.Trim() ;
				
            //    String lname = txtLN.Text.Trim() ;
				
            //    //step2: create the qbXML request
            //    XmlDocument inputXMLDoc = new XmlDocument();
            //    inputXMLDoc.AppendChild(inputXMLDoc.CreateXmlDeclaration("1.0",null, null));
            //    inputXMLDoc.AppendChild(inputXMLDoc.CreateProcessingInstruction("qbposxml", "version=\"4.0\""));
            //    XmlElement qbXML = inputXMLDoc.CreateElement("QBPOSXML");
            //    inputXMLDoc.AppendChild(qbXML);
            //    XmlElement qbXMLMsgsRq = inputXMLDoc.CreateElement("QBPOSXMLMsgsRq");
            //    qbXML.AppendChild(qbXMLMsgsRq);
            //    qbXMLMsgsRq.SetAttribute("onError", "stopOnError");
            //    XmlElement vendAddRq = inputXMLDoc.CreateElement("VendorAddRq");
            //    qbXMLMsgsRq.AppendChild(vendAddRq);
            //    vendAddRq.SetAttribute("requestID", "1");
            //    XmlElement vendAdd = inputXMLDoc.CreateElement("VendorAdd");
            //    vendAddRq.AppendChild(vendAdd);	
            //    vendAdd.AppendChild(inputXMLDoc.CreateElement("FirstName")).InnerText=fname;
            //    vendAdd.AppendChild(inputXMLDoc.CreateElement("LastName")).InnerText=lname;
            //    if( txtEmail.Text.Length  > 0  ) {
            //        vendAdd.AppendChild(inputXMLDoc.CreateElement("Email")).InnerText=txtEmail.Text;
            //    }
            //    if( txtAddr1.Text.Length  > 0  ) {
            //        vendAdd.AppendChild(inputXMLDoc.CreateElement("Street")).InnerText=txtAddr1.Text;
            //    }
            //    if( txtCity.Text.Length  > 0  ) {
            //        vendAdd.AppendChild(inputXMLDoc.CreateElement("City")).InnerText=txtCity.Text;
            //    }
            //    if( txtState.Text.Length  > 0  ) {
            //        vendAdd.AppendChild(inputXMLDoc.CreateElement("State")).InnerText=txtState.Text;
            //    }
            //    if( txtZip.Text.Length  > 0  ) {
            //        vendAdd.AppendChild(inputXMLDoc.CreateElement("PostalCode")).InnerText=txtZip.Text;
            //    }
            //    if( txtCompany.Text.Length  > 0  ) {
            //        vendAdd.AppendChild(inputXMLDoc.CreateElement("CompanyName")).InnerText=txtCompany.Text;
            //    }
            //    if( txtNotes.Text.Length  > 0  ) {
            //        vendAdd.AppendChild(inputXMLDoc.CreateElement("Notes")).InnerText=txtNotes.Text;
            //    }
            //    vendAdd.AppendChild(inputXMLDoc.CreateElement("VendorCode")).InnerText=vcode.ToString();
            //    string input = inputXMLDoc.OuterXml;
            //    //step3: do the qbXMLRP request
            //    string ticket = null;
            //    string response = null;
            //    try {
            //        //rp.OpenConnection("CSVendorAddSample", "IDN VendorAdd C# sample");
            //        rp.OpenConnection("JMPQConnector", "JumpQ_TestApp");
            //        //MessageBox.Show(connString);
            //        ticket = rp.BeginSession(connString);
					
            //        response = rp.ProcessRequest(ticket, input);
            //        requestXML=input.ToString();
            //        responseXML=response.ToString();
					
            //    }
            //    catch( System.Runtime.InteropServices.COMException ex ) {
            //        MessageBox.Show( "COM Error Description = " +  ex.Message, "COM error" );
            //        return;
            //    }
            //    finally {
            //        if( ticket != null ) {
            //            rp.EndSession(ticket);
            //        }
            //        if( rp != null ) {
            //            rp.CloseConnection();
            //        }
            //    };

            //    //step4: parse the XML response and show a message
            //    XmlDocument outputXMLDoc = new XmlDocument();
            //    outputXMLDoc.LoadXml(response);
            //    XmlNodeList qbXMLMsgsRsNodeList = outputXMLDoc.GetElementsByTagName ("VendorAddRs");
            //    if( qbXMLMsgsRsNodeList.Count == 1 ) { //it's always true, since we added a single Vendor
            //        System.Text.StringBuilder popupMessage = new System.Text.StringBuilder();
            //        XmlAttributeCollection rsAttributes = qbXMLMsgsRsNodeList.Item(0).Attributes;
            //        //get the status Code, info and Severity
            //        string retStatusCode = rsAttributes.GetNamedItem("statusCode").Value; 
            //        string retStatusSeverity = rsAttributes.GetNamedItem("statusSeverity").Value;
            //        string retStatusMessage = rsAttributes.GetNamedItem("statusMessage").Value;
            //        popupMessage.AppendFormat( "statusCode = {0}, statusSeverity = {1}, statusMessage = {2}",
            //            retStatusCode, retStatusSeverity, retStatusMessage );

            //        //get the VendorRet node for detailed info
            //        //a VendorAddRs contains max one childNode for "VendorRet"
            //        XmlNodeList vendAddRsNodeList = qbXMLMsgsRsNodeList.Item(0).ChildNodes;
            //        if( vendAddRsNodeList.Count == 1 && vendAddRsNodeList.Item(0).Name.Equals("VendorRet") ) {
            //            XmlNodeList vendRetNodeList = vendAddRsNodeList.Item(0).ChildNodes ;
					
            //            foreach (XmlNode vendRetNode in vendRetNodeList ) {
            //                if ( vendRetNode.Name.Equals( "ListID" ) ) {
            //                    popupMessage.AppendFormat("\r\nVendor ListID = {0}", vendRetNode.InnerText  );
            //                }
            //                else if ( vendRetNode.Name.Equals( "FirstName" ) ) {
            //                    popupMessage.AppendFormat("\r\nVendor First Name = {0}", vendRetNode.InnerText );
            //                }
            //                else if  ( vendRetNode.Name.Equals( "LastName" ) ) {
            //                    popupMessage.AppendFormat("\r\nVendor Last Name = {0}", vendRetNode.InnerText ); 
            //                }
            //            }
            //        } // End of VendorRet
            //        MessageBox.Show (popupMessage.ToString(), "Vendor Add Results!");
            //    } //End of VendorAddRs
            //}
            //catch(Exception ex){
            //    MessageBox.Show(ex.StackTrace);
            //}
		}


        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
            
               	// Step-2b: Connected before -
					// First search the network to see if there is a newer (than last used) version availabl		
					//LabelConnString.Text="Checking for newer versions of QuickBooks POS. Please wait...";
					this.Refresh();			
					// Step-3b: No need to ask user to choose any server and version
					// Just use the current (last used) connection string
					LabelConnString.Text=connString;
					processRequest();
			
			}
			catch(Exception ex)
            {
				MessageBox.Show(ex.Message.ToString(),"JumpQ Konnect Alert!");
			}
        }

        private void btnReq_Click(object sender, EventArgs e)
        {
            if (requestXML.ToString().Trim().Equals(""))
            {
                MessageBox.Show("Request is empty. Please add a vendor first", "JumpQ Konnect Alert!");
            }
            else
            {
                DisplayXML myDisplay = new DisplayXML();
                myDisplay.setDisplay(requestXML.ToString());
                myDisplay.Show();
            }
        }

        private void btnRes_Click(object sender, EventArgs e)
        {
            if (responseXML.ToString().Trim().Equals(""))
            {
                MessageBox.Show("Response is empty. Please add a vendor first", "JumpQ Konnect Alert!");
            }
            else
            {
                DisplayXML myDisplay = new DisplayXML();
                myDisplay.setDisplay(responseXML.ToString());
                myDisplay.Show();
            }
        }
    
        private void btnCancel_Click(object sender, EventArgs e)
        {      
            Dispose();
        }
    


        // IY: CODE FOR HANDLING DIFFERENT VERSIONS
        #endregion
       

        #region
    
        void addSalesreciept()
        {
            try
            {
                // Step-2: When the button is clicked, sample will check the
                // connection string to try to determine if this is the first time
                // it is connecting to QBPOS, or not.
             
                    // Step-2b: Connected before -
                    // First search the network to see if there is a newer (than last used) version available
                   
                    this.Refresh();
                    
           
                        // Step-3b: No need to ask user to choose any server and version
                        // Just use the current (last used) connection string
                        LabelConnString.Text = connString;

                        processSalesRequest();
                  
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "JumpQ Konnect Alert!");
            }
        }


        void processSalesRequest()
        {
            try
            {
                //// step1: verify that a valid vendor code is entered
                //String vcode = txtVCode.Text.Trim();
                //if (vcode.Length <= 0 )
                //{
                //    MessageBox.Show("Please enter a valid value for Vendor code (maximum 3 characters)", "Input Validation");
                //    return;
                //}
                //String fname = txtFN.Text.Trim();

                //String lname = txtLN.Text.Trim();

                //step2: create the qbXML request
                XmlDocument inputXMLDoc = new XmlDocument();
                inputXMLDoc.AppendChild(inputXMLDoc.CreateXmlDeclaration("1.0", null, null));
                inputXMLDoc.AppendChild(inputXMLDoc.CreateProcessingInstruction("qbposxml", "version=\"4.0\""));
                XmlElement qbXML = inputXMLDoc.CreateElement("QBPOSXML");
                inputXMLDoc.AppendChild(qbXML);
                XmlElement qbXMLMsgsRq = inputXMLDoc.CreateElement("QBPOSXMLMsgsRq");
                qbXML.AppendChild(qbXMLMsgsRq);
                qbXMLMsgsRq.SetAttribute("onError", "stopOnError");

                //Create SalesReciepItem aggregate and fill in field values for it
                XmlElement SalesReceiptAddRq = inputXMLDoc.CreateElement("SalesReceiptAddRq");
                qbXMLMsgsRq.AppendChild(SalesReceiptAddRq);
                SalesReceiptAddRq.SetAttribute("requestID", "1");
                XmlElement SalesReceiptAdd = inputXMLDoc.CreateElement("SalesReceiptItemAddList");
                SalesReceiptAddRq.AppendChild(SalesReceiptAdd);
               // SalesReceiptAdd.AppendChild(inputXMLDoc.CreateElement("CustomerListId")).InnerText = "100";
             //   itemServiceModRq.ListID.SetValue(Item.QuickBooksID)
                SalesReceiptAdd.AppendChild(inputXMLDoc.CreateElement("Comments")).InnerText = "OHK";
                SalesReceiptAdd.AppendChild(inputXMLDoc.CreateElement("Cashier")).InnerText = "Victor";
                SalesReceiptAdd.AppendChild(inputXMLDoc.CreateElement("SalesReceiptType")).InnerText = "Sales"; 
                SalesReceiptAdd.AppendChild(inputXMLDoc.CreateElement("ListID")).InnerText = "1";
               // SalesReceiptAdd.AppendChild(inputXMLDoc.CreateElement("Qty")).InnerText = "1";
               // SalesReceiptAdd.AppendChild(inputXMLDoc.CreateElement("Price")).InnerText = "1000";

                XmlElement salesItem= inputXMLDoc.CreateElement("SalesReceiptItem");
                SalesReceiptAdd.AppendChild(salesItem);
                salesItem.AppendChild(inputXMLDoc.CreateElement("ListID")).InnerText = "1";
                //Set field value for TenderAmount <!-- required -->
                salesItem.AppendChild(inputXMLDoc.CreateElement("Qty")).InnerText = "1";
                salesItem.AppendChild(inputXMLDoc.CreateElement("Price")).InnerText = "1000";

                //Done salesItem TenderDepositAdd aggregate





                //Create TenderDepositAdd aggregate and fill in field values for it
                // May create more than one of these aggregates if needed
                XmlElement TenderDepositAdd = inputXMLDoc.CreateElement("TenderAccountAdd");
                SalesReceiptAdd.AppendChild(TenderDepositAdd);
                //Set field value for TenderAmount <!-- required -->
                TenderDepositAdd.AppendChild(inputXMLDoc.CreateElement("TenderAmount")).InnerText = "1000";
                //Done creating TenderDepositAdd aggregate
                string input = inputXMLDoc.OuterXml;

                //step3: do the qbXMLRP request
               
                string response = null;
                try
                {
                    ////rp.OpenConnection("CSVendorAddSample", "IDN VendorAdd C# sample");
                    //rp.OpenConnection("JMPQConnector", "JumpQ_TestApp");
                    //MessageBox.Show(connString);
                    //ticket = rp.BeginSession(connString);

                    //response = rp.ProcessRequest(ticket, input);
                    requestXML = input.ToString();
                    responseXML = response.ToString();

                }
                catch (System.Runtime.InteropServices.COMException ex)
                {
                    MessageBox.Show("COM Error Description = " + ex.Message, "COM error");
                    return;
                }
                finally
                {
                    //if (ticket != null)
                    //{
                    //    rp.EndSession(ticket);
                    //}
                    //if (rp != null)
                    //{
                    //    rp.CloseConnection();
                    //}
                };

                //step4: parse the XML response and show a message
                XmlDocument outputXMLDoc = new XmlDocument();
                outputXMLDoc.LoadXml(response);
                XmlNodeList qbXMLMsgsRsNodeList = outputXMLDoc.GetElementsByTagName("SalesReceiptAddRs");
                MessageBox.Show(qbXMLMsgsRsNodeList.Count.ToString());
                if (qbXMLMsgsRsNodeList.Count == 1)
                {
                    MessageBox.Show("Test");
                    //it's always true, since we added a single Vendor
                    System.Text.StringBuilder popupMessage = new System.Text.StringBuilder();
                    XmlAttributeCollection rsAttributes = qbXMLMsgsRsNodeList.Item(0).Attributes;
                    //get the status Code, info and Severity
                    string retStatusCode = rsAttributes.GetNamedItem("statusCode").Value;
                    string retStatusSeverity = rsAttributes.GetNamedItem("statusSeverity").Value;
                    string retStatusMessage = rsAttributes.GetNamedItem("statusMessage").Value;
                    popupMessage.AppendFormat("statusCode = {0}, statusSeverity = {1}, statusMessage = {2}",
                        retStatusCode, retStatusSeverity, retStatusMessage);






                    //get the VendorRet node for detailed info
                    //a VendorAddRs contains max one childNode for "VendorRet"
                    XmlNodeList SalesReceiptAddRsList = qbXMLMsgsRsNodeList.Item(0).ChildNodes;
                    if (SalesReceiptAddRsList.Count == 1 && SalesReceiptAddRsList.Item(0).Name.Equals("SalesReceiptRet"))
                    {
                        XmlNodeList SalesReceiptRetList = SalesReceiptAddRsList.Item(0).ChildNodes;

                        foreach (XmlNode SalesReceiptRetNode in SalesReceiptRetList)
                        {
                            if (SalesReceiptRetNode.Name.Equals("ListID"))
                            {
                                popupMessage.AppendFormat("\r\nCustomerListId = {0}", SalesReceiptRetNode.InnerText);
                            }
                            else if (SalesReceiptRetNode.Name.Equals("Comments"))
                            {
                                popupMessage.AppendFormat("\r\nComments = {0}", SalesReceiptRetNode.InnerText);
                            }
                            else if (SalesReceiptRetNode.Name.Equals("Cashier"))
                            {
                                popupMessage.AppendFormat("\r\nCashier = {0}", SalesReceiptRetNode.InnerText);
                            }
                            else if (SalesReceiptRetNode.Name.Equals("SalesreceiptType"))
                            {
                                popupMessage.AppendFormat("\r\nSalesreceiptType = {0}", SalesReceiptRetNode.InnerText);
                            }
                            else if (SalesReceiptRetNode.Name.Equals("SalesreceiptItem"))
                            {

                                popupMessage.AppendFormat("\r\nSalesreceiptType = {0}", SalesReceiptRetNode.InnerText);
                            }
                            else if (SalesReceiptRetNode.Name.Equals("SalesreceiptItemQty"))
                            {
                                popupMessage.AppendFormat("\r\nSalesreceiptItemQty = {0}", SalesReceiptRetNode.InnerText);
                            }
                            else if (SalesReceiptRetNode.Name.Equals("SalesreceiptItemPrice"))
                            {
                                popupMessage.AppendFormat("\r\nSalesreceiptItemPrice = {0}", SalesReceiptRetNode.InnerText);
                            }
                            else if (SalesReceiptRetNode.Name.Equals("TenderCash01TenderAmount"))
                            {
                                popupMessage.AppendFormat("\r\nTenderCash01TenderAmount = {0}", SalesReceiptRetNode.InnerText);
                            }
                        }
                        MessageBox.Show(popupMessage.ToString(), "Sales Reciept Add Results!");

                    }
                    else
                    {
                        MessageBox.Show(" not working");
                    }// End of VendorRet
                  //  MessageBox.Show(popupMessage.ToString(), "Sales Reciept Add Results!");
                }
                else
                {
                    MessageBox.Show("doesnt work");
                }//End of VendorAddRs
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }

        private void dbRFIDInsertQuery()
        {
            //return;
            if (jstRfid.Count > 0)
            {
                foreach (var item in jstRfid)
                {
                    String insertQuery = "INSERT INTO RfidTable(TransactDate,RfidCode) VALUES('" + DateTime.Now + "', '" + item + "' )";

                    SQLiteCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = insertQuery;
                    cmd.ExecuteNonQuery();
                }
            }


        }
        private void customizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Custom_Settings cusSet = new Custom_Settings();
            cusSet.ShowDialog();
            getSettings();
            checkSettings();
            this.Refresh();

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void AddSales_Click(object sender, EventArgs e)
        {
           // addSalesreciept();
           
        }
        #endregion

   
        void BarcodeLogic()
        {
            jstRfid.Clear();
            NoRfid.Clear();
            BlockContent.Clear();
            ContainRfid.Clear();
            string s = txtQRCode.Text;
            #region
            //ICollection<string> matches =
            //    Regex.Matches(s.Replace(Environment.NewLine, ""), @"\[([^]]*)\]").Cast<Match>().Select(x => x.Groups[1].Value).ToList();

            //foreach (string match in matches)
            //  MessageBox.Show(match);

            // The following code snippet retrieves a substring that is before the first occurrence of a comma.
            // Get a substring after or before a character  
            //string stringBeforeChar = s.Substring(0, s.IndexOf("["));

            //MessageBox.Show(stringBeforeChar);
            #endregion
            List<string> rfid = new List<string>();

            string[] splitString = s.Split(']');
            //string result = splitString[0].Trim();
            // MessageBox.Show(splitString.Length.ToString());
             //return;
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
                    //MessageBox.Show(rfid.Count.ToString());
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
                //MessageBox.Show(BlockContent.Count.ToString());
                //MessageBox.Show(ContainRfid.Count.ToString());
                //MessageBox.Show(NoRfid.Count.ToString());
                totalAmount = 0;

                foreach (string blockCont in BlockContent)
                {
                    string[] splitblockCont = blockCont.Split('*');
                    string result = splitblockCont[0].Trim();
                    Double result1 = Convert.ToDouble(splitblockCont[1].Trim());
                    Double result2 = Convert.ToDouble(splitblockCont[2].Trim());
                    //   MessageBox.Show(result);
                    totalAmount += result1 * result2;

                }
                StringBuilder popMssg = new StringBuilder();
                popMssg.AppendFormat("\r\nTotal Number of Items: {0}", BlockContent.Count);
                popMssg.AppendFormat("\r\nNumber of rfid Items: {0}", ContainRfid.Count);
                popMssg.AppendFormat("\r\nTotal Amount: {0}", totalAmount);

                MessageBox.Show(popMssg.ToString(), "JumpQ Konnect Reciept!");
                // MessageBox.Show(totalAmount.ToString());
                DoSalesReceiptAdd();
            }
            else
            {
                MessageBox.Show("Barcode Error", "JumpQ Konnect Alert!");
            }

        }


        public void DoSalesReceiptAdd()
        {
            bool sessionBegun = false;
            bool connectionOpen = false;
            QBPOSSessionManager sessionManager = null;
            string ALUCode = "";
            int qtyCode = 1;
            double priceCode = 1000;
            double totAmtCode = 1075;
            try
            {

                //Create the session Manager object
                sessionManager = new QBPOSSessionManager();

                //Create the message set request object to hold our request
                IMsgSetRequest requestMsgSet = sessionManager.CreateMsgSetRequest(4, 0);
                requestMsgSet.Attributes.OnError = ENRqOnError.roeContinue;

                //Connect to QuickBooks and begin a session
                sessionManager.OpenConnection("JumpQKonnect", "JumpQ Konnect");
                connectionOpen = true;

                sessionManager.BeginSession(connString);
                sessionBegun = true;

                string custID = "6015310566967378177";
                string itemListID = "6015319814099075329";
                string cashier = "Okeke Victor";
                string ItemSize = "";
                // List Item id 6015319814099075329
                //Send the request and get the response from QuickBooks
                // IMsgSetResponse responseMsgSet;
                // popupMessage.Clear();
                if (BlockContent.Count >= 1)
                {

                    foreach (string blockCont in BlockContent)
                    {
                        string[] splitblockCont = blockCont.Split('*');
                        ALUCode = splitblockCont[0].Trim();
                        qtyCode = Convert.ToInt32(splitblockCont[1].Trim());
                        //priceCode = Convert.ToDouble(splitblockCont[2].Trim());
                        // MessageBox.Show(result);
                        //  totAmtCode = qtyCode * priceCode;
                        BuildSalesReceiptAddRq(requestMsgSet, custID, itemListID, cashier, ALUCode, priceCode, qtyCode, ItemSize, totAmtCode);
                        IMsgSetResponse responseMsgSet = sessionManager.DoRequests(requestMsgSet);

                        WalkSalesReceiptAddRs(responseMsgSet);
                    }
                    // return;
                    if (StatusSuccess == true)
                    {
                        MessageBox.Show("Sales Item is Successfully Retrieved", "JumpQ Konnector Alert!");
                        StatusSuccess = false;
                        dbRFIDInsertQuery();
                    }
                    else
                    {

                    }
                }


                //End the session and close the connection to QuickBooks
                sessionManager.EndSession();
                sessionBegun = false;
                sessionManager.CloseConnection();
                connectionOpen = false;


            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error");
                if (sessionBegun)
                {
                    sessionManager.EndSession();
                }
                if (connectionOpen)
                {
                    sessionManager.CloseConnection();
                }
            }
        }
        // custID 6015310566967378177
       // List Item id 6015319814099075329
        void BuildSalesReceiptAddRq(IMsgSetRequest requestMsgSet, string CustListID, String ItemListId ,string Cashier, string ALuBarcode, double price, int quantity, string size, double tenderAmount)
        {
                ISalesReceiptAdd SalesReceiptAddRq= requestMsgSet.AppendSalesReceiptAddRq();
           
                SalesReceiptAddRq.Cashier.SetValue(Cashier);
                //Set field value for Comments
                //SalesReceiptAddRq.Comments.SetValue("ab");
               // Set field value for CustomerListID
                SalesReceiptAddRq.CustomerListID.SetValue(CustListID);
                //Set attributes
       
                //Set field value for QuickBooksFlag
                SalesReceiptAddRq.QuickBooksFlag.SetValue(ENQuickBooksFlag.qbfNotPosted);
               
                //Set field value for SalesReceiptType
                SalesReceiptAddRq.SalesReceiptType.SetValue(ENSalesReceiptType.srtSales);
                //Set field value for ShipDate
                         
                //Set field value for TxnDate
                SalesReceiptAddRq.TxnDate.SetValue(DateTime.Now);
                //Set field value for TxnState
                SalesReceiptAddRq.TxnState.SetValue(ENTxnState.tsNormal);
               
                ISalesReceiptItemAdd SalesReceiptItemAdd3748=SalesReceiptAddRq.SalesReceiptItemAddList.Append();
                //Set field value for TxnID
                //SalesReceiptItemAdd3748.TxnID.SetValue("200000-1011023419");
                //Set field value for ListID
                SalesReceiptItemAdd3748.ListID.SetValue(ItemListId);
                //Set attributes

                SalesReceiptItemAdd3748.ALU.SetValue(ALuBarcode);
                //Set field value for Associate
                SalesReceiptItemAdd3748.Associate.SetValue("ab");
                //Set field value for Attribute
                SalesReceiptItemAdd3748.Attribute.SetValue("ab");
                //Set field value for Commission
            
                //Set field value for Desc1
                SalesReceiptItemAdd3748.Desc1.SetValue("ab");


                SalesReceiptItemAdd3748.Price.SetValue(price);
                //Set field value for Qty
                SalesReceiptItemAdd3748.Qty.SetValue(quantity);
                //Set field value for SerialNumber
                SalesReceiptItemAdd3748.SerialNumber.SetValue("ab");
                //Set field value for Size
                SalesReceiptItemAdd3748.Size.SetValue(size);
                //Set field value for TaxCode
               
               
                ITenderAccountAdd TenderAccountAdd3749=SalesReceiptAddRq.TenderAccountAddList.Append();
                //Set field value for TenderAmount
                TenderAccountAdd3749.TenderAmount.SetValue(tenderAmount);
                
        }


        bool StatusSuccess = false;

        void WalkSalesReceiptAddRs(IMsgSetResponse responseMsgSet)
        {
            if (responseMsgSet == null) return;
           
            System.Text.StringBuilder popupMessage = new System.Text.StringBuilder();
                IResponseList responseList = responseMsgSet.ResponseList;

                if (responseList == null) return;
                    //if we sent only one request, there is only one response, we'll walk the list for this sample

                for(int i=0; i < responseList.Count; i++)
                {
                        IResponse response = responseList.GetAt(i);
                        //check the status code of the response, 0=ok, >0 is warning
                       IResponse rsAttributes = responseList.GetAt(0);//.Item(0).Attributes;
                        //get the status Code, info and Severity
                       string retStatusCode = rsAttributes.StatusCode.ToString();//.GetNamedItem("statusCode").Value;
                       string retStatusSeverity = rsAttributes.StatusSeverity.ToString();//.GetNamedItem("statusSeverity").Value;
                       string retStatusMessage = rsAttributes.StatusMessage.ToString();// GetNamedItem("statusMessage").Value;
                        popupMessage.AppendFormat("statusCode = {0}, statusSeverity = {1}, statusMessage = {2}",
                            retStatusCode, retStatusSeverity, retStatusMessage);
                       
                       // MessageBox.Show(response.StatusCode.ToString());
                        if (response.StatusCode >= 0)
                        {
                            //if(response.StatusCode ==0)
                            //{
                            //    StatusSuccess = true;
                            //    //MessageBox.Show("0");
                            //}
                            //else
                            //{
                            //  //  MessageBox.Show(popupMessage.ToString(), "JumpQ Konnect Error!");
                            //    //return;
                            //}
                          
                            //the request-specific response is in the details, make sure we have some
                            if (response.Detail != null)
                            {
                                    //make sure the response is the type we're expecting
                                    ENResponseType responseType = (ENResponseType)response.Type.GetValue();
                                    if (responseType == ENResponseType.rtSalesReceiptAddRs)
                                    {
                                        //  MessageBox.Show("responseType");
                                            //upcast to more specific type here, this is safe because we checked with response.Type check above
                                            ISalesReceiptRet SalesReceiptRet = (ISalesReceiptRet)response.Detail;
                                                    WalkSalesReceiptRet(SalesReceiptRet);
                                    }
                            }
                        }
                }
        }




        void WalkSalesReceiptRet(ISalesReceiptRet SalesReceiptRet)
        {
                if (SalesReceiptRet == null) return;
                //Go through all the elements of ISalesReceiptRet
                //Get value of TxnID
                //if (SalesReceiptRet.TxnID != null)
                //{
                //        string TxnID3757 = (string)SalesReceiptRet.TxnID.GetValue();
                //}
                //Get value of TimeCreated
                if (SalesReceiptRet.TimeCreated != null)
                {
                        DateTime TimeCreated3758 = (DateTime)SalesReceiptRet.TimeCreated.GetValue();
                }
                //Get value of TimeModified
                if (SalesReceiptRet.TimeModified != null)
                {
                        DateTime TimeModified3759 = (DateTime)SalesReceiptRet.TimeModified.GetValue();
                }
                //Get value of Associate
                if (SalesReceiptRet.Associate != null)
                {
                        string Associate3760 = (string)SalesReceiptRet.Associate.GetValue();
                }
                //Get value of Cashier
                if (SalesReceiptRet.Cashier != null)
                {
                        string Cashier3761 = (string)SalesReceiptRet.Cashier.GetValue();
                }
                //Get value of Comments
                if (SalesReceiptRet.Comments != null)
                {
                        string Comments3762 = (string)SalesReceiptRet.Comments.GetValue();
                }
                //Get value of CustomerListID
                if (SalesReceiptRet.CustomerListID != null)
                {
                    string CustomerListID3763 = (string)SalesReceiptRet.CustomerListID.GetValue();
                   // MessageBox.Show(CustomerListID3763);
                }
  
                //Get value of HistoryDocStatus
                if (SalesReceiptRet.HistoryDocStatus != null)
                {
                        ENHistoryDocStatus HistoryDocStatus3766 = (ENHistoryDocStatus)SalesReceiptRet.HistoryDocStatus.GetValue();
                }
                //Get value of ItemsCount
                if (SalesReceiptRet.ItemsCount != null)
                {
                        int ItemsCount3767 = (int)SalesReceiptRet.ItemsCount.GetValue();
                }
                //Get value of PriceLevelNumber
              
                //Get value of SalesReceiptNumber
                if (SalesReceiptRet.SalesReceiptNumber != null)
                {
                        int SalesReceiptNumber3772 = (int)SalesReceiptRet.SalesReceiptNumber.GetValue();
                }
                //Get value of SalesReceiptType
                if (SalesReceiptRet.SalesReceiptType != null)
                {
                        ENSalesReceiptType SalesReceiptType3773 = (ENSalesReceiptType)SalesReceiptRet.SalesReceiptType.GetValue();
                }
               
               
                //if (SalesReceiptRet.Subtotal != null)
                //{
                //        double Subtotal3777 = (double)SalesReceiptRet.Subtotal.GetValue();
                //}
             
                if (SalesReceiptRet.TenderType != null)
                {
                        ENTenderType TenderType3781 = (ENTenderType)SalesReceiptRet.TenderType.GetValue();
                }
                //Get value of TipReceiver
            
                //Get value of Total
                if (SalesReceiptRet.Total != null)
                {
                        double Total3783 = (double)SalesReceiptRet.Total.GetValue();
                }
                //Get value of TrackingNumber
               
                //Get value of TxnDate
                if (SalesReceiptRet.TxnDate != null)
                {
                        DateTime TxnDate3785 = (DateTime)SalesReceiptRet.TxnDate.GetValue();
                }
             


                if (SalesReceiptRet.SalesReceiptItemRetList != null)
                {
                        for (int i3818 = 0; i3818 < SalesReceiptRet.SalesReceiptItemRetList.Count; i3818++)
                        {
                                ISalesReceiptItemRet SalesReceiptItemRet = SalesReceiptRet.SalesReceiptItemRetList.GetAt(i3818);
                                //Get value of ListID
                                if (SalesReceiptItemRet.ListID != null)
                                {
                                    string ListID3819 = (string)SalesReceiptItemRet.ListID.GetValue();
                                }
                                //Get value of ALU
                                if (SalesReceiptItemRet.ALU != null)
                                {
                                        string ALU3820 = (string)SalesReceiptItemRet.ALU.GetValue();
                                }
                                //Get value of Associate
                                if (SalesReceiptItemRet.Associate != null)
                                {
                                        string Associate3821 = (string)SalesReceiptItemRet.Associate.GetValue();
                                }
                                //Get value of Attribute
                                if (SalesReceiptItemRet.Attribute != null)
                                {
                                        string Attribute3822 = (string)SalesReceiptItemRet.Attribute.GetValue();
                                }
                      
                                //Get value of Cost
                                if (SalesReceiptItemRet.Cost != null)
                                {
                                        double Cost3824 = (double)SalesReceiptItemRet.Cost.GetValue();
                                }
                                //Get value of Desc1
                                if (SalesReceiptItemRet.Desc1 != null)
                                {
                                        string Desc13825 = (string)SalesReceiptItemRet.Desc1.GetValue();
                                }
                                //Get value of Desc2
                            
                 
                                //Get value of ItemNumber
                                if (SalesReceiptItemRet.ItemNumber != null)
                                {
                                        int ItemNumber3833 = (int)SalesReceiptItemRet.ItemNumber.GetValue();
                                }
                                //Get value of NumberOfBaseUnits
                             
                                //Get value of Price
                                if (SalesReceiptItemRet.Price != null)
                                {
                                        double Price3835 = (double)SalesReceiptItemRet.Price.GetValue();
                                }
                               
                                //Get value of Qty
                                if (SalesReceiptItemRet.Qty != null)
                                {
                                        int Qty3837 = (int)SalesReceiptItemRet.Qty.GetValue();
                                }
                                //Get value of SerialNumber
                                if (SalesReceiptItemRet.SerialNumber != null)
                                {
                                        string SerialNumber3838 = (string)SalesReceiptItemRet.SerialNumber.GetValue();
                                }
                                //Get value of Size
                                if (SalesReceiptItemRet.Size != null)
                                {
                                        string Size3839 = (string)SalesReceiptItemRet.Size.GetValue();
                                }
                                //Get value of TaxAmount
                              
                 
                        }
                }
                if (SalesReceiptRet.TenderAccountRetList != null)
                {
                        for (int i3849 = 0; i3849 < SalesReceiptRet.TenderAccountRetList.Count; i3849++)
                        {
                                ITenderAccountRet TenderAccountRet = SalesReceiptRet.TenderAccountRetList.GetAt(i3849);
                                //Get value of TenderAmount
                                if (TenderAccountRet.TenderAmount != null)
                                {
                                        double TenderAmount3850 = (double)TenderAccountRet.TenderAmount.GetValue();
                                }
                            
                        }
                }
          
       
         
            
             
                //Get value of TransactionStoreName
                //if (SalesReceiptRet.TransactionStoreName != null)
                //{
                //        string TransactionStoreName3879 = (string)SalesReceiptRet.TransactionStoreName.GetValue();
                //}
                ////Get value of TransactionStoreType
                //if (SalesReceiptRet.TransactionStoreType != null)
                //{
                //        string TransactionStoreType3880 = (string)SalesReceiptRet.TransactionStoreType.GetValue();
                //}
        }


      
       





        

    }
}
