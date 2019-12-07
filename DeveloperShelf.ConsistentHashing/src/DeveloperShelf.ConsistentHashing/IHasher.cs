namespace DeveloperShelf.ConsistentHashing
{
    /// <summary>
    /// Wrapper around the hashing algorithm (SHA256) which is used in this lib
    /// </summary>
    public interface IHasher
    {
        /// <summary>
        /// Computes a Sha256 of the input string value and returns the hash in string format
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        int ComputeHash(string value);
    }
}