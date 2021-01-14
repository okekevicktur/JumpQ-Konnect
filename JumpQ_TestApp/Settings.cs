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

namespace JumpQ_TestApp
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }
        private OdbcConnection _cn;
        string NameofCustomer;
        string IdofCustomer;
        private void BtnAddCustomer_Click(object sender, EventArgs e)
        {
            InsertCustomer(txtFName.Text, txtLName.Text);
        
        }
        void CreateConnect()
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
               // btnConnect.Text = "Errorred";
                MessageBox.Show(string.Format("Error - {0}, Stack Trace {1}", ex.Message, ex.StackTrace));
            }
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
        private void InsertCustomer(string firstname, string lastname)
        {
            if (_cn == null || _cn.State == ConnectionState.Closed)
            {
                AddSalesItem Ads = new AddSalesItem();
                btnConnect_Click(null, null);
            }
            
            string query =
                  string.Format("Insert Into Customer ( FirstName, LastName) Values ('{0}','{1}')", firstname, lastname);
            using (OdbcCommand QBEmployeecmd = new OdbcCommand(query, _cn))
            {
                //MessageBox.Show("" + QBEmployeecmd.Connection.State.ToString());
                QBEmployeecmd.CommandType = CommandType.Text;
                //MessageBox.Show("" + QBEmployeecmd.CommandType.ToString());
                QBEmployeecmd.ExecuteNonQuery();
                //MessageBox.Show("Execute Success");
                string lastInsertedId = GetLastInsertedId("sp_lastInsertID Customer");
                CustomerID.Text=lastInsertedId;
                SaveSettings();
                MessageBox.Show("Added Successfully", "JumpQ Konnect");
            }
           

        }
      

        private void SaveSettings()
        {


            Properties.Settings.Default.CustomerFullname = txtFName.Text + " " + txtLName.Text;
            Properties.Settings.Default.CustomerID = CustomerID.Text;
            Properties.Settings.Default.Save();
                      
       
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
        void getSettings()
        {
            NameofCustomer = Properties.Settings.Default.CustomerFullname;
            CustomerID.Text = Properties.Settings.Default.CustomerID;
         
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            getSettings(); ListOutDSN();
            if (_cn != null && _cn.State != ConnectionState.Closed)
            {
                _cn.Close();
            }
        
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            CreateConnect();
      
        }

     
    }
}
