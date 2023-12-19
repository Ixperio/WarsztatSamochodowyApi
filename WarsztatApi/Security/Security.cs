using WarsztatApi.Security.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace WarsztatApi.Security
{
    public class Security : ISecurity
    {
        private readonly string AES256KEY = "";

        public Security() { }

        private string generateString(int val)
        {
            string data = "QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnm1234567890!@#$%^&*()<>?[]{}-_=+~|";

            string export = String.Empty;

            Random random = new Random();

            while(val >= 0)
            {
                export += data[random.Next(0, data.Length)];
                val--;
            }
            
            return export;

        }

        public string GetTrustString()
        {
            return generateString(256);
        }

        public bool CompareSHA256(string defaultString, string hashedString)
        {
            if(!string.IsNullOrEmpty(defaultString) && !string.IsNullOrEmpty(hashedString))
            {
                defaultString = CalculateSHA256(defaultString);
                if (string.Equals(defaultString, hashedString, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public string CalculateSHA256(string input)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                // Konwertuj ciąg znaków na tablicę bajtów
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);

                // Oblicz skrót SHA-256
                byte[] hashBytes = sha256.ComputeHash(inputBytes);

                // Konwertuj tablicę bajtów na ciąg znaków szesnastkowy
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    builder.Append(hashBytes[i].ToString("x2"));
                }

                return builder.ToString();
            }
        }


    }
}
