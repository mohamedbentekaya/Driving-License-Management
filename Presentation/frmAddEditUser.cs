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
    public partial class frmAddEditUser : Form
    {
        public enum enMode { AddNew = 0, Update = 1 };
        enMode Mode;
        int _UserID;
        ClsUser _User;
        public frmAddEditUser(int UserID)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen; // Center the form on screen
            tabControl1.TabPages[1].Enabled = false;  // Disable TabPage2
            btnSave.Enabled = false;
            _UserID = UserID;
            if (_UserID == -1)
            {
                Mode = enMode.AddNew;
            }
            else
            {
                Mode = enMode.Update;
            }
        }

        private void LoadData()
        {
            if (Mode == enMode.AddNew)
            {
                lblMode.Text = "ADD NEW USER";
                _User = new ClsUser();
                return;
            }

            _User = ClsUser.Find(_UserID);
            if (_User == null)
            {
                MessageBox.Show("this form will be closed because there is no User with this ID");
                this.Close();
                return;
            }

            lblMode.Text = "EDITE USER ID= " + _UserID;
            ctrlPersonCardWithFiltre1.SelectedFilter = "PersonID";
            ctrlPersonCardWithFiltre1.txtFilter = _User.PersonID.ToString();
            ctrlPersonCardWithFiltre1.ClickSearchButton();
            ctrlPersonCardWithFiltre1.DesableFilter();
            ctrlPersonCardWithFiltre1.SetPersonInfoByID( _User.PersonID );
            lblUserID.Text = _User.UserID.ToString();
            txtbUserName.Text = _User.UserName.ToString();
            txtbPassword.UseSystemPasswordChar = false;
            txtbPassword.Text = _User.GetPassword();
            if (_User.IsActive)
            {
                checkBIsActive.Checked = true;
            }
            else
            {
                checkBIsActive.Checked = false;
            }
        }
        private void frmAddEditUser_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnNext_Click(object sender, EventArgs e)
        {
            int PersonID = ctrlPersonCardWithFiltre1.GetPersonID();
            if (PersonID != -1)
            {
                if (Mode == enMode.AddNew)
                {
                    if (!ClsUser.ExistUserByPersonID(PersonID))
                    {
                        tabControl1.TabPages[1].Enabled = true;  // Disable TabPage2
                        tabControl1.SelectedIndex = 1;
                        btnSave.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("Selected Person already has a user, choose another one", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    tabControl1.TabPages[1].Enabled = true;  // Disable TabPage2
                    tabControl1.SelectedIndex = 1;
                    btnSave.Enabled = true;
                }
            }

        }

        private void txtbUserName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtbUserName.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtbUserName, "First Name cannot be empty!");
            }
        }
        private void txtbPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtbPassword.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtbPassword, "Password cannot be empty!");
            }
            if (!string.IsNullOrWhiteSpace(txtbPassword.Text))
            {
                errorProvider1.SetError(txtbPassword, "");  // or null
            }
        }

        private void txtbConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (txtbConfirmPassword.Text != txtbPassword.Text)
            {
                //e.Cancel = true;
                errorProvider1.SetError(txtbConfirmPassword, "Password Confirmation does not match Password!");
            }
            if (txtbConfirmPassword.Text == txtbPassword.Text)
            {
                errorProvider1.SetError(txtbConfirmPassword, "");
            }
        }

        private void txtbPassword_Enter(object sender, EventArgs e)
        {
            txtbPassword.UseSystemPasswordChar = true; // Enable mask
        }
        private bool VerifAllInfo()
        {
            return !string.IsNullOrWhiteSpace(txtbUserName.Text) && !string.IsNullOrWhiteSpace(txtbPassword.Text) && !string.IsNullOrWhiteSpace(txtbConfirmPassword.Text);
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            _User.UserName = txtbUserName.Text;
            _User.PersonID = ctrlPersonCardWithFiltre1.GetPersonID();
            _User.SetPassword(txtbPassword.Text);
            if (checkBIsActive.Checked)
            {
                _User.IsActive = true;
            }
            else
            {
                _User.IsActive = false;
            }
            if (VerifAllInfo())
            {
                if (_User.Save())
                {
                    if (Mode == enMode.AddNew)
                    {
                        MessageBox.Show("User Added successfully");
                    }
                    else
                    {
                        MessageBox.Show("User Updated successfully");
                    }
                }
                else
                {
                    MessageBox.Show("Somthing wrong");
                }
                Mode = enMode.Update;
                lblMode.Text = "EDITE USER ID= " + _User.UserID;
                lblUserID.Text = _User.UserID.ToString();
            }
            else
            {
                MessageBox.Show("Please enter all informations", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtbConfirmPassword_Enter(object sender, EventArgs e)
        {
            txtbConfirmPassword.UseSystemPasswordChar = true;
        }
    }
}
