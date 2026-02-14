using DVDLDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DVDLBusinessLayer
{
    public class ClsHashingBusiness
    {
        public static string ComputeHashing(string input)
        {
            return ClsHashing.ComputeHash(input);
        }
    }
}
