using DVDLBusinessLayer;
using Presentation.Controles;
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
    public partial class frmTestAppointment : Form
    {
        int _LDID;
        int _TestTypeID;
        public frmTestAppointment(int LDID, int TestTypeID)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen; // Center the form on screen
            _LDID = LDID;
            _TestTypeID = TestTypeID;
        }
        public void LoadData()
        {
            switch (_TestTypeID)
            {
                case 1:
                    picBTestAppointment.Image = Properties.Resources.Vesion_Test;
                    lblTestAppointmentMode.Text = "Vision Test Appointment";
                    this.Text = "Vision Test Appointment";
                    break;
                case 2:
                    picBTestAppointment.Image = Properties.Resources.Writen_Test;
                    lblTestAppointmentMode.Text = "Writen Test Appointment";
                    this.Text = "Writen Test Appointment";
                    break;
                case 3:
                    picBTestAppointment.Image = Properties.Resources.Street_Test;
                    lblTestAppointmentMode.Text = "Street Test Appointment";
                    this.Text = "Street Test Appointment";
                    break;
            }
            ctrlApplicationCard1.SetApplicatioInfo(_LDID);

        }
        private void _RefreshManageAppointmentList()
        {
            DataTable dtAppointments = ClsTestAppointment.GetTestAppointments(_LDID, _TestTypeID);
            if (dtAppointments == null || dtAppointments.Rows.Count == 0)
            {
                // No appointments found
                lblAppointmentsCount.Text = "0";
                dgvManageAppointments.DataSource = null; // clear grid
                return;
            }
            dgvManageAppointments.DataSource = dtAppointments;
            lblAppointmentsCount.Text = (dgvManageAppointments.Rows.Count).ToString();
            if (dgvManageAppointments.DataSource != null)
            {
                dgvManageAppointments.Columns["TestAppointmentID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvManageAppointments.Columns["AppointmentDate"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvManageAppointments.Columns["PaidFees"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvManageAppointments.Columns["IsLocked"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void dgvManageAppointments_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                // Clear any previous selection
                dgvManageAppointments.ClearSelection();

                // Select the row under the mouse
                dgvManageAppointments.Rows[e.RowIndex].Selected = true;

                // Optional: set current cell (helps with editing)
                dgvManageAppointments.CurrentCell = dgvManageAppointments.Rows[e.RowIndex].Cells[e.ColumnIndex];
            }
        }
        private void frmTestAppointment_Load(object sender, EventArgs e)
        {
            _RefreshManageAppointmentList();
            LoadData();
        }
        private bool HasUnlockedAppointment()
        {
            foreach (DataGridViewRow row in dgvManageAppointments.Rows)
            {
                // Skip the "new row" placeholder
                if (row.IsNewRow) continue;

                bool isLocked = row.Cells["IsLocked"].Value != DBNull.Value
                                && Convert.ToBoolean(row.Cells["IsLocked"].Value);

                if (!isLocked)
                {
                    return true; // Found at least one row that is not locked
                }
            }

            return false; // All rows are locked
        }
        private void _RefreshManageAppointmentList(object sender)
        {
            DataTable dtAppointments = ClsTestAppointment.GetTestAppointments(_LDID, _TestTypeID);
            dgvManageAppointments.DataSource = dtAppointments;
            lblAppointmentsCount.Text = (dgvManageAppointments.Rows.Count).ToString();
        }
        private void btnAddAppointment_Click(object sender, EventArgs e)
        {
            if (!HasUnlockedAppointment())
            {
                if (!ClsTest.GetTestResult(_LDID, _TestTypeID) && dgvManageAppointments.DataSource != null)
                {
                    frmScheduleTest frm = new frmScheduleTest(-1, _LDID, _TestTypeID, true);
                    frm.DataBack += _RefreshManageAppointmentList;
                    frm.ShowDialog();
                }
                else if (!ClsTest.GetTestResult(_LDID, _TestTypeID))
                {
                    frmScheduleTest frm = new frmScheduleTest(-1, _LDID, _TestTypeID, false);
                    frm.DataBack += _RefreshManageAppointmentList;
                    frm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Person already passed this test, You can only retake failed test", "Unlocked Appointment", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Person already have an active appointment for this test, You cannot add new appointment", "Unlocked Appointment", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmScheduleTest frm = new frmScheduleTest((int)dgvManageAppointments.CurrentRow.Cells[0].Value, _LDID, _TestTypeID, false);
            frm.DataBack += _RefreshManageAppointmentList;
            frm.ShowDialog();
        }
        private void takeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTakeTest frm = new frmTakeTest((int)dgvManageAppointments.CurrentRow.Cells[0].Value, _LDID, _TestTypeID);
            frm.DataBack += _RefreshManageAppointmentList;
            frm.ShowDialog();
        }
    }
}
