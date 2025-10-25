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
    public partial class frmInternationalDriverInfo : Form
    {
        int _IntLicenseID;
        public frmInternationalDriverInfo(int intLicenseID)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen; // Center the form on screen
            _IntLicenseID = intLicenseID;
        }
        private void frmInternationalDriverInfo_Load(object sender, EventArgs e)
        {
            ctrlInternationalLicenseInfoCard1.SetLicenseInfo(_IntLicenseID);
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
