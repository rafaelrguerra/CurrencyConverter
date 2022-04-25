using System;
using System.Security.Cryptography;
using System.Text;

namespace CurrencyConverter.Tools
{
    public class Sha256
    {
        public string Hash(string entry)
        {
            var crypt = new SHA256Managed();
            string hash = String.Empty;
            byte[] crypto = crypt.ComputeHash(Encoding.ASCII.GetBytes(entry));
            foreach (byte theByte in crypto)
            {
                hash += theByte.ToString("x2");
            }
            return hash;
        }
    }
}