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
        /// <summary>
        /// Class that hashes password
        /// </summary>
        /// <param name="plainPassword"></param>
        /// <returns></returns>
        public static string HashPassword(string plainPassword)
        {
            try
            {
                //Todo implement class that reads configs
                plainPassword = "";//Config.SALT + plainPassword;
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
