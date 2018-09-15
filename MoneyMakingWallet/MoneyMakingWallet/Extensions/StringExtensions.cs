using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace IDMONEY.IO
{
    public static class StringExtensions
    {
        #region Methods
        public static string ToCamelCase(this string value)
        {
            return value.ConvertFirstCharacter(x => x.ToLowerInvariant());
        }

        public static string ToPascalCase(this string value)
        {
            return value.ConvertFirstCharacter(x => x.ToUpperInvariant());
        }

        public static bool IsNullOrEmpty(this string value)
        {
            return String.IsNullOrWhiteSpace(value);
        }

        public static bool IsNotNullOrEmpty(this string value)
        {
            return !value.IsNullOrEmpty();
        }

        public static string GenerateSHA512(this string value)
        {
            SHA512 sha512 = SHA512Managed.Create();
            byte[] bytes = Encoding.UTF8.GetBytes(value);
            byte[] hash = sha512.ComputeHash(bytes);
            return GetStringFromHash(hash);
        }
        #endregion

        #region Private Methods
        private static string GetStringFromHash(byte[] hash)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                result.Append(hash[i].ToString("X2"));
            }
            return result.ToString();
        }

        private static string ConvertFirstCharacter(this string value, Func<string, string> converter)
        {
            if (value.IsNullOrEmpty())
            {
                return string.Empty;
            }

            return string.Concat(converter(value.Substring(0, 1)), value.Substring(1));
        }
        #endregion
    }
}
