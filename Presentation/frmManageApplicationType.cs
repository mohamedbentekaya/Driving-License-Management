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
    public partial class frmManageApplicationType : Form
    {
        DataTable dtApplicationTypes = ClsApplicationType.GetAllApplicationTypes();
        public frmManageApplicationType()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen; // Center the form on screen
        }
        private void _RefreshManageApplicationTypesList()
        {
            dgvManageApplicationTypes.DataSource = dtApplicationTypes;
            lblApplicationTypeCount.Text = (dgvManageApplicationTypes.Rows.Count).ToString();
        }
        private void frmManageApplicationType_Load(object sender, EventArgs e)
        {

            _RefreshManageApplicationTypesList();
            dgvManageApplicationTypes.Columns["ApplicationTypeID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvManageApplicationTypes.Columns["ApplicationTypeTitle"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvManageApplicationTypes.Columns["ApplicationFees"].Width = 100;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvManageApplicationTypes_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                // Clear any previous selection
                dgvManageApplicationTypes.ClearSelection();

                // Select the row under the mouse
                dgvManageApplicationTypes.Rows[e.RowIndex].Selected = true;

                // Optional: set current cell (helps with editing)
                dgvManageApplicationTypes.CurrentCell = dgvManageApplicationTypes.Rows[e.RowIndex].Cells[e.ColumnIndex];
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEditApplicationType frm = new frmEditApplicationType((int)dgvManageApplicationTypes.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Re-fetch data from the database
            dtApplicationTypes = ClsApplicationType.GetAllApplicationTypes();
            // Refresh DataGridView
            dgvManageApplicationTypes.DataSource = dtApplicationTypes;

        }
    }
}
