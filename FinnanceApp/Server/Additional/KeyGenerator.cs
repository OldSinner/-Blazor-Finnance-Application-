using System;
using System.Security.Cryptography;

namespace FinnanceApp.Server.Additional
{
    public class KeyGenerator
    {
        public string GetRandomString(int string_length)
        {
            using (var random = new RNGCryptoServiceProvider())
            {
                var bit_count = (string_length * 6);
                var byte_count = ((bit_count + 7) / 8);
                var bytes = new byte[byte_count];
                random.GetBytes(bytes);
                return Convert.ToBase64String(bytes);
            }
        }
    }
}