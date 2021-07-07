using System;

namespace DeveloperShelf.ConsistentHashing
{
    public static class StringExtensions
    {
        public static void CheckIsNullEmptyOrWhitespace(this string value)
        {
            if (string.IsNullOrWhiteSpace(value) || string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentNullException(nameof(value));
            }
        }
    }
}
