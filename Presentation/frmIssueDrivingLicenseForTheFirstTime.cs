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
    public partial class frmIssueDrivingLicenseForTheFirstTime : Form
    {
        int _LDID;
        ClsLocalDrivingLicenseApplication _LDApp;
        ClsLicense _License;
        public frmIssueDrivingLicenseForTheFirstTime(int LDID)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen; // Center the form on screen
            _LDID = LDID;

        }
        private void LoadData()
        {
            _License = new ClsLicense();
            ctrlApplicationCard1.SetApplicatioInfo(_LDID);
            _LDApp = ClsLocalDrivingLicenseApplication.Find(_LDID);
        }
        private void frmIssueDrivingLicenseForTheFirstTime_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            _License.ApplicationID = _LDApp.ApplicationID;
            _License.LicenseClass = _LDApp.LicenseClassID;
            _License.IssueDate = DateTime.Now;
            _License.ExpirationDate = _License.IssueDate.AddYears(ClsLicenseClass.Find(_License.LicenseClass).DefaultValidityLength);
            _License.Notes = txtbNotes.Text;
            _License.PaidFees = ClsLicenseClass.Find(_License.LicenseClass).ClassFees;
            _License.IsActive = true;
            _License.IssueReason = 1;
            _License.CreatedByUserID = ClsCurrentUserInfo.UserID;

            if (_License.Save())
            {
                MessageBox.Show("License Added successfully with ID=", _License.LicenseID.ToString());
                btnIssue.Enabled = false;
            }
            else
            {
                MessageBox.Show("Somthing wrong");
            }
        }

    }
}
