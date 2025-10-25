using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVDLDataAccessLayer;
namespace DVDLBusinessLayer
{
    public class ClsTestType
    {
        public enum enMode { AddNew = 0, Update = 1 };

        public int TestTypeID { get; set; }
        public string TestTypeTitle { get; set; }
        public string TestTypeDescription { get; set; }
        public decimal TestTypeFees { get; set; }
        public enMode Mode { get; set; }

        // Default Constructor
        public ClsTestType()
        {
            this.TestTypeID = -1;
            this.TestTypeTitle = string.Empty;
            this.TestTypeDescription = string.Empty;
            this.TestTypeFees = 0;
            Mode = enMode.AddNew;
        }

        // Private Constructor for Find
        private ClsTestType(int TestTypeID, string TestTypeTitle, string TestTypeDescription, decimal TestTypeFees)
        {
            this.TestTypeID = TestTypeID;
            this.TestTypeTitle = TestTypeTitle;
            this.TestTypeDescription = TestTypeDescription;
            this.TestTypeFees = TestTypeFees;
            Mode = enMode.Update;
        }

        // Find Method
        public static ClsTestType Find(int TestTypeID)
        {
            string TestTypeTitle = string.Empty;
            string TestTypeDescription = string.Empty;
            decimal TestTypeFees = 0;

            if (ClsTestTypeData.GetTestTypeInfoByID(TestTypeID, ref TestTypeTitle, ref TestTypeDescription, ref TestTypeFees))
            {
                return new ClsTestType(TestTypeID, TestTypeTitle, TestTypeDescription, TestTypeFees);
            }
            else
            {
                return null;
            }
        }

        // Private Add Method
        private bool _AddNewTestType()
        {
            this.TestTypeID = ClsTestTypeData.AddNewTestType(this.TestTypeTitle, this.TestTypeDescription, this.TestTypeFees);
            return this.TestTypeID != -1;
        }

        // Private Update Method
        private bool _UpdateTestType()
        {
            return ClsTestTypeData.UpdateTestType(this.TestTypeID, this.TestTypeTitle, this.TestTypeDescription, this.TestTypeFees);
        }

        // Save Method
        public bool Save()
        {
            switch (this.Mode)
            {
                case enMode.AddNew:
                    if (_AddNewTestType())
                    {
                        this.Mode = enMode.Update;
                        return true;
                    }
                    else
                        return false;

                case enMode.Update:
                    return _UpdateTestType();
            }
            return false;
        }

        // Delete
        public static bool DeleteTestType(int TestTypeID)
        {
            return ClsTestTypeData.DeleteTestType(TestTypeID);
        }

        // Get All
        public static DataTable GetAllTestTypes()
        {
            return ClsTestTypeData.GetAllTestTypes();
        }

        // Check Existence
        public static bool ExistTestType(int TestTypeID)
        {
            return ClsTestTypeData.ExistTestType(TestTypeID);
        }
    }
}