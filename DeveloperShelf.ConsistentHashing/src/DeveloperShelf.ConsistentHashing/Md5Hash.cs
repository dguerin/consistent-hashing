using System;
using System.Security.Cryptography;
using System.Text;

namespace DeveloperShelf.ConsistentHashing
{
    public class Md5Hash : IHash
    {
        public int ComputeHash(string value)
        {
            using(var md5Hash = MD5.Create())
            {
                var bytes = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(value.ToLowerInvariant()));
                return Math.Abs(BitConverter.ToInt32(bytes, 0));
            }
        }
    }
}