using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace JumpQ_TestApp
{
    public partial class Custom_Settings : Form
    {
        public Custom_Settings()
        {
            InitializeComponent();
        }

        private void Custom_Settings_Load(object sender, EventArgs e)
        {
          txtServerName.Text=  System.Environment.MachineName;
          cmbVersion.SelectedIndex = 2;
        }
        public void saveSettings()
        {
            Properties.Settings.Default.QbComputerName = txtServerName.Text;
            Properties.Settings.Default.QbCompanyData =txtCompData.Text;
            Properties.Settings.Default.QbVersion = cmbVersion.Text;
            Properties.Settings.Default.Save();
        }

        private void btnApply_Click(object sender, System.EventArgs e)
        {
            if(labcomp.Text != string.Empty)
            {
                saveSettings();
                this.Close();
            }
            else
            {
                MessageBox.Show("Company Data is Empty","Alert!");
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
