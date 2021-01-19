namespace JumpQ_TestApp
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.StateProperties stateProperties2 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.StateProperties();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnLogin = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.ChkRemember = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtPassword = new Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox();
            this.TxtUsername = new Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.BtnLogin);
            this.panel1.Controls.Add(this.ChkRemember);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.TxtPassword);
            this.panel1.Controls.Add(this.TxtUsername);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(408, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(359, 449);
            this.panel1.TabIndex = 0;
            // 
            // BtnLogin
            // 
            this.BtnLogin.BackColor = System.Drawing.Color.Transparent;
            this.BtnLogin.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtnLogin.BackgroundImage")));
            this.BtnLogin.ButtonText = "Login";
            this.BtnLogin.ButtonTextMarginLeft = 0;
            this.BtnLogin.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(161)))), ((int)(((byte)(161)))));
            this.BtnLogin.DisabledFillColor = System.Drawing.Color.Gray;
            this.BtnLogin.DisabledForecolor = System.Drawing.Color.White;
            this.BtnLogin.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnLogin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(148)))), ((int)(((byte)(148)))));
            this.BtnLogin.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.BtnLogin.IconPadding = 10;
            this.BtnLogin.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.BtnLogin.IdleBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(148)))), ((int)(((byte)(148)))));
            this.BtnLogin.IdleBorderRadius = 10;
            this.BtnLogin.IdleBorderThickness = 0;
            this.BtnLogin.IdleFillColor = System.Drawing.Color.White;
            this.BtnLogin.IdleIconLeftImage = null;
            this.BtnLogin.IdleIconRightImage = null;
            this.BtnLogin.Location = new System.Drawing.Point(256, 295);
            this.BtnLogin.Name = "BtnLogin";
            stateProperties2.BorderColor = System.Drawing.Color.Gray;
            stateProperties2.BorderRadius = 1;
            stateProperties2.BorderThickness = 1;
            stateProperties2.FillColor = System.Drawing.Color.Gainsboro;
            stateProperties2.IconLeftImage = null;
            stateProperties2.IconRightImage = null;
            this.BtnLogin.onHoverState = stateProperties2;
            this.BtnLogin.Size = new System.Drawing.Size(77, 33);
            this.BtnLogin.TabIndex = 0;
            this.BtnLogin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.BtnLogin.Click += new System.EventHandler(this.BtnLogin_Click);
            // 
            // ChkRemember
            // 
            this.ChkRemember.AutoSize = true;
            this.ChkRemember.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChkRemember.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(148)))), ((int)(((byte)(148)))));
            this.ChkRemember.Location = new System.Drawing.Point(69, 304);
            this.ChkRemember.Name = "ChkRemember";
            this.ChkRemember.Size = new System.Drawing.Size(104, 19);
            this.ChkRemember.TabIndex = 5;
            this.ChkRemember.Text = "Remember me";
            this.ChkRemember.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(148)))), ((int)(((byte)(148)))));
            this.label3.Location = new System.Drawing.Point(65, 226);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Password";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(148)))), ((int)(((byte)(148)))));
            this.label2.Location = new System.Drawing.Point(65, 156);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Username";
            // 
            // TxtPassword
            // 
            this.TxtPassword.AcceptsReturn = false;
            this.TxtPassword.AcceptsTab = false;
            this.TxtPassword.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.TxtPassword.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.TxtPassword.BackColor = System.Drawing.Color.Transparent;
            this.TxtPassword.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("TxtPassword.BackgroundImage")));
            this.TxtPassword.BorderColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(82)))), ((int)(((byte)(35)))));
            this.TxtPassword.BorderColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(161)))), ((int)(((byte)(161)))));
            this.TxtPassword.BorderColorHover = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(82)))), ((int)(((byte)(35)))));
            this.TxtPassword.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(107)))), ((int)(((byte)(107)))));
            this.TxtPassword.BorderRadius = 7;
            this.TxtPassword.BorderThickness = 2;
            this.TxtPassword.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.TxtPassword.DefaultFont = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtPassword.DefaultText = "";
            this.TxtPassword.FillColor = System.Drawing.Color.White;
            this.TxtPassword.HideSelection = true;
            this.TxtPassword.IconLeft = null;
            this.TxtPassword.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.TxtPassword.IconPadding = 10;
            this.TxtPassword.IconRight = null;
            this.TxtPassword.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.TxtPassword.Location = new System.Drawing.Point(63, 250);
            this.TxtPassword.MaxLength = 32767;
            this.TxtPassword.MinimumSize = new System.Drawing.Size(100, 35);
            this.TxtPassword.Modified = false;
            this.TxtPassword.Name = "TxtPassword";
            this.TxtPassword.PasswordChar = '●';
            this.TxtPassword.ReadOnly = false;
            this.TxtPassword.SelectedText = "";
            this.TxtPassword.SelectionLength = 0;
            this.TxtPassword.SelectionStart = 0;
            this.TxtPassword.ShortcutsEnabled = true;
            this.TxtPassword.Size = new System.Drawing.Size(270, 39);
            this.TxtPassword.Style = Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox._Style.Bunifu;
            this.TxtPassword.TabIndex = 2;
            this.TxtPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.TxtPassword.TextMarginLeft = 5;
            this.TxtPassword.TextPlaceholder = "Enter your password";
            this.TxtPassword.UseSystemPasswordChar = true;
            // 
            // TxtUsername
            // 
            this.TxtUsername.AcceptsReturn = false;
            this.TxtUsername.AcceptsTab = false;
            this.TxtUsername.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.TxtUsername.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.TxtUsername.BackColor = System.Drawing.Color.Transparent;
            this.TxtUsername.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("TxtUsername.BackgroundImage")));
            this.TxtUsername.BorderColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(82)))), ((int)(((byte)(35)))));
            this.TxtUsername.BorderColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(161)))), ((int)(((byte)(161)))));
            this.TxtUsername.BorderColorHover = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(82)))), ((int)(((byte)(35)))));
            this.TxtUsername.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(107)))), ((int)(((byte)(107)))));
            this.TxtUsername.BorderRadius = 7;
            this.TxtUsername.BorderThickness = 2;
            this.TxtUsername.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.TxtUsername.DefaultFont = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtUsername.DefaultText = "";
            this.TxtUsername.FillColor = System.Drawing.Color.White;
            this.TxtUsername.HideSelection = true;
            this.TxtUsername.IconLeft = null;
            this.TxtUsername.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.TxtUsername.IconPadding = 10;
            this.TxtUsername.IconRight = null;
            this.TxtUsername.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.TxtUsername.Location = new System.Drawing.Point(63, 180);
            this.TxtUsername.MaxLength = 32767;
            this.TxtUsername.MinimumSize = new System.Drawing.Size(100, 35);
            this.TxtUsername.Modified = false;
            this.TxtUsername.Name = "TxtUsername";
            this.TxtUsername.PasswordChar = '\0';
            this.TxtUsername.ReadOnly = false;
            this.TxtUsername.SelectedText = "";
            this.TxtUsername.SelectionLength = 0;
            this.TxtUsername.SelectionStart = 0;
            this.TxtUsername.ShortcutsEnabled = true;
            this.TxtUsername.Size = new System.Drawing.Size(270, 39);
            this.TxtUsername.Style = Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox._Style.Bunifu;
            this.TxtUsername.TabIndex = 1;
            this.TxtUsername.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.TxtUsername.TextMarginLeft = 5;
            this.TxtUsername.TextPlaceholder = "Enter your username";
            this.TxtUsername.UseSystemPasswordChar = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(111, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(183, 45);
            this.label1.TabIndex = 0;
            this.label1.Text = "Staff Login";
            // 
            // panel2
            // 
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(408, 449);
            this.panel2.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(32, 94);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(343, 290);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // Login
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(767, 449);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(783, 488);
            this.MinimumSize = new System.Drawing.Size(783, 488);
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "JumpQ Konnect";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox TxtPassword;
        private Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox TxtUsername;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton BtnLogin;
        private System.Windows.Forms.CheckBox ChkRemember;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}