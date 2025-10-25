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
    public partial class frmEditTestType : Form
    {
        int _TestTypeID;
        ClsTestType _TestType;
        public frmEditTestType(int testTypeID)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen; // Center the form on screen
            _TestTypeID = testTypeID;
        }
        private void LoadData()
        {
            _TestType = ClsTestType.Find(_TestTypeID);
            if (_TestType == null)
            {
                MessageBox.Show("this form will be closed because there is no TestType with this ID");
                this.Close();
                return;
            }
            lblTestTypeID.Text = _TestTypeID.ToString();
            txtbTestTypeTitle.Text = _TestType.TestTypeTitle;
            txtbTestTypeDescription.Text = _TestType.TestTypeDescription;
            txtbTestTypeFees.Text = _TestType.TestTypeFees.ToString();
        }
        private void frmEditTestType_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private bool VerifAllInfo()
        {
            return !string.IsNullOrWhiteSpace(txtbTestTypeTitle.Text) && !string.IsNullOrWhiteSpace(txtbTestTypeFees.Text) && !string.IsNullOrWhiteSpace(txtbTestTypeDescription.Text);
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (VerifAllInfo())
            {
                _TestType.TestTypeTitle = txtbTestTypeTitle.Text;
                _TestType.TestTypeDescription = txtbTestTypeDescription.Text;
                _TestType.TestTypeFees = decimal.Parse(txtbTestTypeFees.Text);
            }
            else
            {
                MessageBox.Show("TestType not Updated Please enter all information correctly", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (_TestType.Save())
            {
                MessageBox.Show("TestType Updated successfully");
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
