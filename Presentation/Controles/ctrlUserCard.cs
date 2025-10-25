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
    public partial class ctrlUserCard : UserControl
    {
        public ctrlUserCard()
        {
            InitializeComponent();
        }

        public void SetUserData(int PersonID, string FullName, string NationalNo, byte Gendor, string email,
             string Address, string DateOfBirth, string Phone, string Country, string ImagePath,
             int UserID, string UserName, bool IsActiv)
        {

            ctrlPersonCard1.SetPersonData(PersonID, FullName, NationalNo, Gendor, email,
            Address, DateOfBirth, Phone, Country, ImagePath);
            lblUserID.Text = UserID.ToString();
            lblUserName.Text = UserName;
            if (IsActiv)
            {
                lblIsActive.Text = "yes";
            }
            else
            {
                lblIsActive.Text = "no";
            }
        }
    }
}
