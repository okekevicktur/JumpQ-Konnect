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
using Microsoft.Win32;
namespace JumpQ_TestApp
{
    public partial class AddSalesItem : Form
    {
        private OdbcConnection _cn;
        public AddSalesItem()
        {
            InitializeComponent();
        }

        private void AddSalesItem_Load(object sender, EventArgs e)
        {
            try
            {
                ListOutDSN();
               
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
                    cboListOfDSN.SelectedIndex = 0;
                }
            }
           



        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {

                Application.DoEvents();
                if (btnConnect.Text == "Disconnect")
                {
                    if (_cn != null)
                    {
                        lblConnectionStatus.Text = "Disconnecting....";
                        _cn.Close();
                        _cn.Dispose();
                        _cn = null;
                        btnConnect.Text = "Connect";
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
                        btnConnect.Text = "Disconnect";
                        lblConnectionStatus.Text = "Connected";
                        lblConnectionStatus.ForeColor = Color.Green;
                    }

                }
                Application.DoEvents();
            }
            catch (Exception ex)
            {
                Application.DoEvents();
                btnConnect.Text = "Errorred";
                MessageBox.Show(string.Format("Error - {0}, Stack Trace {1}", ex.Message, ex.StackTrace));
            }

        }

        private void InsertSalesReceiptLineItem(string customerName, string comments, string cashierName, string salesReceiptType, string itemName, int quanity, int rate, int tenderAmount)
        {
            string query =
                   string.Format("Insert Into SalesReceiptItem (CustomerListId, Comments, Cashier, SalesReceiptType, SalesReceiptItemListId,  SalesReceiptItemQty, SalesReceiptItemPrice, TenderCash01TenderAmount) Values ('{0}','{1}','{2}','{3}','{4}',{5},{6},{7})", customerName, comments, cashierName, salesReceiptType, itemName, quanity, rate, tenderAmount);
          
            
            // <---Withou CustomerListId,
            //string query = string.Format("Insert Into SalesReceiptItem ( Comments, Cashier, SalesReceiptType, SalesReceiptItemListId,  SalesReceiptItemQty, SalesReceiptItemPrice, TenderCash01TenderAmount) Values ('{0}','{1}','{2}','{3}','{4}',{5},{6})", comments, cashierName, salesReceiptType, itemName, quanity, rate, tenderAmount);
          
            using (OdbcCommand QBEmployeecmd = new OdbcCommand(query, _cn))
            {
                //MessageBox.Show("" + QBEmployeecmd.Connection.State.ToString());
                QBEmployeecmd.CommandType = CommandType.Text;
                //MessageBox.Show("" + QBEmployeecmd.CommandType.ToString());
                QBEmployeecmd.ExecuteNonQuery();
                //MessageBox.Show("Execute Success");

            }
        }

        private void btnSalesReceiptItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (_cn == null || _cn.State == ConnectionState.Closed)
                {
                    btnConnect_Click(null, null);
                }
                //if (string.IsNullOrEmpty(txtcustomerName.Text))
                //{
                //    MessageBox.Show("Customer Name is Required.");
                //    return;
                //}
                if (string.IsNullOrEmpty(txtComments.Text))
                {
                    MessageBox.Show("Comments is required.");
                    return;
                }
                if (string.IsNullOrEmpty(txtCashierName.Text))
                {
                    MessageBox.Show("Cashier Name is required.");
                    return;
                }
                if (string.IsNullOrEmpty(txtSalesReceiptType.Text))
                {
                    MessageBox.Show("Sales Receipt Type is required.");
                    return;
                }
                if (string.IsNullOrEmpty(txtItemName.Text))
                {
                    MessageBox.Show("Item Name is required.");
                    return;
                }
                if (string.IsNullOrEmpty(txtQuantity.Text))
                {
                    MessageBox.Show("Quantity is required.");
                    return;
                }
                if (string.IsNullOrEmpty(txtItemPrice.Text))
                {
                    MessageBox.Show("Item Price is required.");
                    return;
                }
                if (string.IsNullOrEmpty(txtTenderAmount.Text))
                {
                    MessageBox.Show("Tender Amount is required.");
                    return;
                }
                // <----- I tried avoiding the customer Id 
                //InsertSalesReceiptLineItem(txtComments.Text, txtCashierName.Text, txtSalesReceiptType.Text, txtItemName.Text, int.Parse(txtQuantity.Text), int.Parse(txtItemPrice.Text), int.Parse(txtTenderAmount.Text));

                InsertSalesReceiptLineItem(txtcustomerName.Text, txtComments.Text, txtCashierName.Text, txtSalesReceiptType.Text, txtItemName.Text, int.Parse(txtQuantity.Text), int.Parse(txtItemPrice.Text), int.Parse(txtTenderAmount.Text));
                string lastInsertedId = GetLastInsertedId("sp_lastInsertID SalesReceiptItem");
               // DisplaySalesReceiptInGrid(lastInsertedId);
                //string lastInsertedId = GetLastInsertedId("sp_lastInsertID SalesReceiptItem");
                //DisplaySalesReceiptInGrid(lastInsertedId);
            }
            catch (Exception ex)
            {

                MessageBox.Show(string.Format("Error - {0}, Stack Trace {1}", ex.Message, ex.StackTrace));
            }
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
            if (_cn != null && _cn.State != ConnectionState.Closed)
            {
                _cn.Close();
            }
        }
    }
}
