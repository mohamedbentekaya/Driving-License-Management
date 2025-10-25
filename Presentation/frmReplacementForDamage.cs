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
    public partial class frmReplacementForDamage : Form
    {
        int _LicenseID;
        ClsLicense _License;
        ClsLicense _NewLicense;
        public frmReplacementForDamage()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen; // Center the form on screen
            _LicenseID = -1;
        }
        private void LoadData()
        {
            ctrlLicenseCard1.SetLicenseInfo(_LicenseID);
            ctrlAppReplacementInfo1.SetReplacedAppInfo(_LicenseID);
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
                        btnIssueReplacement.Enabled = true;
                        //linklblShowLicenseHistory.Enabled = true;
                    }
                    else
                    {
                        LoadData();
                        MessageBox.Show("this License is detained!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            frmLicenseInfo frm = new frmLicenseInfo(_NewLicense.LicenseID);
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

        

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void radbDamageLicense_CheckedChanged(object sender, EventArgs e)
        {
            ctrlAppReplacementInfo1.SetlblApplicatioFees(4);
        }

        private void rdbLostLicense_CheckedChanged(object sender, EventArgs e)
        {
            ctrlAppReplacementInfo1.SetlblApplicatioFees(3);
        }

        private void btnIssueReplacement_Click(object sender, EventArgs e)
        {
            ClsApplication NewApplication = new ClsApplication();
            _NewLicense = new ClsLicense();
            if (_License != null)
            {
                ClsApplication LDApp = ClsApplication.Find(_License.ApplicationID);
                NewApplication.ApplicationPersonID = LDApp.ApplicationPersonID;
                NewApplication.ApplicationDate = DateTime.Now;
                //NewApplication.ApplicationTypeID = 2;
                NewApplication.ApplicationStatus = 1;
                NewApplication.LastStatusDate = DateTime.Now;
                //NewApplication.PaidFees = ClsApplicationType.Find(2).ApplicationFees;
                NewApplication.CreatedByUserID = ClsCurrentUserInfo.UserID;
                _NewLicense.DriverID = _License.DriverID;
                _NewLicense.LicenseClass = _License.LicenseClass;
                _NewLicense.IssueDate = DateTime.Now;
                _NewLicense.ExpirationDate = DateTime.Now.AddYears(ClsLicenseClass.Find(_License.LicenseClass).DefaultValidityLength);
                _NewLicense.Notes = _License.Notes;
                _NewLicense.PaidFees = _License.PaidFees;
                _NewLicense.IsActive = true;
                //_NewLicense.IssueReason = 2;
                _NewLicense.CreatedByUserID = ClsCurrentUserInfo.UserID;
                if (radbDamageLicense.Checked)
                {
                    NewApplication.ApplicationTypeID = 4;
                    NewApplication.PaidFees = ClsApplicationType.Find(4).ApplicationFees;
                    _NewLicense.IssueReason = 3;
                }
                else
                {
                    NewApplication.ApplicationTypeID = 3;
                    NewApplication.PaidFees = ClsApplicationType.Find(3).ApplicationFees;
                    _NewLicense.IssueReason = 4;
                }
                if (MessageBox.Show("Are you sure you want to Replace this License?", "Confirm Replace", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    if (_NewLicense.SaveReNewLicense(NewApplication, _LicenseID))
                    {
                        MessageBox.Show("License Replaced successfully with ID="+ _NewLicense.LicenseID.ToString());
                        ctrlAppReplacementInfo1.SetReplacedLicenseID(_NewLicense.LicenseID);
                        ctrlAppReplacementInfo1.SetLRApplicationID(ClsLicense.Find(_NewLicense.LicenseID).ApplicationID);
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

        private void txtbFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                // Block the character
                e.Handled = true;
            }
        }

        private void frmReplacementForDamage_Load(object sender, EventArgs e)
        {
            btnIssueReplacement.Enabled = false;
            linklblShowLicenseHistory.Enabled = false;
            linklblShowNewLicenseInfo.Enabled = false;
        }
    }
}
