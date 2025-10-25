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
    public partial class frmScheduleTest : Form
    {
        // Declare a delegate
        public delegate void DataBackEventHandler(object sender);

        // Declare an event using the delegate
        public event DataBackEventHandler DataBack;
        public enum enMode { AddNew = 0, Update = 1 };
        enMode Mode;
        int _TestAppointmentID;
        ClsTestAppointment _TestAppointment;
        int _DLID;
        ClsLocalDrivingLicenseApplication _DLApp;
        int _TestTypeID;
        ClsApplication _Application;
        bool _RetakeTest;
        public frmScheduleTest(int TestAppointmentID, int DLID, int TestTypeID, bool RetakeTest)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen; // Center the form on screen
            _TestAppointmentID = TestAppointmentID;
            if (_TestAppointmentID == -1)
            {
                Mode = enMode.AddNew;
            }
            else
            {
                Mode = enMode.Update;
            }
            _DLID = DLID;
            _TestTypeID = TestTypeID;
            _RetakeTest = RetakeTest;
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
            dateTimePicker1.MinDate = DateTime.Now;
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            gbRetakeTestInfo.Enabled = false;
            lblRAppFees.Text = "0";
            LoadPicture();
            _DLApp = ClsLocalDrivingLicenseApplication.Find(_DLID);
            if (_DLApp == null)
            {
                MessageBox.Show("No Application with DLAppID=" + _DLID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _Application = ClsApplication.Find(_DLApp.ApplicationID);
            ClsPerson _Person = ClsPerson.FindByID(_Application.ApplicationPersonID);

            lblLDLAppID.Text = _DLID.ToString();
            lblDClass.Text = ClsLicenseClass.Find(_DLApp.LicenseClassID).ClassName;
            lblName.Text = _Person.FullName();
            //lblTrial.Text = 0;
            lblFees.Text = ClsTestType.Find(_TestTypeID).TestTypeFees.ToString();
            lblTotalFees.Text = (decimal.Parse(lblFees.Text) + decimal.Parse(lblRAppFees.Text)).ToString();

            if (_RetakeTest)
            {
                gbRetakeTestInfo.Enabled = true;
                lblRAppFees.Text = "5";
                lblTotalFees.Text = (decimal.Parse(lblFees.Text) + decimal.Parse(lblRAppFees.Text)).ToString();
            }
            if (Mode == enMode.AddNew)
            {

                _TestAppointment = new ClsTestAppointment();
                return;
            }

            _TestAppointment = ClsTestAppointment.Find(_TestAppointmentID);
            if (_TestAppointment == null)
            {
                MessageBox.Show("this form will be closed because there is no Test Appointment with this ID");
                this.Close();
                return;
            }
            if (_TestAppointment.IsLocked)
            {
                lblLockedTest.Text = "Person already sat for the test, appointment locked.";
                gbRetakeTestInfo.Enabled = true;
                lblRAppFees.Text = "0";
                lblTotalFees.Text = lblFees.Text;
                btnSave.Enabled = false;
                dateTimePicker1.Enabled = false;
            }
            if (_TestAppointment.RetakeTestApplicationID != -1)
            {
                _RetakeTest = true;
                gbRetakeTestInfo.Enabled = true;
                lblRAppFees.Text = "5";
                lblTotalFees.Text = (decimal.Parse(lblFees.Text) + decimal.Parse(lblRAppFees.Text)).ToString();
                lblRTestAppID.Text = _TestAppointment.RetakeTestApplicationID.ToString();
            }
        }
        private void frmScheduleTest_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void SaveRetakeApplication()
        {
            ClsApplication RetakeApp = new ClsApplication();
            RetakeApp.ApplicationPersonID = _Application.ApplicationPersonID;
            RetakeApp.ApplicationDate = DateTime.Now;
            RetakeApp.ApplicationTypeID = 8;
            RetakeApp.ApplicationStatus = 1;
            RetakeApp.LastStatusDate = DateTime.Now;
            RetakeApp.PaidFees = ClsApplicationType.Find(RetakeApp.ApplicationTypeID).ApplicationFees;
            RetakeApp.CreatedByUserID = ClsCurrentUserInfo.UserID;


            if (!ClsApplication.ExistApplicationByPersonIDAndLicenseIDAndApplicationType(RetakeApp.ApplicationPersonID, _DLApp.LicenseClassID, RetakeApp.ApplicationTypeID))
            {
                if (_TestAppointment.Save(RetakeApp))
                {
                    if (Mode == enMode.AddNew)
                    {
                        MessageBox.Show("Retake Test Appointment Added successfully");
                    }
                    else
                    {
                        MessageBox.Show("Retake Test Appointment Updated successfully");
                    }
                }
                else
                {
                    MessageBox.Show("Somthing wrong");
                }
            }
            else
            {
                MessageBox.Show("Choose another License Class the selected Person Already have an active retake Test application for the selected Class", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Mode == enMode.AddNew)
            {
                _TestAppointment.TestTypeID = _TestTypeID;
                _TestAppointment.LocalDrivingLicenseApplicationID = _DLID;
                _TestAppointment.AppointmentDate = dateTimePicker1.Value;
                _TestAppointment.PaidFees = decimal.Parse(lblTotalFees.Text);
                _TestAppointment.CreatedByUserID = ClsCurrentUserInfo.UserID;
                _TestAppointment.IsLocked = false;
            }
            else
            {
                _TestAppointment.AppointmentDate = dateTimePicker1.Value;
            }
            if (_RetakeTest)
            {
                SaveRetakeApplication();
            }
            else
            {
                if (_TestAppointment.Save())
                {
                    if (Mode == enMode.AddNew)
                    {
                        MessageBox.Show("Test Appointment Added successfully");
                    }
                    else
                    {
                        MessageBox.Show("Test Appointment Updated successfully");
                    }
                }
                else
                {
                    MessageBox.Show("Somthing wrong");
                }

            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            DataBack?.Invoke(sender);
            this.Close();
        }
        private void frmScheduleTest_FormClosing(object sender, FormClosingEventArgs e)
        {
            DataBack?.Invoke(sender);
        }
    }
}
