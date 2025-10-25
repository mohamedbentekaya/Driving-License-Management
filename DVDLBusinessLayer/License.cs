using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVDLDataAccessLayer;
namespace DVDLBusinessLayer
{
    public class ClsLicense
    {
        public enum enMode { AddNew = 0, Update = 1 };

        public int LicenseID { get; set; }
        public int ApplicationID { get; set; }
        public int DriverID { get; set; }
        public int LicenseClass { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Notes { get; set; }
        public decimal PaidFees { get; set; }
        public bool IsActive { get; set; }
        public byte IssueReason { get; set; }
        public int CreatedByUserID { get; set; }
        public enMode Mode { get; set; }

        public ClsLicense()
        {
            this.LicenseID = -1;
            this.ApplicationID = -1;
            this.DriverID = -1;
            this.LicenseClass = -1;
            this.IssueDate = DateTime.Now;
            this.ExpirationDate = DateTime.Now.AddYears(1);
            this.Notes = string.Empty;
            this.PaidFees = 0;
            this.IsActive = true;
            this.IssueReason = 0;
            this.CreatedByUserID = -1;

            Mode = enMode.AddNew;
        }

        private ClsLicense(int LicenseID, int ApplicationID, int DriverID, int LicenseClass, DateTime IssueDate, DateTime ExpirationDate,
            string Notes, decimal PaidFees, bool IsActive, byte IssueReason, int CreatedByUserID)
        {
            this.LicenseID = LicenseID;
            this.ApplicationID = ApplicationID;
            this.DriverID = DriverID;
            this.LicenseClass = LicenseClass;
            this.IssueDate = IssueDate;
            this.ExpirationDate = ExpirationDate;
            this.Notes = Notes;
            this.PaidFees = PaidFees;
            this.IsActive = IsActive;
            this.IssueReason = IssueReason;
            this.CreatedByUserID = CreatedByUserID;

            Mode = enMode.Update;
        }

        public static ClsLicense Find(int LicenseID)
        {
            int ApplicationID = -1;
            int DriverID = -1;
            int LicenseClass = -1;
            DateTime IssueDate = DateTime.Now;
            DateTime ExpirationDate = DateTime.Now.AddYears(1);
            string Notes = string.Empty;
            decimal PaidFees = 0;
            bool IsActive = true;
            byte IssueReason = 0;
            int CreatedByUserID = -1;

            if (ClsLicenseData.GetLicenseInfoByID(LicenseID, ref ApplicationID, ref DriverID, ref LicenseClass, ref IssueDate, ref ExpirationDate,
                ref Notes, ref PaidFees, ref IsActive, ref IssueReason, ref CreatedByUserID))
            {
                return new ClsLicense(LicenseID, ApplicationID, DriverID, LicenseClass, IssueDate, ExpirationDate,
                    Notes, PaidFees, IsActive, IssueReason, CreatedByUserID);
            }
            else
            {
                return null;
            }
        }
        public static ClsLicense FindRnewLicenseByDriverID(int DriverID)
        {
            int LicenseID = -1;
            int ApplicationID = -1;
            int LicenseClass = -1;
            DateTime IssueDate = DateTime.Now;
            DateTime ExpirationDate = DateTime.Now.AddYears(1);
            string Notes = string.Empty;
            decimal PaidFees = 0;
            bool IsActive = true;
            byte IssueReason = 0;
            int CreatedByUserID = -1;

            if (ClsLicenseData.GetRnewLicenseByDriverID(DriverID, ref ApplicationID, ref LicenseID, ref LicenseClass, ref IssueDate, ref ExpirationDate,
                ref Notes, ref PaidFees, ref IsActive, ref IssueReason, ref CreatedByUserID))
            {
                return new ClsLicense(LicenseID, ApplicationID, DriverID, LicenseClass, IssueDate, ExpirationDate,
                    Notes, PaidFees, IsActive, IssueReason, CreatedByUserID);
            }
            else
            {
                return null;
            }
        }

        private bool _AddNewLicense()
        {
            this.LicenseID = ClsLicenseData.AddNewLicense(this.ApplicationID, this.LicenseClass, this.IssueDate,
                this.ExpirationDate, this.Notes, this.PaidFees, this.IsActive, this.IssueReason, this.CreatedByUserID);
            return this.LicenseID != -1;
        }
        private bool AddReNewLicense(ClsApplication App, int OldLicense)
        {
            this.LicenseID = ClsLicenseData.AddReNewLicense(App.ApplicationPersonID,
            App.ApplicationDate, App.ApplicationTypeID, App.ApplicationStatus,
            App.LastStatusDate, App.PaidFees, App.CreatedByUserID,this.DriverID, this.LicenseClass, this.IssueDate,
                this.ExpirationDate, this.Notes, this.PaidFees, this.IsActive, this.IssueReason, OldLicense);
            return this.LicenseID != -1;
        }

        private bool _UpdateLicense()
        {
            return ClsLicenseData.UpdateLicense(this.LicenseID, this.ApplicationID, this.DriverID, this.LicenseClass, this.IssueDate,
                this.ExpirationDate, this.Notes, this.PaidFees, this.IsActive, this.IssueReason, this.CreatedByUserID);
        }

        public bool Save()
        {
            switch (this.Mode)
            {
                case enMode.AddNew:
                    if (_AddNewLicense())
                    {
                        this.Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdateLicense();
            }
            return false;
        }
        public bool SaveReNewLicense(ClsApplication App, int OldLicense)
        {
            if (AddReNewLicense(App, OldLicense))
            {
                this.Mode = enMode.Update;
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool DeleteLicense(int LicenseID)
        {
            return ClsLicenseData.DeleteLicense(LicenseID);
        }

        public static DataTable GetAllLicensesByPersonID(int PersonID)
        {
            return ClsLicenseData.GetAllLicensesByPersonID(PersonID);
        }

        public static bool ExistLicense(int LicenseID)
        {
            return ClsLicenseData.ExistLicense(LicenseID);
        }
        public static bool ExistLicenseByAppID(int LicenseID)
        {
            return ClsLicenseData.ExistLicenseByAppID(LicenseID);
        }
        public static bool ExistLicenseByPersonIDAndLicenseClass(int PersonID, int LicenseClassID)
        {
            return ClsLicenseData.ExistLicenseByPersonIDAndLicenseClass(PersonID, LicenseClassID);
        }
        public static bool ExistRnewLicenseByDriverID(int DriverID)
        {
            return ClsLicenseData.ExistRnewLicenseByDriverID(DriverID);
        }
        public static int GetLicenseIDByAppID(int ApplicationID)
        {
            return ClsLicenseData.GetLicenseIDByAppID(ApplicationID);
        }
    }
}