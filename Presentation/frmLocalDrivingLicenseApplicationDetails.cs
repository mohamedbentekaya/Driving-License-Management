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
    public partial class frmLocalDrivingLicenseApplicationDetails : Form
    {
        int _LDID;
        public frmLocalDrivingLicenseApplicationDetails(int LDID)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen; // Center the form on screen
            _LDID = LDID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmLocalDrivingLicenseApplicationDetails_Load(object sender, EventArgs e)
        {
            ctrlApplicationCard1.SetApplicatioInfo(_LDID);
        }
    }
}
