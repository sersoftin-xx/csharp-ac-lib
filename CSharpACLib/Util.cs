using System;
using System.Security.Cryptography;
using System.Text;

namespace CSharpACLib
{
    static class Util
    {
        public static string Sha256(string inputString)
        {
            string result;
            using (var sha256Managed = new SHA256Managed())
            {
                var hashBytes = sha256Managed.ComputeHash(Encoding.UTF8.GetBytes(inputString));
                result = BitConverter.ToString(hashBytes);
            }
            return result.Replace("-", string.Empty);
        }
    }
}
