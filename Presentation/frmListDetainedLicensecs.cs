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
    public partial class frmListDetainedLicensecs : Form
    {
        DataTable dtDetainList = ClsDetainedLicense.GetAllDetainedLicenses();
        public frmListDetainedLicensecs()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen; // Center the form on screen
        }
        private void _RefreshDetainLicenseList()
        {
            dgvDetainList.DataSource = dtDetainList;
            lblDetainedLicenseCount.Text = (dgvDetainList.Rows.Count).ToString();
        }
        private void _FillAttributesInComboBox()
        {
            cbFilter.Items.Clear(); // Clear old items

            cbFilter.Items.Add("None");
            cbFilter.Items.Add("DetainID");
            cbFilter.Items.Add("IsReleased");
            cbFilter.Items.Add("NationalNo");
            cbFilter.Items.Add("FullName");
            cbFilter.Items.Add("ReleaseApplicationID");
            cbFilter.SelectedIndex = 0;
        }
        private void frmListDetainedLicensecs_Load(object sender, EventArgs e)
        {
            _RefreshDetainLicenseList();
            _FillAttributesInComboBox();
        }
        private void _FillAttributesInIsReleasedComboBox()
        {
            cbIsReleased.Items.Clear(); // Clear old items
            cbIsReleased.Items.Add("All");
            cbIsReleased.Items.Add("Yes");
            cbIsReleased.Items.Add("No");
            cbIsReleased.SelectedIndex = 0;
        }
        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedColumn = cbFilter.SelectedItem.ToString();

            switch (selectedColumn)
            {
                case "None":
                    txtbManageDetainLicense.Visible = false;
                    cbIsReleased.Visible = false;
                    break;
                case "Is Released":
                    txtbManageDetainLicense.Visible = false;
                    cbIsReleased.Visible = true;
                    _FillAttributesInIsReleasedComboBox();
                    break;
                default:
                    txtbManageDetainLicense.Visible = true;
                    cbIsReleased.Visible = false;
                    break;

            }
        }

        private void cbIsReleased_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataView UsersdataView = dtDetainList.DefaultView;

            string selectedColumn = cbIsReleased.SelectedItem.ToString();

            if (selectedColumn == "All")
            {
                UsersdataView.RowFilter = ""; // remove filter if box is empty
            }
            else
            {
                if (selectedColumn == "Yes")
                {
                    // Correct syntax with quotes and LIKE
                    string query = $"IsReleased = true";
                    UsersdataView.RowFilter = query;
                }
                else
                {
                    string query = $"IsReleased = false";
                    UsersdataView.RowFilter = query;
                }
            }
            lblDetainedLicenseCount.Text = (dgvDetainList.Rows.Count).ToString();
        }

        private void txtbManageDetainLicense_KeyPress(object sender, KeyPressEventArgs e)
        {
            string selectedColumn = cbFilter.SelectedItem.ToString();

            switch (selectedColumn)
            {
                case "Detain ID":
                    if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                    {
                        // Block the character
                        e.Handled = true;
                    }
                    break;
                case "Release Application ID":
                    if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                    {
                        // Block the character
                        e.Handled = true;
                    }
                    break;
                case "Full Name":
                    if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
                    {
                        e.Handled = true; // Block the character
                    }
                    break;
                default:

                    break;
            }
        }

        private void txtbManageDetainLicense_TextChanged(object sender, EventArgs e)
        {
            DataView UsersdataView = dtDetainList.DefaultView;

            string selectedColumn = cbFilter.SelectedItem.ToString();

            if (string.IsNullOrEmpty(txtbManageDetainLicense.Text))
            {
                UsersdataView.RowFilter = ""; // remove filter if box is empty
            }
            else
            {
                if (selectedColumn != "DetainID" && selectedColumn != "ReleaseApplicationID")
                {
                    // Correct syntax with quotes and LIKE
                    string query = $"{selectedColumn} LIKE '{txtbManageDetainLicense.Text}%'";
                    UsersdataView.RowFilter = query;
                }
                else
                {
                    string query = $"Convert({selectedColumn}, 'System.String') LIKE '{txtbManageDetainLicense.Text}%'";
                    UsersdataView.RowFilter = query;
                }
            }
            lblDetainedLicenseCount.Text = (dgvDetainList.Rows.Count).ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvDetainList_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                // Clear any previous selection
                dgvDetainList.ClearSelection();

                // Select the row under the mouse
                dgvDetainList.Rows[e.RowIndex].Selected = true;

                // Optional: set current cell (helps with editing)
                dgvDetainList.CurrentCell = dgvDetainList.Rows[e.RowIndex].Cells[e.ColumnIndex];
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            frmDetainLicense frm = new frmDetainLicense();
            frm.ShowDialog();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            frmReleaseDetainedLicense frm = new frmReleaseDetainedLicense(-1);
            frm.ShowDialog();
        }

        private void showPersonDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClsPerson Person = ClsPerson.FindByNationalNo((string)dgvDetainList.CurrentRow.Cells[6].Value);
            if (Person != null) 
            {
                frmPersonDetails frm = new frmPersonDetails(Person.PersonID);
                frm.ShowDialog();
            }
        }

        private void showLicenseDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLicenseInfo frm = new frmLicenseInfo((int)dgvDetainList.CurrentRow.Cells[1].Value);
            frm.ShowDialog();
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClsPerson Person = ClsPerson.FindByNationalNo((string)dgvDetainList.CurrentRow.Cells[6].Value);
            if (Person != null)
            {
                frmShowLicenseHistory frm = new frmShowLicenseHistory(Person.PersonID);
                frm.ShowDialog();
            }
        }

        private void releaseDetainedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReleaseDetainedLicense frm = new frmReleaseDetainedLicense((int)dgvDetainList.CurrentRow.Cells[1].Value);
            frm.ShowDialog();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            releaseDetainedLicenseToolStripMenuItem.Enabled = true;
            if (dgvDetainList.CurrentRow != null)
            {
                // Access the "IsReleased" cell value from the current selected row
                bool isReleased = Convert.ToBoolean(dgvDetainList.CurrentRow.Cells["IsReleased"].Value);

                if (isReleased)
                {
                    releaseDetainedLicenseToolStripMenuItem.Enabled = false;
                }
                else
                {
                    releaseDetainedLicenseToolStripMenuItem.Enabled = true;
                }
            }
        }
    }
}
