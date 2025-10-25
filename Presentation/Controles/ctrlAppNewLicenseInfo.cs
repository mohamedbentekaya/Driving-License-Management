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

namespace Presentation.Controles
{
    public partial class ctrlAppNewLicenseInfo : UserControl
    {
        int _LicenseID;
        ClsLicense _License;
        public ctrlAppNewLicenseInfo()
        {
            InitializeComponent();
        }
        public void SetRLApplicationID(int RLApplicationID)
        {
            lblRLApplicationID.Text = RLApplicationID.ToString();
        }
        public void SetRenewLicenseID(int RenewLicenseID)
        {
            lblRenewLicenseID.Text = RenewLicenseID.ToString();
        }
        public string GettxtbNotes()
        {
            return txtbNotes.Text;
        }

        public void SetRenewAppInfo(int LicenseID)
        {
            _License = ClsLicense.Find(LicenseID);
            /*if (ClsLicense.ExistRnewLicenseByDriverID(_License.DriverID))
            {
                ClsLicense RenewLicense = ClsLicense.FindRnewLicenseByDriverID(_License.DriverID);
                SetRenewLicenseID(RenewLicense.LicenseID);
                SetRLApplicationID(RenewLicense.ApplicationID);
            }*/
            _LicenseID = LicenseID;
            lblApplicationDate.Text = DateTime.Now.ToString();
            lblIssueDate.Text = DateTime.Now.ToString();
            lblApplicationFees.Text = ClsApplicationType.Find(2).ApplicationFees.ToString();
            lblLicenseFees.Text = ClsLicenseClass.Find(_License.LicenseClass).ClassFees.ToString();
            lblOldLicenseID.Text = _LicenseID.ToString();
            lblExpirationDate.Text = DateTime.Now.AddYears(ClsLicenseClass.Find(_License.LicenseClass).DefaultValidityLength).ToString();
            lblCreatedBy.Text = ClsCurrentUserInfo.UserName;
            lblTotalFees.Text = (decimal.Parse(lblApplicationFees.Text) + decimal.Parse(lblLicenseFees.Text)).ToString();
        }

        
    }
}
