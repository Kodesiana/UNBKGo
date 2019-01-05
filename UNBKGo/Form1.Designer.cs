namespace UNBKGo
{
    partial class Form1
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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
            "Profile"}, -1, System.Drawing.SystemColors.WindowText, System.Drawing.SystemColors.Window, new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold));
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("Last sync");
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem("IP address");
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem("Physical address");
            System.Windows.Forms.ListViewItem listViewItem5 = new System.Windows.Forms.ListViewItem("App: Client");
            System.Windows.Forms.ListViewItem listViewItem6 = new System.Windows.Forms.ListViewItem("App: ExamBrowser");
            System.Windows.Forms.ListViewItem listViewItem7 = new System.Windows.Forms.ListViewItem("App: Chrome");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.lblStatus = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblImgStatus = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.txtSubnet = new System.Windows.Forms.TextBox();
            this.txtGateway = new System.Windows.Forms.TextBox();
            this.txtPrimaryDns = new System.Windows.Forms.TextBox();
            this.txtSecondaryDns = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lvProfile = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label3 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.cmdUseAuto = new System.Windows.Forms.LinkLabel();
            this.cmdApply = new System.Windows.Forms.Button();
            this.imgTabs = new System.Windows.Forms.ImageList(this.components);
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(161, 21);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(103, 15);
            this.lblStatus.TabIndex = 0;
            this.lblStatus.Text = "Waiting for server.";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Highlight;
            this.panel1.Controls.Add(this.lblImgStatus);
            this.panel1.Controls.Add(this.lblStatus);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.ForeColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(399, 56);
            this.panel1.TabIndex = 1;
            // 
            // lblImgStatus
            // 
            this.lblImgStatus.AutoSize = true;
            this.lblImgStatus.Font = new System.Drawing.Font("Marlett", 19F);
            this.lblImgStatus.Location = new System.Drawing.Point(122, 15);
            this.lblImgStatus.Name = "lblImgStatus";
            this.lblImgStatus.Size = new System.Drawing.Size(38, 26);
            this.lblImgStatus.TabIndex = 1;
            this.lblImgStatus.Text = "n";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(57, 18);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(60, 15);
            this.label10.TabIndex = 0;
            this.label10.Text = "IP address";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(57, 45);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(75, 15);
            this.label11.TabIndex = 1;
            this.label11.Text = "Subnet mask";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(57, 72);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(92, 15);
            this.label12.TabIndex = 2;
            this.label12.Text = "Default gateway";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(57, 106);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(74, 15);
            this.label13.TabIndex = 3;
            this.label13.Text = "Primary DNS";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(57, 133);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(88, 15);
            this.label14.TabIndex = 4;
            this.label14.Text = "Secondary DNS";
            // 
            // txtIP
            // 
            this.txtIP.Font = new System.Drawing.Font("Consolas", 10F);
            this.txtIP.Location = new System.Drawing.Point(160, 15);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(143, 23);
            this.txtIP.TabIndex = 5;
            this.txtIP.Text = "192.168.1.1";
            // 
            // txtSubnet
            // 
            this.txtSubnet.Font = new System.Drawing.Font("Consolas", 10F);
            this.txtSubnet.Location = new System.Drawing.Point(160, 42);
            this.txtSubnet.Name = "txtSubnet";
            this.txtSubnet.Size = new System.Drawing.Size(143, 23);
            this.txtSubnet.TabIndex = 6;
            // 
            // txtGateway
            // 
            this.txtGateway.Font = new System.Drawing.Font("Consolas", 10F);
            this.txtGateway.Location = new System.Drawing.Point(160, 69);
            this.txtGateway.Name = "txtGateway";
            this.txtGateway.Size = new System.Drawing.Size(143, 23);
            this.txtGateway.TabIndex = 7;
            // 
            // txtPrimaryDns
            // 
            this.txtPrimaryDns.Font = new System.Drawing.Font("Consolas", 10F);
            this.txtPrimaryDns.Location = new System.Drawing.Point(160, 103);
            this.txtPrimaryDns.Name = "txtPrimaryDns";
            this.txtPrimaryDns.Size = new System.Drawing.Size(143, 23);
            this.txtPrimaryDns.TabIndex = 8;
            // 
            // txtSecondaryDns
            // 
            this.txtSecondaryDns.Font = new System.Drawing.Font("Consolas", 10F);
            this.txtSecondaryDns.Location = new System.Drawing.Point(160, 130);
            this.txtSecondaryDns.Name = "txtSecondaryDns";
            this.txtSecondaryDns.Size = new System.Drawing.Size(143, 23);
            this.txtSecondaryDns.TabIndex = 9;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.ImageList = this.imgTabs;
            this.tabControl1.Location = new System.Drawing.Point(12, 67);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(375, 250);
            this.tabControl1.TabIndex = 12;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lvProfile);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.ImageIndex = 0;
            this.tabPage1.Location = new System.Drawing.Point(4, 37);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(367, 209);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Control";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lvProfile
            // 
            this.lvProfile.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lvProfile.GridLines = true;
            this.lvProfile.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3,
            listViewItem4,
            listViewItem5,
            listViewItem6,
            listViewItem7});
            this.lvProfile.Location = new System.Drawing.Point(18, 30);
            this.lvProfile.Name = "lvProfile";
            this.lvProfile.Size = new System.Drawing.Size(330, 164);
            this.lvProfile.TabIndex = 28;
            this.lvProfile.UseCompatibleStateImageBehavior = false;
            this.lvProfile.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Field";
            this.columnHeader1.Width = 133;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Value";
            this.columnHeader2.Width = 172;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 15);
            this.label3.TabIndex = 12;
            this.label3.Text = "Current profile:";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.cmdUseAuto);
            this.tabPage2.Controls.Add(this.cmdApply);
            this.tabPage2.Controls.Add(this.txtSecondaryDns);
            this.tabPage2.Controls.Add(this.txtIP);
            this.tabPage2.Controls.Add(this.txtPrimaryDns);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.txtGateway);
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Controls.Add(this.txtSubnet);
            this.tabPage2.Controls.Add(this.label12);
            this.tabPage2.Controls.Add(this.label13);
            this.tabPage2.Controls.Add(this.label14);
            this.tabPage2.ImageIndex = 1;
            this.tabPage2.Location = new System.Drawing.Point(4, 37);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(367, 209);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Network";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // cmdUseAuto
            // 
            this.cmdUseAuto.AutoSize = true;
            this.cmdUseAuto.Enabled = false;
            this.cmdUseAuto.Location = new System.Drawing.Point(114, 173);
            this.cmdUseAuto.Name = "cmdUseAuto";
            this.cmdUseAuto.Size = new System.Drawing.Size(83, 15);
            this.cmdUseAuto.TabIndex = 12;
            this.cmdUseAuto.TabStop = true;
            this.cmdUseAuto.Text = "Use automatic";
            this.cmdUseAuto.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.cmdUseAuto_LinkClicked);
            // 
            // cmdApply
            // 
            this.cmdApply.Enabled = false;
            this.cmdApply.Location = new System.Drawing.Point(203, 169);
            this.cmdApply.Name = "cmdApply";
            this.cmdApply.Size = new System.Drawing.Size(99, 23);
            this.cmdApply.TabIndex = 11;
            this.cmdApply.Text = "Apply";
            this.cmdApply.UseVisualStyleBackColor = true;
            this.cmdApply.Click += new System.EventHandler(this.cmdApply_Click);
            // 
            // imgTabs
            // 
            this.imgTabs.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgTabs.ImageStream")));
            this.imgTabs.TransparentColor = System.Drawing.Color.Transparent;
            this.imgTabs.Images.SetKeyName(0, "icons8-control-panel-30.png");
            this.imgTabs.Images.SetKeyName(1, "icons8-hub-30.png");
            this.imgTabs.Images.SetKeyName(2, "icons8-settings-30.png");
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(399, 329);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "UNBKGo Client";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblImgStatus;
        private System.Windows.Forms.TextBox txtSecondaryDns;
        private System.Windows.Forms.TextBox txtPrimaryDns;
        private System.Windows.Forms.TextBox txtGateway;
        private System.Windows.Forms.TextBox txtSubnet;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ImageList imgTabs;
        private System.Windows.Forms.Button cmdApply;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.LinkLabel cmdUseAuto;
        private System.Windows.Forms.ListView lvProfile;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
    }
}

