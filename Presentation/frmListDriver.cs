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
    public partial class frmListDriver : Form
    {
        DataTable dtDrivers = ClsDriver.GetAllDrivers();
        public frmListDriver()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen; // Center the form on screen
        }
        private void _RefreshManageDriverList()
        {
            dgvManageDrivers.DataSource = dtDrivers;
            lblDriversCount.Text = (dgvManageDrivers.Rows.Count).ToString();
        }
        private void _FillAttributesInComboBox()
        {
            cbFilter.Items.Clear(); // Clear old items

            cbFilter.Items.Add("None");
            cbFilter.SelectedIndex = 0;

            foreach (DataGridViewColumn column in dgvManageDrivers.Columns)
            {
                if (column.HeaderText != "Date")
                {
                    cbFilter.Items.Add(column.HeaderText);  // Add header text
                }
            }
        }
        private void frmListDriver_Load(object sender, EventArgs e)
        {
            _RefreshManageDriverList();
            _FillAttributesInComboBox();
            dgvManageDrivers.Columns["DriverID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvManageDrivers.Columns["PersonID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvManageDrivers.Columns["FullName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvManageDrivers.Columns["IsActive"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
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
                    txtbManageDrivers.Visible = false;
                    cbIsActive.Visible = false;
                    break;
                case "IsActive":
                    txtbManageDrivers.Visible = false;
                    cbIsActive.Visible = true;
                    _FillAttributesInIsActiveComboBox();
                    break;
                default:
                    txtbManageDrivers.Visible = true;
                    cbIsActive.Visible = false;
                    break;

            }
        }

        private void cbIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataView DriversdataView = dtDrivers.DefaultView;

            string selectedColumn = cbIsActive.SelectedItem.ToString();

            if (selectedColumn == "All")
            {
                DriversdataView.RowFilter = ""; // remove filter if box is empty
            }
            else
            {
                if (selectedColumn == "Yes")
                {
                    // Correct syntax with quotes and LIKE
                    string query = $"IsActive = true";
                    DriversdataView.RowFilter = query;
                }
                else
                {
                    string query = $"IsActive = false";
                    DriversdataView.RowFilter = query;
                }
            }
            lblDriversCount.Text = (dgvManageDrivers.Rows.Count).ToString();
        }

        private void txtbManageDrivers_KeyPress(object sender, KeyPressEventArgs e)
        {
            string selectedColumn = cbFilter.SelectedItem.ToString();

            switch (selectedColumn)
            {
                case "DriverID":
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
                case "FullName":
                    if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
                    {
                        e.Handled = true; // Block the character
                    }
                    break;
                default:

                    break;
            }
        }

        private void txtbManageDrivers_TextChanged(object sender, EventArgs e)
        {
            DataView DriversdataView = dtDrivers.DefaultView;

            string selectedColumn = cbFilter.SelectedItem.ToString();

            if (string.IsNullOrEmpty(txtbManageDrivers.Text))
            {
                DriversdataView.RowFilter = ""; // remove filter if box is empty
            }
            else
            {
                if (selectedColumn != "DriverID" && selectedColumn != "PersonID")
                {
                    // Correct syntax with quotes and LIKE
                    string query = $"{selectedColumn} LIKE '{txtbManageDrivers.Text}%'";
                    DriversdataView.RowFilter = query;
                }
                else
                {
                    string query = $"Convert({selectedColumn}, 'System.String') LIKE '{txtbManageDrivers.Text}%'";
                    DriversdataView.RowFilter = query;
                }
            }
            lblDriversCount.Text = (dgvManageDrivers.Rows.Count).ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvManageDrivers_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                // Clear any previous selection
                dgvManageDrivers.ClearSelection();

                // Select the row under the mouse
                dgvManageDrivers.Rows[e.RowIndex].Selected = true;

                // Optional: set current cell (helps with editing)
                dgvManageDrivers.CurrentCell = dgvManageDrivers.Rows[e.RowIndex].Cells[e.ColumnIndex];
            }
        }

        private void showPersonInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPersonDetails frm = new frmPersonDetails((int)dgvManageDrivers.CurrentRow.Cells[1].Value);
            frm.ShowDialog();
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowLicenseHistory frm = new frmShowLicenseHistory((int)dgvManageDrivers.CurrentRow.Cells[1].Value);
            frm.ShowDialog();
        }
    }
}
