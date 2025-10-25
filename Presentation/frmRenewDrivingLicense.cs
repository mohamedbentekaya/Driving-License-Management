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
    public partial class frmRenewDrivingLicense : Form
    {
        int _LicenseID;
        ClsLicense _License;
        ClsLicense _NewLicense;
        public frmRenewDrivingLicense()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen; // Center the form on screen
            _LicenseID = -1;
        }
        public void DesableFilter()
        {
            gbFilter.Enabled = false;
        }


        private void LoadData()
        {
            ctrlLicenseCard1.SetLicenseInfo(_LicenseID);
            ctrlAppNewLicenseInfo1.SetRenewAppInfo(_LicenseID);
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
                if (_License.IsActive)
                {
                    if (!ClsDetainedLicense.ExistByLicenseID(_License.LicenseID))
                    {
                        if (_License.ExpirationDate > DateTime.Now)
                        {
                            LoadData();
                            //btnRenew.Enabled = true;
                            linklblShowLicenseHistory.Enabled = true;
                            MessageBox.Show("Selected license is not yet expiared it will expire on:" + _License.ExpirationDate.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            LoadData();
                            btnRenew.Enabled = true;
                            linklblShowLicenseHistory.Enabled = true;
                        }
                    }
                    else
                    {
                        MessageBox.Show("this License is detained!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
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

        private void frmRenewDrivingLicense_Load(object sender, EventArgs e)
        {
            btnRenew.Enabled = false;
            linklblShowLicenseHistory.Enabled = false;
            linklblShowNewLicenseInfo.Enabled = false;
        }

        private void btnRenew_Click(object sender, EventArgs e)
        {
            ClsApplication NewApplication = new ClsApplication();
            _NewLicense = new ClsLicense();
            if (_License != null)
            {
                ClsApplication LDApp = ClsApplication.Find(_License.ApplicationID);
                NewApplication.ApplicationPersonID = LDApp.ApplicationPersonID;
                NewApplication.ApplicationDate = DateTime.Now;
                NewApplication.ApplicationTypeID = 2;
                NewApplication.ApplicationStatus = 1;
                NewApplication.LastStatusDate = DateTime.Now;
                NewApplication.PaidFees = ClsApplicationType.Find(2).ApplicationFees;
                NewApplication.CreatedByUserID = ClsCurrentUserInfo.UserID;

                _NewLicense.DriverID = _License.DriverID;
                _NewLicense.LicenseClass = _License.LicenseClass;
                _NewLicense.IssueDate = DateTime.Now;
                _NewLicense.ExpirationDate = DateTime.Now.AddYears(ClsLicenseClass.Find(_License.LicenseClass).DefaultValidityLength);
                _NewLicense.Notes = ctrlAppNewLicenseInfo1.GettxtbNotes();
                _NewLicense.PaidFees = _License.PaidFees;
                _NewLicense.IsActive = true;
                _NewLicense.IssueReason = 2;
                _NewLicense.CreatedByUserID = ClsCurrentUserInfo.UserID;
                if (MessageBox.Show("Are you sure you want to Renew this License?", "Confirm Renew", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    if (_NewLicense.SaveReNewLicense(NewApplication, _LicenseID))
                    {
                        MessageBox.Show("License Renewed successfully with ID="+_NewLicense.LicenseID.ToString());
                        ctrlAppNewLicenseInfo1.SetRenewLicenseID(_NewLicense.LicenseID);
                        ctrlAppNewLicenseInfo1.SetRLApplicationID(ClsLicense.Find(_NewLicense.LicenseID).ApplicationID);
                        linklblShowNewLicenseInfo.Enabled = true;
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

        private void linklblShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ClsApplication App = ClsApplication.Find(_License.ApplicationID);
            if (App != null)
            {
                frmShowLicenseHistory frm = new frmShowLicenseHistory(App.ApplicationPersonID);
                frm.ShowDialog();
            }
        }

        private void linklblShowNewLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLicenseInfo frm = new frmLicenseInfo(_NewLicense.LicenseID);
            frm.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
