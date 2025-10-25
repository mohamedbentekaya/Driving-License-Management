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
    public partial class frmNewLocalDrivingLicenseApplication : Form
    {
        public enum enMode { AddNew = 0, Update = 1 };
        enMode Mode;
        int _LocalDrivingLicenseApplicationID;
        ClsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication;
        ClsApplication _Application;
        public frmNewLocalDrivingLicenseApplication(int LocalDrivingLicenseApplicationID)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen; // Center the form on screen
            tabControl1.TabPages[1].Enabled = false;  // Disable TabPage2
            btnSave.Enabled = false;
            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            if (_LocalDrivingLicenseApplicationID == -1)
            {
                Mode = enMode.AddNew;
            }
            else
            {
                Mode = enMode.Update;
            }
        }
        private void FillLicenseClassComboBox()
        {
            DataTable dt = ClsLicenseClass.GetAllLicenseClasses();

            foreach (DataRow dr in dt.Rows)
            {
                cbLicenseClass.Items.Add(dr[1].ToString());
            }

        }
        private void LoadData()
        {
            FillLicenseClassComboBox();
            cbLicenseClass.SelectedIndex = 0;


            lblUserName.Text = ClsCurrentUserInfo.UserName;
            if (Mode == enMode.AddNew)
            {
                lblDLApplicationDate.Text = DateTime.Now.ToString();
                lblDLApplicationFees.Text = "15";
                lblMode.Text = "New Local Driving License";
                _LocalDrivingLicenseApplication = new ClsLocalDrivingLicenseApplication();
                _Application = new ClsApplication();
                return;
            }
            _LocalDrivingLicenseApplication = ClsLocalDrivingLicenseApplication.Find(_LocalDrivingLicenseApplicationID);
            _Application = ClsApplication.Find(_LocalDrivingLicenseApplication.ApplicationID);
            if (_Application == null || _LocalDrivingLicenseApplication == null)
            {
                MessageBox.Show("this form will be closed because there is no Application with this ID");
                this.Close();
                return;
            }
            lblDLApplicationFees.Text = ClsApplicationType.Find(_Application.ApplicationTypeID).ApplicationFees.ToString();
            lblDLApplicationDate.Text = _Application.ApplicationDate.ToString();
            lblMode.Text = "Edite Local Driving License ID= " + _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID;


            ctrlPersonCardWithFiltre1.SetPersonInfoByID(_Application.ApplicationPersonID);


            lblDLApplicationID.Text = _Application.ApplicationID.ToString();

        }
        private void frmNewLocalDrivingLicenseApplication_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            int PersonID = ctrlPersonCardWithFiltre1.GetPersonID();
            if (PersonID != -1)
            {
                tabControl1.TabPages[1].Enabled = true;  // Disable TabPage2
                tabControl1.SelectedIndex = 1;
                btnSave.Enabled = true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _Application.ApplicationPersonID = ctrlPersonCardWithFiltre1.GetPersonID();
            _Application.ApplicationDate = DateTime.Parse(lblDLApplicationDate.Text);
            _Application.ApplicationTypeID = 1;
            _Application.ApplicationStatus = 1;
            _Application.LastStatusDate = DateTime.Now;
            _Application.PaidFees = int.Parse(lblDLApplicationFees.Text);
            _Application.CreatedByUserID = ClsCurrentUserInfo.UserID;
            int LicenseClassID = ClsLicenseClass.FindByClassName(cbLicenseClass.SelectedItem.ToString()).LicenseClassID;

            _LocalDrivingLicenseApplication.LicenseClassID = LicenseClassID;

            if (!ClsApplication.ExistApplicationByPersonIDAndLicenseIDAndApplicationType(_Application.ApplicationPersonID, LicenseClassID, _Application.ApplicationTypeID))
            {
                if (ClsLicense.ExistLicenseByPersonIDAndLicenseClass(_Application.ApplicationPersonID, LicenseClassID))
                {
                    MessageBox.Show("Person Already have a License with the same applied Driving Class, Chosse another Driving Clss", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (_LocalDrivingLicenseApplication.Save(_Application))
                    {
                        if (Mode == enMode.AddNew)
                        {
                            MessageBox.Show("Application Added successfully");
                        }
                        else
                        {
                            MessageBox.Show("Application Updated successfully");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Somthing wrong");
                    }
                    Mode = enMode.Update;
                    lblMode.Text = "Edite Local Driving License ID= " + _Application.ApplicationID;
                    lblDLApplicationID.Text = _Application.ApplicationID.ToString();
                }
            }
            else
            {
                MessageBox.Show("Choose another License Class the selected Person Already have an active application for the selected Class", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
    }
}
