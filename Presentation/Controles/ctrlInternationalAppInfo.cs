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
    public partial class ctrlInternationalAppInfo : UserControl
    {
        int _LicenseID;
        ClsLicense _License;
        public ctrlInternationalAppInfo()
        {
            InitializeComponent();
        }
        public void SetILApplicationID(int ILApplicationID)
        {
            lblILApplicationID.Text = ILApplicationID.ToString();
        }
        public void SetILLicenseID(int ILLicenseID)
        {
            lblILLicenseID.Text = ILLicenseID.ToString();
        }
        public int GetIntLicenseID()
        {
            return int.Parse(lblILLicenseID.Text);
        }
        public void SetIntAppInfo(int LicenseID)
        {
            _License = ClsLicense.Find(LicenseID);
            if (ClsInternationalLicense.ExistInternationalLicenseByDriverID(_License.DriverID))
            {
                ClsInternationalLicense IntLicense = ClsInternationalLicense.FindByDriverID(_License.DriverID);
                SetILLicenseID(IntLicense.InternationalLicenseID);
                SetILApplicationID(IntLicense.ApplicationID);
            }
            _LicenseID = LicenseID;
            _License = ClsLicense.Find(_LicenseID);
            lblApplicationDate.Text = DateTime.Now.ToString();
            lblIssueDate.Text = DateTime.Now.ToString();
            lblFees.Text = ClsApplicationType.Find(6).ApplicationFees.ToString();
            lblLocalLicenseID.Text = _LicenseID.ToString();
            lblExpirationDate.Text = DateTime.Now.AddYears(1).ToString();
            lblCreatedBy.Text = ClsCurrentUserInfo.UserName;
        }

       
    }
}
