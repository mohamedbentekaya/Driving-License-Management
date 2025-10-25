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
    public partial class frmUserDetails : Form
    {
        int _UserID;
        ClsUser _User;
        public frmUserDetails(int UserID)
        {
            _UserID = UserID;
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen; // Center the form on screen
        }

        private void frmUserDetails_Load(object sender, EventArgs e)
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
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
