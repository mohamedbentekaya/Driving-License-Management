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
    public partial class frmShowLicenseHistory : Form
    {
        int _PersonID;
        DataTable dtLicensesTypes;
        DataTable dtIntLicensesTypes;
        public frmShowLicenseHistory(int PersonID)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen; // Center the form on screen
            _PersonID = PersonID;

        }
        private void _RefreshManageLicensesTypesList()
        {
            dtLicensesTypes = ClsLicense.GetAllLicensesByPersonID(_PersonID);
            dgvLocalLicensesHistory.DataSource = dtLicensesTypes;
            lblCountLocalRecords.Text = (dgvLocalLicensesHistory.Rows.Count).ToString();

            dtIntLicensesTypes = ClsInternationalLicense.GetAllIntLicensesByPersonID(_PersonID);
            dgvInternationalLicenseHistory.DataSource = dtIntLicensesTypes;
            lblInternationalLicensesCount.Text = (dgvInternationalLicenseHistory.Rows.Count).ToString();
        }
        private void frmShowLicenseHistory_Load(object sender, EventArgs e)
        {
            if (!ClsDriver.ExistDriverByPersonID(_PersonID)) 
            {
                MessageBox.Show("Tere is no driver linked with person with id= "+_PersonID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            ctrlPersonCard1.SetPersonInfoByPersonID(sender, _PersonID);
            _RefreshManageLicensesTypesList();
            if (dtLicensesTypes.Rows.Count > 0)
            {
                dgvLocalLicensesHistory.Columns["LicID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvLocalLicensesHistory.Columns["AppID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvLocalLicensesHistory.Columns["ClassName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvLocalLicensesHistory.Columns["IsActive"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
            if (dtIntLicensesTypes.Rows.Count > 0)
            {
                dgvInternationalLicenseHistory.Columns["IntLicenseID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvInternationalLicenseHistory.Columns["AppID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvInternationalLicenseHistory.Columns["LLicenseID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvInternationalLicenseHistory.Columns["IssueDate"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvInternationalLicenseHistory.Columns["ExpirationDate"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvInternationalLicenseHistory.Columns["IsActive"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvLocalLicensesHistory_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                // Clear any previous selection
                dgvLocalLicensesHistory.ClearSelection();

                // Select the row under the mouse
                dgvLocalLicensesHistory.Rows[e.RowIndex].Selected = true;

                // Optional: set current cell (helps with editing)
                dgvLocalLicensesHistory.CurrentCell = dgvLocalLicensesHistory.Rows[e.RowIndex].Cells[e.ColumnIndex];
            }
        }

        private void showLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInternationalDriverInfo frm = new frmInternationalDriverInfo((int)dgvInternationalLicenseHistory.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmLicenseInfo frm = new frmLicenseInfo((int)dgvLocalLicensesHistory.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }
    }
}
