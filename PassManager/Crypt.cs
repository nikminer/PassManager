using System;
using System.Text;
using System.Security.Cryptography;

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

            Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(key, Encoding.UTF8.GetBytes(HashSHA512(key)));

            RijndaelManaged cipher = new RijndaelManaged();
            cipher.KeySize = 256;
            cipher.BlockSize = 256;
            cipher.Padding = PaddingMode.ISO10126;
            cipher.Mode = CipherMode.CBC;
            cipher.Key = pdb.GetBytes(32);
            cipher.IV = pdb.GetBytes(32);

            ICryptoTransform t = cipher.CreateEncryptor();
            byte[] textInBytes = Encoding.UTF8.GetBytes(Text);
            return Convert.ToBase64String(t.TransformFinalBlock(textInBytes, 0, textInBytes.Length));
        }

        public static string decrypt(string encryptText, string key)
        {
            if (string.IsNullOrEmpty(encryptText))
                return "";

            Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(key, Encoding.UTF8.GetBytes(HashSHA512(key)));

            RijndaelManaged cipher = new RijndaelManaged();
            cipher.KeySize = 256;
            cipher.BlockSize = 256;
            cipher.Padding = PaddingMode.ISO10126;
            cipher.Mode = CipherMode.CBC;
            cipher.Key = pdb.GetBytes(32);
            cipher.IV = pdb.GetBytes(32);

            ICryptoTransform t = cipher.CreateDecryptor();
            byte[] textInBytes = Convert.FromBase64String(encryptText);

            return Encoding.UTF8.GetString(t.TransformFinalBlock(textInBytes, 0, textInBytes.Length));
        }
    }
   
}
