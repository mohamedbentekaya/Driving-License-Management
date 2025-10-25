using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDLBusinessLayer
{
    public static class ClsCurrentUserInfo
    {
        public enum enMode { AddNew = 0, Update = 1 };

        // Properties
        public static int UserID { get; set; }
        public static int PersonID { get; set; }
        public static string UserName { get; set; }
        private static string Password { get; set; }
        public static bool IsActive { get; set; }
        public static enMode Mode { get; set; }
        public static string GetPassword()
        {
             return Password; 
        }
        public static void SetPassword(string value)
        {
            Password = value;
        }
        public static void Clear()
        {
            UserID = 0;
            PersonID = 0;
            UserName = "";
            Password = "";
        }


    }
}
