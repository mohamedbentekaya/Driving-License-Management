using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVDLDataAccessLayer;

namespace DVDLBusinessLayer
{
    public class ClsCountry
    {
        public enum enMode { AddNew = 0, Update = 1 };

        public int CountryID { get; set; }
        public string CountryName { get; set; }
        public enMode Mode { get; set; }

        public ClsCountry()
        {
            this.CountryID = -1;
            this.CountryName = string.Empty;
            Mode = enMode.AddNew;
        }

        private ClsCountry(int CountryID, string CountryName)
        {
            this.CountryID = CountryID;
            this.CountryName = CountryName;
            Mode = enMode.Update;
        }

        public static ClsCountry Find(int CountryID)
        {
            string CountryName = string.Empty;

            if (ClsCountryData.GetCountryInfoByID(CountryID, ref CountryName))
            {
                return new ClsCountry(CountryID, CountryName);
            }
            else
            {
                return null;
            }
        }
        public static ClsCountry FindByName(string CountryName)
        {
            int CountryID = -1;
            if (ClsCountryData.GetCountryInfoByName(CountryName, ref CountryID))
            {
                return new ClsCountry(CountryID, CountryName);
            }
            else
            {
                return null;
            }
        }
        private bool _AddNewCountry()
        {
            this.CountryID = ClsCountryData.AddNewCountry(this.CountryName);
            return this.CountryID != -1;
        }

        private bool _UpdateCountry()
        {
            return ClsCountryData.UpdateCountry(this.CountryID, this.CountryName);
        }

        public bool Save()
        {
            switch (this.Mode)
            {
                case enMode.AddNew:
                    if (_AddNewCountry())
                    {
                        this.Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdateCountry();
            }
            return false;
        }

        public static bool DeleteCountry(int CountryID)
        {
            return ClsCountryData.DeleteCountry(CountryID);
        }

        public static DataTable GetAllCountries()
        {
            return ClsCountryData.GetAllCountries();
        }

        public static bool ExistCountryByID(int CountryID)
        {
            return ClsCountryData.ExistCountryByID(CountryID);
        }
        public static bool ExistCountryByName(string CountryName)
        {
            return ClsCountryData.ExistCountryByName(CountryName);
        }
    }
}
