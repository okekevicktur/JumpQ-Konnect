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
    public partial class DisplayXML : Form
    {
        public DisplayXML()
        {
            InitializeComponent();
        }

        public void setDisplay(string xmlString)
        {
            txtDisplay.Text = xmlString;
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
