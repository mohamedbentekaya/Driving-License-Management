using DVDLDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDLBusinessLayer
{
    public class ClsInternationalLicense
    {
        public enum enMode { AddNew = 0, Update = 1 };

        public int InternationalLicenseID { get; set; }
        public int ApplicationID { get; set; }
        public int DriverID { get; set; }
        public int IssuedUsingLocalLicenseID { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public bool IsActive { get; set; }
        public int CreatedByUserID { get; set; }
        public enMode Mode { get; set; }

        public ClsInternationalLicense()
        {
            this.InternationalLicenseID = -1;
            this.ApplicationID = -1;
            this.DriverID = -1;
            this.IssuedUsingLocalLicenseID = -1;
            this.IssueDate = DateTime.Now;
            this.ExpirationDate = DateTime.Now.AddYears(1);
            this.IsActive = true;
            this.CreatedByUserID = -1;

            Mode = enMode.AddNew;
        }

        private ClsInternationalLicense(int InternationalLicenseID, int ApplicationID, int DriverID, int IssuedUsingLocalLicenseID,
            DateTime IssueDate, DateTime ExpirationDate, bool IsActive, int CreatedByUserID)
        {
            this.InternationalLicenseID = InternationalLicenseID;
            this.ApplicationID = ApplicationID;
            this.DriverID = DriverID;
            this.IssuedUsingLocalLicenseID = IssuedUsingLocalLicenseID;
            this.IssueDate = IssueDate;
            this.ExpirationDate = ExpirationDate;
            this.IsActive = IsActive;
            this.CreatedByUserID = CreatedByUserID;

            Mode = enMode.Update;
        }

        public static ClsInternationalLicense Find(int InternationalLicenseID)
        {
            int ApplicationID = -1;
            int DriverID = -1;
            int IssuedUsingLocalLicenseID = -1;
            DateTime IssueDate = DateTime.Now;
            DateTime ExpirationDate = DateTime.Now.AddYears(1);
            bool IsActive = true;
            int CreatedByUserID = -1;

            if (ClsInternationalLicenseData.GetInternationalLicenseInfoByID(InternationalLicenseID, ref ApplicationID, ref DriverID,
                ref IssuedUsingLocalLicenseID, ref IssueDate, ref ExpirationDate, ref IsActive, ref CreatedByUserID))
            {
                return new ClsInternationalLicense(InternationalLicenseID, ApplicationID, DriverID, IssuedUsingLocalLicenseID,
                    IssueDate, ExpirationDate, IsActive, CreatedByUserID);
            }
            else
            {
                return null;
            }
        }

        public static ClsInternationalLicense FindByAppID(int ApplicationID)
        {
            int InternationalLicenseID = -1;
            int DriverID = -1;
            int IssuedUsingLocalLicenseID = -1;
            DateTime IssueDate = DateTime.Now;
            DateTime ExpirationDate = DateTime.Now.AddYears(1);
            bool IsActive = true;
            int CreatedByUserID = -1;

            if (ClsInternationalLicenseData.GetInternationalLicenseInfoByAppID(ApplicationID, ref InternationalLicenseID, ref DriverID,
                ref IssuedUsingLocalLicenseID, ref IssueDate, ref ExpirationDate, ref IsActive, ref CreatedByUserID))
            {
                return new ClsInternationalLicense(InternationalLicenseID, ApplicationID, DriverID, IssuedUsingLocalLicenseID,
                    IssueDate, ExpirationDate, IsActive, CreatedByUserID);
            }
            else
            {
                return null;
            }
        }
        public static ClsInternationalLicense FindByDriverID(int DriverID)
        {
            int InternationalLicenseID = -1;
            int ApplicationID = -1;
            int IssuedUsingLocalLicenseID = -1;
            DateTime IssueDate = DateTime.Now;
            DateTime ExpirationDate = DateTime.Now.AddYears(1);
            bool IsActive = true;
            int CreatedByUserID = -1;

            if (ClsInternationalLicenseData.GetInternationalLicenseInfoByDriverID(DriverID, ref InternationalLicenseID, ref ApplicationID,
                ref IssuedUsingLocalLicenseID, ref IssueDate, ref ExpirationDate, ref IsActive, ref CreatedByUserID))
            {
                return new ClsInternationalLicense(InternationalLicenseID, ApplicationID, DriverID, IssuedUsingLocalLicenseID,
                    IssueDate, ExpirationDate, IsActive, CreatedByUserID);
            }
            else
            {
                return null;
            }
        }

        private bool _AddNewApplicationAndInternationalLicense(ClsApplication App)
        {
            App.ApplicationID = ClsInternationalLicenseData._AddNewApplicationAndInternationalLicense(App.ApplicationPersonID, 
                App.ApplicationDate, App.ApplicationTypeID, App.ApplicationStatus, App.LastStatusDate,
                App.PaidFees, App.CreatedByUserID, this.DriverID, this.IssuedUsingLocalLicenseID,
                this.IssueDate, this.ExpirationDate, this.IsActive);
            this.ApplicationID = App.ApplicationID;
            return this.ApplicationID != -1;
        }

        private bool _UpdateApplicationAndInternationalLicense(ClsApplication App)
        {
            return ClsInternationalLicenseData._UpdateApplicationAndInternationalLicense(App.ApplicationID, 
                App.ApplicationPersonID, App.ApplicationDate, App.ApplicationTypeID,
                App.ApplicationStatus, App.LastStatusDate, App.PaidFees, App.CreatedByUserID,
                 this.DriverID, this.IssuedUsingLocalLicenseID, this.IssueDate, this.ExpirationDate, this.IsActive);
        }

        public bool Save(ClsApplication App)
        {
            switch (this.Mode)
            {
                case enMode.AddNew:
                    if (_AddNewApplicationAndInternationalLicense(App))
                    {
                        this.Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdateApplicationAndInternationalLicense(App);
            }
            return false;
        }

        public static bool DeleteInternationalLicense(int InternationalLicenseID)
        {
            return ClsInternationalLicenseData.DeleteInternationalLicense(InternationalLicenseID);
        }

        public static DataTable GetAllInternationalLicenses()
        {
            return ClsInternationalLicenseData.GetAllInternationalLicenses();
        }
        public static DataTable GetAllIntLicensesByPersonID(int PersonID)
        {
            return ClsInternationalLicenseData.GetAllIntLicensesByPersonID(PersonID);
        }

        public static bool ExistInternationalLicense(int InternationalLicenseID)
        {
            return ClsInternationalLicenseData.ExistInternationalLicense(InternationalLicenseID);
        }
        public static bool ExistInternationalLicenseByDriverID(int DriverID)
        {
            return ClsInternationalLicenseData.ExistInternationalLicenseByDriverID(DriverID);
        }
    }
}