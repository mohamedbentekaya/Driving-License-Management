using DVDLDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDLBusinessLayer
{
    public class ClsUser
    {
        public enum enMode { AddNew = 0, Update = 1 };

        // Properties
        public int UserID { get; set; }
        public int PersonID { get; set; }
        public string UserName { get; set; }
        private string Password { get; set; }
        public bool IsActive { get; set; }
        public enMode Mode { get; set; }

        // Default Constructor
        public ClsUser()
        {
            this.UserID = -1;
            this.PersonID = -1;
            this.UserName = string.Empty;
            this.Password = string.Empty;
            this.IsActive = true;
            this.Mode = enMode.AddNew;
        }

        // Private Constructor for loading existing user
        private ClsUser(int userID, int personID, string userName, string password, bool isActive)
        {
            this.UserID = userID;
            this.PersonID = personID;
            this.UserName = userName;
            this.Password = password;
            this.IsActive = isActive;
            this.Mode = enMode.Update;
        }

        // Find User by ID
        public static ClsUser Find(int userID)
        {
            int personID = -1;
            string userName = string.Empty;
            string password = string.Empty;
            bool isActive = true;

            if (ClsUserData.GetUserInfoByID(userID, ref personID, ref userName, ref password, ref isActive))
            {
                return new ClsUser(userID, personID, userName, password, isActive);
            }
            else
            {
                return null;
            }
        }

        // Add New User
        private bool _AddNewUser()
        {
            this.UserID = ClsUserData.AddNewUser(this.PersonID, this.UserName, this.Password, this.IsActive);
            return this.UserID != -1;
        }

        // Update Existing User
        private bool _UpdateUser()
        {
            return ClsUserData.UpdateUser(this.UserID, this.PersonID, this.UserName, this.Password, this.IsActive);
        }

        // Save Method
        public bool Save()
        {
            switch (this.Mode)
            {
                case enMode.AddNew:
                    if (_AddNewUser())
                    {
                        this.Mode = enMode.Update;
                        return true;
                    }
                    else
                        return false;

                case enMode.Update:
                    return _UpdateUser();
            }
            return false;
        }

        // Delete User
        public static bool DeleteUser(int userID)
        {
            return ClsUserData.DeleteUser(userID);
        }

        // Get All Users
        public static DataTable GetAllUsers()
        {
            return ClsUserData.GetAllUsers();
        }

        // Check if User Exists
        public static bool ExistUser(int userID)
        {
            return ClsUserData.ExistUser(userID);
        }

        public static bool ExistUserByPersonID(int PersonID)
        {
            return ClsUserData.ExistUserByPersonID(PersonID);
        }
        // Set Password
        public void SetPassword(string newPassword)
        {
            this.Password = newPassword;
        }

        public string GetPassword()
        {
            return this.Password;
        }

        // Check Password
        public bool CheckPassword(string inputPassword)
        {
            return this.Password == inputPassword;
        }

        public static ClsUser ExistUserByUserNamePassword(string UserName, string Password)
        {
            int userID = -1;
            int personID = -1;
            bool isActive = false;

            if (ClsUserData.ExistUserByUserNamePassword(UserName, Password, ref userID, ref personID, ref isActive))
            {
                return new ClsUser(userID, personID, UserName, Password, isActive);
            }
            else
            {
                return null;
            }
        }
    }
}