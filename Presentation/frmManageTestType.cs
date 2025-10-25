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
    public partial class frmManageTestType : Form
    {
        DataTable dtTestTypes = ClsTestType.GetAllTestTypes();
        public frmManageTestType()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen; // Center the form on screen
        }
        private void _RefreshManageTestTypesList()
        {
            dgvManageTestTypes.DataSource = dtTestTypes;
            lblTestTypeCount.Text = (dgvManageTestTypes.Rows.Count).ToString();
        }
        private void frmManageTestType_Load(object sender, EventArgs e)
        {
            _RefreshManageTestTypesList();
            dgvManageTestTypes.Columns["TestTypeID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvManageTestTypes.Columns["TestTypeTitle"].Width = 120;
            dgvManageTestTypes.Columns["TestTypeDescription"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvManageTestTypes.Columns["TestTypeFees"].Width = 100;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvManageTestTypes_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                // Clear any previous selection
                dgvManageTestTypes.ClearSelection();

                // Select the row under the mouse
                dgvManageTestTypes.Rows[e.RowIndex].Selected = true;

                // Optional: set current cell (helps with editing)
                dgvManageTestTypes.CurrentCell = dgvManageTestTypes.Rows[e.RowIndex].Cells[e.ColumnIndex];
            }
        }

        private void editTestTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEditTestType frm = new frmEditTestType((int)dgvManageTestTypes.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Re-fetch data from the database
            dtTestTypes = ClsTestType.GetAllTestTypes();
            // Refresh DataGridView
            dgvManageTestTypes.DataSource = dtTestTypes;
        }
    }
}
