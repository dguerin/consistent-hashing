using System;
using System.Security.Cryptography;
using System.Text;

namespace DeveloperShelf.ConsistentHashing
{
    public class Sha256Hasher : IHasher
    {
        public int ComputeHash(string value)
        {
            using (var sha256Hash = SHA256.Create())
            {
                var bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(value.ToLowerInvariant()));
                return Math.Abs(BitConverter.ToInt32(bytes, 0));
            }
        }
    }
}