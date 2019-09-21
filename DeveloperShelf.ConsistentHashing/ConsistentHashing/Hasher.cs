using System.Security.Cryptography;
using System.Text;

namespace ConsistentHashing
{
    
    public class Hasher : IHasher
    {
        public string ComputeHash(string value)
        {
            using (var sha256Hash = SHA256.Create())
            {
                var bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(value.ToLowerInvariant()));
                var builder = new StringBuilder();
                foreach (var t in bytes)
                {
                    builder.Append(t.ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}