namespace JumpQ_TestApp
{
    partial class FormSelectSV
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
            this.LabelGetConnString = new System.Windows.Forms.Label();
            this.groupBoxVersion = new System.Windows.Forms.GroupBox();
            this.lblVersions = new System.Windows.Forms.Label();
            this.cmdVersion = new System.Windows.Forms.Button();
            this.comboVersion = new System.Windows.Forms.ComboBox();
            this.groupBoxServer = new System.Windows.Forms.GroupBox();
            this.cmdServer = new System.Windows.Forms.Button();
            this.cmdStart = new System.Windows.Forms.Button();
            this.comboServer = new System.Windows.Forms.ComboBox();
            this.groupBoxVersion.SuspendLayout();
            this.groupBoxServer.SuspendLayout();
            this.SuspendLayout();
            // 
            // LabelGetConnString
            // 
            this.LabelGetConnString.Location = new System.Drawing.Point(10, 14);
            this.LabelGetConnString.Name = "LabelGetConnString";
            this.LabelGetConnString.Size = new System.Drawing.Size(344, 64);
            this.LabelGetConnString.TabIndex = 38;
            this.LabelGetConnString.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBoxVersion
            // 
            this.groupBoxVersion.Controls.Add(this.lblVersions);
            this.groupBoxVersion.Controls.Add(this.cmdVersion);
            this.groupBoxVersion.Controls.Add(this.comboVersion);
            this.groupBoxVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxVersion.Location = new System.Drawing.Point(10, 174);
            this.groupBoxVersion.Name = "groupBoxVersion";
            this.groupBoxVersion.Size = new System.Drawing.Size(344, 72);
            this.groupBoxVersion.TabIndex = 37;
            this.groupBoxVersion.TabStop = false;
            this.groupBoxVersion.Text = " Step - 2: Select a version  ";
            // 
            // lblVersions
            // 
            this.lblVersions.Location = new System.Drawing.Point(16, 48);
            this.lblVersions.Name = "lblVersions";
            this.lblVersions.Size = new System.Drawing.Size(232, 16);
            this.lblVersions.TabIndex = 35;
            // 
            // cmdVersion
            // 
            this.cmdVersion.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmdVersion.Location = new System.Drawing.Point(264, 48);
            this.cmdVersion.Name = "cmdVersion";
            this.cmdVersion.Size = new System.Drawing.Size(72, 16);
            this.cmdVersion.TabIndex = 2;
            this.cmdVersion.Text = "OK";
            this.cmdVersion.Click += new System.EventHandler(this.cmdVersion_Click);
            // 
            // comboVersion
            // 
            this.comboVersion.Location = new System.Drawing.Point(16, 24);
            this.comboVersion.Name = "comboVersion";
            this.comboVersion.Size = new System.Drawing.Size(320, 21);
            this.comboVersion.TabIndex = 0;
            // 
            // groupBoxServer
            // 
            this.groupBoxServer.Controls.Add(this.cmdServer);
            this.groupBoxServer.Controls.Add(this.cmdStart);
            this.groupBoxServer.Controls.Add(this.comboServer);
            this.groupBoxServer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxServer.Location = new System.Drawing.Point(10, 86);
            this.groupBoxServer.Name = "groupBoxServer";
            this.groupBoxServer.Size = new System.Drawing.Size(344, 72);
            this.groupBoxServer.TabIndex = 36;
            this.groupBoxServer.TabStop = false;
            this.groupBoxServer.Text = " Step - 1: Select a server ";
            // 
            // cmdServer
            // 
            this.cmdServer.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmdServer.Location = new System.Drawing.Point(264, 48);
            this.cmdServer.Name = "cmdServer";
            this.cmdServer.Size = new System.Drawing.Size(72, 16);
            this.cmdServer.TabIndex = 2;
            this.cmdServer.Text = "OK";
            this.cmdServer.Click += new System.EventHandler(this.cmdServer_Click);
            // 
            // cmdStart
            // 
            this.cmdStart.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmdStart.Location = new System.Drawing.Point(16, 48);
            this.cmdStart.Name = "cmdStart";
            this.cmdStart.Size = new System.Drawing.Size(160, 16);
            this.cmdStart.TabIndex = 1;
            this.cmdStart.Text = "Find all available servers";
            this.cmdStart.Click += new System.EventHandler(this.cmdStart_Click);
            // 
            // comboServer
            // 
            this.comboServer.Location = new System.Drawing.Point(16, 24);
            this.comboServer.Name = "comboServer";
            this.comboServer.Size = new System.Drawing.Size(320, 21);
            this.comboServer.TabIndex = 0;
            // 
            // FormSelectSV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(362, 262);
            this.Controls.Add(this.LabelGetConnString);
            this.Controls.Add(this.groupBoxVersion);
            this.Controls.Add(this.groupBoxServer);
            this.Name = "FormSelectSV";
            this.Text = "Select QBPOS Server and Version";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormSelectSV_FormClosed);
            this.groupBoxVersion.ResumeLayout(false);
            this.groupBoxServer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Label LabelGetConnString;
        public System.Windows.Forms.GroupBox groupBoxVersion;
        public System.Windows.Forms.Label lblVersions;
        public System.Windows.Forms.Button cmdVersion;
        public System.Windows.Forms.ComboBox comboVersion;
        public System.Windows.Forms.GroupBox groupBoxServer;
        public System.Windows.Forms.Button cmdServer;
        public System.Windows.Forms.Button cmdStart;
        public System.Windows.Forms.ComboBox comboServer;
    }
}