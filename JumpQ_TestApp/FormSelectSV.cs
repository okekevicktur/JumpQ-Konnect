using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace JumpQ_TestApp
{
    public partial class FormSelectSV : Form
    {

        public string serverName = "";
        public string companyName = "";
        public string versionName = "";
        public string connString = "";
        public bool fcon;
        public int currentVersion;
        public Form1 vAdd;
        public FormSelectSV(Form1 vendorAdd)
        {
            vAdd = vendorAdd;
            InitializeComponent();
        }
        //bool
        public void getNewServers()
        {
            /*
                        'Method signature for POSServers():
                        'HRESULT POSServers([in] VARIANT_BOOL IsPractice, [out,retval] BSTR* ServersXML);
                        '
                        'Returns data about the available QBPOS instances, companies, and versions in the local network.
                        '
                        'Where,
                        'IsPractice
                        'Specify True if the company is the QBPOS practice company. This can decrease the lookup time by restricting the search to the test company. Useful for development. For real deployments, however, this value would be set to False to make sure all companies were listed.
                        '
                        'ServersXML
                        'Pointer to the returned string containing an XML document containing the list of available servers.
                        '
                        'An example of what is returned as ServersXML from POSServers()
                        '
                        '<POSServers>
                        '<POSServer>
                        '    <ServerName>mtvd040202111</ServerName>
                        '    <CompanyName>al&apos;s sports hut</CompanyName>
                        '    <Version>4</Version>
                        '</POSServer>
                        '<POSServer>
                        '    <ServerName>mtvl040202118</ServerName>
                        '    <CompanyName>al&apos;s sports hut</CompanyName>
                        '    <Version>4</Version>
                        '</POSServer>
                        '...
                        '</POSServers>
           
            bool retVal = false;
            string posserversXML = null;
            posserversXML = vAdd.rp.POSServers(false);
            XmlDocument xMLDoc = new XmlDocument();
            xMLDoc.LoadXml(posserversXML);
            XmlNodeList serversNodeList = xMLDoc.GetElementsByTagName("POSServer");
            int y = -1;
            string version = "";
            for (int x = 0; x < serversNodeList.Count; x++)
            {

                XmlNodeList serverNodeList = serversNodeList.Item(x).ChildNodes;
                string server = "";
                foreach (XmlNode childNode in serverNodeList)
                {
                    if (childNode.Name.Equals("ServerName"))
                    {
                        server = childNode.InnerText;
                    }
                    else if (childNode.Name.Equals("CompanyName"))
                    {
                        server = server + " - " + childNode.InnerText;
                    }
                    else if (childNode.Name.Equals("Version"))
                    {
                        version = childNode.InnerText;
                        server = server + " - " + version;
                        if (Convert.ToInt32(version) > currentVersion)
                        {
                            y++;
                            comboServer.Items.Add(server);
                            retVal = true;
                        }
                    }
                }
            }
            return retVal; */
        }

        public int get_currentVersion()
        {
            return currentVersion;
        }

        public void set_currentVersion(int s)
        {
            currentVersion = s;
        }

        public bool get_fcon()
        {
            return fcon;
        }

        public void set_fcon(bool s)
        {
            fcon = s;
        }

        private void getVersions()
        {
            int pos1;
            string serverInfo = "";
            string text1 = "";

            serverInfo = comboServer.Text;
            pos1 = serverInfo.IndexOf("-");
            serverName = serverInfo.Substring(0, pos1).Trim();

            text1 = serverInfo.Substring(pos1 + 2);
            pos1 = text1.IndexOf("-");
            companyName = text1.Substring(0, pos1).Trim();
            connString = "Computer Name=" + serverName + ";Company Data=" + companyName;
            string[] versions = null;
            //versions = vAdd.rp.POSVersions(serverName, companyName, false) as string[];
            //for (int i = 0; i < versions.Length; i++)
            //{
            //    comboVersion.Items.Add(versions[i]);
            //}
        }

        private void FormSelectSV_FormClosed(object sender, FormClosedEventArgs e)
        {
            vAdd.processRequest();
        }
        private void setConnString()
        {
            versionName = comboVersion.Text;
            if (!versionName.Trim().Equals(""))
            {
                connString = "Computer Name=" + serverName + ";Company Data=" + companyName + ";Version=" + versionName;
            }
        }
        private void cmdStart_Click(object sender, EventArgs e)
        {
            // Step-I:
            // Search for all servers available using POSServers()
            // For first time connection, getServers() is used
            // For later connections, the getNewServers() is used
            cmdStart.Text = "Searching. Please wait...";
            getServers();
            cmdStart.Text = "Done";
            cmdServer.Enabled = true;
        }
        private void cmdVersion_Click(object sender, EventArgs e)
        {
            // Step-III:
            // User has selected a version.
            // Build a connection string for this server and version
            //setConnString();
            //if (!connString.Equals(""))
            //{
            //    vAdd.set_ConnString(connString);
            //}
            //vAdd.LabelConnString.Text = vAdd.get_ConnString();
            // proceed with the operation
            // FormSelectSV_Closed contains the processRequest()
            this.Close();
        }

        private void cmdServer_Click(object sender, EventArgs e)
        {
            // Step-II:
            // User has selected a server.
            // Use POSVersions to find all versions for that server.
            cmdStart.Text = "Find all available servers";
            groupBoxVersion.Enabled = true;
            lblVersions.Text = "Searching. Please wait...";
            lblVersions.Refresh();
            getVersions();
            lblVersions.Text = "Done";
        }
        private void getServers()
        {
            /*
                        'Method signature for POSServers():
                        'HRESULT POSServers([in] VARIANT_BOOL IsPractice, [out,retval] BSTR* ServersXML);
                        '
                        'Returns data about the available QBPOS instances, companies, and versions in the local network.
                        '
                        'Where,
                        'IsPractice
                        'Specify True if the company is the QBPOS practice company. This can decrease the lookup time by restricting the search to the test company. Useful for development. For real deployments, however, this value would be set to False to make sure all companies were listed.
                        '
                        'ServersXML
                        'Pointer to the returned string containing an XML document containing the list of available servers.
                        '
                        'An example of what is returned as ServersXML from POSServers()
                        '
                        '<POSServers>
                        '<POSServer>
                        '    <ServerName>mtvd040202111</ServerName>
                        '    <CompanyName>al&apos;s sports hut</CompanyName>
                        '    <Version>4</Version>
                        '</POSServer>
                        '<POSServer>
                        '    <ServerName>mtvl040202118</ServerName>
                        '    <CompanyName>al&apos;s sports hut</CompanyName>
                        '    <Version>4</Version>
                        '</POSServer>
                        '...
                        '</POSServers>
          
            string posserversXML = null;
            posserversXML = vAdd.rp.POSServers(false);
            XmlDocument xMLDoc = new XmlDocument();
            xMLDoc.LoadXml(posserversXML);
            XmlNodeList serversNodeList = xMLDoc.GetElementsByTagName("POSServer");
            for (int x = 0; x < serversNodeList.Count; x++)
            {

                XmlNodeList serverNodeList = serversNodeList.Item(x).ChildNodes;
                string server = "";
                foreach (XmlNode childNode in serverNodeList)
                {
                    if (childNode.Name.Equals("ServerName"))
                    {
                        server = childNode.InnerText;
                    }
                    else if (childNode.Name.Equals("CompanyName"))
                    {
                        server = server + " - " + childNode.InnerText;
                    }
                    else if (childNode.Name.Equals("Version"))
                    {
                        server = server + " - " + childNode.InnerText;
                    }
                }
                comboServer.Items.Add(server);

            }  */
        }
       
    }
}
