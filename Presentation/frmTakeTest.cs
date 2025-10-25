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
    public partial class frmTakeTest : Form
    {
        // Declare a delegate
        public delegate void DataBackEventHandler(object sender);

        // Declare an event using the delegate
        public event DataBackEventHandler DataBack;
        public enum enMode { AddNew = 0, Update = 1 };
        enMode Mode;
        int _TestID;
        ClsTest _Test;
        int _TestAppointmentID;
        ClsTestAppointment _TestAppointment;
        int _DLID;
        ClsLocalDrivingLicenseApplication _DLApp;
        int _TestTypeID;
        ClsApplication _Application;
        public frmTakeTest(int TestAppointmentID, int DLID, int TestTypeID)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen; // Center the form on screen
            _Test = ClsTest.FindByTestAppointmentID(TestAppointmentID);
            if (_Test != null)
            {
                _TestID = _Test.TestID;
            }
            else
            {
                _TestID = -1;
            }
            if (_TestID == -1)
            {
                Mode = enMode.AddNew;
            }
            else
            {
                Mode = enMode.Update;
            }
            _TestAppointmentID = TestAppointmentID;
            _DLID = DLID;
            _TestTypeID = TestTypeID;
        }
        private void LoadPicture()
        {
            switch (_TestTypeID)
            {
                case 1:
                    picBTestAppointment.Image = Properties.Resources.Vesion_Test;
                    groupBox1.Text = "Vesion Test";
                    break;
                case 2:
                    picBTestAppointment.Image = Properties.Resources.Writen_Test;
                    groupBox1.Text = "Writen Test";
                    break;
                case 3:
                    picBTestAppointment.Image = Properties.Resources.Street_Test;
                    groupBox1.Text = "Street Test";
                    break;
            }
        }
        private void LoadData()
        {
            LoadPicture();
            _DLApp = ClsLocalDrivingLicenseApplication.Find(_DLID);
            if (_DLApp == null)
            {
                MessageBox.Show("No Application with DLAppID=" + _DLID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _Application = ClsApplication.Find(_DLApp.ApplicationID);
            ClsPerson _Person = ClsPerson.FindByID(_Application.ApplicationPersonID);
            _TestAppointment = ClsTestAppointment.Find(_TestAppointmentID);
            lblLDLAppID.Text = _DLID.ToString();
            lblDClass.Text = ClsLicenseClass.Find(_DLApp.LicenseClassID).ClassName;
            lblName.Text = _Person.FullName();
            lblTrial.Text = ClsTest.GetFailTestCount(_DLID, _TestTypeID).ToString();
            lblDate.Text = _TestAppointment.AppointmentDate.ToString("dd/MMM/yyyy");
            if (_TestAppointment.RetakeTestApplicationID != -1)
            {
                lblFees.Text = (ClsTestType.Find(_TestTypeID).TestTypeFees + ClsApplicationType.Find(8).ApplicationFees).ToString();
            }
            else
            {
                lblFees.Text = ClsTestType.Find(_TestTypeID).TestTypeFees.ToString();
            }
            if (Mode == enMode.AddNew)
            {
                _Test = new ClsTest();
                return;
            }
            _Test = ClsTest.Find(_TestID);
            if (_Test.TestResult)
            {
                radbtnPass.Checked = true;
            }
            else
            {
                radbtnFail.Checked = true;
            }
            txtbNotes.Text = _Test.Notes.ToString();
            radbtnPass.Enabled = false;
            radbtnFail.Enabled = false;
            if (_Test == null)
            {
                MessageBox.Show("this form will be closed because there is no Test with this ID");
                this.Close();
                return;
            }

        }
        private void frmTakeTest_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private bool VerifInfo()
        {
            return radbtnFail.Checked || radbtnPass.Checked;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            _Test.TestAppointmentID = _TestAppointmentID;
            if (radbtnPass.Checked)
            {
                _Test.TestResult = true;
            }
            else
            {
                _Test.TestResult = false;
            }
            if (!string.IsNullOrWhiteSpace(txtbNotes.Text))
            {
                _Test.Notes = txtbNotes.Text;
            }
            _Test.CreatedByUserID = ClsCurrentUserInfo.UserID;

            if (VerifInfo())
            {
                if (_Test.Save())
                {
                    if (Mode == enMode.AddNew)
                    {
                        MessageBox.Show("Test Taked successfully");
                    }
                    else
                    {
                        MessageBox.Show("Test Result Updated successfully");
                    }
                    lblTestID.Text = _Test.TestAppointmentID.ToString();
                }
                else
                {
                    MessageBox.Show("Somthing wrong");
                }
            }
            else
            {
                MessageBox.Show("Please enter the result", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DataBack?.Invoke(sender);
            this.Close();
        }

        private void frmTakeTest_FormClosing(object sender, FormClosingEventArgs e)
        {
            DataBack?.Invoke(sender);
        }
    }
}
