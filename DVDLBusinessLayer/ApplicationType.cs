using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVDLDataAccessLayer;

namespace DVDLBusinessLayer
{
    public class ClsApplicationType
    {
        public enum enMode { AddNew = 0, Update = 1 };

        public int ApplicationTypeID { get; set; }
        public string ApplicationTypeTitle { get; set; }
        public decimal ApplicationFees { get; set; }
        public enMode Mode { get; set; }

        public ClsApplicationType()
        {
            this.ApplicationTypeID = -1;
            this.ApplicationTypeTitle = string.Empty;
            this.ApplicationFees = 0;
            Mode = enMode.AddNew;
        }

        private ClsApplicationType(int ApplicationTypeID, string ApplicationTypeTitle, decimal ApplicationFees)
        {
            this.ApplicationTypeID = ApplicationTypeID;
            this.ApplicationTypeTitle = ApplicationTypeTitle;
            this.ApplicationFees = ApplicationFees;
            Mode = enMode.Update;
        }

        public static ClsApplicationType Find(int ApplicationTypeID)
        {
            string ApplicationTypeTitle = string.Empty;
            decimal ApplicationFees = 0;

            if (ClsApplicationTypeData.GetApplicationTypeInfoByID(ApplicationTypeID, ref ApplicationTypeTitle, ref ApplicationFees))
            {
                return new ClsApplicationType(ApplicationTypeID, ApplicationTypeTitle, ApplicationFees);
            }
            else
            {
                return null;
            }
        }

        private bool _AddNewApplicationType()
        {
            this.ApplicationTypeID = ClsApplicationTypeData.AddNewApplicationType(this.ApplicationTypeTitle, this.ApplicationFees);
            return this.ApplicationTypeID != -1;
        }

        private bool _UpdateApplicationType()
        {
            return ClsApplicationTypeData.UpdateApplicationType(this.ApplicationTypeID, this.ApplicationTypeTitle, this.ApplicationFees);
        }

        public bool Save()
        {
            switch (this.Mode)
            {
                case enMode.AddNew:
                    if (_AddNewApplicationType())
                    {
                        this.Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdateApplicationType();
            }
            return false;
        }

        public static bool DeleteApplicationType(int ApplicationTypeID)
        {
            return ClsApplicationTypeData.DeleteApplicationType(ApplicationTypeID);
        }

        public static DataTable GetAllApplicationTypes()
        {
            return ClsApplicationTypeData.GetAllApplicationTypes();
        }

        public static bool ExistApplicationType(int ApplicationTypeID)
        {
            return ClsApplicationTypeData.ExistApplicationType(ApplicationTypeID);
        }
    }
}
