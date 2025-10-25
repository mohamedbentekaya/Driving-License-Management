using DVDLDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DVDLBusinessLayer
{
    public class ClsLocalDrivingLicenseApplication
    {
        public enum enMode { AddNew = 0, Update = 1 };

        public int LocalDrivingLicenseApplicationID { get; set; }
        public int ApplicationID { get; set; }
        public int LicenseClassID { get; set; }
        public enMode Mode { get; set; }

        public ClsLocalDrivingLicenseApplication()
        {
            this.LocalDrivingLicenseApplicationID = -1;
            this.ApplicationID = -1;
            this.LicenseClassID = -1;
            Mode = enMode.AddNew;
        }

        private ClsLocalDrivingLicenseApplication(int LocalDrivingLicenseApplicationID, int ApplicationID, int LicenseClassID)
        {
            this.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            this.ApplicationID = ApplicationID;
            this.LicenseClassID = LicenseClassID;
            Mode = enMode.Update;
        }

        public static ClsLocalDrivingLicenseApplication Find(int LocalDrivingLicenseApplicationID)
        {
            int ApplicationID = -1;
            int LicenseClassID = -1;

            if (ClsLocalDrivingLicenseApplicationData.GetLocalDrivingLicenseApplicationInfoByID(LocalDrivingLicenseApplicationID,
                ref ApplicationID, ref LicenseClassID))
            {
                return new ClsLocalDrivingLicenseApplication(LocalDrivingLicenseApplicationID, ApplicationID, LicenseClassID);
            }
            else
            {
                return null;
            }
        }

        private bool _AddNewApplicationAndLocalDrivingLicense(ClsApplication App)
        {
            App.ApplicationID = ClsLocalDrivingLicenseApplicationData.AddNewApplicationAndLocalDrivingLicense(App.ApplicationPersonID, App.ApplicationDate, App.ApplicationTypeID,
                App.ApplicationStatus, App.LastStatusDate, App.PaidFees, App.CreatedByUserID, this.LicenseClassID);
            this.ApplicationID = App.ApplicationID;
            return App.ApplicationID != -1;

        }

        private bool _UpdateApplicationAndLocalDrivingLicense(ClsApplication App)
        {
            return ClsLocalDrivingLicenseApplicationData.UpdateApplicationAndLocalDrivingLicense(App.ApplicationID, App.ApplicationPersonID, App.ApplicationDate, App.ApplicationTypeID,
                App.ApplicationStatus, App.LastStatusDate, App.PaidFees, App.CreatedByUserID, this.LicenseClassID);
        }
        public bool Save(ClsApplication App)
        {
            switch (this.Mode)
            {
                case enMode.AddNew:
                    if (_AddNewApplicationAndLocalDrivingLicense(App))
                    {
                        this.Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case enMode.Update:
                    if (_UpdateApplicationAndLocalDrivingLicense(App))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
            }
            return false;
        }

        public static bool DeleteLocalDrivingLicenseApplication(int LocalDrivingLicenseApplicationID)
        {
            return ClsLocalDrivingLicenseApplicationData.DeleteLocalDrivingLicenseApplication(LocalDrivingLicenseApplicationID);
        }

        public static DataTable GetAllLocalDrivingLicenseApplications()
        {
            return ClsLocalDrivingLicenseApplicationData.GetAllLocalDrivingLicenseApplications();
        }
        public static int GetPassedTests(int ID)
        {
            return ClsLocalDrivingLicenseApplicationData.GetPassedTests(ID);
        }

        public static bool ExistLocalDrivingLicenseApplication(int LocalDrivingLicenseApplicationID)
        {
            return ClsLocalDrivingLicenseApplicationData.ExistLocalDrivingLicenseApplication(LocalDrivingLicenseApplicationID);
        }
    }
}