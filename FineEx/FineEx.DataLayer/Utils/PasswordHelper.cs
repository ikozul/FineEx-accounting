using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FineEx.DataLayer.Utils
{
    public static class PasswordHelper
    {

        public static bool CheckPasswordValidity(string plainPassword)
        {
            return plainPassword == HashPassword(plainPassword);
        }
        /// <summary>
        /// Method that hashes password
        /// </summary>
        /// <param name="plainPassword"></param>
        /// <returns></returns>
        /// <code>User.Password != PasswordHelper.HashPassword(Pass)</code>
        public static string HashPassword(string plainPassword)
        {
            //Todo We need to use this when we are registering User
            try
            {
                plainPassword = Config.Salt + plainPassword;
                var hashedBytes = new SHA1CryptoServiceProvider().ComputeHash(Encoding.UTF8.GetBytes(plainPassword));
                var hashedInput = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
                return hashedInput;
            }
            catch (Exception ex)
            {
               //Todo Implement Error logger
               //.Error("PasswordHelper - HashPassword", "plainPassword=" + plainPassword, ex, null);
            }
            return null;
        }

    }
}
