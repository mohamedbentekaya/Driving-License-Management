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
using static System.Net.Mime.MediaTypeNames;

namespace Presentation.Controles
{
    public partial class ctrlApplicationCard : UserControl
    {
        int _DLAppID;
        ClsLocalDrivingLicenseApplication _DLApp;
        ClsApplication _Application;
        public ctrlApplicationCard()
        {
            InitializeComponent();
        }
        public void SetApplicatioInfo(int DLAppID)
        {
            _DLAppID = DLAppID;
            _DLApp = ClsLocalDrivingLicenseApplication.Find(_DLAppID);
            if (_DLApp != null)
            {
                _Application = ClsApplication.Find(_DLApp.ApplicationID);
            }
            else
            {
                MessageBox.Show("No Application with DLAppID=" + _DLAppID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            ClsApplicationType _ApplicationType = ClsApplicationType.Find(_Application.ApplicationTypeID);
            ClsUser _User = ClsUser.Find(_Application.CreatedByUserID);
            ClsPerson _Person = ClsPerson.FindByID(_Application.ApplicationPersonID);

            lblLDLAppID.Text = _DLAppID.ToString();
            lblAppliedForLicense.Text = ClsLicenseClass.Find(_DLApp.LicenseClassID).ClassName;
            lblTestsPassed.Text = ClsLocalDrivingLicenseApplication.GetPassedTests(_DLAppID).ToString() + "/3";
            if (!ClsLicense.ExistLicenseByAppID(_DLApp.ApplicationID))
            {
                linklblLicenseInfo.Enabled = false;
            }
            lblApplicationID.Text = _Application.ApplicationID.ToString();
            lblStatus.Text = _Application.ApplicationStatus.ToString();
            switch (_Application.ApplicationStatus)
            {
                case 1:
                    lblStatus.Text = "new";
                    break;
                case 2:
                    lblStatus.Text = "cancelled";
                    break;
                case 3:
                    lblStatus.Text = "completed";
                    break;
            }
            lblFees.Text = _Application.PaidFees.ToString();
            lblType.Text = _ApplicationType.ApplicationTypeTitle;
            lblApplicant.Text = _Person.FullName();
            lblDate.Text = _Application.ApplicationDate.ToString();
            lblStatusDate.Text = _Application.LastStatusDate.ToString();
            lblCreatedBy.Text = _User.UserName;
        }

        private void linklblLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLicenseInfo frm = new frmLicenseInfo(ClsLicense.GetLicenseIDByAppID(_Application.ApplicationID));
            frm.ShowDialog();
        }

        private void linklblPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmPersonDetails frm = new frmPersonDetails(_Application.ApplicationPersonID);
            frm.ShowDialog();
        }
    }
}
