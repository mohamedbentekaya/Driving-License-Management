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
    public partial class ctrlPersonCardWithFiltre : UserControl
    {
        int _PersonID;
        public ctrlPersonCardWithFiltre()
        {
            InitializeComponent();
            _PersonID = -1;
        }

        public string txtFilter
        {
            get { return txtbFilterPeople.Text; }
            set { txtbFilterPeople.Text = value; }
        }

        // Expose ComboBox selected value
        public string SelectedFilter
        {
            get { return cbFilter.SelectedItem?.ToString(); }
            set { cbFilter.SelectedItem = value; }
        }
        public void ClickSearchButton()
        {
            btnSearchPerson.PerformClick();
        }
        public void DesableFilter()
        {
            cbFilter.Enabled = false;
            label1.Enabled = false;
            txtbFilterPeople.Enabled = false;
            btnSearchPerson.Enabled = false;
            btnAddPerson.Enabled = false;
        }
        private void FillComboBoxFilter()
        {
            cbFilter.Items.Clear();
            cbFilter.Items.Add("NationalNo");
            cbFilter.Items.Add("PersonID");
            cbFilter.SelectedIndex = 0;
        }
        public void SetPersonInfoByID(int PersonID)
        {
            SelectedFilter = "PersonID";
            txtbFilterPeople.Text = PersonID.ToString();
            ClickSearchButton();
            DesableFilter();
        }
        private void ctrlPersonCardWithFiltre_Load(object sender, EventArgs e)
        {
            FillComboBoxFilter();
        }
        public int GetPersonID()
        {
            return _PersonID;
        }
        private void txtbFilterPeople_KeyPress(object sender, KeyPressEventArgs e)
        {
            string selectedColumn = cbFilter.SelectedItem.ToString();

            if (selectedColumn == "PersonID")
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    // Block the character
                    e.Handled = true;
                }
            }
        }
        private void btnSearchPerson_Click(object sender, EventArgs e)
        {
            string selectedColumn = cbFilter.SelectedItem.ToString();

            if (!string.IsNullOrEmpty(txtbFilterPeople.Text))
            {
                if (selectedColumn == "PersonID")
                {
                    ClsPerson Person = ClsPerson.FindByID(int.Parse(txtbFilterPeople.Text));
                    if (Person == null)
                    {
                        MessageBox.Show("No Person with PersonID=" + txtbFilterPeople.Text, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    _PersonID = Person.PersonID;
                    ctrlPersonCard1.SetPersonData(Person.PersonID, Person.FullName(), Person.NationalNo, Person.Gendor,
                        Person.Email, Person.Address, Person.DateOfBirth.ToString(), Person.Phone,
                        ClsCountry.Find(Person.NationalityCountryID).CountryName, Person.ImagePath);
                }
                else
                {
                    ClsPerson Person = ClsPerson.FindByNationalNo(txtbFilterPeople.Text);
                    if (Person == null)
                    {
                        MessageBox.Show("No Person with Nationalno=" + txtbFilterPeople.Text, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    _PersonID = Person.PersonID;
                    ctrlPersonCard1.SetPersonData(Person.PersonID, Person.FullName(), Person.NationalNo, Person.Gendor,
                        Person.Email, Person.Address, Person.DateOfBirth.ToString(), Person.Phone,
                        ClsCountry.Find(Person.NationalityCountryID).CountryName, Person.ImagePath);
                }
            }
        }
        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            frmAddEditPerson frm = new frmAddEditPerson(-1);
            frm.DataBack += SetPersonInfoByPersonID;
            frm.ShowDialog();
        }
        public void SetPersonInfoByPersonID(object sender, int PersonID)
        {
            ClsPerson Person = ClsPerson.FindByID(PersonID);
            if (Person == null)
            {
                MessageBox.Show("No Person with PersonID=" + txtbFilterPeople.Text, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _PersonID = Person.PersonID;
            ctrlPersonCard1.SetPersonData(Person.PersonID, Person.FullName(), Person.NationalNo, Person.Gendor,
                Person.Email, Person.Address, Person.DateOfBirth.ToString(), Person.Phone,
                ClsCountry.Find(Person.NationalityCountryID).CountryName, Person.ImagePath);
        }

       
    }
}
