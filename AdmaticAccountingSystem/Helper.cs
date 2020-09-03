using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace AdmaticAccountingSystem
{
    public class Helper
    {
        private static string Salt(string password)
        {
            return "%493!2'" + password + "+'s434A";
        }
        public static string PwHash(string password)
        {
            SHA512Managed crypt = new SHA512Managed();
            string hash = String.Empty;
            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(Salt(password)), 0, Encoding.UTF8.GetByteCount(Salt(password)));
            foreach (byte bit in crypto)
            {
                hash += bit.ToString("x2");
            }
            return hash;
        }
    }
}