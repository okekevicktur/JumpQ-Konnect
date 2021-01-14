using AForge.Video.DirectShow;
using AForge.Video;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;
using Interop.QBPOSXMLRPLIB;
using System.IO;
using System.Xml;
using System.Data.Odbc;
using QBPOSFC4Lib;


namespace JumpQ_TestApp
{
    public  partial class Form1 : Form
    {
       
        public string requestXML = "";

        public string serverName = "";
        public string companyName = "";
        public string versionName = "";
        public string connString = "";
        public FormSelectSV frmSV;
        public RequestProcessor rp = null;

        public StreamWriter SW;
        public string fileName = "cstr.txt";
        public string responseXML = "";
        public Form1()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            //
            // TODO: Add any constructor code after InitializeComponent call
            //

            rp = new RequestProcessor();
        }
      
        FilterInfoCollection filterInfoCollection;
        VideoCaptureDevice captureDevice;
        public string isTaxable = null;
        private void Form1_Load(object sender, EventArgs e)
        {
            filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo filterInfo in filterInfoCollection)
            {
                cameraTypes.Items.Add(filterInfo.Name);
                cameraTypes.SelectedIndex = 0;
            }
            // Step-1: When the form is loaded, reading from a text file 
            // or you could use registry) to get the last stored connection string
            connString = "";
            fileName = "cstr.txt";
            connString = FileRead();
            LabelConnString.Text = connString;
            if (!connString.Equals(""))
            {
                // Step-1a: Connection string has been found.
                // Parsing the connection string to get
                // machineName, companyName, and versionName
                parseConnString();
                //MessageBox.Show("serverName = " + serverName + "\r\n" + "companyName = " + companyName + "\r\n" + "versionName = " + versionName);
            }
        }
       
        
        //I created a txt file where  i added some details about the quickbook;
        //this is content of the text: Computer Name=DESKTOP-B2QR973;Company Data=Grace;Version=19
        //Where Computer name represents server/Workstation and Company Data represents the Company name on the quickBooks POS and Version being te version of the quickBooks PoS being used.
        //This method reads the text from the file Named cstr.txt
        public string FileRead()
        {
            string txt = "";
            if (File.Exists(fileName))
            {
                using (StreamReader sr = File.OpenText(fileName))
                {
                    string s = "";
                    while ((s = sr.ReadLine()) != null)
                    {
                        txt = txt + s;
                    }
                }
            }
            return txt;
        }
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
       
        //Conenction string builder
        public void parseConnString()
        {
            int pos1, pos2, pos3;
            //connString="Computer Name=mtvl04a200337;Company Data=my company;Version=4";
            pos1 = connString.IndexOf("Computer Name=");
            pos2 = connString.IndexOf("Company Data=");
            pos3 = connString.IndexOf("Version=");
            if (pos1 >= 0)
            {
                if (pos2 > 0)
                {
                    serverName = connString.Substring(pos1 + 14, pos2 - pos1 - 15).Trim();
                }
                else
                {
                    serverName = connString.Substring(pos1 + 14).Trim();
                }
            }
            if (pos2 >= 0)
            {
                if (pos3 > 0)
                {
                    companyName = connString.Substring(pos2 + 13, pos3 - pos2 - 14).Trim();
                }
                else
                {
                    serverName = connString.Substring(pos2 + 13).Trim();
                }
            }
            if (pos3 > 0)
            {
                versionName = connString.Substring(pos3 + 8).Trim();
            }
        }

        #region This part decrypts the barcode and not the logic of the decryted barcode
        private void startBtn_Click(object sender, EventArgs e)
        {
            captureDevice = new VideoCaptureDevice(filterInfoCollection[cameraTypes.SelectedIndex].MonikerString);
            captureDevice.NewFrame += captureDevice_NewFrame;
            captureDevice.Start();
            timer1.Start();
        }

        void captureDevice_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            pictureBox.Image = (Bitmap)eventArgs.Frame.Clone();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (captureDevice.IsRunning)
            //    captureDevice.Stop();
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
                    MessageBox.Show("Test");
		             txtQRCode.Text= result.ToString();
                    timer1.Stop();
                    if (captureDevice.IsRunning)
                        captureDevice.Stop();
	            }
            }
        }

        public void processRequest()
        {
			try{
				// step1: verify that a valid vendor code is entered
				String vcode=txtVCode.Text.Trim();
				if (vcode.Length<=0 || vcode.Length>3){
					MessageBox.Show("Please enter a valid value for Vendor code (maximum 3 characters)", "Input Validation");
					return;
				}
				String fname = txtFN.Text.Trim() ;
				
				String lname = txtLN.Text.Trim() ;
				
				//step2: create the qbXML request
				XmlDocument inputXMLDoc = new XmlDocument();
				inputXMLDoc.AppendChild(inputXMLDoc.CreateXmlDeclaration("1.0",null, null));
				inputXMLDoc.AppendChild(inputXMLDoc.CreateProcessingInstruction("qbposxml", "version=\"4.0\""));
				XmlElement qbXML = inputXMLDoc.CreateElement("QBPOSXML");
				inputXMLDoc.AppendChild(qbXML);
				XmlElement qbXMLMsgsRq = inputXMLDoc.CreateElement("QBPOSXMLMsgsRq");
				qbXML.AppendChild(qbXMLMsgsRq);
				qbXMLMsgsRq.SetAttribute("onError", "stopOnError");
				XmlElement vendAddRq = inputXMLDoc.CreateElement("VendorAddRq");
				qbXMLMsgsRq.AppendChild(vendAddRq);
				vendAddRq.SetAttribute("requestID", "1");
				XmlElement vendAdd = inputXMLDoc.CreateElement("VendorAdd");
				vendAddRq.AppendChild(vendAdd);	
				vendAdd.AppendChild(inputXMLDoc.CreateElement("FirstName")).InnerText=fname;
				vendAdd.AppendChild(inputXMLDoc.CreateElement("LastName")).InnerText=lname;
				if( txtEmail.Text.Length  > 0  ) {
					vendAdd.AppendChild(inputXMLDoc.CreateElement("Email")).InnerText=txtEmail.Text;
				}
				if( txtAddr1.Text.Length  > 0  ) {
					vendAdd.AppendChild(inputXMLDoc.CreateElement("Street")).InnerText=txtAddr1.Text;
				}
				if( txtCity.Text.Length  > 0  ) {
					vendAdd.AppendChild(inputXMLDoc.CreateElement("City")).InnerText=txtCity.Text;
				}
				if( txtState.Text.Length  > 0  ) {
					vendAdd.AppendChild(inputXMLDoc.CreateElement("State")).InnerText=txtState.Text;
				}
				if( txtZip.Text.Length  > 0  ) {
					vendAdd.AppendChild(inputXMLDoc.CreateElement("PostalCode")).InnerText=txtZip.Text;
				}
				if( txtCompany.Text.Length  > 0  ) {
					vendAdd.AppendChild(inputXMLDoc.CreateElement("CompanyName")).InnerText=txtCompany.Text;
				}
				if( txtNotes.Text.Length  > 0  ) {
					vendAdd.AppendChild(inputXMLDoc.CreateElement("Notes")).InnerText=txtNotes.Text;
				}
				vendAdd.AppendChild(inputXMLDoc.CreateElement("VendorCode")).InnerText=vcode.ToString();
				string input = inputXMLDoc.OuterXml;
				//step3: do the qbXMLRP request
				string ticket = null;
				string response = null;
				try {
		  			//rp.OpenConnection("CSVendorAddSample", "IDN VendorAdd C# sample");
                    rp.OpenConnection("JMPQConnector", "JumpQ_TestApp");
					MessageBox.Show(connString);
					ticket = rp.BeginSession(connString);
					
					response = rp.ProcessRequest(ticket, input);
					requestXML=input.ToString();
					responseXML=response.ToString();
					
				}
				catch( System.Runtime.InteropServices.COMException ex ) {
					MessageBox.Show( "COM Error Description = " +  ex.Message, "COM error" );
					return;
				}
				finally {
					if( ticket != null ) {
						rp.EndSession(ticket);
					}
					if( rp != null ) {
						rp.CloseConnection();
					}
				};

				//step4: parse the XML response and show a message
				XmlDocument outputXMLDoc = new XmlDocument();
				outputXMLDoc.LoadXml(response);
				XmlNodeList qbXMLMsgsRsNodeList = outputXMLDoc.GetElementsByTagName ("VendorAddRs");
				if( qbXMLMsgsRsNodeList.Count == 1 ) { //it's always true, since we added a single Vendor
					System.Text.StringBuilder popupMessage = new System.Text.StringBuilder();
					XmlAttributeCollection rsAttributes = qbXMLMsgsRsNodeList.Item(0).Attributes;
					//get the status Code, info and Severity
					string retStatusCode = rsAttributes.GetNamedItem("statusCode").Value; 
					string retStatusSeverity = rsAttributes.GetNamedItem("statusSeverity").Value;
					string retStatusMessage = rsAttributes.GetNamedItem("statusMessage").Value;
					popupMessage.AppendFormat( "statusCode = {0}, statusSeverity = {1}, statusMessage = {2}",
						retStatusCode, retStatusSeverity, retStatusMessage );

					//get the VendorRet node for detailed info
					//a VendorAddRs contains max one childNode for "VendorRet"
					XmlNodeList vendAddRsNodeList = qbXMLMsgsRsNodeList.Item(0).ChildNodes;
					if( vendAddRsNodeList.Count == 1 && vendAddRsNodeList.Item(0).Name.Equals("VendorRet") ) {
						XmlNodeList vendRetNodeList = vendAddRsNodeList.Item(0).ChildNodes ;
					
						foreach (XmlNode vendRetNode in vendRetNodeList ) {
							if ( vendRetNode.Name.Equals( "ListID" ) ) {
								popupMessage.AppendFormat("\r\nVendor ListID = {0}", vendRetNode.InnerText  );
							}
							else if ( vendRetNode.Name.Equals( "FirstName" ) ) {
								popupMessage.AppendFormat("\r\nVendor First Name = {0}", vendRetNode.InnerText );
							}
							else if  ( vendRetNode.Name.Equals( "LastName" ) ) {
								popupMessage.AppendFormat("\r\nVendor Last Name = {0}", vendRetNode.InnerText ); 
							}
						}
					} // End of VendorRet
					MessageBox.Show (popupMessage.ToString(), "Vendor Add Results!");
				} //End of VendorAddRs
			}
			catch(Exception ex){
				MessageBox.Show(ex.StackTrace);
			}
		}


        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
            // Step-2: When the button is clicked, sample will check the
				// connection string to try to determine if this is the first time
				// it is connecting to QBPOS, or not.
				if (connString.Equals("")){
					// Step-2a: First time connected -
					// Show FormSelectSV to give user an option to select the servers and corresponding versions
					// to build the connection string.
					LabelConnString.Text=connString;
					frmSV= new FormSelectSV(this);
					frmSV.set_fcon(true);
					frmSV.LabelGetConnString.Text="Please select a QuickBooks POS server and a version to connect.";
					frmSV.groupBoxVersion.Enabled=false;
					frmSV.cmdServer.Enabled=false;
					frmSV.Show();
					// Continued as Step-I in FormSelectSV
				}
				else
                {
					// Step-2b: Connected before -
					// First search the network to see if there is a newer (than last used) version available
					parseConnString();
					frmSV= new FormSelectSV(this);
					frmSV.set_fcon(false);
					frmSV.set_currentVersion(Convert.ToInt32(versionName));
					LabelConnString.Text="Checking for newer versions of QuickBooks POS. Please wait...";
					this.Refresh();
					if (frmSV.getNewServers())
                    {
						// Step-3a: If a newer version is found
						// Bring up a dialog to let user select the new server and version
						LabelConnString.Text="New version found";
						this.Refresh();
						frmSV.LabelGetConnString.Text="One or more new version(s) of QuickBooks POS have been detected. Please select a server and new version to connect. If you do not select one, last connected server and version will be used.";
						frmSV.groupBoxVersion.Enabled=true;
						frmSV.cmdServer.Enabled=true;
						frmSV.Show();
						// Continued as Step-II in FormSelectSV
					}
					else
                    {
						// Step-3b: No need to ask user to choose any server and version
						// Just use the current (last used) connection string
						LabelConnString.Text=connString;
						processRequest();
					}
				} // if
			}
			catch(Exception ex){
				MessageBox.Show(ex.Message.ToString());
			}
        }

        private void btnReq_Click(object sender, EventArgs e)
        {
            if (requestXML.ToString().Trim().Equals(""))
            {
                MessageBox.Show("Request is empty. Please add a vendor first");
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
                MessageBox.Show("Response is empty. Please add a vendor first");
            }
            else
            {
                DisplayXML myDisplay = new DisplayXML();
                myDisplay.setDisplay(responseXML.ToString());
                myDisplay.Show();
            }
        }
        public void FileWrite(string text)
        {
            SW = File.CreateText(fileName);
            SW.WriteLine(text);
            SW.Close();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            FileWrite(connString);
            Dispose();
        }
        public string get_ConnString()
        {
            return connString;
        }
        public void set_ConnString(string text)
        {
            connString = text;
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
                if (connString.Equals(""))
                {
                    // Step-2a: First time connected -
                    // Show FormSelectSV to give user an option to select the servers and corresponding versions
                    // to build the connection string.
                    LabelConnString.Text = connString;
                    frmSV = new FormSelectSV(this);
                    frmSV.set_fcon(true);
                    frmSV.LabelGetConnString.Text = "Please select a QuickBooks POS server and a version to connect.";
                    frmSV.groupBoxVersion.Enabled = false;
                    frmSV.cmdServer.Enabled = false;
                    frmSV.Show();
                    // Continued as Step-I in FormSelectSV
                }
                else
                {
                    // Step-2b: Connected before -
                    // First search the network to see if there is a newer (than last used) version available
                    parseConnString();
                    frmSV = new FormSelectSV(this);
                    frmSV.set_fcon(false);
                    frmSV.set_currentVersion(Convert.ToInt32(versionName));
                    LabelConnString.Text = "Checking for newer versions of QuickBooks POS. Please wait...";
                    this.Refresh();
                    if (frmSV.getNewServers())
                    {
                        // Step-3a: If a newer version is found
                        // Bring up a dialog to let user select the new server and version
                        LabelConnString.Text = "New version found";
                        this.Refresh();
                        frmSV.LabelGetConnString.Text = "One or more new version(s) of QuickBooks POS have been detected. Please select a server and new version to connect. If you do not select one, last connected server and version will be used.";
                        frmSV.groupBoxVersion.Enabled = true;
                        frmSV.cmdServer.Enabled = true;
                        frmSV.Show();
                        // Continued as Step-II in FormSelectSV
                    }
                    else
                    {
                        // Step-3b: No need to ask user to choose any server and version
                        // Just use the current (last used) connection string
                        LabelConnString.Text = connString;

                        processSalesRequest();
                    }
                } // if
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
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
                SalesReceiptAdd.AppendChild(inputXMLDoc.CreateElement("CustomerListId")).InnerText = "100";
                SalesReceiptAdd.AppendChild(inputXMLDoc.CreateElement("Comments")).InnerText = "OHK";
                SalesReceiptAdd.AppendChild(inputXMLDoc.CreateElement("Cashier")).InnerText = "Victor";
                SalesReceiptAdd.AppendChild(inputXMLDoc.CreateElement("SalesReceiptType")).InnerText = "Sales"; //ENSalesReceiptType.srtSales;
                SalesReceiptAdd.AppendChild(inputXMLDoc.CreateElement("SalesReceiptItemListId")).InnerText = "1";
                SalesReceiptAdd.AppendChild(inputXMLDoc.CreateElement("SalesReceiptItemQty")).InnerText = "1";
                SalesReceiptAdd.AppendChild(inputXMLDoc.CreateElement("SalesReceiptItemPrice")).InnerText = "1000";







                //Create TenderDepositAdd aggregate and fill in field values for it
                // May create more than one of these aggregates if needed
                XmlElement TenderDepositAdd = inputXMLDoc.CreateElement("TenderAccountAdd");
                SalesReceiptAdd.AppendChild(TenderDepositAdd);
                //Set field value for TenderAmount <!-- required -->
                TenderDepositAdd.AppendChild(inputXMLDoc.CreateElement("TenderCash01TenderAmount")).InnerText = "1000";
                //Done creating TenderDepositAdd aggregate
                string input = inputXMLDoc.OuterXml;

                //step3: do the qbXMLRP request
                string ticket = null;
                string response = null;
                try
                {
                    //rp.OpenConnection("CSVendorAddSample", "IDN VendorAdd C# sample");
                    rp.OpenConnection("JMPQConnector", "JumpQ_TestApp");
                    MessageBox.Show(connString);
                    ticket = rp.BeginSession(connString);

                    response = rp.ProcessRequest(ticket, input);
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
                    if (ticket != null)
                    {
                        rp.EndSession(ticket);
                    }
                    if (rp != null)
                    {
                        rp.CloseConnection();
                    }
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
                            if (SalesReceiptRetNode.Name.Equals("CustomerListId"))
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
                    }
                    else
                    {
                        MessageBox.Show(" not working");
                    }// End of VendorRet
                    MessageBox.Show(popupMessage.ToString(), "Sales Reciept Add Results!");
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
        private void AddSales_Click(object sender, EventArgs e)
        {
            addSalesreciept();
        }
        #endregion

    }
}
