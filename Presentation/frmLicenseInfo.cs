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
    public partial class frmLicenseInfo : Form
    {
        int _LDID;
        public frmLicenseInfo(int LDID)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen; // Center the form on screen
            _LDID = LDID;
        }

        private void frmLicenseInfo_Load(object sender, EventArgs e)
        {
            ctrlLicenseCard1.SetLicenseInfo(_LDID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
