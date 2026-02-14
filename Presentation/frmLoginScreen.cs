using DVDLBusinessLayer;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

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
        /*public static (string UserName, string Password) GetUser()
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
        }*/
        public static (string UserName, string Password) GetUser()
        {
            string keyPath = @"SOFTWARE\DVLD";

            try
            {
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(keyPath))
                {
                    if (key == null)
                        return (null, null);

                    string username = key.GetValue("Username") as string;
                    string password = key.GetValue("Password") as string;

                    return (username, password);
                }
            }
            catch
            {
                return (null, null);
            }
        }
        /*private bool UserRememberExists()//to be change
    {
        string filePath = @"C:\Users\dell\Desktop\formation C++\level19\Files\users.txt";

        if (!File.Exists(filePath))
            return false; // File doesn't exist

        // Check if there is at least one non-empty line
        return File.ReadLines(filePath).Any(line => !string.IsNullOrWhiteSpace(line));
    }*/
        private bool UserRememberExists()
        {
            string keyPath = @"SOFTWARE\DVLD";

            try
            {
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(keyPath))
                {
                    if (key == null) return false;

                    object userIdObj = key.GetValue("UserID");
                    object usernameObj = key.GetValue("Username");
                    object passwordObj = key.GetValue("Password");

                    if (userIdObj == null || usernameObj == null || passwordObj == null)
                        return false;

                    int userId = (int)userIdObj;
                    string username = usernameObj.ToString();
                    string password = passwordObj.ToString();

                    return userId > 0 &&
                           !string.IsNullOrWhiteSpace(username) &&
                           !string.IsNullOrWhiteSpace(password);
                }
            }
            catch
            {
                return false;
            }
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
        /*private void AddUserToFile()//to be change
        {
            string path = @"C:\Users\dell\Desktop\formation C++\level19\Files\users.txt";
            string separator = "#//#";

            // Ensure the folder exists
            Directory.CreateDirectory(Path.GetDirectoryName(path));

                string content = _User.UserID + separator + _User.UserName + separator + _User.GetPassword() + "\n";
                File.WriteAllText(path, content);
            
        }*/
        private void AddUserToRegistry()
        {
            // Specify the Registry key and path


            // string keyPath = @"HKEY_LOCAL_MACHINE\SOFTWARE\YourSoftware";
            string keyPath = @"HKEY_CURRENT_USER\SOFTWARE\DVLD";

            int UserID = _User.UserID;
            string UserName = _User.UserName;
            string UserPassword = _User.GetPassword();
            


            try
            {
                // Write values to Registry
                Registry.SetValue(keyPath, "UserID", UserID, RegistryValueKind.DWord);
                Registry.SetValue(keyPath, "Username", UserName, RegistryValueKind.String);
                Registry.SetValue(keyPath, "Password", UserPassword, RegistryValueKind.String);
            }
            catch (Exception ex)
            {
                ClsEventLogBusiness.ErrorEventLog(ex.Message);
                MessageBox.Show("An error occurred:\n" + ex.Message);
            }
        }
        /*private static void DeleteUserFromFile()//to be change
        {
            string filePath = @"C:\Users\dell\Desktop\formation C++\level19\Files\users.txt";

            if (File.Exists(filePath))
            {
                File.WriteAllText(filePath, string.Empty); // clears all file content
            }
        }*/
        private static void DeleteUserFromRegistry()
        {
            string subKeyPath = @"SOFTWARE\DVLD";

            try
            {
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(subKeyPath, true))
                {
                    if (key != null)
                    {
                        key.DeleteValue("UserID", false);
                        key.DeleteValue("Username", false);
                        key.DeleteValue("Password", false);
                    }
                }
            }
            catch (Exception ex)
            {
                ClsEventLogBusiness.ErrorEventLog(ex.Message);
                MessageBox.Show("Error deleting saved login:\n" + ex.Message);
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
            _User = ClsUser.ExistUserByUserNamePassword(txtUserName.Text, ClsHashingBusiness.ComputeHashing(txtPassword.Text));
            if (_User != null)
            {
                
                if (_User.IsActive)
                {
                    _User.SetPassword(txtPassword.Text);
                    SetCurrentUserInfo(_User);
                    if (checkBoxRememberMe.Checked)
                    {
                        AddUserToRegistry();
                    }
                    else
                    {
                        DeleteUserFromRegistry();
                    }
                    // Open main form
                    //this.Hide();
                    //Form1 form1 = new Form1(this);
                    Form1 form1 = new Form1();
                    form1.DataBack += frmLoginScreen_Load;
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
