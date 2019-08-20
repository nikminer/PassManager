using System;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace PassManager
{
    class Crypt
    {
        static public string HashSHA512(string encryptText)
        {
            string hash=string.Empty;
            foreach (byte i in new SHA512Managed().ComputeHash(Encoding.UTF8.GetBytes(encryptText)))
                hash += i.ToString("X2");
            return hash;
        }

        public static string encrypt(string Text,string key)
        {

            if (string.IsNullOrEmpty(Text))
                return "";

            byte[] textInBytes = Encoding.UTF8.GetBytes(Text);

            Rfc2898DeriveBytes deriveBytes = new Rfc2898DeriveBytes(key, Encoding.UTF8.GetBytes(HashSHA512(key)));

            RijndaelManaged rijndael = new RijndaelManaged();

            rijndael.KeySize = 256;
            rijndael.BlockSize = 256;
            rijndael.Padding = PaddingMode.ISO10126;
            rijndael.Mode = CipherMode.CBC;
            rijndael.Key = deriveBytes.GetBytes(32);
            rijndael.IV = deriveBytes.GetBytes(32);

            byte[] encryptTextBytes = null;

            using (ICryptoTransform encryptor = rijndael.CreateEncryptor())
            {
                using (MemoryStream memStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memStream, encryptor, CryptoStreamMode.Write))
                    {
                        cryptoStream.Write(textInBytes, 0, textInBytes.Length);
                        cryptoStream.FlushFinalBlock();
                        encryptTextBytes = memStream.ToArray();
                        memStream.Close();
                        cryptoStream.Close();
                    }
                }
            }
            rijndael.Clear();
            return Convert.ToBase64String(encryptTextBytes);
        }

        public static string decrypt(string encryptText, string key)
        {
            if (string.IsNullOrEmpty(encryptText))
                return "";

            byte[] textInBytes = Convert.FromBase64String(encryptText);
            Rfc2898DeriveBytes deriveBytes = new Rfc2898DeriveBytes(key, Encoding.UTF8.GetBytes(HashSHA512(key)));
            RijndaelManaged rijndael = new RijndaelManaged();

            rijndael.KeySize = 256;
            rijndael.BlockSize = 256;
            rijndael.Padding = PaddingMode.ISO10126;
            rijndael.Mode = CipherMode.CBC;
            rijndael.Key = deriveBytes.GetBytes(32);
            rijndael.IV = deriveBytes.GetBytes(32);

            byte[] plainTextBytes = new byte[textInBytes.Length];
            int byteCount = 0;

            try
            {
                using (ICryptoTransform decryptor = rijndael.CreateDecryptor())
                {
                    using (MemoryStream mSt = new MemoryStream(textInBytes))
                    {
                        using (CryptoStream cryptoStream = new CryptoStream(mSt, decryptor, CryptoStreamMode.Read))
                        {
                            byteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
                            mSt.Close();
                            cryptoStream.Close();
                        }
                    }
                }
                rijndael.Clear();
                return Encoding.UTF8.GetString(plainTextBytes, 0, byteCount);
            }
            catch (CryptographicException)
            {
                return "Error";
            }
        }
    }
   
}
