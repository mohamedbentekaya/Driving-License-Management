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
    public partial class ctrlLicenseCard : UserControl
    {
        int _LicenseID;
        ClsLicense _License;
        public ctrlLicenseCard()
        {
            InitializeComponent();
        }
        public void SetLicenseInfo(int LicenseID)
        {
            _LicenseID = LicenseID;
            _License = ClsLicense.Find(_LicenseID);
            ClsApplication _Application;
            ClsPerson _Person;
            if (_License != null)
            {
                _Application = ClsApplication.Find(_License.ApplicationID);
                if (_Application != null)
                {
                    _Person = ClsPerson.FindByID(_Application.ApplicationPersonID);
                }
                else
                {
                    MessageBox.Show("Person not found for LicenseID=" + _LicenseID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                MessageBox.Show("No License with _LicenseID=" + _LicenseID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            lblClass.Text = ClsLicenseClass.Find(_License.LicenseClass).ClassName;
            lblName.Text = _Person.FullName();
            lblLicenseID.Text = _LicenseID.ToString();
            lblNationalNo.Text = _Person.NationalNo;
            if (_Person.Gendor == 0)
            {
                lblGendor.Text = "Male";
                pictureBox4.Image = Properties.Resources.icons8_male_50;
            }
            else
            {
                lblGendor.Text = "Female";
                pictureBox4.Image = Properties.Resources.icons8_female_50;
            }
            lblIssueDate.Text = _License.IssueDate.ToString();
            switch (_License.IssueReason)
            {
                case 1:
                    lblIssueReason.Text = "First Time";
                    break;
                case 2:
                    lblIssueReason.Text = "Renew";
                    break;
                case 3:
                    lblIssueReason.Text = "Replacement For Lost";
                    break;
                case 4:
                    lblIssueReason.Text = "Replacement For Damage";
                    break;
            }
            lblNotes.Text = _License.Notes;
            if (_License.IsActive)
            {
                lblIsActive.Text = "YES";
            }
            else
            {
                lblIsActive.Text = "NO";
            }
            lblDateOfBirth.Text = _Person.DateOfBirth.ToString();
            lblDriverID.Text = _License.DriverID.ToString();
            lblExpirationDate.Text = _License.ExpirationDate.ToString();
            if (ClsDetainedLicense.ExistByLicenseID(_LicenseID))
            {
                lblIsDetained.Text = "YES";
            }
            else
            {
                lblIsDetained.Text = "NO";
            }
            if (_Person.ImagePath != "")
            {
                pictureBox14.Load(_Person.ImagePath);
            }
            else
            {
                if (_Person.Gendor == 0)
                {
                    pictureBox14.Image = Properties.Resources.unknown_Person;
                }
                else
                {
                    pictureBox14.Image = Properties.Resources.unkown_women;
                }
            }
        }

        
    }
}
