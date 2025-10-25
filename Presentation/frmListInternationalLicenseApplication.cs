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
    public partial class frmListInternationalLicenseApplication : Form
    {
        DataTable dtIntDrivingLicenseApplication = ClsInternationalLicense.GetAllInternationalLicenses();
        public frmListInternationalLicenseApplication()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen; // Center the form on screen
        }
        private void _RefreshManageLocalDrivingLicenseApplicationList()
        {
            dgvManageIntDrivingLicenseApplication.DataSource = dtIntDrivingLicenseApplication;
            lblIntDrivingLicenseApplicationCount.Text = (dgvManageIntDrivingLicenseApplication.Rows.Count).ToString();

        }
        private void _FillAttributesInComboBox()
        {
            cbFilter.Items.Clear(); // Clear old items

            cbFilter.Items.Add("None");
            cbFilter.SelectedIndex = 0;

            foreach (DataGridViewColumn column in dgvManageIntDrivingLicenseApplication.Columns)
            {
                if (column.HeaderText != "IssueDate" && column.HeaderText != "ExpirationDate")
                {
                    cbFilter.Items.Add(column.HeaderText);  // Add header text
                }

            }
        }
        private void _FillAttributesInIsActiveComboBox()
        {
            cbIsActive.Items.Clear(); // Clear old items
            cbIsActive.Items.Add("All");
            cbIsActive.Items.Add("Yes");
            cbIsActive.Items.Add("No");
            cbIsActive.SelectedIndex = 0;
        }
        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedColumn = cbFilter.SelectedItem.ToString();

            switch (selectedColumn)
            {
                case "None":
                    txtbManageIntDrivingLicenseApplication.Visible = false;
                    cbIsActive.Visible = false;
                    break;
                case "IsActive":
                    txtbManageIntDrivingLicenseApplication.Visible = false;
                    cbIsActive.Visible = true;
                    _FillAttributesInIsActiveComboBox();
                    break;
                default:
                    txtbManageIntDrivingLicenseApplication.Visible = true;
                    cbIsActive.Visible = false;
                    break;

            }
        }
        private void cbIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataView UsersdataView = dtIntDrivingLicenseApplication.DefaultView;

            string selectedColumn = cbIsActive.SelectedItem.ToString();

            if (selectedColumn == "All")
            {
                UsersdataView.RowFilter = ""; // remove filter if box is empty
            }
            else
            {
                if (selectedColumn == "Yes")
                {
                    // Correct syntax with quotes and LIKE
                    string query = $"IsActive = true";
                    UsersdataView.RowFilter = query;
                }
                else
                {
                    string query = $"IsActive = false";
                    UsersdataView.RowFilter = query;
                }
            }
            lblIntDrivingLicenseApplicationCount.Text = (dtIntDrivingLicenseApplication.Rows.Count).ToString();
        }
        private void frmListInternationalLicenseApplication_Load(object sender, EventArgs e)
        {
            _RefreshManageLocalDrivingLicenseApplicationList();
            _FillAttributesInComboBox();
            dgvManageIntDrivingLicenseApplication.Columns["IssueDate"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvManageIntDrivingLicenseApplication.Columns["ExpirationDate"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
        private void txtbManageIntDrivingLicenseApplication_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                // Block the character
                e.Handled = true;
            }
        }
        private void txtbManageIntDrivingLicenseApplication_TextChanged(object sender, EventArgs e)
        {
            DataView UsersdataView = dtIntDrivingLicenseApplication.DefaultView;

            string selectedColumn = cbFilter.SelectedItem.ToString();

            if (string.IsNullOrEmpty(txtbManageIntDrivingLicenseApplication.Text))
            {
                UsersdataView.RowFilter = ""; // remove filter if box is empty
            }
            else
            {
                string query = $"Convert({selectedColumn}, 'System.String') LIKE '{txtbManageIntDrivingLicenseApplication.Text}%'";
                UsersdataView.RowFilter = query;
            }
            lblIntDrivingLicenseApplicationCount.Text = (dgvManageIntDrivingLicenseApplication.Rows.Count).ToString();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            frmNewInternationalLicenseApplication frm = new frmNewInternationalLicenseApplication();
            frm.ShowDialog();
        }
        private void dgvManageIntDrivingLicenseApplication_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                // Clear any previous selection
                dgvManageIntDrivingLicenseApplication.ClearSelection();

                // Select the row under the mouse
                dgvManageIntDrivingLicenseApplication.Rows[e.RowIndex].Selected = true;

                // Optional: set current cell (helps with editing)
                dgvManageIntDrivingLicenseApplication.CurrentCell = dgvManageIntDrivingLicenseApplication.Rows[e.RowIndex].Cells[e.ColumnIndex];
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            // Re-fetch data from the database
            dtIntDrivingLicenseApplication = ClsUser.GetAllUsers();

            // Clear any filters in the DataView
            dtIntDrivingLicenseApplication.DefaultView.RowFilter = "";

            // Refresh DataGridView
            dgvManageIntDrivingLicenseApplication.DataSource = dtIntDrivingLicenseApplication;

            // Update Users Count
            //lblUsersCount.Text = dgvManageUsers.Rows.Count.ToString();

            // Reset the filter TextBox
            txtbManageIntDrivingLicenseApplication.Clear();

            // Reset the ComboBox filter selection
            cbFilter.SelectedIndex = 0;
        }
        private void showPersonDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClsApplication Application = ClsApplication.Find((int)dgvManageIntDrivingLicenseApplication.CurrentRow.Cells[1].Value);
            if (Application != null)
            {
                frmPersonDetails frm = new frmPersonDetails(Application.ApplicationPersonID);
                frm.ShowDialog();
            }
        }
        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClsApplication Application = ClsApplication.Find((int)dgvManageIntDrivingLicenseApplication.CurrentRow.Cells[1].Value);
            if (Application != null)
            {
                frmShowLicenseHistory frm = new frmShowLicenseHistory(Application.ApplicationPersonID);
                frm.ShowDialog();
            }
        }
        private void showLicenseDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLicenseInfo frm = new frmLicenseInfo((int)dgvManageIntDrivingLicenseApplication.CurrentRow.Cells[3].Value);
            frm.ShowDialog();
        }
    }
}
