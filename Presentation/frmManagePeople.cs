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
    public partial class frmManagePeople : Form
    {
        DataTable dtPeople = ClsPerson.GetAllPeople();
        public frmManagePeople()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen; // Center the form on screen
        }

        private void _RefreshManagePeopleList()
        {
            dgvManagePeople.DataSource = dtPeople;
            lblPeopleCount.Text = (dgvManagePeople.Rows.Count).ToString();
        }
        private void _FillAttributesInComboBox()
        {
            cbFilter.Items.Clear(); // Clear old items

            cbFilter.Items.Add("None");
            cbFilter.SelectedIndex = 0;

            foreach (DataGridViewColumn column in dgvManagePeople.Columns)
            {
                if (column.HeaderText != "DateOfBirth" && column.HeaderText != "ImagePath" && column.HeaderText != "NationalityCountryID")
                {
                    cbFilter.Items.Add(column.HeaderText);  // Add header text
                }

            }
        }
        private void frmManagePeople_Load(object sender, EventArgs e)
        {
            _RefreshManagePeopleList();
            _FillAttributesInComboBox();
            sendEmailToolStripMenuItem.Enabled = false;
            callPhoneToolStripMenuItem.Enabled = false;
        }
        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedColumn = cbFilter.SelectedItem.ToString();

            if (selectedColumn == "None")
            {
                txtbManagePeople.Visible = false;
            }
            else
            {
                txtbManagePeople.Visible = true;
            }
        }
        private void txtbManagePeople_KeyPress(object sender, KeyPressEventArgs e)
        {
            string selectedColumn = cbFilter.SelectedItem.ToString();

            switch (selectedColumn)
            {
                case "PersonID":
                    if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                    {
                        // Block the character
                        e.Handled = true;
                    }
                    break;
                case "Phone":
                    if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                    {
                        // Block the character
                        e.Handled = true;
                    }
                    break;
                case "Email":
                    if (!char.IsControl(e.KeyChar) &&
                        !char.IsLetterOrDigit(e.KeyChar) &&
                        e.KeyChar != '@' &&
                        e.KeyChar != '.' &&
                        e.KeyChar != '_' &&
                        e.KeyChar != '-')
                    {
                        e.Handled = true; // Block character
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
                case "Gendor":
                    // Allow Backspace
                    if (char.IsControl(e.KeyChar))
                        return;

                    // Only allow M, m, F, f
                    if (e.KeyChar != 'M' && e.KeyChar != 'm' && e.KeyChar != 'F' && e.KeyChar != 'f')
                    {
                        e.Handled = true; // Block the character
                        return;
                    }

                    // Prevent entering more than one character
                    if (txtbManagePeople.Text.Length >= 1)
                    {
                        e.Handled = true;
                    }
                    break;
                default:

                    break;
            }

        }
        private void txtbManagePeople_TextChanged(object sender, EventArgs e)
        {
            DataView PeopledataView = dtPeople.DefaultView;

            string selectedColumn = cbFilter.SelectedItem.ToString();

            if (string.IsNullOrEmpty(txtbManagePeople.Text))
            {
                PeopledataView.RowFilter = ""; // remove filter if box is empty
            }
            else
            {
                if (selectedColumn != "PersonID")
                {
                    // Correct syntax with quotes and LIKE
                    string query = $"{selectedColumn} LIKE '{txtbManagePeople.Text}%'";
                    PeopledataView.RowFilter = query;
                }
                else
                {
                    string query = $"Convert({selectedColumn}, 'System.String') LIKE '{txtbManagePeople.Text}%'";
                    PeopledataView.RowFilter = query;
                }
            }
            lblPeopleCount.Text = (dgvManagePeople.Rows.Count).ToString();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            frmAddEditPerson frm = new frmAddEditPerson(-1);
            frm.ShowDialog();
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditPerson frm = new frmAddEditPerson(-1);
            frm.ShowDialog();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditPerson frm = new frmAddEditPerson((int)dgvManagePeople.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int DeletePersonID = (int)dgvManagePeople.CurrentRow.Cells[0].Value;
            if (MessageBox.Show("Are you sure you want to delete Person [" + DeletePersonID + "]", "Confirm Delete", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                if (ClsPerson.DeletePerson(DeletePersonID))
                {
                    MessageBox.Show("Person deleted successfully");
                }
                else
                {
                    MessageBox.Show("Person was not deleted because it has data linked to it", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvManagePeople_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                // Clear any previous selection
                dgvManagePeople.ClearSelection();

                // Select the row under the mouse
                dgvManagePeople.Rows[e.RowIndex].Selected = true;

                // Optional: set current cell (helps with editing)
                dgvManagePeople.CurrentCell = dgvManagePeople.Rows[e.RowIndex].Cells[e.ColumnIndex];
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Re-fetch data from the database
            dtPeople = ClsPerson.GetAllPeople();

            // Clear any filters in the DataView
            dtPeople.DefaultView.RowFilter = "";

            // Refresh DataGridView
            dgvManagePeople.DataSource = dtPeople;

            // Update People Count
            lblPeopleCount.Text = dgvManagePeople.Rows.Count.ToString();

            // Reset the filter TextBox
            txtbManagePeople.Clear();

            // Reset the ComboBox filter selection
            cbFilter.SelectedIndex = 0;
        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPersonDetails frm = new frmPersonDetails((int)dgvManagePeople.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }
    }
}
