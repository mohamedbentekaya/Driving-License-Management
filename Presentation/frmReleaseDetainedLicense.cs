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
    public partial class frmReleaseDetainedLicense : Form
    {
        int _LicenseID;
        ClsLicense _License;
        ClsDetainedLicense _DetainLicense;
        public frmReleaseDetainedLicense(int LicenseID)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen; // Center the form on screen
            _LicenseID = LicenseID;
        }
        private void LoadData()
        {
            ctrlLicenseCard1.SetLicenseInfo(_LicenseID);
            ctrlDetainLicenseInfo1.SetDetainInfo(_LicenseID);
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
                    if (ClsDetainedLicense.ExistByLicenseID(_License.LicenseID))
                    {
                        LoadData();
                        btnRelease.Enabled = true;
                        //linklblShowLicenseHistory.Enabled = true;
                    }
                    else
                    {
                        LoadData();
                        MessageBox.Show("this License is not detained, choose another one.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        private void linklblShowNewLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLicenseInfo frm = new frmLicenseInfo(_License.LicenseID);
            frm.ShowDialog();
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
        private void txtbFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                // Block the character
                e.Handled = true;
            }
        }
        private void frmReleaseDetainedLicense_Load(object sender, EventArgs e)
        {
            if (_LicenseID != -1)
            {
                linklblShowLicenseHistory.Enabled = true;
                btnRelease.Enabled = true;
                txtbFilter.Text = _LicenseID.ToString();
                btnSearchPerson.PerformClick();
                gbFilter.Enabled = false;
            }
            else
            {
                btnRelease.Enabled = false;
                linklblShowLicenseHistory.Enabled = false;
            }
                linklblShowNewLicenseInfo.Enabled = false;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRelease_Click(object sender, EventArgs e)
        {
            ClsApplication NewApplication = new ClsApplication();
            if (_License != null)
            {
                _DetainLicense = ClsDetainedLicense.FindByLicenseID(_LicenseID);
                _DetainLicense.ReleaseDate = DateTime.Now;
                _DetainLicense.ReleasedByUserID = ClsCurrentUserInfo.UserID;

                ClsApplication LDApp = ClsApplication.Find(_License.ApplicationID);
                NewApplication.ApplicationPersonID = LDApp.ApplicationPersonID;
                NewApplication.ApplicationDate = DateTime.Now;
                NewApplication.ApplicationTypeID = 5;
                NewApplication.ApplicationStatus = 1;
                NewApplication.LastStatusDate = DateTime.Now;
                NewApplication.PaidFees = ClsApplicationType.Find(5).ApplicationFees;
                NewApplication.CreatedByUserID = ClsCurrentUserInfo.UserID;
                
                if (MessageBox.Show("Are you sure you want to Rlease this License?", "Confirm Rlease", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    if (_DetainLicense.SaveRelease(NewApplication))
                    {
                        MessageBox.Show("Detained License Rleased successfully ");
                        _DetainLicense = ClsDetainedLicense.Find(_DetainLicense.DetainID);
                        ctrlDetainLicenseInfo1.SetlblApplicationID(_DetainLicense.ReleaseApplicationID);
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
    }
}
