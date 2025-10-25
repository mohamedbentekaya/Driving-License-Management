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
    public partial class frmDetainLicense : Form
    {
        int _LicenseID;
        ClsLicense _License;
        ClsDetainedLicense _DetainedLicense;
        public frmDetainLicense()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen; // Center the form on screen
            _LicenseID = -1;
        }
        private void LoadData()
        {
            ctrlLicenseCard1.SetLicenseInfo(_LicenseID);
            ctrlDetainLicense1.SetDetainInfo(_LicenseID);
        }
        private void frmDetainLicense_Load(object sender, EventArgs e)
        {
            btnDetain.Enabled = false;
            linklblShowLicenseHistory.Enabled = false;
            linklblShowLicenseInfo.Enabled = false;
        }
        private void btnSearchPerson_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtbFilter.Text))
            {
                _License = ClsLicense.Find(int.Parse(txtbFilter.Text));
                if (_License == null)
                {
                    MessageBox.Show("No License with LicenseID=" + txtbFilter.Text, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                _LicenseID = _License.LicenseID;
                linklblShowLicenseHistory.Enabled = true;
                if (_License.IsActive)
                {
                    if (!ClsDetainedLicense.ExistByLicenseID(_License.LicenseID))
                    {
                        LoadData();
                        btnDetain.Enabled = true;
                        //linklblShowLicenseHistory.Enabled = true;
                    }
                    else
                    {
                        LoadData();
                        MessageBox.Show("Selected License is already detained, choose another one.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    LoadData();
                    MessageBox.Show("this License is not active!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        private void txtbFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                // Block the character
                e.Handled = true;
            }
        }

        private void linklblShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ClsApplication App = ClsApplication.Find(_License.ApplicationID);
            if (App != null)
            {
                frmShowLicenseHistory frm = new frmShowLicenseHistory(App.ApplicationPersonID);
                frm.ShowDialog();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDetain_Click(object sender, EventArgs e)
        {
            if (_License != null)
            {
                _DetainedLicense = new ClsDetainedLicense();
                _DetainedLicense.LicenseID = _LicenseID;
                _DetainedLicense.DetainDate = DateTime.Now;
                decimal Fees = ctrlDetainLicense1.GettxtbFineFees();
                if (Fees != 0)
                {
                    _DetainedLicense.FineFees = Fees;
                }
                _DetainedLicense.CreatedByUserID = ClsCurrentUserInfo.UserID;
                _DetainedLicense.IsReleased = false;

                if (MessageBox.Show("Are you sure you want to Detain this License?", "Confirm Replace", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    if (_DetainedLicense.Save())
                    {
                        MessageBox.Show("License Detained successfully with ID=" + _DetainedLicense.DetainID.ToString());
                        ctrlDetainLicense1.SetDetainID(_DetainedLicense.DetainID);
                        linklblShowLicenseInfo.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("Somthing wrong");
                    }
                }
            }
            else
            {
                MessageBox.Show("No License with LicenseID=" + _LicenseID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void linklblShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLicenseInfo frm = new frmLicenseInfo(_LicenseID);
            frm.ShowDialog();
        }
    }
}
