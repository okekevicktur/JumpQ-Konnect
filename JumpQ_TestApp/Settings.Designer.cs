namespace JumpQ_TestApp
{
    partial class Settings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.lblConnectionStatus = new System.Windows.Forms.Label();
            this.btnConnect = new System.Windows.Forms.Button();
            this.cboListOfDSN = new System.Windows.Forms.ComboBox();
            this.CustomerID = new System.Windows.Forms.Label();
            this.BtnAddCustomer = new Bunifu.Framework.UI.BunifuThinButton2();
            this.txtFName = new System.Windows.Forms.TextBox();
            this.txtLName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCompData = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.TxtCompanyData = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAddCompany = new Bunifu.Framework.UI.BunifuThinButton2();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(82)))), ((int)(((byte)(35)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(475, 25);
            this.panel1.TabIndex = 28;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(5, 106);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 20);
            this.label1.TabIndex = 21;
            this.label1.Text = "Add a default Customer";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.btnAddCompany);
            this.panel3.Controls.Add(this.TxtCompanyData);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.lblConnectionStatus);
            this.panel3.Controls.Add(this.btnConnect);
            this.panel3.Controls.Add(this.cboListOfDSN);
            this.panel3.Controls.Add(this.CustomerID);
            this.panel3.Controls.Add(this.BtnAddCustomer);
            this.panel3.Controls.Add(this.txtFName);
            this.panel3.Controls.Add(this.txtLName);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(475, 238);
            this.panel3.TabIndex = 30;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 53);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(63, 13);
            this.label9.TabIndex = 34;
            this.label9.Text = "Select DSN";
            // 
            // lblConnectionStatus
            // 
            this.lblConnectionStatus.AutoSize = true;
            this.lblConnectionStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConnectionStatus.ForeColor = System.Drawing.Color.DarkRed;
            this.lblConnectionStatus.Location = new System.Drawing.Point(7, 27);
            this.lblConnectionStatus.Name = "lblConnectionStatus";
            this.lblConnectionStatus.Size = new System.Drawing.Size(121, 18);
            this.lblConnectionStatus.TabIndex = 33;
            this.lblConnectionStatus.Text = "Not Connected";
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(167, 64);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(78, 28);
            this.btnConnect.TabIndex = 32;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // cboListOfDSN
            // 
            this.cboListOfDSN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboListOfDSN.FormattingEnabled = true;
            this.cboListOfDSN.Location = new System.Drawing.Point(7, 69);
            this.cboListOfDSN.Name = "cboListOfDSN";
            this.cboListOfDSN.Size = new System.Drawing.Size(137, 21);
            this.cboListOfDSN.TabIndex = 31;
            // 
            // CustomerID
            // 
            this.CustomerID.AutoSize = true;
            this.CustomerID.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CustomerID.Location = new System.Drawing.Point(255, 110);
            this.CustomerID.Name = "CustomerID";
            this.CustomerID.Size = new System.Drawing.Size(70, 15);
            this.CustomerID.TabIndex = 27;
            this.CustomerID.Text = "CustomerID";
            // 
            // BtnAddCustomer
            // 
            this.BtnAddCustomer.ActiveBorderThickness = 1;
            this.BtnAddCustomer.ActiveCornerRadius = 20;
            this.BtnAddCustomer.ActiveFillColor = System.Drawing.Color.White;
            this.BtnAddCustomer.ActiveForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(82)))), ((int)(((byte)(35)))));
            this.BtnAddCustomer.ActiveLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(82)))), ((int)(((byte)(35)))));
            this.BtnAddCustomer.BackColor = System.Drawing.SystemColors.Control;
            this.BtnAddCustomer.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtnAddCustomer.BackgroundImage")));
            this.BtnAddCustomer.ButtonText = "Add Customer";
            this.BtnAddCustomer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnAddCustomer.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAddCustomer.ForeColor = System.Drawing.Color.White;
            this.BtnAddCustomer.IdleBorderThickness = 1;
            this.BtnAddCustomer.IdleCornerRadius = 20;
            this.BtnAddCustomer.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(82)))), ((int)(((byte)(35)))));
            this.BtnAddCustomer.IdleForecolor = System.Drawing.Color.White;
            this.BtnAddCustomer.IdleLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(241)))), ((int)(((byte)(189)))));
            this.BtnAddCustomer.Location = new System.Drawing.Point(328, 148);
            this.BtnAddCustomer.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BtnAddCustomer.Name = "BtnAddCustomer";
            this.BtnAddCustomer.Size = new System.Drawing.Size(129, 39);
            this.BtnAddCustomer.TabIndex = 19;
            this.BtnAddCustomer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.BtnAddCustomer.Click += new System.EventHandler(this.BtnAddCustomer_Click);
            // 
            // txtFName
            // 
            this.txtFName.Location = new System.Drawing.Point(134, 130);
            this.txtFName.Name = "txtFName";
            this.txtFName.Size = new System.Drawing.Size(187, 20);
            this.txtFName.TabIndex = 26;
            // 
            // txtLName
            // 
            this.txtLName.Location = new System.Drawing.Point(134, 161);
            this.txtLName.Name = "txtLName";
            this.txtLName.Size = new System.Drawing.Size(187, 20);
            this.txtLName.TabIndex = 25;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 159);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 20);
            this.label6.TabIndex = 24;
            this.label6.Text = "Last Name";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(11, 130);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 20);
            this.label5.TabIndex = 22;
            this.label5.Text = "First Name";
            // 
            // txtCompData
            // 
            this.txtCompData.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCompData.Location = new System.Drawing.Point(188, 111);
            this.txtCompData.Name = "txtCompData";
            this.txtCompData.Size = new System.Drawing.Size(205, 27);
            this.txtCompData.TabIndex = 24;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 238);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(475, 32);
            this.panel2.TabIndex = 29;
            // 
            // TxtCompanyData
            // 
            this.TxtCompanyData.Location = new System.Drawing.Point(134, 197);
            this.TxtCompanyData.Name = "TxtCompanyData";
            this.TxtCompanyData.Size = new System.Drawing.Size(187, 20);
            this.TxtCompanyData.TabIndex = 36;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 195);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 20);
            this.label2.TabIndex = 35;
            this.label2.Text = "Company Name";
            // 
            // btnAddCompany
            // 
            this.btnAddCompany.ActiveBorderThickness = 1;
            this.btnAddCompany.ActiveCornerRadius = 20;
            this.btnAddCompany.ActiveFillColor = System.Drawing.Color.White;
            this.btnAddCompany.ActiveForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(82)))), ((int)(((byte)(35)))));
            this.btnAddCompany.ActiveLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(82)))), ((int)(((byte)(35)))));
            this.btnAddCompany.BackColor = System.Drawing.SystemColors.Control;
            this.btnAddCompany.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAddCompany.BackgroundImage")));
            this.btnAddCompany.ButtonText = "Add Company ";
            this.btnAddCompany.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddCompany.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddCompany.ForeColor = System.Drawing.Color.White;
            this.btnAddCompany.IdleBorderThickness = 1;
            this.btnAddCompany.IdleCornerRadius = 20;
            this.btnAddCompany.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(82)))), ((int)(((byte)(35)))));
            this.btnAddCompany.IdleForecolor = System.Drawing.Color.White;
            this.btnAddCompany.IdleLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(241)))), ((int)(((byte)(189)))));
            this.btnAddCompany.Location = new System.Drawing.Point(328, 187);
            this.btnAddCompany.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAddCompany.Name = "btnAddCompany";
            this.btnAddCompany.Size = new System.Drawing.Size(129, 39);
            this.btnAddCompany.TabIndex = 37;
            this.btnAddCompany.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnAddCompany.Click += new System.EventHandler(this.btnAddCompany_Click);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(475, 270);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.txtCompData);
            this.Controls.Add(this.panel2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Settings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.Settings_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtCompData;
        private System.Windows.Forms.Panel panel2;
        private Bunifu.Framework.UI.BunifuThinButton2 BtnAddCustomer;
        private System.Windows.Forms.TextBox txtFName;
        private System.Windows.Forms.TextBox txtLName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label CustomerID;
        private System.Windows.Forms.ComboBox cboListOfDSN;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Label lblConnectionStatus;
        private System.Windows.Forms.Label label9;
        private Bunifu.Framework.UI.BunifuThinButton2 btnAddCompany;
        private System.Windows.Forms.TextBox TxtCompanyData;
        private System.Windows.Forms.Label label2;
    }
}