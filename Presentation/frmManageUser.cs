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
    public partial class frmManageUser : Form
    {
        DataTable dtUsers = ClsUser.GetAllUsers();
        public frmManageUser()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen; // Center the form on screen
        }

        private void _RefreshManageUsersList()
        {
            dgvManageUsers.DataSource = dtUsers;
            lblUsersCount.Text = (dgvManageUsers.Rows.Count).ToString();
        }
        private void _FillAttributesInFilterComboBox()
        {
            cbFilterUsers.Items.Clear(); // Clear old items
            cbFilterUsers.Items.Add("None");
            cbFilterUsers.SelectedIndex = 0;

            foreach (DataGridViewColumn column in dgvManageUsers.Columns)
            {
                cbFilterUsers.Items.Add(column.HeaderText);  // Add header text
            }
        }
        private void cbFilterUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedColumn = cbFilterUsers.SelectedItem.ToString();

            switch (selectedColumn)
            {
                case "None":
                    txtbManageUsers.Visible = false;
                    cbIsActive.Visible = false;
                    break;
                case "IsActive":
                    txtbManageUsers.Visible = false;
                    cbIsActive.Visible = true;
                    _FillAttributesInIsActiveComboBox();
                    break;
                default:
                    txtbManageUsers.Visible = true;
                    cbIsActive.Visible = false;
                    break;

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
        private void cbIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataView UsersdataView = dtUsers.DefaultView;

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
            lblUsersCount.Text = (dgvManageUsers.Rows.Count).ToString();
        }
        private void txtbManageUsers_KeyPress(object sender, KeyPressEventArgs e)
        {
            string selectedColumn = cbFilterUsers.SelectedItem.ToString();

            switch (selectedColumn)
            {
                case "UserID":
                    if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                    {
                        // Block the character
                        e.Handled = true;
                    }
                    break;
                case "PersonID":
                    if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                    {
                        // Block the character
                        e.Handled = true;
                    }
                    break;
                case "FirstName":
                    if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
                    {
                        e.Handled = true; // Block the character
                    }
                    break;
                case "LastName":
                    if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
                    {
                        e.Handled = true; // Block the character
                    }
                    break;
                default:

                    break;
            }
        }
        private void txtbManageUsers_TextChanged(object sender, EventArgs e)
        {
            DataView UsersdataView = dtUsers.DefaultView;

            string selectedColumn = cbFilterUsers.SelectedItem.ToString();

            if (string.IsNullOrEmpty(txtbManageUsers.Text))
            {
                UsersdataView.RowFilter = ""; // remove filter if box is empty
            }
            else
            {
                if (selectedColumn != "UserID" && selectedColumn != "PersonID")
                {
                    // Correct syntax with quotes and LIKE
                    string query = $"{selectedColumn} LIKE '{txtbManageUsers.Text}%'";
                    UsersdataView.RowFilter = query;
                }
                else
                {
                    string query = $"Convert({selectedColumn}, 'System.String') LIKE '{txtbManageUsers.Text}%'";
                    UsersdataView.RowFilter = query;
                }
            }
            lblUsersCount.Text = (dgvManageUsers.Rows.Count).ToString();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();   
        }
        private void btnAddUser_Click(object sender, EventArgs e)
        {
            frmAddEditUser frm = new frmAddEditUser(-1);
            frm.ShowDialog();
        }
        private void dgvManageUsers_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                // Clear any previous selection
                dgvManageUsers.ClearSelection();

                // Select the row under the mouse
                dgvManageUsers.Rows[e.RowIndex].Selected = true;

                // Optional: set current cell (helps with editing)
                dgvManageUsers.CurrentCell = dgvManageUsers.Rows[e.RowIndex].Cells[e.ColumnIndex];
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            // Re-fetch data from the database
            dtUsers = ClsUser.GetAllUsers();

            // Clear any filters in the DataView
            dtUsers.DefaultView.RowFilter = "";

            // Refresh DataGridView
            dgvManageUsers.DataSource = dtUsers;

            // Update Users Count
            //lblUsersCount.Text = dgvManageUsers.Rows.Count.ToString();

            // Reset the filter TextBox
            txtbManageUsers.Clear();

            // Reset the ComboBox filter selection
            cbFilterUsers.SelectedIndex = 0;

        }
        private void frmManageUser_Load(object sender, EventArgs e)
        {
            _RefreshManageUsersList();
            _FillAttributesInFilterComboBox();
            sendEmailToolStripMenuItem.Enabled = false;
            callPhoneToolStripMenuItem.Enabled = false;
        }
        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditUser frm = new frmAddEditUser(-1);
            frm.ShowDialog();
        }
        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditUser frm = new frmAddEditUser((int)dgvManageUsers.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int DeleteUserID = (int)dgvManageUsers.CurrentRow.Cells[0].Value;
            if (MessageBox.Show("Are you sure you want to delete User [" + DeleteUserID + "]", "Confirm Delete", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                if (ClsUser.DeleteUser(DeleteUserID))
                {
                    MessageBox.Show("User deleted successfully");
                }
                else
                {
                    MessageBox.Show("User was not deleted because it has data linked to it", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUserDetails frm = new frmUserDetails((int)dgvManageUsers.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }
        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangePassword frm = new frmChangePassword((int)dgvManageUsers.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }
    }
}
