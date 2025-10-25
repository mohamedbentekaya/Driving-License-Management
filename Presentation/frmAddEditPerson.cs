using DVDLBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentation
{
    public partial class frmAddEditPerson : Form
    {
        // Declare a delegate
        public delegate void DataBackEventHandler(object sender, int PersonID);

        // Declare an event using the delegate
        public event DataBackEventHandler DataBack;
        public enum enMode { AddNew = 0, Update = 1 };
        enMode Mode;
        int _PersonID;
        ClsPerson _Person;
        public frmAddEditPerson(int PersonID)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen; // Center the form on screen
            _PersonID = PersonID;
            if (_PersonID == -1)
            {
                Mode = enMode.AddNew;
            }
            else
            {
                Mode = enMode.Update;
            }
        }
        private void _FillCountriesInComboBox()
        {
            DataTable dt = ClsCountry.GetAllCountries();

            foreach (DataRow dr in dt.Rows)
            {
                comboBoxCountry.Items.Add(dr[1].ToString());
            }


        }

        private void LoadData()
        {
            _FillCountriesInComboBox();

            dateTimePicker1.MaxDate = DateTime.Now.AddYears(-18); ;
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            comboBoxCountry.SelectedIndex = ClsCountry.FindByName("Tunisia").CountryID - 1;
            radbtnMale.Checked = true;

            if (Mode == enMode.AddNew)
            {
                lblMode.Text = "ADD NEW PERSON";
                _Person = new ClsPerson();
                return;
            }

            _Person = ClsPerson.FindByID(_PersonID);
            if (_Person == null)
            {
                MessageBox.Show("this form will be closed because there is no Person with this ID");
                this.Close();
                return;
            }

            lblMode.Text = "EDITE PERSON ID= " + _PersonID;
            lblPersonID.Text = _PersonID.ToString();
            txtbNationalNo.Text = _Person.NationalNo;
            txtbFirstName.Text = _Person.FirstName;
            txtbLastName.Text = _Person.LastName;
            dateTimePicker1.Value = _Person.DateOfBirth;
            if (_Person.Gendor == 0)
            {
                radbtnMale.Checked = true;
            }
            else
            {
                radbtnFemale.Checked = true;
            }
            txtbAddress.Text = _Person.Address;
            txtbPhone.Text = _Person.Phone;
            txtbEmail.Text = _Person.Email;
            comboBoxCountry.SelectedIndex = comboBoxCountry.FindString(ClsCountry.Find(_Person.NationalityCountryID).CountryName);
            if (_Person.ImagePath != "")
            {
                pictureBox1.Load(_Person.ImagePath);
            }
            linklblRemoveImage.Visible = _Person.ImagePath != "";
        }
        private void frmAddEditPerson_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private string _CopyImage(string sourcePath, string destinationFolder)
        {
            // Ensure destination folder exists
            if (!Directory.Exists(destinationFolder))
            {
                Directory.CreateDirectory(destinationFolder);
            }

            // Generate a GUID filename with the same extension
            string extension = Path.GetExtension(sourcePath);
            string newFileName = Guid.NewGuid().ToString() + extension;

            // Full destination path
            string destinationPath = Path.Combine(destinationFolder, newFileName);

            // Copy the file
            File.Copy(sourcePath, destinationPath);

            return destinationPath;
        }
        private bool _DeleteImage(string imagePath)
        {
            //string imagePath = @"C:\Users\YourName\Pictures\image.jpg";

            if (File.Exists(imagePath))
            {
                File.Delete(imagePath);
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool VerifAllInfo()
        {
            return !string.IsNullOrWhiteSpace(txtbFirstName.Text) && !string.IsNullOrWhiteSpace(txtbLastName.Text) && !string.IsNullOrWhiteSpace(txtbNationalNo.Text) && !string.IsNullOrWhiteSpace(txtbAddress.Text);
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            int CountryID = ClsCountry.FindByName(comboBoxCountry.Text).CountryID;

            _Person.NationalNo = txtbNationalNo.Text;
            _Person.FirstName = txtbFirstName.Text;
            _Person.LastName = txtbLastName.Text;
            _Person.DateOfBirth = dateTimePicker1.Value;
            if (radbtnMale.Checked)
            {
                _Person.Gendor = 0;
            }
            else
            {
                _Person.Gendor = 1;
            }
            _Person.Address = txtbAddress.Text;
            _Person.Phone = txtbPhone.Text;
            _Person.Email = txtbEmail.Text;
            _Person.NationalityCountryID = CountryID;

            if (pictureBox1.ImageLocation != null)
            {
                if (Mode == enMode.AddNew)
                {
                    _Person.ImagePath = _CopyImage(pictureBox1.ImageLocation.ToString(), @"C:\DVLD_People_Images\");
                }
                else
                {
                    string OldImagePath = ClsPerson.FindByID(_PersonID).ImagePath;
                    if (pictureBox1.ImageLocation.ToString() != OldImagePath)
                    {
                        if (OldImagePath != "")
                        {
                            _DeleteImage(OldImagePath);
                        }
                        _Person.ImagePath = _CopyImage(pictureBox1.ImageLocation.ToString(), @"C:\DVLD_People_Images\");
                    }
                }

            }
            else
            {
                _Person.ImagePath = "";
            }
            if (VerifAllInfo())
            {
                if (_Person.Save())
                {
                    if (Mode == enMode.AddNew)
                    {
                        MessageBox.Show("Person Added successfully");
                    }
                    else
                    {
                        MessageBox.Show("Person Updated successfully");
                    }
                }
                else
                {
                    MessageBox.Show("Somthing wrong");
                }
                Mode = enMode.Update;
                lblMode.Text = "EDITE PERSON ID= " + _Person.PersonID;
                lblPersonID.Text = _Person.PersonID.ToString();
            }
            else
            {
                MessageBox.Show("Please enter all informations", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            int PersonID = int.Parse(lblPersonID.Text);
            DataBack?.Invoke(sender, PersonID);
            this.Close();
        }
        private void frmAddEditPerson_FormClosing(object sender, FormClosingEventArgs e)
        {
            int personID;
            if (int.TryParse(lblPersonID.Text, out personID))
            {
                DataBack?.Invoke(sender, personID);
            }
        }
        private void linklblSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Process the selected file
                string selectedFilePath = openFileDialog1.FileName;
                //MessageBox.Show("Selected Image is:" + selectedFilePath);

                pictureBox1.Load(selectedFilePath);
                // ...
            }
        }

        private void linklblRemoveImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pictureBox1.ImageLocation = null;
            linklblRemoveImage.Visible = false;
            _DeleteImage(_Person.ImagePath);
        }

        private void txtbNationalNo_Validating(object sender, CancelEventArgs e)
        {
            if (ClsPerson.ExistPersonByNationalNo(txtbNationalNo.Text))
            {
                e.Cancel = true;
                txtbNationalNo.Focus();
                errorProvider1.SetError(txtbNationalNo, "National Number is used for another person!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtbNationalNo, "");
            }
            //Make sure the national number is not used by another person
            if (txtbNationalNo.Text.Trim() != _Person.NationalNo && ClsPerson.ExistPersonByNationalNo(txtbNationalNo.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtbNationalNo, "National Number is used for another person!");

            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtbNationalNo, "");
            }
        }
        private void radbtnFemale_CheckedChanged(object sender, EventArgs e)
        {
            pictureBox1.Image = Properties.Resources.unkown_women;

        }
        private void radbtnMale_CheckedChanged(object sender, EventArgs e)
        {
            pictureBox1.Image = Properties.Resources.unknown_Person;

        }

        private void txtbEmail_Validating(object sender, CancelEventArgs e)
        {
            string email = txtbEmail.Text;

            // Regular expression for email validation
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

            if (!string.IsNullOrWhiteSpace(email))
            {
                if (!Regex.IsMatch(email, pattern))
                {
                    e.Cancel = true;
                    errorProvider1.SetError(txtbEmail, "Invalid email format!");
                }
                else
                {
                    e.Cancel = false;
                    errorProvider1.SetError(txtbEmail, "");
                }
            }
        }

        private void txtbAddress_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtbAddress.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtbAddress, "Address cannot be empty!");
            }

        }
    }
}
