using System;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using System.Linq;
using System.Web;

namespace SurveyApp.Web.Util
{
    public static class StringCipher
    {
        public static System.Text.Encoding encoding { get; set; } = System.Text.Encoding.ASCII;
        public static string EncryptString(string stringvalue)
        {
            Byte[] stringBytes = encoding.GetBytes(stringvalue);
            StringBuilder sbBytes = new StringBuilder(stringBytes.Length * 2);
            foreach (byte b in stringBytes)
            {
                sbBytes.AppendFormat("{0:X2}", b);
            }
            return sbBytes.ToString();
        }
        public static string DecryptString(string hexvalue)
        {
            int CharsLength = hexvalue.Length;
            byte[] bytesarray = new byte[CharsLength / 2];
            for (int i = 0; i < CharsLength; i += 2)
            {
                bytesarray[i / 2] = Convert.ToByte(hexvalue.Substring(i, 2), 16);
            }
            return encoding.GetString(bytesarray);
        }
        //public static string EncryptString(string inputText, string key, string salt)
        //{
        //    byte[] plainText = Encoding.UTF8.GetBytes(inputText);

        //    using (RijndaelManaged rijndaelCipher = new RijndaelManaged())
        //    {
        //        PasswordDeriveBytes secretKey = new PasswordDeriveBytes(Encoding.ASCII.GetBytes(key), Encoding.ASCII.GetBytes(salt));
        //        using (ICryptoTransform encryptor = rijndaelCipher.CreateEncryptor(secretKey.GetBytes(32), secretKey.GetBytes(16)))
        //        {
        //            using (MemoryStream memoryStream = new MemoryStream())
        //            {
        //                using (CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
        //                {
        //                    cryptoStream.Write(plainText, 0, plainText.Length);
        //                    cryptoStream.FlushFinalBlock();
        //                    string base64 = Convert.ToBase64String(memoryStream.ToArray());

        //                    // Generate a string that won't get screwed up when passed as a query string.
        //                    string urlEncoded = HttpUtility.UrlEncode(base64);
        //                    return urlEncoded;
        //                }
        //            }
        //        }
        //    }
        //}

        //public static string DecryptString(string inputText, string key, string salt)
        //{
        //    byte[] encryptedData = Convert.FromBase64String(inputText);
        //    PasswordDeriveBytes secretKey = new PasswordDeriveBytes(Encoding.ASCII.GetBytes(key), Encoding.ASCII.GetBytes(salt));

        //    using (RijndaelManaged rijndaelCipher = new RijndaelManaged())
        //    {
        //        using (ICryptoTransform decryptor = rijndaelCipher.CreateDecryptor(secretKey.GetBytes(32), secretKey.GetBytes(16)))
        //        {
        //            using (MemoryStream memoryStream = new MemoryStream(encryptedData))
        //            {
        //                using (CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
        //                {
        //                    byte[] plainText = new byte[encryptedData.Length];
        //                    cryptoStream.Read(plainText, 0, plainText.Length);
        //                    string utf8 = Encoding.UTF8.GetString(plainText);
        //                    return utf8;
        //                }
        //            }
        //        }
        //    }
        //}
        //public static string EncryptString(string text, string keyString)
        //{
        //    var key = Encoding.UTF8.GetBytes(keyString);

        //    using (var aesAlg = Aes.Create())
        //    {
        //        using (var encryptor = aesAlg.CreateEncryptor(key, aesAlg.IV))
        //        {
        //            using (var msEncrypt = new MemoryStream())
        //            {
        //                using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
        //                using (var swEncrypt = new StreamWriter(csEncrypt))
        //                {
        //                    swEncrypt.Write(text);
        //                }

        //                var iv = aesAlg.IV;

        //                var decryptedContent = msEncrypt.ToArray();

        //                var result = new byte[iv.Length + decryptedContent.Length];

        //                Buffer.BlockCopy(iv, 0, result, 0, iv.Length);
        //                Buffer.BlockCopy(decryptedContent, 0, result, iv.Length, decryptedContent.Length);

        //                return Convert.ToBase64String(result);
        //            }
        //        }
        //    }
        //}

        //public static string DecryptString(string cipherText, string keyString)
        //{


        //    try
        //    {
        //        var fullCipher = Convert.FromBase64String(cipherText);

        //        var iv = new byte[16];
        //        var cipher = new byte[16];

        //        Buffer.BlockCopy(fullCipher, 0, iv, 0, iv.Length);
        //        Buffer.BlockCopy(fullCipher, iv.Length, cipher, 0, iv.Length);
        //        var key = Encoding.UTF8.GetBytes(keyString);

        //        using (var aesAlg = Aes.Create())
        //        {
        //            using (var decryptor = aesAlg.CreateDecryptor(key, iv))
        //            {
        //                string result;
        //                using (var msDecrypt = new MemoryStream(cipher))
        //                {
        //                    using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
        //                    {
        //                        using (var srDecrypt = new StreamReader(csDecrypt))
        //                        {
        //                            result = srDecrypt.ReadToEnd();
        //                        }
        //                    }
        //                }

        //                return result;
        //            }
        //        }
        //    }
        //    catch (Exception)
        //    {

        //        return null;
        //    }
        //}
    }
}


