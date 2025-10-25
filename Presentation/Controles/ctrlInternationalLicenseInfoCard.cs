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
    public partial class ctrlInternationalLicenseInfoCard : UserControl
    {
        int _IntLicenseID;
        ClsInternationalLicense _IntLicense;
        public ctrlInternationalLicenseInfoCard()
        {
            InitializeComponent();
        }

        public void SetLicenseInfo(int IntLicenseID)
        {
            _IntLicenseID = IntLicenseID;
            _IntLicense = ClsInternationalLicense.Find(_IntLicenseID);
            ClsApplication _Application;
            ClsPerson _Person;
            if (_IntLicense != null)
            {
                _Application = ClsApplication.Find(_IntLicense.ApplicationID);
                if (_Application != null)
                {
                    _Person = ClsPerson.FindByID(_Application.ApplicationPersonID);
                }
                else
                {
                    MessageBox.Show("Person not found for International LicenseID=" + _IntLicenseID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                MessageBox.Show("No International License with _IntLicenseID=" + _IntLicenseID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            lblName.Text = _Person.FullName();
            lblIntLicenseID.Text = _IntLicenseID.ToString();
            lblLicenseID.Text = _IntLicense.IssuedUsingLocalLicenseID.ToString();
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
            lblIssueDate.Text = _IntLicense.IssueDate.ToString();
            lblApplicationID.Text = _IntLicense.ApplicationID.ToString();
            if (_IntLicense.IsActive)
            {
                lblIsActive.Text = "YES";
            }
            else
            {
                lblIsActive.Text = "NO";
            }
            lblDateOfBirth.Text = _Person.DateOfBirth.ToString();
            lblDriverID.Text = _IntLicense.DriverID.ToString();
            lblExpirationDate.Text = _IntLicense.ExpirationDate.ToString();
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
