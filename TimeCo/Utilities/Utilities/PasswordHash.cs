using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;


namespace TimeCo.Utilities
{ 
    public class PasswordHash
    {
        const int keySize = 64;
        const int iterations = 350000;
        HashAlgorithmName hashAlgorithm = HashAlgorithmName.SHA512;

        // Method for hashing password
        public string HashPassword(string password)
        {
            var hash = Rfc2898DeriveBytes.Pbkdf2(
                Encoding.UTF8.GetBytes(password),
                new byte[0], // Empty salt
                iterations,
                hashAlgorithm,
                keySize);

            return Convert.ToHexString(hash);
        }

        // Method for verifying hashed password
        public bool VerifyPassword(string password, string hashedPassword)
        {
            var hashToCompare = Rfc2898DeriveBytes.Pbkdf2(
                Encoding.UTF8.GetBytes(password),
                new byte[0], // Empty salt
                iterations,
                hashAlgorithm,
                keySize);

            string computedHash = Convert.ToHexString(hashToCompare);

            return string.Equals(hashedPassword, computedHash, StringComparison.OrdinalIgnoreCase);
        }
    }
}
