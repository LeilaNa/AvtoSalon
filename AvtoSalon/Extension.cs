using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace AvtoSalon
{
   public static class Extension
    {
        public static string hashpassword(string Password)
        {
            byte[] byteArray = ASCIIEncoding.ASCII.GetBytes(Password);
            byte[] hashedArray = new SHA256Managed().ComputeHash(byteArray);
            string HashedPassword = ASCIIEncoding.ASCII.GetString(hashedArray);
            return HashedPassword;
        }
        public static bool checkPassword(string password, string hashedpassword)
        {
            return hashpassword(password) == hashedpassword;
        }
    }
}
