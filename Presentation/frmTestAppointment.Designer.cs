namespace Presentation
{
    partial class frmTestAppointment
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
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.takeTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblAppointmentsCount = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvManageAppointments = new System.Windows.Forms.DataGridView();
            this.lblTestAppointmentMode = new System.Windows.Forms.Label();
            this.btnAddAppointment = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.picBTestAppointment = new System.Windows.Forms.PictureBox();
            this.ctrlApplicationCard1 = new Presentation.Controles.ctrlApplicationCard();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvManageAppointments)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBTestAppointment)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem,
            this.takeTestToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(215, 84);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Image = global::Presentation.Properties.Resources.update_Application;
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(214, 26);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // takeTestToolStripMenuItem
            // 
            this.takeTestToolStripMenuItem.Image = global::Presentation.Properties.Resources.Schedule_Test;
            this.takeTestToolStripMenuItem.Name = "takeTestToolStripMenuItem";
            this.takeTestToolStripMenuItem.Size = new System.Drawing.Size(214, 26);
            this.takeTestToolStripMenuItem.Text = "Take Test";
            this.takeTestToolStripMenuItem.Click += new System.EventHandler(this.takeTestToolStripMenuItem_Click);
            // 
            // lblAppointmentsCount
            // 
            this.lblAppointmentsCount.AutoSize = true;
            this.lblAppointmentsCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAppointmentsCount.Location = new System.Drawing.Point(101, 736);
            this.lblAppointmentsCount.Name = "lblAppointmentsCount";
            this.lblAppointmentsCount.Size = new System.Drawing.Size(0, 18);
            this.lblAppointmentsCount.TabIndex = 61;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 570);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 18);
            this.label1.TabIndex = 60;
            this.label1.Text = "Appointments:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(4, 736);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 18);
            this.label3.TabIndex = 57;
            this.label3.Text = "# Records:";
            // 
            // dgvManageAppointments
            // 
            this.dgvManageAppointments.AllowUserToAddRows = false;
            this.dgvManageAppointments.AllowUserToDeleteRows = false;
            this.dgvManageAppointments.AllowUserToOrderColumns = true;
            this.dgvManageAppointments.BackgroundColor = System.Drawing.Color.Linen;
            this.dgvManageAppointments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvManageAppointments.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvManageAppointments.Location = new System.Drawing.Point(7, 608);
            this.dgvManageAppointments.Name = "dgvManageAppointments";
            this.dgvManageAppointments.ReadOnly = true;
            this.dgvManageAppointments.RowHeadersWidth = 51;
            this.dgvManageAppointments.RowTemplate.Height = 24;
            this.dgvManageAppointments.Size = new System.Drawing.Size(873, 114);
            this.dgvManageAppointments.TabIndex = 56;
            this.dgvManageAppointments.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvManageAppointments_CellMouseDown);
            // 
            // lblTestAppointmentMode
            // 
            this.lblTestAppointmentMode.AutoSize = true;
            this.lblTestAppointmentMode.Font = new System.Drawing.Font("Microsoft YaHei", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTestAppointmentMode.ForeColor = System.Drawing.Color.Peru;
            this.lblTestAppointmentMode.Location = new System.Drawing.Point(250, 151);
            this.lblTestAppointmentMode.Name = "lblTestAppointmentMode";
            this.lblTestAppointmentMode.Size = new System.Drawing.Size(101, 37);
            this.lblTestAppointmentMode.TabIndex = 55;
            this.lblTestAppointmentMode.Text = "label1";
            // 
            // btnAddAppointment
            // 
            this.btnAddAppointment.BackgroundImage = global::Presentation.Properties.Resources.btn_Add_appointment;
            this.btnAddAppointment.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAddAppointment.Location = new System.Drawing.Point(829, 558);
            this.btnAddAppointment.Name = "btnAddAppointment";
            this.btnAddAppointment.Size = new System.Drawing.Size(51, 44);
            this.btnAddAppointment.TabIndex = 59;
            this.btnAddAppointment.UseVisualStyleBackColor = true;
            this.btnAddAppointment.Click += new System.EventHandler(this.btnAddAppointment_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Image = global::Presentation.Properties.Resources.close_button;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(782, 728);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(98, 35);
            this.button1.TabIndex = 58;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // picBTestAppointment
            // 
            this.picBTestAppointment.Location = new System.Drawing.Point(369, 10);
            this.picBTestAppointment.Name = "picBTestAppointment";
            this.picBTestAppointment.Size = new System.Drawing.Size(119, 138);
            this.picBTestAppointment.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBTestAppointment.TabIndex = 54;
            this.picBTestAppointment.TabStop = false;
            // 
            // ctrlApplicationCard1
            // 
            this.ctrlApplicationCard1.BackColor = System.Drawing.Color.Linen;
            this.ctrlApplicationCard1.Location = new System.Drawing.Point(1, 191);
            this.ctrlApplicationCard1.Name = "ctrlApplicationCard1";
            this.ctrlApplicationCard1.Size = new System.Drawing.Size(879, 365);
            this.ctrlApplicationCard1.TabIndex = 62;
            // 
            // frmTestAppointment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Linen;
            this.ClientSize = new System.Drawing.Size(885, 772);
            this.Controls.Add(this.ctrlApplicationCard1);
            this.Controls.Add(this.lblAppointmentsCount);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAddAppointment);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgvManageAppointments);
            this.Controls.Add(this.lblTestAppointmentMode);
            this.Controls.Add(this.picBTestAppointment);
            this.Name = "frmTestAppointment";
            this.Text = "frmTestAppointment";
            this.Load += new System.EventHandler(this.frmTestAppointment_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvManageAppointments)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBTestAppointment)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem takeTestToolStripMenuItem;
        private System.Windows.Forms.Label lblAppointmentsCount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAddAppointment;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvManageAppointments;
        private System.Windows.Forms.Label lblTestAppointmentMode;
        private System.Windows.Forms.PictureBox picBTestAppointment;
        private Controles.ctrlApplicationCard ctrlApplicationCard1;
    }
}