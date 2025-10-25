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
    public partial class ctrlPersonCard : UserControl
    {
        int _PersonID;
        public ctrlPersonCard()
        {
            InitializeComponent();
            _PersonID = -1;
        }

        public void SetPersonData(int PersonID, string FullName, string NationalNo, byte Gendor, string email,
            string Address, string DateOfBirth, string Phone, string Country, string ImagePath)
        {

            _PersonID = PersonID;
            lblPersonID.Text = PersonID.ToString();
            lblFullName.Text = FullName;
            lblNationalNo.Text = NationalNo;
            if (Gendor == 0)
            {
                lblGendor.Text = "Male";
            }
            else
            {
                lblGendor.Text = "Female";
            }
            lblEmail.Text = email;
            lblAddress.Text = Address;
            lblDateOfBirth.Text = DateOfBirth;
            lblPhone.Text = Phone;
            lblCountry.Text = Country;
            if (ImagePath != "")
            {
                pictureBox1.Load(ImagePath);
            }
            else
            {
                if (Gendor == 1)
                {
                    pictureBox1.Image = Properties.Resources.unkown_women;
                }
                else
                {
                    pictureBox1.Image = Properties.Resources.unknown_Person;
                }
            }
        }

        private void linklblEditPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddEditPerson frm = new frmAddEditPerson(_PersonID);
            frm.DataBack += SetPersonInfoByPersonID;
            frm.ShowDialog();
        }

        public void SetPersonInfoByPersonID(object sender, int PersonID)
        {
            ClsPerson Person = ClsPerson.FindByID(PersonID);
            if (Person == null)
            {
                MessageBox.Show("No Person with PersonID=" + PersonID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _PersonID = Person.PersonID;
            SetPersonData(Person.PersonID, Person.FullName(), Person.NationalNo, Person.Gendor,
                Person.Email, Person.Address, Person.DateOfBirth.ToString(), Person.Phone,
                ClsCountry.Find(Person.NationalityCountryID).CountryName, Person.ImagePath);
        }
    }
}
