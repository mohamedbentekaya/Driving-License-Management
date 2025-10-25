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
    public partial class frmPersonDetails : Form
    {
        int _PersonID;
        ClsPerson _Person;
        public frmPersonDetails(int PersonID)
        {
            _PersonID = PersonID;
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen; // Center the form on screen
        }
        private void LoadData()
        {
            _Person = ClsPerson.FindByID(_PersonID);
            if (_Person == null)
            {
                MessageBox.Show("this form will be closed because there is no Person with this ID");
                this.Close();
                return;
            }
            ctrlPersonCard1.SetPersonData(_Person.PersonID, _Person.FullName(), _Person.NationalNo, _Person.Gendor,
                _Person.Email, _Person.Address, _Person.DateOfBirth.ToString(), _Person.Phone,
                ClsCountry.Find(_Person.NationalityCountryID).CountryName, _Person.ImagePath);
        }
        private void frmPersonDetails_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
