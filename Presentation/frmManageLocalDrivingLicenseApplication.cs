using DVDLBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentation
{
    public partial class frmManageLocalDrivingLicenseApplication : Form
    {
        DataTable dtLocalDrivingLicenseApplication = ClsLocalDrivingLicenseApplication.GetAllLocalDrivingLicenseApplications();
        public frmManageLocalDrivingLicenseApplication()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen; // Center the form on screen
        }
        private void _RefreshManageLocalDrivingLicenseApplicationList()
        {
            dgvManageLocalDrivingLicenseApplication.DataSource = dtLocalDrivingLicenseApplication;
            lblLocalDrivingLicenseApplicationCount.Text = (dgvManageLocalDrivingLicenseApplication.Rows.Count).ToString();

        }
        private void _FillAttributesInComboBox()
        {
            cbFilter.Items.Clear(); // Clear old items

            cbFilter.Items.Add("None");
            cbFilter.Items.Add("LDLAppID");
            cbFilter.Items.Add("NationalNo");
            cbFilter.Items.Add("FullName");
            cbFilter.Items.Add("Status");
            cbFilter.SelectedIndex = 0;
        }
        private void frmManageLocalDrivingLicenseApplication_Load(object sender, EventArgs e)
        {
            _RefreshManageLocalDrivingLicenseApplicationList();
            _FillAttributesInComboBox();
            dgvManageLocalDrivingLicenseApplication.Columns["LDLAppID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvManageLocalDrivingLicenseApplication.Columns["DrivingClass"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvManageLocalDrivingLicenseApplication.Columns["FullName"].Width = 150;
        }
        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedColumn = cbFilter.SelectedItem.ToString();

            if (selectedColumn == "None")
            {
                txtbManageLocalDrivingLicenseApplication.Visible = false;
            }
            else
            {
                txtbManageLocalDrivingLicenseApplication.Visible = true;
            }
        }

        private void txtbManageLocalDrivingLicenseApplication_KeyPress(object sender, KeyPressEventArgs e)
        {
            string selectedColumn = cbFilter.SelectedItem.ToString();

            switch (selectedColumn)
            {
                case "LDLAppID":
                    if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                    {
                        // Block the character
                        e.Handled = true;
                    }
                    break;
                case "FullName":
                    if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
                    {
                        e.Handled = true; // Block the character
                    }
                    break;
                case "Status":
                    if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
                    {
                        e.Handled = true; // Only allow letters and backspace
                    }
                    break;
                default:

                    break;
            }
        }

        private void txtbManageLocalDrivingLicenseApplication_TextChanged(object sender, EventArgs e)
        {
            DataView LocalDrivingLicenseApplicationdataView = dtLocalDrivingLicenseApplication.DefaultView;

            string selectedColumn = cbFilter.SelectedItem.ToString();

            if (string.IsNullOrEmpty(txtbManageLocalDrivingLicenseApplication.Text))
            {
                LocalDrivingLicenseApplicationdataView.RowFilter = ""; // remove filter if box is empty
            }
            else
            {
                switch (selectedColumn)
                {
                    case "LDLAppID":
                        string query = $"Convert({selectedColumn}, 'System.String') LIKE '{txtbManageLocalDrivingLicenseApplication.Text}%'";
                        LocalDrivingLicenseApplicationdataView.RowFilter = query;
                        break;
                    case "Status":
                        break;
                    default:
                        // Correct syntax with quotes and LIKE
                        query = $"{selectedColumn} LIKE '{txtbManageLocalDrivingLicenseApplication.Text}%'";
                        LocalDrivingLicenseApplicationdataView.RowFilter = query;
                        break;
                }
            }
            lblLocalDrivingLicenseApplicationCount.Text = (dgvManageLocalDrivingLicenseApplication.Rows.Count).ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            frmNewLocalDrivingLicenseApplication frm = new frmNewLocalDrivingLicenseApplication(-1);
            frm.ShowDialog();
        }
        private void cancelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClsLocalDrivingLicenseApplication LocalDrivingLicenseApplication = ClsLocalDrivingLicenseApplication.Find((int)dgvManageLocalDrivingLicenseApplication.CurrentRow.Cells[0].Value);
            ClsApplication Application = ClsApplication.Find(LocalDrivingLicenseApplication.ApplicationID);
            Application.ApplicationStatus = 2;
            Application.LastStatusDate = DateTime.Now;
            Application.Save();
        }
        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNewLocalDrivingLicenseApplication frm = new frmNewLocalDrivingLicenseApplication((int)dgvManageLocalDrivingLicenseApplication.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int DeleteLocalDrivingLicenseApplicationID = (int)dgvManageLocalDrivingLicenseApplication.CurrentRow.Cells[0].Value;
            if (MessageBox.Show("Are you sure you want to delete this Local Driving License Application [" + DeleteLocalDrivingLicenseApplicationID + "]", "Confirm Delete", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                if (ClsLocalDrivingLicenseApplication.DeleteLocalDrivingLicenseApplication(DeleteLocalDrivingLicenseApplicationID))
                {
                    MessageBox.Show("Local Driving License Application deleted successfully");
                }
                else
                {
                    MessageBox.Show("Local Driving License Application was not deleted because it has data linked to it", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void dgvManageLocalDrivingLicenseApplication_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                // Clear any previous selection
                dgvManageLocalDrivingLicenseApplication.ClearSelection();

                // Select the row under the mouse
                dgvManageLocalDrivingLicenseApplication.Rows[e.RowIndex].Selected = true;

                // Optional: set current cell (helps with editing)
                dgvManageLocalDrivingLicenseApplication.CurrentCell = dgvManageLocalDrivingLicenseApplication.Rows[e.RowIndex].Cells[e.ColumnIndex];
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            // Re-fetch data from the database
            dtLocalDrivingLicenseApplication = ClsLocalDrivingLicenseApplication.GetAllLocalDrivingLicenseApplications();

            // Clear any filters in the DataView
            dtLocalDrivingLicenseApplication.DefaultView.RowFilter = "";

            // Refresh DataGridView
            dgvManageLocalDrivingLicenseApplication.DataSource = dtLocalDrivingLicenseApplication;

            // Update LocalDrivingLicenseApplication Count
            lblLocalDrivingLicenseApplicationCount.Text = dgvManageLocalDrivingLicenseApplication.Rows.Count.ToString();

            // Reset the filter TextBox
            txtbManageLocalDrivingLicenseApplication.Clear();

            // Reset the ComboBox filter selection
            cbFilter.SelectedIndex = 0;
        }
        private void dgvManageLocalDrivingLicenseApplication_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvManageLocalDrivingLicenseApplication.Columns["LDLAppID"].HeaderText = "L.D.L.AppID";
            dgvManageLocalDrivingLicenseApplication.Columns["FullName"].HeaderText = "Full Name";
            dgvManageLocalDrivingLicenseApplication.Columns["NationalNo"].HeaderText = "National No";
            dgvManageLocalDrivingLicenseApplication.Columns["ApplicationStatus"].HeaderText = "Status";
        }
        private void dgvManageLocalDrivingLicenseApplication_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvManageLocalDrivingLicenseApplication.Columns[e.ColumnIndex].Name == "ApplicationStatus" && e.Value != null)
            {
                switch (e.Value.ToString())
                {
                    case "1":
                        e.Value = "New";
                        break;
                    case "2":
                        e.Value = "Cancelled";
                        break;
                    case "3":
                        e.Value = "Completed";
                        break;
                }
                e.FormattingApplied = true;
            }
        }
        private void txtbManageLocalDrivingLicenseApplication_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (cbFilter.SelectedItem.ToString() == "Status")
                {
                    DataView LocalDrivingLicenseApplicationdataView = dtLocalDrivingLicenseApplication.DefaultView;

                    string filterValue = txtbManageLocalDrivingLicenseApplication.Text.Trim();
                    byte status = 0;

                    switch (filterValue.ToLower())
                    {
                        case "new":
                            status = 1;
                            break;
                        case "cancelled":
                            status = 2;
                            break;
                        case "completed":
                            status = 3;
                            break;
                        default:
                            MessageBox.Show("Status must be New, Completed, or Cancelled.", "Invalid Status", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtbManageLocalDrivingLicenseApplication.Focus();
                            return;
                    }

                    // Convert numeric column to string for LIKE filtering
                    string query = $"Convert(ApplicationStatus, 'System.String') LIKE '%{status}%'";
                    LocalDrivingLicenseApplicationdataView.RowFilter = query;
                }

                e.Handled = true;  // Prevent "ding" sound
                e.SuppressKeyPress = true;
            }
        }
        private void contextMenuManageLocalDrivingLicenseApplication_Opening(object sender, CancelEventArgs e)
        {
            // Always reset the menu items first
            sechduleVisionTestToolStripMenuItem.Enabled = true;
            sechduleWritenTestToolStripMenuItem.Enabled = true;
            secToolStripMenuItem.Enabled = true;
            IssueDrivingLicenseToolStripMenuItem.Enabled = false;
            cancelToolStripMenuItem.Enabled = true;
            editToolStripMenuItem.Enabled = true;
            deleteToolStripMenuItem.Enabled = true;
            SechduleTestToolStripMenuItem.Enabled = true;
            showLicenseToolStripMenuItem.Enabled = false;

            if (dgvManageLocalDrivingLicenseApplication.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvManageLocalDrivingLicenseApplication.SelectedRows[0];

                int SelectedLDApplicationID = Convert.ToInt32(selectedRow.Cells["LDLAppID"].Value);
                if (ClsTest.GetTestResult(SelectedLDApplicationID, 1))
                {
                    sechduleVisionTestToolStripMenuItem.Enabled = false;
                    sechduleWritenTestToolStripMenuItem.Enabled = true;
                    secToolStripMenuItem.Enabled = false;
                }
                else
                {
                    sechduleWritenTestToolStripMenuItem.Enabled = false;
                    secToolStripMenuItem.Enabled = false;
                }
                if (ClsTest.GetTestResult(SelectedLDApplicationID, 2))
                {
                    sechduleVisionTestToolStripMenuItem.Enabled = false;
                    sechduleWritenTestToolStripMenuItem.Enabled = false;
                    secToolStripMenuItem.Enabled = true;
                }
                if (ClsTest.GetTestResult(SelectedLDApplicationID, 3))
                {
                    sechduleVisionTestToolStripMenuItem.Enabled = false;
                    sechduleWritenTestToolStripMenuItem.Enabled = false;
                    secToolStripMenuItem.Enabled = false;
                    if (!ClsLicense.ExistLicenseByAppID(ClsLocalDrivingLicenseApplication.Find(SelectedLDApplicationID).ApplicationID))
                    {
                        IssueDrivingLicenseToolStripMenuItem.Enabled = true;
                    }
                    else
                    {
                        cancelToolStripMenuItem.Enabled = false;
                        editToolStripMenuItem.Enabled = false;
                        deleteToolStripMenuItem.Enabled = false;
                        SechduleTestToolStripMenuItem.Enabled = false;
                        showLicenseToolStripMenuItem.Enabled = true;
                    }
                }

            }
            else
            {
                sechduleWritenTestToolStripMenuItem.Enabled = false;
                secToolStripMenuItem.Enabled = false;
            }
        }
        private void sechduleVisionTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((byte)dgvManageLocalDrivingLicenseApplication.CurrentRow.Cells[6].Value == 1)
            {
                frmTestAppointment frm = new frmTestAppointment((int)dgvManageLocalDrivingLicenseApplication.CurrentRow.Cells[0].Value, 1);
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("this Application is Cancelled you cannot manage schedule test", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void sechduleWritenTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((byte)dgvManageLocalDrivingLicenseApplication.CurrentRow.Cells[6].Value == 1)
            {
                frmTestAppointment frm = new frmTestAppointment((int)dgvManageLocalDrivingLicenseApplication.CurrentRow.Cells[0].Value, 2);
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("this Application is Cancelled you cannot manage schedule test", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void secToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((byte)dgvManageLocalDrivingLicenseApplication.CurrentRow.Cells[6].Value == 1)
            {
                frmTestAppointment frm = new frmTestAppointment((int)dgvManageLocalDrivingLicenseApplication.CurrentRow.Cells[0].Value, 3);
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("this Application is Cancelled you cannot manage schedule test", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void IssueDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmIssueDrivingLicenseForTheFirstTime frm = new frmIssueDrivingLicenseForTheFirstTime((int)dgvManageLocalDrivingLicenseApplication.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }

        private void showLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClsLocalDrivingLicenseApplication LDApp = ClsLocalDrivingLicenseApplication.Find((int)dgvManageLocalDrivingLicenseApplication.CurrentRow.Cells[0].Value);
            frmLicenseInfo frm = new frmLicenseInfo(ClsLicense.GetLicenseIDByAppID(LDApp.ApplicationID));
            frm.ShowDialog();
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClsLocalDrivingLicenseApplication LDApp = ClsLocalDrivingLicenseApplication.Find((int)dgvManageLocalDrivingLicenseApplication.CurrentRow.Cells[0].Value);
            ClsApplication Application = ClsApplication.Find(LDApp.ApplicationID);
            frmShowLicenseHistory frm = new frmShowLicenseHistory(Application.ApplicationPersonID);
            frm.ShowDialog();
        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLocalDrivingLicenseApplicationDetails frm = new frmLocalDrivingLicenseApplicationDetails((int)dgvManageLocalDrivingLicenseApplication.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }
    }
}
