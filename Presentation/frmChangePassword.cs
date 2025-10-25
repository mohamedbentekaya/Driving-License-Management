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
    public partial class frmChangePassword : Form
    {
        int _UserID;
        ClsUser _User;
        public frmChangePassword(int UserID)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen; // Center the form on screen
            _UserID = UserID;
        }

        private void LoadData()
        {
            _User = ClsUser.Find(_UserID);
            if (_User == null)
            {
                MessageBox.Show("this form will be closed because there is no User with this ID");
                this.Close();
                return;
            }
            ClsPerson _Person = ClsPerson.FindByID(_User.PersonID);
            ctrlUserCard1.SetUserData(_Person.PersonID, _Person.FullName(), _Person.NationalNo, _Person.Gendor,
                _Person.Email, _Person.Address, _Person.DateOfBirth.ToString(), _Person.Phone,
                ClsCountry.Find(_Person.NationalityCountryID).CountryName, _Person.ImagePath, _User.UserID, _User.UserName, _User.IsActive);
            txtbNewPassword.UseSystemPasswordChar = true;
            txtbConfirmNewPassword.UseSystemPasswordChar = true;

        }
        private void frmChangePassword_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void txtbCurrentPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtbCurrentPassword.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtbCurrentPassword, "Current Password cannot be empty!");
            }
            if (txtbCurrentPassword.Text != _User.GetPassword())
            {
                e.Cancel = true;
                errorProvider1.SetError(txtbCurrentPassword, "Current Password is wrong!");
            }
            if (!string.IsNullOrWhiteSpace(txtbCurrentPassword.Text) && txtbCurrentPassword.Text == _User.GetPassword())
            {
                errorProvider1.SetError(txtbCurrentPassword, "");  // or null
            }
        }

        private void txtbNewPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtbNewPassword.Text))
            {
                //e.Cancel = true;
                errorProvider1.SetError(txtbNewPassword, "New Password cannot be empty!");
            }
            if (!string.IsNullOrWhiteSpace(txtbNewPassword.Text))
            {
                errorProvider1.SetError(txtbNewPassword, "");  // or null
            }
        }

        private void txtbConfirmNewPassword_Validating(object sender, CancelEventArgs e)
        {
            if (txtbConfirmNewPassword.Text != txtbNewPassword.Text)
            {
                //e.Cancel = true;
                errorProvider1.SetError(txtbConfirmNewPassword, "New Password Confirmation does not match the New Password!");
            }
            if (txtbConfirmNewPassword.Text == txtbNewPassword.Text)
            {
                errorProvider1.SetError(txtbConfirmNewPassword, "");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private bool VerifAllInfo()
        {
            return !string.IsNullOrWhiteSpace(txtbNewPassword.Text) && !string.IsNullOrWhiteSpace(txtbConfirmNewPassword.Text);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (VerifAllInfo() && txtbNewPassword.Text == txtbConfirmNewPassword.Text)
            {
                _User.SetPassword(txtbConfirmNewPassword.Text);
            }
            else
            {
                MessageBox.Show("User Password not changedn Please enter all information correctly", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (_User.Save())
            {
                MessageBox.Show("User Password changed successfully");
            }
            else
            {
                MessageBox.Show("Somthing wrong", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtbNewPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtbCurrentPassword.Text) || txtbCurrentPassword.Text != _User.GetPassword()) // your condition
            {
                e.Handled = true; // Block the key
            }
        }

        private void txtbConfirmNewPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtbCurrentPassword.Text) || txtbCurrentPassword.Text != _User.GetPassword()) // your condition
            {
                e.Handled = true; // Block the key
            }
        }
    }
}
