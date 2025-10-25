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
    public partial class frmNewInternationalLicenseApplication : Form
    {
        int _LicenseID;
        ClsLicense _License;
        public frmNewInternationalLicenseApplication()
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
            ctrlInternationalAppInfo1.SetIntAppInfo(_LicenseID);
            if (ClsInternationalLicense.ExistInternationalLicenseByDriverID(_License.DriverID))
            {
                linklblShowLicenseInfo.Enabled = true;
            }
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
                            btnIssue.Enabled = true;
                            linklblShowLicenseHistory.Enabled = true;
                        }
                        else
                        {
                            MessageBox.Show("Your license is no longer valid. The expiration date has already passed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
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

        private void linklblShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmInternationalDriverInfo frm = new frmInternationalDriverInfo(ctrlInternationalAppInfo1.GetIntLicenseID());
            frm.ShowDialog();
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            ClsApplication Application = new ClsApplication();
            ClsInternationalLicense InternationalLicense = new ClsInternationalLicense();
            //_License = ClsLicense.Find(_LicenseID);
            if (_License != null)
            {
                ClsApplication LDApp = ClsApplication.Find(_License.ApplicationID);
                Application.ApplicationPersonID = LDApp.ApplicationPersonID;
                Application.ApplicationDate = DateTime.Now;
                Application.ApplicationTypeID = 6;
                Application.ApplicationStatus = 1;
                Application.LastStatusDate = DateTime.Now;
                Application.PaidFees = ClsApplicationType.Find(6).ApplicationFees;
                Application.CreatedByUserID = ClsCurrentUserInfo.UserID;

                InternationalLicense.DriverID = _License.DriverID;
                InternationalLicense.IssuedUsingLocalLicenseID = _License.LicenseID;
                InternationalLicense.IssueDate = DateTime.Now;
                InternationalLicense.ExpirationDate = DateTime.Now.AddYears(1);
                InternationalLicense.IsActive = true;
                InternationalLicense.CreatedByUserID = ClsCurrentUserInfo.UserID;
                if (!ClsInternationalLicense.ExistInternationalLicenseByDriverID(_License.DriverID))
                {
                    if (ClsLicense.ExistLicenseByPersonIDAndLicenseClass(Application.ApplicationPersonID, 3))
                    {
                        if (InternationalLicense.Save(Application))
                        {
                            MessageBox.Show("International License Added successfully");
                            ctrlInternationalAppInfo1.SetILApplicationID(Application.ApplicationID);
                            ctrlInternationalAppInfo1.SetILLicenseID(ClsInternationalLicense.FindByAppID(Application.ApplicationID).InternationalLicenseID);
                            linklblShowLicenseInfo.Enabled = true;
                        }
                        else
                        {
                            MessageBox.Show("Somthing wrong");
                        }
                    }
                    else
                    {
                        MessageBox.Show("selected License should be class 3 ,shouse another one", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Person already have an active international Driving License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
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
            ClsLicense License = ClsLicense.Find(_LicenseID);
            if (License != null)
            {
                ClsApplication Application = ClsApplication.Find(License.ApplicationID);
                frmShowLicenseHistory frm = new frmShowLicenseHistory(Application.ApplicationPersonID);
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("No License with LicenseID=" + _LicenseID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

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

        private void frmNewInternationalLicenseApplication_Load(object sender, EventArgs e)
        {
            btnIssue.Enabled = false;
            linklblShowLicenseHistory.Enabled = false;
            linklblShowLicenseInfo.Enabled = false;
        }
    }
}
