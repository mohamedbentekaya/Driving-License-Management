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
    public partial class ctrlDetainLicense : UserControl
    {
        int _LicenseID;
        ClsLicense _License;
        public ctrlDetainLicense()
        {
            InitializeComponent();
        }
        public void SetDetainID(int DetainID)
        {
            lblDetainID.Text = DetainID.ToString();
        }
        public decimal GettxtbFineFees()
        {
            if (!string.IsNullOrEmpty(txtbFineFees.Text))
            {
                return decimal.Parse(txtbFineFees.Text);
            }
            else
            {
                return 0;
            }
        }

        private void txtbFineFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                // Block the character
                e.Handled = true;
            }
        }
        public void SetDetainInfo(int LicenseID)
        {
            _License = ClsLicense.Find(LicenseID);

            _LicenseID = LicenseID;
            lblDetainDate.Text = DateTime.Now.ToString();
            lblLicenseID.Text = _LicenseID.ToString();
            lblCreatedBy.Text = ClsCurrentUserInfo.UserName;
        }

        
    }
}
