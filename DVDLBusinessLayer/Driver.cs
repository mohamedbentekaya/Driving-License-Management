using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVDLDataAccessLayer;
namespace DVDLBusinessLayer
{
    public class ClsDriver
    {
        public enum enMode { AddNew = 0, Update = 1 };

        public int DriverID { get; set; }
        public int PersonID { get; set; }
        public int CreatedByUserID { get; set; }
        public DateTime CreatedDate { get; set; }
        public enMode Mode { get; set; }

        public ClsDriver()
        {
            this.DriverID = -1;
            this.PersonID = -1;
            this.CreatedByUserID = -1;
            this.CreatedDate = DateTime.Now;

            Mode = enMode.AddNew;
        }

        private ClsDriver(int DriverID, int PersonID, int CreatedByUserID, DateTime CreatedDate)
        {
            this.DriverID = DriverID;
            this.PersonID = PersonID;
            this.CreatedByUserID = CreatedByUserID;
            this.CreatedDate = CreatedDate;

            Mode = enMode.Update;
        }

        public static ClsDriver Find(int DriverID)
        {
            int PersonID = -1;
            int CreatedByUserID = -1;
            DateTime CreatedDate = DateTime.Now;

            if (ClsDriverData.GetDriverInfoByID(DriverID, ref PersonID, ref CreatedByUserID, ref CreatedDate))
            {
                return new ClsDriver(DriverID, PersonID, CreatedByUserID, CreatedDate);
            }
            else
            {
                return null;
            }
        }

        private bool _AddNewDriver()
        {
            this.DriverID = ClsDriverData.AddNewDriver(this.PersonID, this.CreatedByUserID, this.CreatedDate);
            return this.DriverID != -1;
        }

        private bool _UpdateDriver()
        {
            return ClsDriverData.UpdateDriver(this.DriverID, this.PersonID, this.CreatedByUserID, this.CreatedDate);
        }

        public bool Save()
        {
            switch (this.Mode)
            {
                case enMode.AddNew:
                    if (_AddNewDriver())
                    {
                        this.Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdateDriver();
            }
            return false;
        }

        public static bool DeleteDriver(int DriverID)
        {
            return ClsDriverData.DeleteDriver(DriverID);
        }

        public static DataTable GetAllDrivers()
        {
            return ClsDriverData.GetAllDrivers();
        }

        public static bool ExistDriver(int DriverID)
        {
            return ClsDriverData.ExistDriver(DriverID);
        }
        public static bool ExistDriverByPersonID(int PersonID)
        {
            return ClsDriverData.ExistDriverByPersonID(PersonID);
        }
    }
}
