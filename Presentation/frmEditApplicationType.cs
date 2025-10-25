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
    public partial class frmEditApplicationType : Form
    {
        int _ApplicationTypeID;
        ClsApplicationType _ApplicationType;
        public frmEditApplicationType(int ApplicationTypeID)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen; // Center the form on screen
            _ApplicationTypeID = ApplicationTypeID;
        }
        private void LoadData()
        {
            _ApplicationType = ClsApplicationType.Find(_ApplicationTypeID);
            if (_ApplicationType == null)
            {
                MessageBox.Show("this form will be closed because there is no ApplicationType with this ID");
                this.Close();
                return;
            }
            lblApplicationTypeID.Text = _ApplicationTypeID.ToString();
            txtbApplicationTypeTitle.Text = _ApplicationType.ApplicationTypeTitle;
            txtbApplicationTypeFees.Text = _ApplicationType.ApplicationFees.ToString();

        }
        private void frmEditApplicationType_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private bool VerifAllInfo()
        {
            return !string.IsNullOrWhiteSpace(txtbApplicationTypeTitle.Text) && !string.IsNullOrWhiteSpace(txtbApplicationTypeFees.Text);
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (VerifAllInfo())
            {
                _ApplicationType.ApplicationTypeTitle = txtbApplicationTypeTitle.Text;
                _ApplicationType.ApplicationFees = decimal.Parse(txtbApplicationTypeFees.Text);
            }
            else
            {
                MessageBox.Show("ApplicationType not Updated Please enter all information correctly", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (_ApplicationType.Save())
            {
                MessageBox.Show("ApplicationType Updated successfully");
            }
            else
            {
                MessageBox.Show("Somthing wrong", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
