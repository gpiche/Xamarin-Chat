using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace IdentityServer.Services
{
    public class CryptoService : ICryptoService
    {
        public string GenerateSalt()
        {
            Guid g = Guid.NewGuid();
            string guidString = Convert.ToBase64String(g.ToByteArray());
            guidString = guidString.Replace("=", "");
            guidString = guidString.Replace("+", "");
            return guidString;
        }

        public string HashSha512(string value, string salt)
        {
            var sha = SHA512.Create();
            var saltedValue = Encoding.UTF8.GetBytes(value + salt);
            var hashedSaltedValue = sha.ComputeHash(saltedValue);
            return Convert.ToBase64String(hashedSaltedValue);
        }
    }
}
