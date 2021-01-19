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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.StateProperties stateProperties5 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.StateProperties();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.StateProperties stateProperties6 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.StateProperties();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.StateProperties stateProperties7 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.StateProperties();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.StateProperties stateProperties8 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.StateProperties();
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
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.lblConnectionStatus = new System.Windows.Forms.Label();
            this.cboListOfDSN = new System.Windows.Forms.ComboBox();
            this.cameraTypes = new System.Windows.Forms.ComboBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.bunifuGradientPanel1 = new Bunifu.Framework.UI.BunifuGradientPanel();
            this.btnHelp = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.btnSet = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.btnClose = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.ConnectBtn = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtQRCode = new System.Windows.Forms.Label();
            this.BtnPostSales = new Bunifu.Framework.UI.BunifuFlatButton();
            this.scANvERITFY = new Bunifu.Framework.UI.BunifuFlatButton();
            this.labNotFound = new System.Windows.Forms.Label();
            this.BarcodeInput1 = new System.Windows.Forms.TextBox();
            this.BarcodeInput2 = new System.Windows.Forms.TextBox();
            this.Printbtn = new Bunifu.Framework.UI.BunifuFlatButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.grvData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.bunifuGradientPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grvData
            // 
            this.grvData.AllowUserToAddRows = false;
            this.grvData.AllowUserToDeleteRows = false;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.CornflowerBlue;
            this.grvData.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.grvData.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grvData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
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
            this.grvData.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(82)))), ((int)(((byte)(35)))));
            this.grvData.Location = new System.Drawing.Point(230, 305);
            this.grvData.Name = "grvData";
            this.grvData.ReadOnly = true;
            this.grvData.RowHeadersVisible = false;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grvData.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.grvData.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.CornflowerBlue;
            this.grvData.RowTemplate.ReadOnly = true;
            this.grvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grvData.ShowEditingIcon = false;
            this.grvData.Size = new System.Drawing.Size(859, 361);
            this.grvData.TabIndex = 15;
            // 
            // Column1
            // 
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
            this.scanBtn.Activecolor = System.Drawing.SystemColors.Menu;
            this.scanBtn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.scanBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(82)))), ((int)(((byte)(35)))));
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
            this.scanBtn.Location = new System.Drawing.Point(823, 174);
            this.scanBtn.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.scanBtn.Name = "scanBtn";
            this.scanBtn.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(82)))), ((int)(((byte)(35)))));
            this.scanBtn.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(241)))), ((int)(((byte)(189)))));
            this.scanBtn.OnHoverTextColor = System.Drawing.Color.Black;
            this.scanBtn.selected = false;
            this.scanBtn.Size = new System.Drawing.Size(117, 73);
            this.scanBtn.TabIndex = 70;
            this.scanBtn.Text = "Click to Scan";
            this.scanBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.scanBtn.Textcolor = System.Drawing.Color.White;
            this.scanBtn.TextFont = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scanBtn.Click += new System.EventHandler(this.scanBtn_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox.Location = new System.Drawing.Point(29, 21);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(245, 173);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox.TabIndex = 68;
            this.pictureBox.TabStop = false;
            // 
            // lblConnectionStatus
            // 
            this.lblConnectionStatus.AutoSize = true;
            this.lblConnectionStatus.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblConnectionStatus.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConnectionStatus.ForeColor = System.Drawing.Color.Red;
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
            this.cboListOfDSN.Location = new System.Drawing.Point(17, 140);
            this.cboListOfDSN.Name = "cboListOfDSN";
            this.cboListOfDSN.Size = new System.Drawing.Size(166, 25);
            this.cboListOfDSN.TabIndex = 9;
            // 
            // cameraTypes
            // 
            this.cameraTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cameraTypes.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cameraTypes.FormattingEnabled = true;
            this.cameraTypes.Location = new System.Drawing.Point(17, 69);
            this.cameraTypes.Name = "cameraTypes";
            this.cameraTypes.Size = new System.Drawing.Size(164, 25);
            this.cameraTypes.TabIndex = 17;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // bunifuGradientPanel1
            // 
            this.bunifuGradientPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuGradientPanel1.BackgroundImage")));
            this.bunifuGradientPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuGradientPanel1.Controls.Add(this.btnHelp);
            this.bunifuGradientPanel1.Controls.Add(this.btnSet);
            this.bunifuGradientPanel1.Controls.Add(this.btnClose);
            this.bunifuGradientPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.bunifuGradientPanel1.GradientBottomLeft = System.Drawing.Color.White;
            this.bunifuGradientPanel1.GradientBottomRight = System.Drawing.Color.White;
            this.bunifuGradientPanel1.GradientTopLeft = System.Drawing.Color.White;
            this.bunifuGradientPanel1.GradientTopRight = System.Drawing.Color.White;
            this.bunifuGradientPanel1.Location = new System.Drawing.Point(0, 0);
            this.bunifuGradientPanel1.Name = "bunifuGradientPanel1";
            this.bunifuGradientPanel1.Quality = 10;
            this.bunifuGradientPanel1.Size = new System.Drawing.Size(1279, 52);
            this.bunifuGradientPanel1.TabIndex = 72;
            // 
            // btnHelp
            // 
            this.btnHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHelp.BackColor = System.Drawing.Color.Transparent;
            this.btnHelp.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnHelp.BackgroundImage")));
            this.btnHelp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnHelp.ButtonText = "?";
            this.btnHelp.ButtonTextMarginLeft = 2;
            this.btnHelp.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(161)))), ((int)(((byte)(161)))));
            this.btnHelp.DisabledFillColor = System.Drawing.Color.Gray;
            this.btnHelp.DisabledForecolor = System.Drawing.Color.White;
            this.btnHelp.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHelp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(148)))), ((int)(((byte)(148)))));
            this.btnHelp.IconLeftCursor = System.Windows.Forms.Cursors.Hand;
            this.btnHelp.IconPadding = 10;
            this.btnHelp.IconRightCursor = System.Windows.Forms.Cursors.Hand;
            this.btnHelp.IdleBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(179)))), ((int)(((byte)(179)))));
            this.btnHelp.IdleBorderRadius = 10;
            this.btnHelp.IdleBorderThickness = 1;
            this.btnHelp.IdleFillColor = System.Drawing.Color.White;
            this.btnHelp.IdleIconLeftImage = null;
            this.btnHelp.IdleIconRightImage = null;
            this.btnHelp.Location = new System.Drawing.Point(1213, 12);
            this.btnHelp.Name = "btnHelp";
            stateProperties5.BorderColor = System.Drawing.Color.White;
            stateProperties5.BorderRadius = 20;
            stateProperties5.BorderThickness = 0;
            stateProperties5.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(179)))), ((int)(((byte)(179)))));
            stateProperties5.IconLeftImage = null;
            stateProperties5.IconRightImage = null;
            this.btnHelp.onHoverState = stateProperties5;
            this.btnHelp.Size = new System.Drawing.Size(29, 31);
            this.btnHelp.TabIndex = 39;
            this.btnHelp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSet
            // 
            this.btnSet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSet.BackColor = System.Drawing.Color.Transparent;
            this.btnSet.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSet.BackgroundImage")));
            this.btnSet.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSet.ButtonText = "";
            this.btnSet.ButtonTextMarginLeft = 2;
            this.btnSet.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(161)))), ((int)(((byte)(161)))));
            this.btnSet.DisabledFillColor = System.Drawing.Color.Gray;
            this.btnSet.DisabledForecolor = System.Drawing.Color.White;
            this.btnSet.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSet.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(148)))), ((int)(((byte)(148)))));
            this.btnSet.IconLeftCursor = System.Windows.Forms.Cursors.Hand;
            this.btnSet.IconPadding = 10;
            this.btnSet.IconRightCursor = System.Windows.Forms.Cursors.Hand;
            this.btnSet.IdleBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(179)))), ((int)(((byte)(179)))));
            this.btnSet.IdleBorderRadius = 10;
            this.btnSet.IdleBorderThickness = 1;
            this.btnSet.IdleFillColor = System.Drawing.Color.White;
            this.btnSet.IdleIconLeftImage = ((System.Drawing.Image)(resources.GetObject("btnSet.IdleIconLeftImage")));
            this.btnSet.IdleIconRightImage = null;
            this.btnSet.Location = new System.Drawing.Point(1172, 12);
            this.btnSet.Name = "btnSet";
            stateProperties6.BorderColor = System.Drawing.Color.White;
            stateProperties6.BorderRadius = 20;
            stateProperties6.BorderThickness = 0;
            stateProperties6.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(179)))), ((int)(((byte)(179)))));
            stateProperties6.IconLeftImage = null;
            stateProperties6.IconRightImage = null;
            this.btnSet.onHoverState = stateProperties6;
            this.btnSet.Size = new System.Drawing.Size(35, 31);
            this.btnSet.TabIndex = 38;
            this.btnSet.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnSet.Click += new System.EventHandler(this.btnSet_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnClose.BackgroundImage")));
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnClose.ButtonText = "X";
            this.btnClose.ButtonTextMarginLeft = 2;
            this.btnClose.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(161)))), ((int)(((byte)(161)))));
            this.btnClose.DisabledFillColor = System.Drawing.Color.Gray;
            this.btnClose.DisabledForecolor = System.Drawing.Color.White;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(148)))), ((int)(((byte)(148)))));
            this.btnClose.IconLeftCursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.IconPadding = 10;
            this.btnClose.IconRightCursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.IdleBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(179)))), ((int)(((byte)(179)))));
            this.btnClose.IdleBorderRadius = 10;
            this.btnClose.IdleBorderThickness = 1;
            this.btnClose.IdleFillColor = System.Drawing.Color.White;
            this.btnClose.IdleIconLeftImage = null;
            this.btnClose.IdleIconRightImage = null;
            this.btnClose.Location = new System.Drawing.Point(1247, 12);
            this.btnClose.Name = "btnClose";
            stateProperties7.BorderColor = System.Drawing.Color.White;
            stateProperties7.BorderRadius = 20;
            stateProperties7.BorderThickness = 0;
            stateProperties7.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(179)))), ((int)(((byte)(179)))));
            stateProperties7.IconLeftImage = null;
            stateProperties7.IconRightImage = null;
            this.btnClose.onHoverState = stateProperties7;
            this.btnClose.Size = new System.Drawing.Size(29, 31);
            this.btnClose.TabIndex = 36;
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ConnectBtn
            // 
            this.ConnectBtn.BackColor = System.Drawing.Color.Transparent;
            this.ConnectBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ConnectBtn.BackgroundImage")));
            this.ConnectBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ConnectBtn.ButtonText = "Connect to QB POS";
            this.ConnectBtn.ButtonTextMarginLeft = 0;
            this.ConnectBtn.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(161)))), ((int)(((byte)(161)))));
            this.ConnectBtn.DisabledFillColor = System.Drawing.Color.Gray;
            this.ConnectBtn.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(161)))), ((int)(((byte)(161)))));
            this.ConnectBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConnectBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(161)))), ((int)(((byte)(161)))));
            this.ConnectBtn.IconLeftCursor = System.Windows.Forms.Cursors.Hand;
            this.ConnectBtn.IconPadding = 10;
            this.ConnectBtn.IconRightCursor = System.Windows.Forms.Cursors.Hand;
            this.ConnectBtn.IdleBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(82)))), ((int)(((byte)(35)))));
            this.ConnectBtn.IdleBorderRadius = 30;
            this.ConnectBtn.IdleBorderThickness = 0;
            this.ConnectBtn.IdleFillColor = System.Drawing.Color.White;
            this.ConnectBtn.IdleIconLeftImage = null;
            this.ConnectBtn.IdleIconRightImage = null;
            this.ConnectBtn.Location = new System.Drawing.Point(9, 188);
            this.ConnectBtn.Name = "ConnectBtn";
            stateProperties8.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(215)))), ((int)(((byte)(215)))));
            stateProperties8.BorderRadius = 20;
            stateProperties8.BorderThickness = 3;
            stateProperties8.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(82)))), ((int)(((byte)(35)))));
            stateProperties8.IconLeftImage = null;
            stateProperties8.IconRightImage = null;
            this.ConnectBtn.onHoverState = stateProperties8;
            this.ConnectBtn.Size = new System.Drawing.Size(185, 54);
            this.ConnectBtn.TabIndex = 75;
            this.ConnectBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ConnectBtn.Click += new System.EventHandler(this.ConnectBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(148)))), ((int)(((byte)(148)))));
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 20);
            this.label2.TabIndex = 78;
            this.label2.Text = "Select scan device";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(148)))), ((int)(((byte)(148)))));
            this.label1.Location = new System.Drawing.Point(13, 117);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(181, 20);
            this.label1.TabIndex = 79;
            this.label1.Text = "Select Data Source Name";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.cameraTypes);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.ConnectBtn);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.lblConnectionStatus);
            this.panel1.Controls.Add(this.cboListOfDSN);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 52);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(206, 673);
            this.panel1.TabIndex = 80;
            // 
            // txtQRCode
            // 
            this.txtQRCode.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtQRCode.AutoSize = true;
            this.txtQRCode.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQRCode.Location = new System.Drawing.Point(31, 202);
            this.txtQRCode.Name = "txtQRCode";
            this.txtQRCode.Size = new System.Drawing.Size(242, 25);
            this.txtQRCode.TabIndex = 81;
            this.txtQRCode.Text = "                                              ";
            // 
            // BtnPostSales
            // 
            this.BtnPostSales.Activecolor = System.Drawing.SystemColors.Menu;
            this.BtnPostSales.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.BtnPostSales.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(82)))), ((int)(((byte)(35)))));
            this.BtnPostSales.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnPostSales.BorderRadius = 5;
            this.BtnPostSales.ButtonText = "Post Sales";
            this.BtnPostSales.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnPostSales.DisabledColor = System.Drawing.Color.Gray;
            this.BtnPostSales.Font = new System.Drawing.Font("Segoe UI Semibold", 19F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnPostSales.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(82)))), ((int)(((byte)(35)))));
            this.BtnPostSales.Iconcolor = System.Drawing.Color.Transparent;
            this.BtnPostSales.Iconimage = null;
            this.BtnPostSales.Iconimage_right = null;
            this.BtnPostSales.Iconimage_right_Selected = null;
            this.BtnPostSales.Iconimage_Selected = null;
            this.BtnPostSales.IconMarginLeft = 0;
            this.BtnPostSales.IconMarginRight = 0;
            this.BtnPostSales.IconRightVisible = false;
            this.BtnPostSales.IconRightZoom = 0D;
            this.BtnPostSales.IconVisible = true;
            this.BtnPostSales.IconZoom = 40D;
            this.BtnPostSales.IsTab = false;
            this.BtnPostSales.Location = new System.Drawing.Point(1095, 584);
            this.BtnPostSales.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.BtnPostSales.Name = "BtnPostSales";
            this.BtnPostSales.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(82)))), ((int)(((byte)(35)))));
            this.BtnPostSales.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(241)))), ((int)(((byte)(189)))));
            this.BtnPostSales.OnHoverTextColor = System.Drawing.Color.Black;
            this.BtnPostSales.selected = false;
            this.BtnPostSales.Size = new System.Drawing.Size(112, 34);
            this.BtnPostSales.TabIndex = 82;
            this.BtnPostSales.Text = "Post Sales";
            this.BtnPostSales.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.BtnPostSales.Textcolor = System.Drawing.Color.White;
            this.BtnPostSales.TextFont = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnPostSales.Click += new System.EventHandler(this.BtnPostSales_Click);
            // 
            // scANvERITFY
            // 
            this.scANvERITFY.Activecolor = System.Drawing.SystemColors.Menu;
            this.scANvERITFY.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.scANvERITFY.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(82)))), ((int)(((byte)(35)))));
            this.scANvERITFY.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.scANvERITFY.BorderRadius = 5;
            this.scANvERITFY.ButtonText = "Verify Item";
            this.scANvERITFY.Cursor = System.Windows.Forms.Cursors.Hand;
            this.scANvERITFY.DisabledColor = System.Drawing.Color.Gray;
            this.scANvERITFY.Font = new System.Drawing.Font("Segoe UI Semibold", 19F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scANvERITFY.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(82)))), ((int)(((byte)(35)))));
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
            this.scANvERITFY.Location = new System.Drawing.Point(955, 267);
            this.scANvERITFY.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.scANvERITFY.Name = "scANvERITFY";
            this.scANvERITFY.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(82)))), ((int)(((byte)(35)))));
            this.scANvERITFY.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(241)))), ((int)(((byte)(189)))));
            this.scANvERITFY.OnHoverTextColor = System.Drawing.Color.Black;
            this.scANvERITFY.selected = false;
            this.scANvERITFY.Size = new System.Drawing.Size(134, 34);
            this.scANvERITFY.TabIndex = 83;
            this.scANvERITFY.Text = "Verify Item";
            this.scANvERITFY.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.scANvERITFY.Textcolor = System.Drawing.Color.White;
            this.scANvERITFY.TextFont = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scANvERITFY.Click += new System.EventHandler(this.scANvERITFY_Click);
            // 
            // labNotFound
            // 
            this.labNotFound.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labNotFound.AutoSize = true;
            this.labNotFound.Font = new System.Drawing.Font("Segoe UI Semibold", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labNotFound.ForeColor = System.Drawing.Color.Red;
            this.labNotFound.Location = new System.Drawing.Point(454, 669);
            this.labNotFound.Name = "labNotFound";
            this.labNotFound.Size = new System.Drawing.Size(383, 37);
            this.labNotFound.TabIndex = 84;
            this.labNotFound.Text = "Item is not part of transaction";
            this.labNotFound.Visible = false;
            // 
            // BarcodeInput1
            // 
            this.BarcodeInput1.Location = new System.Drawing.Point(1095, 385);
            this.BarcodeInput1.Name = "BarcodeInput1";
            this.BarcodeInput1.Size = new System.Drawing.Size(172, 20);
            this.BarcodeInput1.TabIndex = 85;
            this.BarcodeInput1.Tag = "1";
            // 
            // BarcodeInput2
            // 
            this.BarcodeInput2.Location = new System.Drawing.Point(1095, 421);
            this.BarcodeInput2.Name = "BarcodeInput2";
            this.BarcodeInput2.Size = new System.Drawing.Size(172, 20);
            this.BarcodeInput2.TabIndex = 86;
            this.BarcodeInput2.Tag = "2";
            // 
            // Printbtn
            // 
            this.Printbtn.Activecolor = System.Drawing.SystemColors.Menu;
            this.Printbtn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Printbtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(82)))), ((int)(((byte)(35)))));
            this.Printbtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Printbtn.BorderRadius = 5;
            this.Printbtn.ButtonText = "Print";
            this.Printbtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Printbtn.DisabledColor = System.Drawing.Color.Gray;
            this.Printbtn.Font = new System.Drawing.Font("Segoe UI Semibold", 19F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Printbtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(82)))), ((int)(((byte)(35)))));
            this.Printbtn.Iconcolor = System.Drawing.Color.Transparent;
            this.Printbtn.Iconimage = null;
            this.Printbtn.Iconimage_right = null;
            this.Printbtn.Iconimage_right_Selected = null;
            this.Printbtn.Iconimage_Selected = null;
            this.Printbtn.IconMarginLeft = 0;
            this.Printbtn.IconMarginRight = 0;
            this.Printbtn.IconRightVisible = false;
            this.Printbtn.IconRightZoom = 0D;
            this.Printbtn.IconVisible = true;
            this.Printbtn.IconZoom = 40D;
            this.Printbtn.IsTab = false;
            this.Printbtn.Location = new System.Drawing.Point(1095, 632);
            this.Printbtn.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.Printbtn.Name = "Printbtn";
            this.Printbtn.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(82)))), ((int)(((byte)(35)))));
            this.Printbtn.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(241)))), ((int)(((byte)(189)))));
            this.Printbtn.OnHoverTextColor = System.Drawing.Color.Black;
            this.Printbtn.selected = false;
            this.Printbtn.Size = new System.Drawing.Size(112, 34);
            this.Printbtn.TabIndex = 87;
            this.Printbtn.Text = "Print";
            this.Printbtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Printbtn.Textcolor = System.Drawing.Color.White;
            this.Printbtn.TextFont = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Printbtn.Click += new System.EventHandler(this.Printbtn_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pictureBox);
            this.groupBox1.Controls.Add(this.txtQRCode);
            this.groupBox1.Location = new System.Drawing.Point(515, 58);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(299, 236);
            this.groupBox1.TabIndex = 88;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "JumpQ Barcode";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1279, 725);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Printbtn);
            this.Controls.Add(this.BarcodeInput2);
            this.Controls.Add(this.BarcodeInput1);
            this.Controls.Add(this.labNotFound);
            this.Controls.Add(this.scANvERITFY);
            this.Controls.Add(this.BtnPostSales);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.bunifuGradientPanel1);
            this.Controls.Add(this.scanBtn);
            this.Controls.Add(this.grvData);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddSalesItem";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AddSalesItem_FormClosing);
            this.Load += new System.EventHandler(this.AddSalesItem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grvData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.bunifuGradientPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
        private Bunifu.Framework.UI.BunifuGradientPanel bunifuGradientPanel1;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton btnHelp;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton btnSet;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton btnClose;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton ConnectBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label txtQRCode;
        private Bunifu.Framework.UI.BunifuFlatButton BtnPostSales;
        private Bunifu.Framework.UI.BunifuFlatButton scANvERITFY;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.Label labNotFound;
        private System.Windows.Forms.TextBox BarcodeInput1;
        private System.Windows.Forms.TextBox BarcodeInput2;
        private Bunifu.Framework.UI.BunifuFlatButton BtnPrint;
        private Bunifu.Framework.UI.BunifuFlatButton Printbtn;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}