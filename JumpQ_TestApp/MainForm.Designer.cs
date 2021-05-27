namespace JumpQ_TestApp
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.grvData = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.scanBtn = new Bunifu.Framework.UI.BunifuFlatButton();
            this.lblConnectionStatus = new System.Windows.Forms.Label();
            this.cboListOfDSN = new System.Windows.Forms.ComboBox();
            this.cameraTypes = new System.Windows.Forms.ComboBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSet = new System.Windows.Forms.Button();
            this.BtnPostSales = new Bunifu.Framework.UI.BunifuFlatButton();
            this.ConnectBtn = new System.Windows.Forms.Button();
            this.txtQRCode = new System.Windows.Forms.Label();
            this.scANvERITFY = new Bunifu.Framework.UI.BunifuFlatButton();
            this.labNotFound = new System.Windows.Forms.Label();
            this.BarcodeInput1 = new System.Windows.Forms.TextBox();
            this.BarcodeInput2 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBuzzer = new System.Windows.Forms.PictureBox();
            this.timerColor = new System.Windows.Forms.Timer(this.components);
            this.ManualVerification = new Bunifu.Framework.UI.BunifuFlatButton();
            ((System.ComponentModel.ISupportInitialize)(this.grvData)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBuzzer)).BeginInit();
            this.SuspendLayout();
            // 
            // grvData
            // 
            this.grvData.AllowUserToAddRows = false;
            this.grvData.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(169)))), ((int)(((byte)(184)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.grvData.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grvData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grvData.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(169)))), ((int)(((byte)(184)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grvData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.grvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column8,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Total,
            this.Column7});
            this.grvData.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(154)))), ((int)(((byte)(184)))));
            this.grvData.Location = new System.Drawing.Point(54, 274);
            this.grvData.Name = "grvData";
            this.grvData.ReadOnly = true;
            this.grvData.RowHeadersVisible = false;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            this.grvData.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.grvData.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.grvData.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.CornflowerBlue;
            this.grvData.RowTemplate.ReadOnly = true;
            this.grvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grvData.ShowEditingIcon = false;
            this.grvData.Size = new System.Drawing.Size(769, 307);
            this.grvData.TabIndex = 15;
            // 
            // Column1
            // 
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(169)))), ((int)(((byte)(184)))));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Column1.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column1.HeaderText = "S/N";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 50;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Qty Verified";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column2.HeaderText = "Item Name";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Price";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Quantity";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "QRcode";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Visible = false;
            // 
            // Column6
            // 
            this.Column6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column6.HeaderText = "Description";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // Total
            // 
            this.Total.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Total.HeaderText = "Total Amount";
            this.Total.Name = "Total";
            this.Total.ReadOnly = true;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "ListID";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Visible = false;
            // 
            // scanBtn
            // 
            this.scanBtn.Active = false;
            this.scanBtn.Activecolor = System.Drawing.SystemColors.ActiveCaption;
            this.scanBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(154)))), ((int)(((byte)(184)))));
            this.scanBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.scanBtn.BorderRadius = 5;
            this.scanBtn.ButtonText = "Click to Scan";
            this.scanBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.scanBtn.DisabledColor = System.Drawing.Color.Gray;
            this.scanBtn.Font = new System.Drawing.Font("Segoe UI Semibold", 19F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scanBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(82)))), ((int)(((byte)(35)))));
            this.scanBtn.Iconcolor = System.Drawing.Color.Transparent;
            this.scanBtn.Iconimage = null;
            this.scanBtn.Iconimage_right = null;
            this.scanBtn.Iconimage_right_Selected = null;
            this.scanBtn.Iconimage_Selected = null;
            this.scanBtn.IconMarginLeft = 0;
            this.scanBtn.IconMarginRight = 0;
            this.scanBtn.IconRightVisible = false;
            this.scanBtn.IconRightZoom = 0D;
            this.scanBtn.IconVisible = true;
            this.scanBtn.IconZoom = 40D;
            this.scanBtn.IsTab = false;
            this.scanBtn.Location = new System.Drawing.Point(54, 228);
            this.scanBtn.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.scanBtn.Name = "scanBtn";
            this.scanBtn.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(154)))), ((int)(((byte)(184)))));
            this.scanBtn.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.scanBtn.OnHoverTextColor = System.Drawing.Color.White;
            this.scanBtn.selected = false;
            this.scanBtn.Size = new System.Drawing.Size(131, 36);
            this.scanBtn.TabIndex = 70;
            this.scanBtn.Text = "Click to Scan";
            this.scanBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.scanBtn.Textcolor = System.Drawing.Color.White;
            this.scanBtn.TextFont = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scanBtn.Click += new System.EventHandler(this.scanBtn_Click);
            // 
            // lblConnectionStatus
            // 
            this.lblConnectionStatus.AutoSize = true;
            this.lblConnectionStatus.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblConnectionStatus.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConnectionStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(21)))), ((int)(((byte)(28)))));
            this.lblConnectionStatus.Location = new System.Drawing.Point(0, 0);
            this.lblConnectionStatus.Name = "lblConnectionStatus";
            this.lblConnectionStatus.Size = new System.Drawing.Size(122, 21);
            this.lblConnectionStatus.TabIndex = 11;
            this.lblConnectionStatus.Text = "Not Connected";
            // 
            // cboListOfDSN
            // 
            this.cboListOfDSN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboListOfDSN.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboListOfDSN.FormattingEnabled = true;
            this.cboListOfDSN.Location = new System.Drawing.Point(11, 151);
            this.cboListOfDSN.Name = "cboListOfDSN";
            this.cboListOfDSN.Size = new System.Drawing.Size(182, 25);
            this.cboListOfDSN.TabIndex = 9;
            // 
            // cameraTypes
            // 
            this.cameraTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cameraTypes.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cameraTypes.FormattingEnabled = true;
            this.cameraTypes.Location = new System.Drawing.Point(11, 80);
            this.cameraTypes.Name = "cameraTypes";
            this.cameraTypes.Size = new System.Drawing.Size(182, 25);
            this.cameraTypes.TabIndex = 17;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(6, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 20);
            this.label2.TabIndex = 78;
            this.label2.Text = "Select scan device";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 128);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(181, 20);
            this.label1.TabIndex = 79;
            this.label1.Text = "Select Data Source Name";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(169)))), ((int)(((byte)(184)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnSet);
            this.panel1.Controls.Add(this.BtnPostSales);
            this.panel1.Controls.Add(this.ConnectBtn);
            this.panel1.Controls.Add(this.cameraTypes);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.lblConnectionStatus);
            this.panel1.Controls.Add(this.cboListOfDSN);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(913, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(206, 600);
            this.panel1.TabIndex = 80;
            // 
            // btnSet
            // 
            this.btnSet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(169)))), ((int)(((byte)(184)))));
            this.btnSet.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSet.BackgroundImage")));
            this.btnSet.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSet.FlatAppearance.BorderSize = 0;
            this.btnSet.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(154)))), ((int)(((byte)(184)))));
            this.btnSet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSet.Location = new System.Drawing.Point(184, 1);
            this.btnSet.Name = "btnSet";
            this.btnSet.Size = new System.Drawing.Size(18, 22);
            this.btnSet.TabIndex = 90;
            this.btnSet.UseVisualStyleBackColor = false;
            this.btnSet.Click += new System.EventHandler(this.btnSet_Click);
            // 
            // BtnPostSales
            // 
            this.BtnPostSales.Active = false;
            this.BtnPostSales.Activecolor = System.Drawing.SystemColors.ActiveCaption;
            this.BtnPostSales.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.BtnPostSales.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BtnPostSales.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(154)))), ((int)(((byte)(184)))));
            this.BtnPostSales.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnPostSales.BorderRadius = 5;
            this.BtnPostSales.ButtonText = "Post Sales";
            this.BtnPostSales.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnPostSales.DisabledColor = System.Drawing.Color.Gray;
            this.BtnPostSales.Font = new System.Drawing.Font("Segoe UI Semibold", 19F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnPostSales.ForeColor = System.Drawing.Color.White;
            this.BtnPostSales.Iconcolor = System.Drawing.Color.Transparent;
            this.BtnPostSales.Iconimage = null;
            this.BtnPostSales.Iconimage_right = null;
            this.BtnPostSales.Iconimage_right_Selected = null;
            this.BtnPostSales.Iconimage_Selected = null;
            this.BtnPostSales.IconMarginLeft = 0;
            this.BtnPostSales.IconMarginRight = 0;
            this.BtnPostSales.IconRightVisible = false;
            this.BtnPostSales.IconRightZoom = 0D;
            this.BtnPostSales.IconVisible = false;
            this.BtnPostSales.IconZoom = 0D;
            this.BtnPostSales.IsTab = false;
            this.BtnPostSales.Location = new System.Drawing.Point(-4, 521);
            this.BtnPostSales.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.BtnPostSales.Name = "BtnPostSales";
            this.BtnPostSales.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(154)))), ((int)(((byte)(184)))));
            this.BtnPostSales.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.BtnPostSales.OnHoverTextColor = System.Drawing.Color.White;
            this.BtnPostSales.selected = false;
            this.BtnPostSales.Size = new System.Drawing.Size(183, 59);
            this.BtnPostSales.TabIndex = 82;
            this.BtnPostSales.Text = "Post Sales";
            this.BtnPostSales.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.BtnPostSales.Textcolor = System.Drawing.Color.White;
            this.BtnPostSales.TextFont = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnPostSales.Click += new System.EventHandler(this.BtnPostSales_Click);
            // 
            // ConnectBtn
            // 
            this.ConnectBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(154)))), ((int)(((byte)(184)))));
            this.ConnectBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ConnectBtn.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.ConnectBtn.ForeColor = System.Drawing.Color.White;
            this.ConnectBtn.Location = new System.Drawing.Point(21, 197);
            this.ConnectBtn.Name = "ConnectBtn";
            this.ConnectBtn.Size = new System.Drawing.Size(172, 42);
            this.ConnectBtn.TabIndex = 91;
            this.ConnectBtn.Text = "Connect to QB POS";
            this.ConnectBtn.UseVisualStyleBackColor = false;
            this.ConnectBtn.Click += new System.EventHandler(this.ConnectBtn_Click);
            // 
            // txtQRCode
            // 
            this.txtQRCode.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtQRCode.AutoSize = true;
            this.txtQRCode.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQRCode.Location = new System.Drawing.Point(41, 180);
            this.txtQRCode.Name = "txtQRCode";
            this.txtQRCode.Size = new System.Drawing.Size(182, 21);
            this.txtQRCode.TabIndex = 81;
            this.txtQRCode.Text = "                                           ";
            // 
            // scANvERITFY
            // 
            this.scANvERITFY.Active = false;
            this.scANvERITFY.Activecolor = System.Drawing.SystemColors.ActiveCaption;
            this.scANvERITFY.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(154)))), ((int)(((byte)(184)))));
            this.scANvERITFY.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.scANvERITFY.BorderRadius = 5;
            this.scANvERITFY.ButtonText = "Verify Item";
            this.scANvERITFY.Cursor = System.Windows.Forms.Cursors.Hand;
            this.scANvERITFY.DisabledColor = System.Drawing.Color.Gray;
            this.scANvERITFY.Font = new System.Drawing.Font("Segoe UI Semibold", 19F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scANvERITFY.ForeColor = System.Drawing.Color.White;
            this.scANvERITFY.Iconcolor = System.Drawing.Color.Transparent;
            this.scANvERITFY.Iconimage = null;
            this.scANvERITFY.Iconimage_right = null;
            this.scANvERITFY.Iconimage_right_Selected = null;
            this.scANvERITFY.Iconimage_Selected = null;
            this.scANvERITFY.IconMarginLeft = 0;
            this.scANvERITFY.IconMarginRight = 0;
            this.scANvERITFY.IconRightVisible = false;
            this.scANvERITFY.IconRightZoom = 0D;
            this.scANvERITFY.IconVisible = true;
            this.scANvERITFY.IconZoom = 40D;
            this.scANvERITFY.IsTab = false;
            this.scANvERITFY.Location = new System.Drawing.Point(202, 228);
            this.scANvERITFY.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.scANvERITFY.Name = "scANvERITFY";
            this.scANvERITFY.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(154)))), ((int)(((byte)(184)))));
            this.scANvERITFY.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.scANvERITFY.OnHoverTextColor = System.Drawing.Color.White;
            this.scANvERITFY.selected = false;
            this.scANvERITFY.Size = new System.Drawing.Size(131, 36);
            this.scANvERITFY.TabIndex = 83;
            this.scANvERITFY.Text = "Verify Item";
            this.scANvERITFY.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.scANvERITFY.Textcolor = System.Drawing.Color.White;
            this.scANvERITFY.TextFont = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scANvERITFY.Click += new System.EventHandler(this.scANvERITFY_Click);
            // 
            // labNotFound
            // 
            this.labNotFound.AutoSize = true;
            this.labNotFound.Font = new System.Drawing.Font("Segoe UI Semibold", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labNotFound.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(21)))), ((int)(((byte)(28)))));
            this.labNotFound.Location = new System.Drawing.Point(414, 223);
            this.labNotFound.Name = "labNotFound";
            this.labNotFound.Size = new System.Drawing.Size(285, 28);
            this.labNotFound.TabIndex = 84;
            this.labNotFound.Text = "Item is not part of transaction";
            this.labNotFound.Visible = false;
            // 
            // BarcodeInput1
            // 
            this.BarcodeInput1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BarcodeInput1.Location = new System.Drawing.Point(347, 21);
            this.BarcodeInput1.Multiline = true;
            this.BarcodeInput1.Name = "BarcodeInput1";
            this.BarcodeInput1.Size = new System.Drawing.Size(383, 29);
            this.BarcodeInput1.TabIndex = 85;
            this.BarcodeInput1.Tag = "1";
            // 
            // BarcodeInput2
            // 
            this.BarcodeInput2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BarcodeInput2.Location = new System.Drawing.Point(347, 53);
            this.BarcodeInput2.Name = "BarcodeInput2";
            this.BarcodeInput2.Size = new System.Drawing.Size(383, 22);
            this.BarcodeInput2.TabIndex = 86;
            this.BarcodeInput2.Tag = "2";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtQRCode);
            this.groupBox1.Controls.Add(this.pictureBox);
            this.groupBox1.Location = new System.Drawing.Point(54, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(277, 210);
            this.groupBox1.TabIndex = 88;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "JumpQ Barcode";
            // 
            // pictureBox
            // 
            this.pictureBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBox.BackgroundImage = global::JumpQ_TestApp.Properties.Resources.QR_Code;
            this.pictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox.Location = new System.Drawing.Point(18, 21);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(237, 156);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox.TabIndex = 68;
            this.pictureBox.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(3, 15);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(47, 46);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 41;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBuzzer
            // 
            this.pictureBuzzer.BackColor = System.Drawing.Color.White;
            this.pictureBuzzer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBuzzer.Location = new System.Drawing.Point(347, 77);
            this.pictureBuzzer.Name = "pictureBuzzer";
            this.pictureBuzzer.Size = new System.Drawing.Size(383, 144);
            this.pictureBuzzer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBuzzer.TabIndex = 89;
            this.pictureBuzzer.TabStop = false;
            // 
            // timerColor
            // 
            this.timerColor.Interval = 1000;
            this.timerColor.Tick += new System.EventHandler(this.timerColor_Tick);
            // 
            // ManualVerification
            // 
            this.ManualVerification.Active = false;
            this.ManualVerification.Activecolor = System.Drawing.SystemColors.ActiveCaption;
            this.ManualVerification.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(154)))), ((int)(((byte)(184)))));
            this.ManualVerification.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ManualVerification.BorderRadius = 5;
            this.ManualVerification.ButtonText = "Verify";
            this.ManualVerification.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ManualVerification.DisabledColor = System.Drawing.Color.Gray;
            this.ManualVerification.Font = new System.Drawing.Font("Segoe UI Semibold", 19F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ManualVerification.ForeColor = System.Drawing.Color.White;
            this.ManualVerification.Iconcolor = System.Drawing.Color.Transparent;
            this.ManualVerification.Iconimage = null;
            this.ManualVerification.Iconimage_right = null;
            this.ManualVerification.Iconimage_right_Selected = null;
            this.ManualVerification.Iconimage_Selected = null;
            this.ManualVerification.IconMarginLeft = 0;
            this.ManualVerification.IconMarginRight = 0;
            this.ManualVerification.IconRightVisible = false;
            this.ManualVerification.IconRightZoom = 0D;
            this.ManualVerification.IconVisible = false;
            this.ManualVerification.IconZoom = 0D;
            this.ManualVerification.IsTab = false;
            this.ManualVerification.Location = new System.Drawing.Point(739, 22);
            this.ManualVerification.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.ManualVerification.Name = "ManualVerification";
            this.ManualVerification.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(154)))), ((int)(((byte)(184)))));
            this.ManualVerification.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.ManualVerification.OnHoverTextColor = System.Drawing.Color.White;
            this.ManualVerification.selected = false;
            this.ManualVerification.Size = new System.Drawing.Size(77, 52);
            this.ManualVerification.TabIndex = 90;
            this.ManualVerification.Text = "Verify";
            this.ManualVerification.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ManualVerification.Textcolor = System.Drawing.Color.White;
            this.ManualVerification.TextFont = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ManualVerification.Click += new System.EventHandler(this.ManualVerification_Click);
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1119, 600);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.ManualVerification);
            this.Controls.Add(this.pictureBuzzer);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.scanBtn);
            this.Controls.Add(this.BarcodeInput2);
            this.Controls.Add(this.scANvERITFY);
            this.Controls.Add(this.BarcodeInput1);
            this.Controls.Add(this.labNotFound);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.grvData);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "JumpQ Konnect";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AddSalesItem_FormClosing);
            this.Load += new System.EventHandler(this.AddSalesItem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grvData)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBuzzer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView grvData;
        private System.Windows.Forms.Label lblConnectionStatus;
        private System.Windows.Forms.ComboBox cboListOfDSN;
        private Bunifu.Framework.UI.BunifuFlatButton scanBtn;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.ComboBox cameraTypes;
        private System.Windows.Forms.Timer timer1;

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label txtQRCode;
        private Bunifu.Framework.UI.BunifuFlatButton BtnPostSales;
        private Bunifu.Framework.UI.BunifuFlatButton scANvERITFY;
        private System.Windows.Forms.Label labNotFound;
        private System.Windows.Forms.TextBox BarcodeInput1;
        private System.Windows.Forms.TextBox BarcodeInput2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBuzzer;
        private System.Windows.Forms.Timer timerColor;
        private System.Windows.Forms.Button ConnectBtn;
        private System.Windows.Forms.Button btnSet;
        private Bunifu.Framework.UI.BunifuFlatButton ManualVerification;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
    }
}