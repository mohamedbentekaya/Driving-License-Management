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
    public partial class ctrlDetainLicenseInfo : UserControl
    {
        int _LicenseID;
        ClsLicense _License;
        public ctrlDetainLicenseInfo()
        {
            InitializeComponent();
        }
        public void SetDetainID(int DetainID)
        {
            lblDetainID.Text = DetainID.ToString();
        }
        public void SetLicenseID(int LicenseID)
        {
            lblLicenseID.Text = LicenseID.ToString();
        }
        public void SetlblApplicationID(int ApplicationID)
        {
            lblApplicationID.Text = ApplicationID.ToString();
        }
        public void SetDetainInfo(int LicenseID)
        {
            _License = ClsLicense.Find(LicenseID);
            _LicenseID = LicenseID;
            ClsDetainedLicense DetainedLicense = ClsDetainedLicense.FindByLicenseID(_LicenseID);
            if (DetainedLicense != null) 
            {
                lblDetainID.Text = DetainedLicense.DetainID.ToString();
                lblDetainDate.Text = DetainedLicense.DetainDate.ToString();
                lblApplicationFees.Text = ClsApplicationType.Find(5).ApplicationFees.ToString();
                lblLicenseID.Text = _LicenseID.ToString();
                lblCreatedBy.Text = DetainedLicense.CreatedByUserID.ToString();
                lblFineFees.Text = DetainedLicense.FineFees.ToString();
                lblTotalFees.Text = (decimal.Parse(lblApplicationFees.Text) + decimal.Parse(lblFineFees.Text)).ToString();
            }
        }

    }
}
