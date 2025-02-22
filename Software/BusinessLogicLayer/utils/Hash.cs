using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.utils
{
    public class Hash
    {
        public static string HashPassword(string password)
        {
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

            SHA256 sha256 = SHA256.Create();
            byte[] hash = sha256.ComputeHash(passwordBytes);

            return BitConverter.ToString(hash).Replace("-", string.Empty).Substring(0, 49);
        }
    }
}
