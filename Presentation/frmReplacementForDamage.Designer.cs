namespace Presentation
{
    partial class frmReplacementForDamage
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
            this.gbFilter = new System.Windows.Forms.GroupBox();
            this.btnSearchPerson = new System.Windows.Forms.Button();
            this.txtbFilter = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTestAppointmentMode = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdbLostLicense = new System.Windows.Forms.RadioButton();
            this.radbDamageLicense = new System.Windows.Forms.RadioButton();
            this.btnIssueReplacement = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.ctrlAppReplacementInfo1 = new Presentation.Controles.ctrlAppReplacementInfo();
            this.ctrlLicenseCard1 = new Presentation.Controles.ctrlLicenseCard();
            this.gbFilter.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // linklblShowNewLicenseInfo
            // 
            this.linklblShowNewLicenseInfo.AutoSize = true;
            this.linklblShowNewLicenseInfo.Location = new System.Drawing.Point(204, 676);
            this.linklblShowNewLicenseInfo.Name = "linklblShowNewLicenseInfo";
            this.linklblShowNewLicenseInfo.Size = new System.Drawing.Size(144, 16);
            this.linklblShowNewLicenseInfo.TabIndex = 130;
            this.linklblShowNewLicenseInfo.TabStop = true;
            this.linklblShowNewLicenseInfo.Text = "Show New License Info";
            this.linklblShowNewLicenseInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linklblShowNewLicenseInfo_LinkClicked);
            // 
            // linklblShowLicenseHistory
            // 
            this.linklblShowLicenseHistory.AutoSize = true;
            this.linklblShowLicenseHistory.Location = new System.Drawing.Point(18, 676);
            this.linklblShowLicenseHistory.Name = "linklblShowLicenseHistory";
            this.linklblShowLicenseHistory.Size = new System.Drawing.Size(135, 16);
            this.linklblShowLicenseHistory.TabIndex = 129;
            this.linklblShowLicenseHistory.TabStop = true;
            this.linklblShowLicenseHistory.Text = "Show License History";
            this.linklblShowLicenseHistory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linklblShowLicenseHistory_LinkClicked);
            // 
            // gbFilter
            // 
            this.gbFilter.Controls.Add(this.btnSearchPerson);
            this.gbFilter.Controls.Add(this.txtbFilter);
            this.gbFilter.Controls.Add(this.label1);
            this.gbFilter.Location = new System.Drawing.Point(12, 58);
            this.gbFilter.Name = "gbFilter";
            this.gbFilter.Size = new System.Drawing.Size(655, 74);
            this.gbFilter.TabIndex = 125;
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
            this.lblTestAppointmentMode.Location = new System.Drawing.Point(179, 18);
            this.lblTestAppointmentMode.Name = "lblTestAppointmentMode";
            this.lblTestAppointmentMode.Size = new System.Drawing.Size(488, 37);
            this.lblTestAppointmentMode.TabIndex = 124;
            this.lblTestAppointmentMode.Text = "Replacement For Damage License";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdbLostLicense);
            this.groupBox1.Controls.Add(this.radbDamageLicense);
            this.groupBox1.Location = new System.Drawing.Point(674, 58);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(217, 74);
            this.groupBox1.TabIndex = 132;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // rdbLostLicense
            // 
            this.rdbLostLicense.AutoSize = true;
            this.rdbLostLicense.Location = new System.Drawing.Point(7, 48);
            this.rdbLostLicense.Name = "rdbLostLicense";
            this.rdbLostLicense.Size = new System.Drawing.Size(103, 20);
            this.rdbLostLicense.TabIndex = 1;
            this.rdbLostLicense.Text = "Lost License";
            this.rdbLostLicense.UseVisualStyleBackColor = true;
            this.rdbLostLicense.CheckedChanged += new System.EventHandler(this.rdbLostLicense_CheckedChanged);
            // 
            // radbDamageLicense
            // 
            this.radbDamageLicense.AutoSize = true;
            this.radbDamageLicense.Checked = true;
            this.radbDamageLicense.Location = new System.Drawing.Point(7, 22);
            this.radbDamageLicense.Name = "radbDamageLicense";
            this.radbDamageLicense.Size = new System.Drawing.Size(131, 20);
            this.radbDamageLicense.TabIndex = 0;
            this.radbDamageLicense.TabStop = true;
            this.radbDamageLicense.Text = "Damage License";
            this.radbDamageLicense.UseVisualStyleBackColor = true;
            this.radbDamageLicense.CheckedChanged += new System.EventHandler(this.radbDamageLicense_CheckedChanged);
            // 
            // btnIssueReplacement
            // 
            this.btnIssueReplacement.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIssueReplacement.Image = global::Presentation.Properties.Resources.Show_License_btn;
            this.btnIssueReplacement.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIssueReplacement.Location = new System.Drawing.Point(674, 666);
            this.btnIssueReplacement.Name = "btnIssueReplacement";
            this.btnIssueReplacement.Size = new System.Drawing.Size(226, 35);
            this.btnIssueReplacement.TabIndex = 128;
            this.btnIssueReplacement.Text = "Issue Replacement";
            this.btnIssueReplacement.UseVisualStyleBackColor = true;
            this.btnIssueReplacement.Click += new System.EventHandler(this.btnIssueReplacement_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::Presentation.Properties.Resources.close_button;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(563, 666);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(104, 35);
            this.btnClose.TabIndex = 127;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ctrlAppReplacementInfo1
            // 
            this.ctrlAppReplacementInfo1.BackColor = System.Drawing.Color.Linen;
            this.ctrlAppReplacementInfo1.Location = new System.Drawing.Point(12, 492);
            this.ctrlAppReplacementInfo1.Name = "ctrlAppReplacementInfo1";
            this.ctrlAppReplacementInfo1.Size = new System.Drawing.Size(887, 171);
            this.ctrlAppReplacementInfo1.TabIndex = 133;
            // 
            // ctrlLicenseCard1
            // 
            this.ctrlLicenseCard1.BackColor = System.Drawing.Color.Linen;
            this.ctrlLicenseCard1.Location = new System.Drawing.Point(12, 138);
            this.ctrlLicenseCard1.Name = "ctrlLicenseCard1";
            this.ctrlLicenseCard1.Size = new System.Drawing.Size(885, 348);
            this.ctrlLicenseCard1.TabIndex = 126;
            // 
            // frmReplacementForDamage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Linen;
            this.ClientSize = new System.Drawing.Size(912, 713);
            this.Controls.Add(this.ctrlAppReplacementInfo1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.linklblShowNewLicenseInfo);
            this.Controls.Add(this.linklblShowLicenseHistory);
            this.Controls.Add(this.btnIssueReplacement);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.ctrlLicenseCard1);
            this.Controls.Add(this.gbFilter);
            this.Controls.Add(this.lblTestAppointmentMode);
            this.Name = "frmReplacementForDamage";
            this.Text = "frmReplacementForDamage";
            this.Load += new System.EventHandler(this.frmReplacementForDamage_Load);
            this.gbFilter.ResumeLayout(false);
            this.gbFilter.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.LinkLabel linklblShowNewLicenseInfo;
        private System.Windows.Forms.LinkLabel linklblShowLicenseHistory;
        private System.Windows.Forms.Button btnIssueReplacement;
        private System.Windows.Forms.Button btnClose;
        private Controles.ctrlLicenseCard ctrlLicenseCard1;
        private System.Windows.Forms.GroupBox gbFilter;
        private System.Windows.Forms.Button btnSearchPerson;
        private System.Windows.Forms.TextBox txtbFilter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTestAppointmentMode;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdbLostLicense;
        private System.Windows.Forms.RadioButton radbDamageLicense;
        private Controles.ctrlAppReplacementInfo ctrlAppReplacementInfo1;
    }
}