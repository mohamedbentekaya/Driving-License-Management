namespace Presentation
{
    partial class frmReleaseDetainedLicense
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
            this.linklblShowNewLicenseInfo = new System.Windows.Forms.LinkLabel();
            this.linklblShowLicenseHistory = new System.Windows.Forms.LinkLabel();
            this.btnRelease = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.gbFilter = new System.Windows.Forms.GroupBox();
            this.btnSearchPerson = new System.Windows.Forms.Button();
            this.txtbFilter = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTestAppointmentMode = new System.Windows.Forms.Label();
            this.ctrlLicenseCard1 = new Presentation.Controles.ctrlLicenseCard();
            this.ctrlDetainLicenseInfo1 = new Presentation.Controles.ctrlDetainLicenseInfo();
            this.gbFilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // linklblShowNewLicenseInfo
            // 
            this.linklblShowNewLicenseInfo.AutoSize = true;
            this.linklblShowNewLicenseInfo.Location = new System.Drawing.Point(207, 735);
            this.linklblShowNewLicenseInfo.Name = "linklblShowNewLicenseInfo";
            this.linklblShowNewLicenseInfo.Size = new System.Drawing.Size(144, 16);
            this.linklblShowNewLicenseInfo.TabIndex = 140;
            this.linklblShowNewLicenseInfo.TabStop = true;
            this.linklblShowNewLicenseInfo.Text = "Show New License Info";
            this.linklblShowNewLicenseInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linklblShowNewLicenseInfo_LinkClicked);
            // 
            // linklblShowLicenseHistory
            // 
            this.linklblShowLicenseHistory.AutoSize = true;
            this.linklblShowLicenseHistory.Location = new System.Drawing.Point(21, 735);
            this.linklblShowLicenseHistory.Name = "linklblShowLicenseHistory";
            this.linklblShowLicenseHistory.Size = new System.Drawing.Size(135, 16);
            this.linklblShowLicenseHistory.TabIndex = 139;
            this.linklblShowLicenseHistory.TabStop = true;
            this.linklblShowLicenseHistory.Text = "Show License History";
            this.linklblShowLicenseHistory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linklblShowLicenseHistory_LinkClicked);
            // 
            // btnRelease
            // 
            this.btnRelease.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRelease.Image = global::Presentation.Properties.Resources.Show_License_btn;
            this.btnRelease.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRelease.Location = new System.Drawing.Point(778, 725);
            this.btnRelease.Name = "btnRelease";
            this.btnRelease.Size = new System.Drawing.Size(125, 35);
            this.btnRelease.TabIndex = 138;
            this.btnRelease.Text = "Release";
            this.btnRelease.UseVisualStyleBackColor = true;
            this.btnRelease.Click += new System.EventHandler(this.btnRelease_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::Presentation.Properties.Resources.close_button;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(668, 725);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(104, 35);
            this.btnClose.TabIndex = 137;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // gbFilter
            // 
            this.gbFilter.Controls.Add(this.btnSearchPerson);
            this.gbFilter.Controls.Add(this.txtbFilter);
            this.gbFilter.Controls.Add(this.label1);
            this.gbFilter.Location = new System.Drawing.Point(16, 49);
            this.gbFilter.Name = "gbFilter";
            this.gbFilter.Size = new System.Drawing.Size(655, 74);
            this.gbFilter.TabIndex = 135;
            this.gbFilter.TabStop = false;
            this.gbFilter.Text = "Filter";
            // 
            // btnSearchPerson
            // 
            this.btnSearchPerson.BackgroundImage = global::Presentation.Properties.Resources.driving_license_services;
            this.btnSearchPerson.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSearchPerson.Location = new System.Drawing.Point(338, 27);
            this.btnSearchPerson.Name = "btnSearchPerson";
            this.btnSearchPerson.Size = new System.Drawing.Size(49, 38);
            this.btnSearchPerson.TabIndex = 13;
            this.btnSearchPerson.UseVisualStyleBackColor = true;
            this.btnSearchPerson.Click += new System.EventHandler(this.btnSearchPerson_Click);
            // 
            // txtbFilter
            // 
            this.txtbFilter.Location = new System.Drawing.Point(130, 35);
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
            // lblTestAppointmentMode
            // 
            this.lblTestAppointmentMode.AutoSize = true;
            this.lblTestAppointmentMode.Font = new System.Drawing.Font("Microsoft YaHei", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTestAppointmentMode.ForeColor = System.Drawing.Color.Peru;
            this.lblTestAppointmentMode.Location = new System.Drawing.Point(252, 9);
            this.lblTestAppointmentMode.Name = "lblTestAppointmentMode";
            this.lblTestAppointmentMode.Size = new System.Drawing.Size(367, 37);
            this.lblTestAppointmentMode.TabIndex = 134;
            this.lblTestAppointmentMode.Text = "Release Detained License";
            // 
            // ctrlLicenseCard1
            // 
            this.ctrlLicenseCard1.BackColor = System.Drawing.Color.Linen;
            this.ctrlLicenseCard1.Location = new System.Drawing.Point(16, 129);
            this.ctrlLicenseCard1.Name = "ctrlLicenseCard1";
            this.ctrlLicenseCard1.Size = new System.Drawing.Size(885, 348);
            this.ctrlLicenseCard1.TabIndex = 136;
            // 
            // ctrlDetainLicenseInfo1
            // 
            this.ctrlDetainLicenseInfo1.BackColor = System.Drawing.Color.Linen;
            this.ctrlDetainLicenseInfo1.Location = new System.Drawing.Point(14, 474);
            this.ctrlDetainLicenseInfo1.Name = "ctrlDetainLicenseInfo1";
            this.ctrlDetainLicenseInfo1.Size = new System.Drawing.Size(887, 245);
            this.ctrlDetainLicenseInfo1.TabIndex = 142;
            // 
            // frmReleaseDetainedLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Linen;
            this.ClientSize = new System.Drawing.Size(920, 771);
            this.Controls.Add(this.ctrlDetainLicenseInfo1);
            this.Controls.Add(this.linklblShowNewLicenseInfo);
            this.Controls.Add(this.linklblShowLicenseHistory);
            this.Controls.Add(this.btnRelease);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.ctrlLicenseCard1);
            this.Controls.Add(this.gbFilter);
            this.Controls.Add(this.lblTestAppointmentMode);
            this.Name = "frmReleaseDetainedLicense";
            this.Text = "frmReleaseDetainedLicense";
            this.Load += new System.EventHandler(this.frmReleaseDetainedLicense_Load);
            this.gbFilter.ResumeLayout(false);
            this.gbFilter.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.LinkLabel linklblShowNewLicenseInfo;
        private System.Windows.Forms.LinkLabel linklblShowLicenseHistory;
        private System.Windows.Forms.Button btnRelease;
        private System.Windows.Forms.Button btnClose;
        private Controles.ctrlLicenseCard ctrlLicenseCard1;
        private System.Windows.Forms.GroupBox gbFilter;
        private System.Windows.Forms.Button btnSearchPerson;
        private System.Windows.Forms.TextBox txtbFilter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTestAppointmentMode;
        private Controles.ctrlDetainLicenseInfo ctrlDetainLicenseInfo1;
    }
}