namespace Presentation
{
    partial class frmManageLocalDrivingLicenseApplication
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
            this.lblLocalDrivingLicenseApplicationCount = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtbManageLocalDrivingLicenseApplication = new System.Windows.Forms.TextBox();
            this.cbFilter = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvManageLocalDrivingLicenseApplication = new System.Windows.Forms.DataGridView();
            this.contextMenuManageLocalDrivingLicenseApplication = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cancelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SechduleTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sechduleVisionTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sechduleWritenTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.secToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.IssueDrivingLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showPersonLicenseHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvManageLocalDrivingLicenseApplication)).BeginInit();
            this.contextMenuManageLocalDrivingLicenseApplication.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblLocalDrivingLicenseApplicationCount
            // 
            this.lblLocalDrivingLicenseApplicationCount.AutoSize = true;
            this.lblLocalDrivingLicenseApplicationCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLocalDrivingLicenseApplicationCount.Location = new System.Drawing.Point(126, 662);
            this.lblLocalDrivingLicenseApplicationCount.Name = "lblLocalDrivingLicenseApplicationCount";
            this.lblLocalDrivingLicenseApplicationCount.Size = new System.Drawing.Size(0, 18);
            this.lblLocalDrivingLicenseApplicationCount.TabIndex = 33;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(29, 662);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 18);
            this.label3.TabIndex = 32;
            this.label3.Text = "# Records:";
            // 
            // txtbManageLocalDrivingLicenseApplication
            // 
            this.txtbManageLocalDrivingLicenseApplication.Location = new System.Drawing.Point(266, 275);
            this.txtbManageLocalDrivingLicenseApplication.Name = "txtbManageLocalDrivingLicenseApplication";
            this.txtbManageLocalDrivingLicenseApplication.Size = new System.Drawing.Size(197, 22);
            this.txtbManageLocalDrivingLicenseApplication.TabIndex = 31;
            this.txtbManageLocalDrivingLicenseApplication.TextChanged += new System.EventHandler(this.txtbManageLocalDrivingLicenseApplication_TextChanged);
            this.txtbManageLocalDrivingLicenseApplication.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtbManageLocalDrivingLicenseApplication_KeyDown);
            this.txtbManageLocalDrivingLicenseApplication.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbManageLocalDrivingLicenseApplication_KeyPress);
            // 
            // cbFilter
            // 
            this.cbFilter.FormattingEnabled = true;
            this.cbFilter.Location = new System.Drawing.Point(111, 273);
            this.cbFilter.Name = "cbFilter";
            this.cbFilter.Size = new System.Drawing.Size(149, 24);
            this.cbFilter.TabIndex = 29;
            this.cbFilter.SelectedIndexChanged += new System.EventHandler(this.cbFilter_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(29, 280);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 18);
            this.label2.TabIndex = 28;
            this.label2.Text = "Filter By:";
            // 
            // dgvManageLocalDrivingLicenseApplication
            // 
            this.dgvManageLocalDrivingLicenseApplication.AllowUserToAddRows = false;
            this.dgvManageLocalDrivingLicenseApplication.AllowUserToDeleteRows = false;
            this.dgvManageLocalDrivingLicenseApplication.AllowUserToOrderColumns = true;
            this.dgvManageLocalDrivingLicenseApplication.BackgroundColor = System.Drawing.Color.Linen;
            this.dgvManageLocalDrivingLicenseApplication.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvManageLocalDrivingLicenseApplication.ContextMenuStrip = this.contextMenuManageLocalDrivingLicenseApplication;
            this.dgvManageLocalDrivingLicenseApplication.Location = new System.Drawing.Point(6, 314);
            this.dgvManageLocalDrivingLicenseApplication.Name = "dgvManageLocalDrivingLicenseApplication";
            this.dgvManageLocalDrivingLicenseApplication.ReadOnly = true;
            this.dgvManageLocalDrivingLicenseApplication.RowHeadersWidth = 51;
            this.dgvManageLocalDrivingLicenseApplication.RowTemplate.Height = 24;
            this.dgvManageLocalDrivingLicenseApplication.Size = new System.Drawing.Size(1266, 336);
            this.dgvManageLocalDrivingLicenseApplication.TabIndex = 27;
            this.dgvManageLocalDrivingLicenseApplication.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvManageLocalDrivingLicenseApplication_CellFormatting);
            this.dgvManageLocalDrivingLicenseApplication.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvManageLocalDrivingLicenseApplication_CellMouseDown);
            this.dgvManageLocalDrivingLicenseApplication.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvManageLocalDrivingLicenseApplication_DataBindingComplete);
            // 
            // contextMenuManageLocalDrivingLicenseApplication
            // 
            this.contextMenuManageLocalDrivingLicenseApplication.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuManageLocalDrivingLicenseApplication.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showToolStripMenuItem,
            this.cancelToolStripMenuItem,
            this.editToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.SechduleTestToolStripMenuItem,
            this.IssueDrivingLicenseToolStripMenuItem,
            this.showLicenseToolStripMenuItem,
            this.showPersonLicenseHistoryToolStripMenuItem});
            this.contextMenuManageLocalDrivingLicenseApplication.Name = "contextMenuManagePeople";
            this.contextMenuManageLocalDrivingLicenseApplication.Size = new System.Drawing.Size(293, 240);
            this.contextMenuManageLocalDrivingLicenseApplication.Text = "Delete";
            this.contextMenuManageLocalDrivingLicenseApplication.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuManageLocalDrivingLicenseApplication_Opening);
            // 
            // showToolStripMenuItem
            // 
            this.showToolStripMenuItem.Image = global::Presentation.Properties.Resources.Show_Application_Details;
            this.showToolStripMenuItem.Name = "showToolStripMenuItem";
            this.showToolStripMenuItem.Size = new System.Drawing.Size(292, 26);
            this.showToolStripMenuItem.Text = "Show Application Details";
            this.showToolStripMenuItem.Click += new System.EventHandler(this.showToolStripMenuItem_Click);
            // 
            // cancelToolStripMenuItem
            // 
            this.cancelToolStripMenuItem.Image = global::Presentation.Properties.Resources.cancel_Application;
            this.cancelToolStripMenuItem.Name = "cancelToolStripMenuItem";
            this.cancelToolStripMenuItem.Size = new System.Drawing.Size(292, 26);
            this.cancelToolStripMenuItem.Text = "Cancel Application";
            this.cancelToolStripMenuItem.Click += new System.EventHandler(this.cancelToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Image = global::Presentation.Properties.Resources.update_Application;
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(292, 26);
            this.editToolStripMenuItem.Text = "Edit Application";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Image = global::Presentation.Properties.Resources.Delete_Application;
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(292, 26);
            this.deleteToolStripMenuItem.Text = "Delete Application";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // SechduleTestToolStripMenuItem
            // 
            this.SechduleTestToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sechduleVisionTestToolStripMenuItem,
            this.sechduleWritenTestToolStripMenuItem,
            this.secToolStripMenuItem});
            this.SechduleTestToolStripMenuItem.Image = global::Presentation.Properties.Resources.Schedule_Test;
            this.SechduleTestToolStripMenuItem.Name = "SechduleTestToolStripMenuItem";
            this.SechduleTestToolStripMenuItem.Size = new System.Drawing.Size(292, 26);
            this.SechduleTestToolStripMenuItem.Text = "Sechdule Tests";
            // 
            // sechduleVisionTestToolStripMenuItem
            // 
            this.sechduleVisionTestToolStripMenuItem.Image = global::Presentation.Properties.Resources.Vesion_Test;
            this.sechduleVisionTestToolStripMenuItem.Name = "sechduleVisionTestToolStripMenuItem";
            this.sechduleVisionTestToolStripMenuItem.Size = new System.Drawing.Size(230, 26);
            this.sechduleVisionTestToolStripMenuItem.Text = "Sechdule Vision Test";
            this.sechduleVisionTestToolStripMenuItem.Click += new System.EventHandler(this.sechduleVisionTestToolStripMenuItem_Click);
            // 
            // sechduleWritenTestToolStripMenuItem
            // 
            this.sechduleWritenTestToolStripMenuItem.Image = global::Presentation.Properties.Resources.Writen_Test;
            this.sechduleWritenTestToolStripMenuItem.Name = "sechduleWritenTestToolStripMenuItem";
            this.sechduleWritenTestToolStripMenuItem.Size = new System.Drawing.Size(230, 26);
            this.sechduleWritenTestToolStripMenuItem.Text = "Sechdule Writen Test";
            this.sechduleWritenTestToolStripMenuItem.Click += new System.EventHandler(this.sechduleWritenTestToolStripMenuItem_Click);
            // 
            // secToolStripMenuItem
            // 
            this.secToolStripMenuItem.Image = global::Presentation.Properties.Resources.Street_Test;
            this.secToolStripMenuItem.Name = "secToolStripMenuItem";
            this.secToolStripMenuItem.Size = new System.Drawing.Size(230, 26);
            this.secToolStripMenuItem.Text = "Sechdule Street Test";
            this.secToolStripMenuItem.Click += new System.EventHandler(this.secToolStripMenuItem_Click);
            // 
            // IssueDrivingLicenseToolStripMenuItem
            // 
            this.IssueDrivingLicenseToolStripMenuItem.Image = global::Presentation.Properties.Resources.Issue_Driving_License;
            this.IssueDrivingLicenseToolStripMenuItem.Name = "IssueDrivingLicenseToolStripMenuItem";
            this.IssueDrivingLicenseToolStripMenuItem.Size = new System.Drawing.Size(292, 26);
            this.IssueDrivingLicenseToolStripMenuItem.Text = "Issue Driving License(First Time)";
            this.IssueDrivingLicenseToolStripMenuItem.Click += new System.EventHandler(this.IssueDrivingLicenseToolStripMenuItem_Click);
            // 
            // showLicenseToolStripMenuItem
            // 
            this.showLicenseToolStripMenuItem.Image = global::Presentation.Properties.Resources.Show_License;
            this.showLicenseToolStripMenuItem.Name = "showLicenseToolStripMenuItem";
            this.showLicenseToolStripMenuItem.Size = new System.Drawing.Size(292, 26);
            this.showLicenseToolStripMenuItem.Text = "Show License";
            this.showLicenseToolStripMenuItem.Click += new System.EventHandler(this.showLicenseToolStripMenuItem_Click);
            // 
            // showPersonLicenseHistoryToolStripMenuItem
            // 
            this.showPersonLicenseHistoryToolStripMenuItem.Image = global::Presentation.Properties.Resources.Personal_License_history;
            this.showPersonLicenseHistoryToolStripMenuItem.Name = "showPersonLicenseHistoryToolStripMenuItem";
            this.showPersonLicenseHistoryToolStripMenuItem.Size = new System.Drawing.Size(292, 26);
            this.showPersonLicenseHistoryToolStripMenuItem.Text = "Show Person License History";
            this.showPersonLicenseHistoryToolStripMenuItem.Click += new System.EventHandler(this.showPersonLicenseHistoryToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Coral;
            this.label1.Location = new System.Drawing.Point(383, 226);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(477, 37);
            this.label1.TabIndex = 26;
            this.label1.Text = "Local Driving License Application";
            // 
            // button3
            // 
            this.button3.BackgroundImage = global::Presentation.Properties.Resources.refresh_button__2_;
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button3.Location = new System.Drawing.Point(1154, 260);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(56, 48);
            this.button3.TabIndex = 35;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Image = global::Presentation.Properties.Resources.close_button;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(1174, 656);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(98, 35);
            this.button1.TabIndex = 34;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackgroundImage = global::Presentation.Properties.Resources.Add_person_;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.Location = new System.Drawing.Point(1216, 260);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(56, 48);
            this.button2.TabIndex = 30;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Presentation.Properties.Resources.Manage_application;
            this.pictureBox1.Location = new System.Drawing.Point(494, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(248, 201);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 25;
            this.pictureBox1.TabStop = false;
            // 
            // frmManageLocalDrivingLicenseApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Linen;
            this.ClientSize = new System.Drawing.Size(1283, 698);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblLocalDrivingLicenseApplicationCount);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtbManageLocalDrivingLicenseApplication);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.cbFilter);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvManageLocalDrivingLicenseApplication);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "frmManageLocalDrivingLicenseApplication";
            this.Text = "frmManageLocalDrivingLicenseApplication";
            this.Load += new System.EventHandler(this.frmManageLocalDrivingLicenseApplication_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvManageLocalDrivingLicenseApplication)).EndInit();
            this.contextMenuManageLocalDrivingLicenseApplication.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblLocalDrivingLicenseApplicationCount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtbManageLocalDrivingLicenseApplication;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox cbFilter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvManageLocalDrivingLicenseApplication;
        private System.Windows.Forms.ContextMenuStrip contextMenuManageLocalDrivingLicenseApplication;
        private System.Windows.Forms.ToolStripMenuItem showToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cancelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SechduleTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sechduleVisionTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sechduleWritenTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem secToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem IssueDrivingLicenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showLicenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showPersonLicenseHistoryToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}