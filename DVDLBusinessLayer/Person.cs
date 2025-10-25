using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using DVDLDataAccessLayer;
namespace DVDLBusinessLayer
{
    public class ClsPerson
    {
        public enum enMode { AddNew = 0,   Update = 1 }
        public enMode Mode { get; set; } = enMode.AddNew;

        public int PersonID { get; set; }
        public string FirstName { get; set; } 
        public string LastName { get; set; } 

        public string FullName()
        {
            return FirstName+" "+LastName;
        }

        public string NationalNo { get; set; }
        public DateTime DateOfBirth { get; set; }
        public byte Gendor { get; set; }
        public string Address { get; set; } 
        public string Phone { get; set; } 
        public string Email { get; set; } 
        public int NationalityCountryID { get; set; }
        public string ImagePath { get; set; }

        public ClsPerson()
        {
            this.PersonID = -1;
            this.FirstName = "";
            this.LastName = "";
            this.DateOfBirth = DateTime.Now;
            this.Address = "";
            this.Phone = "";
            this.Email = "";
            this.NationalityCountryID = -1;
            this.ImagePath = "";

            Mode = enMode.AddNew;
        }
        private ClsPerson(int personID, string nationalNo, string firstName, string lastName, 
            DateTime dateOfBirth, byte Gendor, string address, string phone, string email,
            int nationalityCountryID, string imagePath)
        {
            this.PersonID = personID;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.NationalNo = nationalNo;
            this.DateOfBirth = dateOfBirth;
            this.Gendor = Gendor;
            this.Address = address;
            this.Phone = phone;
            this.Email = email;
            this.NationalityCountryID = nationalityCountryID;
            this.ImagePath = imagePath;
            Mode = enMode.Update;
        }

        public static ClsPerson FindByID(int PersonID)
        {
            string NationalNo="";
            string FirstName = "";
            string LastName = "";
            DateTime DateOfBirth = DateTime.Now;
            byte Gendor = 0;
            string Address = "";
            string Phone = "";
            string Email = "";
            int NationalityCountryID = -1;
            string ImagePath = "";
            if (ClsPersonData.GetPersonInfoByID(PersonID, ref NationalNo, ref FirstName, ref LastName,
            ref DateOfBirth, ref Gendor, ref Address, ref Phone, ref Email,
             ref NationalityCountryID, ref ImagePath))
            {
                return new ClsPerson(PersonID, NationalNo, FirstName, LastName,
                DateOfBirth, Gendor, Address, Phone, Email,
                NationalityCountryID, ImagePath);
            }
            else
            {
                return null;
            }
        }
        public static ClsPerson FindByNationalNo(string NationalNo)
        {
            int PersonID = -1;
            string FirstName = "";
            string LastName = "";
            DateTime DateOfBirth = DateTime.Now;
            byte Gendor = 0;
            string Address = "";
            string Phone = "";
            string Email = "";
            int NationalityCountryID = -1;
            string ImagePath = "";
            if (ClsPersonData.GetPersonInfoByNationalNo(NationalNo, ref PersonID, ref FirstName, ref LastName,
            ref DateOfBirth, ref Gendor, ref Address, ref Phone, ref Email,
             ref NationalityCountryID, ref ImagePath))
            {
                return new ClsPerson(PersonID, NationalNo, FirstName, LastName,
                DateOfBirth, Gendor, Address, Phone, Email,
                NationalityCountryID, ImagePath);
            }
            else
            {
                return null;
            }
        }

        private bool _AddNewPerson()
        {
            this.PersonID = ClsPersonData.AddNewPerson(this.NationalNo, this.FirstName, this.LastName,
            this.DateOfBirth, this.Gendor, this.Address, this.Phone, this.Email,
             this.NationalityCountryID, this.ImagePath);
            return PersonID != -1;
        }
        private bool _UpdatePerson()
        {
            return ClsPersonData.UpdatePerson(this.PersonID, this.NationalNo, this.FirstName, this.LastName,
            this.DateOfBirth, this.Gendor, this.Address, this.Phone, this.Email,
             this.NationalityCountryID, this.ImagePath);
        }

        public bool Save()
        {
            switch (this.Mode)
            {
                case enMode.AddNew:
                    if (this._AddNewPerson())
                    {
                        this.Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case enMode.Update:
                    if (this._UpdatePerson())
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

        public static bool DeletePerson(int PersonID)
        {
            return ClsPersonData.DeletePerson(PersonID);
        }

        public static DataTable GetAllPeople()
        {
            return ClsPersonData.GetAllPeople();
        }

        public static bool ExistPersonByID(int PersonID)
        {
            return ClsPersonData.IsPersonExistID(PersonID);
        }
        public static bool ExistPersonByNationalNo(string NationalNo)
        {
            return ClsPersonData.IsPersonExistNationalNo(NationalNo);
        }
    }
}
