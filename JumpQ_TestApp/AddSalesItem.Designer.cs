namespace JumpQ_TestApp
{
    partial class AddSalesItem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddSalesItem));
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.StateProperties stateProperties21 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.StateProperties();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.StateProperties stateProperties22 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.StateProperties();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.StateProperties stateProperties23 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.StateProperties();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.StateProperties stateProperties24 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.StateProperties();
            this.grvData = new System.Windows.Forms.DataGridView();
            this.txtQRCode = new System.Windows.Forms.TextBox();
            this.scanBtn = new Bunifu.Framework.UI.BunifuFlatButton();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.lblConnectionStatus = new System.Windows.Forms.Label();
            this.cboListOfDSN = new System.Windows.Forms.ComboBox();
            this.cameraTypes = new System.Windows.Forms.ComboBox();
            this.Camera = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label9 = new System.Windows.Forms.Label();
            this.bunifuGradientPanel1 = new Bunifu.Framework.UI.BunifuGradientPanel();
            this.btnHelp = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.btnSet = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.btnClose = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.ConnectBtn = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.sfDataGrid1 = new Syncfusion.WinForms.DataGrid.SfDataGrid();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grvData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.bunifuGradientPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sfDataGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // grvData
            // 
            this.grvData.AllowUserToAddRows = false;
            this.grvData.AllowUserToDeleteRows = false;
            this.grvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Total});
            this.grvData.Location = new System.Drawing.Point(12, 324);
            this.grvData.Name = "grvData";
            this.grvData.ReadOnly = true;
            this.grvData.RowHeadersVisible = false;
            this.grvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grvData.ShowEditingIcon = false;
            this.grvData.Size = new System.Drawing.Size(703, 196);
            this.grvData.TabIndex = 15;
            // 
            // txtQRCode
            // 
            this.txtQRCode.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtQRCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(240)))), ((int)(((byte)(238)))));
            this.txtQRCode.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.txtQRCode.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQRCode.Location = new System.Drawing.Point(723, 308);
            this.txtQRCode.Multiline = true;
            this.txtQRCode.Name = "txtQRCode";
            this.txtQRCode.ReadOnly = true;
            this.txtQRCode.Size = new System.Drawing.Size(283, 70);
            this.txtQRCode.TabIndex = 69;
            // 
            // scanBtn
            // 
            this.scanBtn.Activecolor = System.Drawing.SystemColors.Menu;
            this.scanBtn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.scanBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(82)))), ((int)(((byte)(35)))));
            this.scanBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.scanBtn.BorderRadius = 5;
            this.scanBtn.ButtonText = "";
            this.scanBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.scanBtn.DisabledColor = System.Drawing.Color.Gray;
            this.scanBtn.Font = new System.Drawing.Font("Segoe UI Semibold", 19F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scanBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(82)))), ((int)(((byte)(35)))));
            this.scanBtn.Iconcolor = System.Drawing.Color.Transparent;
            this.scanBtn.Iconimage = global::JumpQ_TestApp.Properties.Resources.QR_Code;
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
            this.scanBtn.Location = new System.Drawing.Point(992, 124);
            this.scanBtn.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.scanBtn.Name = "scanBtn";
            this.scanBtn.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(82)))), ((int)(((byte)(35)))));
            this.scanBtn.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(241)))), ((int)(((byte)(189)))));
            this.scanBtn.OnHoverTextColor = System.Drawing.Color.Black;
            this.scanBtn.selected = false;
            this.scanBtn.Size = new System.Drawing.Size(92, 91);
            this.scanBtn.TabIndex = 70;
            this.scanBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.scanBtn.Textcolor = System.Drawing.Color.White;
            this.scanBtn.TextFont = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scanBtn.Click += new System.EventHandler(this.scanBtn_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox.Location = new System.Drawing.Point(723, 93);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(260, 199);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox.TabIndex = 68;
            this.pictureBox.TabStop = false;
            // 
            // lblConnectionStatus
            // 
            this.lblConnectionStatus.AutoSize = true;
            this.lblConnectionStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConnectionStatus.ForeColor = System.Drawing.Color.DarkRed;
            this.lblConnectionStatus.Location = new System.Drawing.Point(963, 50);
            this.lblConnectionStatus.Name = "lblConnectionStatus";
            this.lblConnectionStatus.Size = new System.Drawing.Size(121, 18);
            this.lblConnectionStatus.TabIndex = 11;
            this.lblConnectionStatus.Text = "Not Connected";
            // 
            // cboListOfDSN
            // 
            this.cboListOfDSN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboListOfDSN.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboListOfDSN.FormattingEnabled = true;
            this.cboListOfDSN.Location = new System.Drawing.Point(199, 212);
            this.cboListOfDSN.Name = "cboListOfDSN";
            this.cboListOfDSN.Size = new System.Drawing.Size(151, 25);
            this.cboListOfDSN.TabIndex = 9;
            // 
            // cameraTypes
            // 
            this.cameraTypes.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cameraTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cameraTypes.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cameraTypes.FormattingEnabled = true;
            this.cameraTypes.Location = new System.Drawing.Point(190, 137);
            this.cameraTypes.Name = "cameraTypes";
            this.cameraTypes.Size = new System.Drawing.Size(164, 25);
            this.cameraTypes.TabIndex = 17;
            // 
            // Camera
            // 
            this.Camera.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Camera.AutoSize = true;
            this.Camera.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Camera.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(82)))), ((int)(((byte)(35)))));
            this.Camera.Location = new System.Drawing.Point(195, 104);
            this.Camera.Name = "Camera";
            this.Camera.Size = new System.Drawing.Size(146, 21);
            this.Camera.TabIndex = 16;
            this.Camera.Text = "Select Scan Device";
            this.Camera.Visible = false;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(82)))), ((int)(((byte)(35)))));
            this.label9.Location = new System.Drawing.Point(208, 188);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(91, 21);
            this.label9.TabIndex = 71;
            this.label9.Text = "Select DSN";
            this.label9.Visible = false;
            // 
            // bunifuGradientPanel1
            // 
            this.bunifuGradientPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuGradientPanel1.BackgroundImage")));
            this.bunifuGradientPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuGradientPanel1.Controls.Add(this.btnHelp);
            this.bunifuGradientPanel1.Controls.Add(this.btnSet);
            this.bunifuGradientPanel1.Controls.Add(this.btnClose);
            this.bunifuGradientPanel1.Controls.Add(this.lblConnectionStatus);
            this.bunifuGradientPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.bunifuGradientPanel1.GradientBottomLeft = System.Drawing.Color.White;
            this.bunifuGradientPanel1.GradientBottomRight = System.Drawing.Color.White;
            this.bunifuGradientPanel1.GradientTopLeft = System.Drawing.Color.White;
            this.bunifuGradientPanel1.GradientTopRight = System.Drawing.Color.White;
            this.bunifuGradientPanel1.Location = new System.Drawing.Point(0, 0);
            this.bunifuGradientPanel1.Name = "bunifuGradientPanel1";
            this.bunifuGradientPanel1.Quality = 10;
            this.bunifuGradientPanel1.Size = new System.Drawing.Size(1095, 78);
            this.bunifuGradientPanel1.TabIndex = 72;
            // 
            // btnHelp
            // 
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
            this.btnHelp.Location = new System.Drawing.Point(636, 20);
            this.btnHelp.Name = "btnHelp";
            stateProperties21.BorderColor = System.Drawing.Color.White;
            stateProperties21.BorderRadius = 20;
            stateProperties21.BorderThickness = 0;
            stateProperties21.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(179)))), ((int)(((byte)(179)))));
            stateProperties21.IconLeftImage = null;
            stateProperties21.IconRightImage = null;
            this.btnHelp.onHoverState = stateProperties21;
            this.btnHelp.Size = new System.Drawing.Size(29, 31);
            this.btnHelp.TabIndex = 39;
            this.btnHelp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSet
            // 
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
            this.btnSet.Location = new System.Drawing.Point(595, 20);
            this.btnSet.Name = "btnSet";
            stateProperties22.BorderColor = System.Drawing.Color.White;
            stateProperties22.BorderRadius = 20;
            stateProperties22.BorderThickness = 0;
            stateProperties22.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(179)))), ((int)(((byte)(179)))));
            stateProperties22.IconLeftImage = null;
            stateProperties22.IconRightImage = null;
            this.btnSet.onHoverState = stateProperties22;
            this.btnSet.Size = new System.Drawing.Size(35, 31);
            this.btnSet.TabIndex = 38;
            this.btnSet.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnSet.Click += new System.EventHandler(this.btnSet_Click);
            // 
            // btnClose
            // 
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
            this.btnClose.Location = new System.Drawing.Point(670, 20);
            this.btnClose.Name = "btnClose";
            stateProperties23.BorderColor = System.Drawing.Color.White;
            stateProperties23.BorderRadius = 20;
            stateProperties23.BorderThickness = 0;
            stateProperties23.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(179)))), ((int)(((byte)(179)))));
            stateProperties23.IconLeftImage = null;
            stateProperties23.IconRightImage = null;
            this.btnClose.onHoverState = stateProperties23;
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
            this.ConnectBtn.ButtonText = "Connect";
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
            this.ConnectBtn.Location = new System.Drawing.Point(452, 188);
            this.ConnectBtn.Name = "ConnectBtn";
            stateProperties24.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(215)))), ((int)(((byte)(215)))));
            stateProperties24.BorderRadius = 20;
            stateProperties24.BorderThickness = 3;
            stateProperties24.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(82)))), ((int)(((byte)(35)))));
            stateProperties24.IconLeftImage = null;
            stateProperties24.IconRightImage = null;
            this.ConnectBtn.onHoverState = stateProperties24;
            this.ConnectBtn.Size = new System.Drawing.Size(159, 106);
            this.ConnectBtn.TabIndex = 75;
            this.ConnectBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ConnectBtn.Click += new System.EventHandler(this.ConnectBtn_Click);
            // 
            // sfDataGrid1
            // 
            this.sfDataGrid1.AccessibleName = "Table";
            this.sfDataGrid1.Location = new System.Drawing.Point(412, 84);
            this.sfDataGrid1.Name = "sfDataGrid1";
            this.sfDataGrid1.Size = new System.Drawing.Size(119, 70);
            this.sfDataGrid1.TabIndex = 76;
            this.sfDataGrid1.Text = "sfDataGrid1";
            // 
            // Column1
            // 
            this.Column1.HeaderText = "S/N";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
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
            // AddSalesItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1095, 640);
            this.Controls.Add(this.sfDataGrid1);
            this.Controls.Add(this.ConnectBtn);
            this.Controls.Add(this.bunifuGradientPanel1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cameraTypes);
            this.Controls.Add(this.Camera);
            this.Controls.Add(this.txtQRCode);
            this.Controls.Add(this.cboListOfDSN);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.scanBtn);
            this.Controls.Add(this.grvData);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AddSalesItem";
            this.Text = "AddSalesItem";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AddSalesItem_FormClosing);
            this.Load += new System.EventHandler(this.AddSalesItem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grvData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.bunifuGradientPanel1.ResumeLayout(false);
            this.bunifuGradientPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sfDataGrid1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView grvData;
        private System.Windows.Forms.Label lblConnectionStatus;
        private System.Windows.Forms.ComboBox cboListOfDSN;
        private Bunifu.Framework.UI.BunifuFlatButton scanBtn;
        private System.Windows.Forms.TextBox txtQRCode;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.ComboBox cameraTypes;
        private System.Windows.Forms.Label Camera;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label9;
        private Bunifu.Framework.UI.BunifuGradientPanel bunifuGradientPanel1;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton btnHelp;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton btnSet;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton btnClose;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton ConnectBtn;
        private Syncfusion.WinForms.DataGrid.SfDataGrid sfDataGrid1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
    }
}