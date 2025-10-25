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
    public partial class ctrlAppReplacementInfo : UserControl
    {
        int _LicenseID;
        ClsLicense _License;
        public ctrlAppReplacementInfo()
        {
            InitializeComponent();
        }
        public void SetLRApplicationID(int LRApplicationID)
        {
            lblLRApplicationID.Text = LRApplicationID.ToString();
        }
        public void SetReplacedLicenseID(int ReplacedLicenseID)
        {
            lblReplacedLicenseID.Text = ReplacedLicenseID.ToString();
        }
        public void SetlblApplicatioFees(int ApplicationTypeID)
        {
            lblApplicationFees.Text = ClsApplicationType.Find(ApplicationTypeID).ApplicationFees.ToString();
        }
        public decimal GetlblApplicatioFees()
        {
            return decimal.Parse(lblApplicationFees.Text);
        }
        public void SetReplacedAppInfo(int LicenseID)
        {
            _License = ClsLicense.Find(LicenseID);
            
            _LicenseID = LicenseID;
            lblApplicationDate.Text = DateTime.Now.ToString();
            lblApplicationFees.Text = ClsApplicationType.Find(2).ApplicationFees.ToString();
            lblOldLicenseID.Text = _LicenseID.ToString();
            lblCreatedBy.Text = ClsCurrentUserInfo.UserName;
        }

    }
}
