using DVDLBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentation
{
    public partial class frmLoginScreen : Form
    {
        
        ClsUser _User;
        public frmLoginScreen()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen; // Center the form on screen
           
        }
        private void btnLogin_MouseDown(object sender, MouseEventArgs e)
        {
            btnLogin.FlatAppearance.BorderSize = 1; // Show border when clicked
        }
        private void btnLogin_MouseUp(object sender, MouseEventArgs e)
        {
            btnLogin.FlatAppearance.BorderSize = 0; // Show border when clicked
        }
        public static (string UserName, string Password) GetUser()
        {
            string filePath = @"C:\Users\dell\Desktop\formation C++\level19\Files\users.txt";

            if (!File.Exists(filePath))
                throw new FileNotFoundException("The data file was not found.");

            string[] lines = File.ReadAllLines(filePath);

            if (lines.Length == 0 || string.IsNullOrWhiteSpace(lines[0]))
                return (null, null); // No user stored

            string[] parts = lines[0].Split(new string[] { "#//#" }, StringSplitOptions.None);

            if (parts.Length == 3)
            {
                string username = parts[1];
                string password = parts[2];
                return (username, password);
            }

            return (null, null); // Invalid file format
        }

        private bool UserRememberExists()
        {
            string filePath = @"C:\Users\dell\Desktop\formation C++\level19\Files\users.txt";

            if (!File.Exists(filePath))
                return false; // File doesn't exist

            // Check if there is at least one non-empty line
            return File.ReadLines(filePath).Any(line => !string.IsNullOrWhiteSpace(line));
        }

        private void LoadData()
        {
            txtUserName.Text = "User Name";

            txtPassword.Text = "Password";

            txtPassword.UseSystemPasswordChar = false; // Disable mask for placeholder

            // Example hex color
            string hexColor = "#14599f";

            // Convert hex to Color
            Color myColor = ColorTranslator.FromHtml(hexColor);

            // Apply to a Label or TextBox
            checkBoxRememberMe.ForeColor = myColor;
            if (UserRememberExists())
            {
                txtUserName.ForeColor = Color.Black;
                txtPassword.ForeColor = Color.Black;
                // Get user by ID
                var result = GetUser();

                if (result.UserName != null)
                {
                    txtUserName.Text = result.UserName;
                    txtPassword.Text = result.Password;
                    checkBoxRememberMe.Checked = true;
                }
            }
            else
            {
                txtUserName.ForeColor = Color.Gray;
                txtPassword.ForeColor = Color.Gray;
            }

        }
        private void frmLoginScreen_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void txtUserName_Enter(object sender, EventArgs e)
        {
            if (txtUserName.Text == "User Name")
            {
                txtUserName.Text = "";
                txtUserName.ForeColor = Color.Black;
            }
        }
        private void txtUserName_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUserName.Text))
            {
                txtUserName.Text = "User Name";
                txtUserName.ForeColor = Color.Gray;
            }
        }
        private void txtPassword_Enter(object sender, EventArgs e)
        {
            if (txtPassword.Text == "Password")
            {
                txtPassword.Text = "";
                txtPassword.ForeColor = Color.Black;
                txtPassword.UseSystemPasswordChar = true; // Enable mask
            }
        }
        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                txtPassword.Text = "Password";
                txtPassword.ForeColor = Color.Gray;
                txtPassword.UseSystemPasswordChar = false; // Disable mask for placeholder
            }
        }
        private void AddUserToFile()
        {
            string path = @"C:\Users\dell\Desktop\formation C++\level19\Files\users.txt";
            string separator = "#//#";

            // Ensure the folder exists
            Directory.CreateDirectory(Path.GetDirectoryName(path));

                string content = _User.UserID + separator + _User.UserName + separator + _User.GetPassword() + "\n";
                File.WriteAllText(path, content);
            
        }
        private static void DeleteUserFromFile()
        {
            string filePath = @"C:\Users\dell\Desktop\formation C++\level19\Files\users.txt";

            if (File.Exists(filePath))
            {
                File.WriteAllText(filePath, string.Empty); // clears all file content
            }
        }

        public void SetCurrentUserInfo(ClsUser User)
        {
            ClsCurrentUserInfo.UserID = User.UserID;
            ClsCurrentUserInfo.PersonID = User.PersonID;
            ClsCurrentUserInfo.UserName = User.UserName;
            ClsCurrentUserInfo.SetPassword(User.GetPassword());
            ClsCurrentUserInfo.IsActive = User.IsActive;
            ClsCurrentUserInfo.Mode = (ClsCurrentUserInfo.enMode)User.Mode;
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            _User = ClsUser.ExistUserByUserNamePassword(txtUserName.Text, txtPassword.Text);
            if (_User != null)
            {
                
                if (_User.IsActive)
                {
                    if (checkBoxRememberMe.Checked)
                    {
                        AddUserToFile();
                    }
                    else
                    {
                        DeleteUserFromFile();
                    }
                    SetCurrentUserInfo(_User);
                    // Open main form
                    this.Hide();
                    Form1 form1 = new Form1(this);
                    form1.ShowDialog();
                    
                }
                else
                {
                    MessageBox.Show("Your account is deactivated please contact your admin", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Invalid User Name/Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
