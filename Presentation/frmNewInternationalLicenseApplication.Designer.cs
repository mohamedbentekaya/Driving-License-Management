namespace Presentation
{
    partial class frmNewInternationalLicenseApplication
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
            this.lblTestAppointmentMode = new System.Windows.Forms.Label();
            this.gbFilter = new System.Windows.Forms.GroupBox();
            this.btnSearchPerson = new System.Windows.Forms.Button();
            this.txtbFilter = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnIssue = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.linklblShowLicenseHistory = new System.Windows.Forms.LinkLabel();
            this.linklblShowLicenseInfo = new System.Windows.Forms.LinkLabel();
            this.ctrlInternationalAppInfo1 = new Presentation.Controles.ctrlInternationalAppInfo();
            this.ctrlLicenseCard1 = new Presentation.Controles.ctrlLicenseCard();
            this.gbFilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTestAppointmentMode
            // 
            this.lblTestAppointmentMode.AutoSize = true;
            this.lblTestAppointmentMode.Font = new System.Drawing.Font("Microsoft YaHei", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTestAppointmentMode.ForeColor = System.Drawing.Color.Peru;
            this.lblTestAppointmentMode.Location = new System.Drawing.Point(203, 9);
            this.lblTestAppointmentMode.Name = "lblTestAppointmentMode";
            this.lblTestAppointmentMode.Size = new System.Drawing.Size(476, 37);
            this.lblTestAppointmentMode.TabIndex = 4;
            this.lblTestAppointmentMode.Text = "International License Application";
            // 
            // gbFilter
            // 
            this.gbFilter.Controls.Add(this.btnSearchPerson);
            this.gbFilter.Controls.Add(this.txtbFilter);
            this.gbFilter.Controls.Add(this.label1);
            this.gbFilter.Location = new System.Drawing.Point(24, 74);
            this.gbFilter.Name = "gbFilter";
            this.gbFilter.Size = new System.Drawing.Size(655, 101);
            this.gbFilter.TabIndex = 5;
            this.gbFilter.TabStop = false;
            this.gbFilter.Text = "Filter";
            // 
            // btnSearchPerson
            // 
            this.btnSearchPerson.BackgroundImage = global::Presentation.Properties.Resources.driving_license_services;
            this.btnSearchPerson.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSearchPerson.Location = new System.Drawing.Point(332, 27);
            this.btnSearchPerson.Name = "btnSearchPerson";
            this.btnSearchPerson.Size = new System.Drawing.Size(49, 38);
            this.btnSearchPerson.TabIndex = 13;
            this.btnSearchPerson.UseVisualStyleBackColor = true;
            this.btnSearchPerson.Click += new System.EventHandler(this.btnSearchPerson_Click);
            // 
            // txtbFilter
            // 
            this.txtbFilter.Location = new System.Drawing.Point(126, 35);
            this.txtbFilter.Multiline = true;
            this.txtbFilter.Name = "txtbFilter";
            this.txtbFilter.Size = new System.Drawing.Size(187, 23);
            this.txtbFilter.TabIndex = 12;
            this.txtbFilter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbFilter_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(19, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 18);
            this.label1.TabIndex = 10;
            this.label1.Text = "License ID:";
            // 
            // btnIssue
            // 
            this.btnIssue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIssue.Image = global::Presentation.Properties.Resources.Show_License_btn;
            this.btnIssue.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIssue.Location = new System.Drawing.Point(805, 730);
            this.btnIssue.Name = "btnIssue";
            this.btnIssue.Size = new System.Drawing.Size(98, 35);
            this.btnIssue.TabIndex = 108;
            this.btnIssue.Text = "Issue";
            this.btnIssue.UseVisualStyleBackColor = true;
            this.btnIssue.Click += new System.EventHandler(this.btnIssue_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::Presentation.Properties.Resources.close_button;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(705, 730);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(98, 35);
            this.btnClose.TabIndex = 107;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // linklblShowLicenseHistory
            // 
            this.linklblShowLicenseHistory.AutoSize = true;
            this.linklblShowLicenseHistory.Location = new System.Drawing.Point(21, 740);
            this.linklblShowLicenseHistory.Name = "linklblShowLicenseHistory";
            this.linklblShowLicenseHistory.Size = new System.Drawing.Size(135, 16);
            this.linklblShowLicenseHistory.TabIndex = 109;
            this.linklblShowLicenseHistory.TabStop = true;
            this.linklblShowLicenseHistory.Text = "Show License History";
            this.linklblShowLicenseHistory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linklblShowLicenseHistory_LinkClicked);
            // 
            // linklblShowLicenseInfo
            // 
            this.linklblShowLicenseInfo.AutoSize = true;
            this.linklblShowLicenseInfo.Location = new System.Drawing.Point(207, 740);
            this.linklblShowLicenseInfo.Name = "linklblShowLicenseInfo";
            this.linklblShowLicenseInfo.Size = new System.Drawing.Size(114, 16);
            this.linklblShowLicenseInfo.TabIndex = 110;
            this.linklblShowLicenseInfo.TabStop = true;
            this.linklblShowLicenseInfo.Text = "Show License Info";
            this.linklblShowLicenseInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linklblShowLicenseInfo_LinkClicked);
            // 
            // ctrlInternationalAppInfo1
            // 
            this.ctrlInternationalAppInfo1.BackColor = System.Drawing.Color.Linen;
            this.ctrlInternationalAppInfo1.Location = new System.Drawing.Point(24, 529);
            this.ctrlInternationalAppInfo1.Name = "ctrlInternationalAppInfo1";
            this.ctrlInternationalAppInfo1.Size = new System.Drawing.Size(882, 203);
            this.ctrlInternationalAppInfo1.TabIndex = 7;
            // 
            // ctrlLicenseCard1
            // 
            this.ctrlLicenseCard1.BackColor = System.Drawing.Color.Linen;
            this.ctrlLicenseCard1.Location = new System.Drawing.Point(24, 181);
            this.ctrlLicenseCard1.Name = "ctrlLicenseCard1";
            this.ctrlLicenseCard1.Size = new System.Drawing.Size(885, 342);
            this.ctrlLicenseCard1.TabIndex = 6;
            // 
            // frmNewInternationalLicenseApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Linen;
            this.ClientSize = new System.Drawing.Size(929, 777);
            this.Controls.Add(this.linklblShowLicenseInfo);
            this.Controls.Add(this.linklblShowLicenseHistory);
            this.Controls.Add(this.btnIssue);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.ctrlInternationalAppInfo1);
            this.Controls.Add(this.ctrlLicenseCard1);
            this.Controls.Add(this.gbFilter);
            this.Controls.Add(this.lblTestAppointmentMode);
            this.Name = "frmNewInternationalLicenseApplication";
            this.Text = "frmNewInternationalLicenseApplication";
            this.Load += new System.EventHandler(this.frmNewInternationalLicenseApplication_Load);
            this.gbFilter.ResumeLayout(false);
            this.gbFilter.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTestAppointmentMode;
        private System.Windows.Forms.GroupBox gbFilter;
        private System.Windows.Forms.Button btnSearchPerson;
        private System.Windows.Forms.TextBox txtbFilter;
        private System.Windows.Forms.Label label1;
        private Controles.ctrlLicenseCard ctrlLicenseCard1;
        private Controles.ctrlInternationalAppInfo ctrlInternationalAppInfo1;
        private System.Windows.Forms.Button btnIssue;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.LinkLabel linklblShowLicenseHistory;
        private System.Windows.Forms.LinkLabel linklblShowLicenseInfo;
    }
}