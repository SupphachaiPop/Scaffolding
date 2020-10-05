using System;
using System.Configuration;
using System.Security.Cryptography;
using System.Text;

namespace Scaffolding.Common
{
    // Append Class by Teeramed Tangjirawattana 2562
    public interface IUtilityCommon
    {
        string Base64Encode(string plainText);
        string Base64Decode(string base64EncodedData);
        T Base64Decode<T>(string base64EncodedData);

        string MD5Hash(string input);
        string EncryptData(string textData, string Encryptionkey);
        string DecryptData(string EncryptedText, string Encryptionkey);
    }

    public class UtilityCommon : IUtilityCommon
    {
        #region [Encryption Methods]
        public string Base64Encode(string plainText)
        {
            string result = string.Empty;
            if (!string.IsNullOrEmpty(plainText))
            {
                var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
                result = System.Convert.ToBase64String(plainTextBytes);
            }
            return result;
        }

        public string Base64Decode(string base64EncodedData)
        {
            string result = string.Empty;
            if (!string.IsNullOrEmpty(base64EncodedData))
            {
                var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
                result = System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
            }
            return result;
        }

        public T Base64Decode<T>(string base64EncodedData)
        {
            string result = this.Base64Decode(base64EncodedData: base64EncodedData);
            try
            {
                return (T)Convert.ChangeType(result, typeof(T));
            }
            catch
            {
                return default(T);
            }
        }

        public string MD5Hash(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return string.Empty;
            }

            StringBuilder hash = new StringBuilder();
            MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider();
            byte[] bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(input));

            for (int i = 0; i < bytes.Length; i++)
            {
                hash.Append(bytes[i].ToString("x2"));
            }
            return hash.ToString();
        }

        public string MD5HashWithKey(string input, string Encryptionkey)
        {
            string result = string.Empty;
            string md5HashResult = this.MD5Hash(input: input);
            if (!string.IsNullOrEmpty(md5HashResult))
            {
                result = this.EncryptData(textData: md5HashResult, Encryptionkey: Encryptionkey);
            }
            return result;
        }

        public string EncryptData(string textData, string Encryptionkey)
        {
            RijndaelManaged objrij = new RijndaelManaged();
            //set the mode for operation of the algorithm
            objrij.Mode = CipherMode.CBC;
            //set the padding mode used in the algorithm.
            objrij.Padding = PaddingMode.PKCS7;
            //set the size, in bits, for the secret key.
            objrij.KeySize = 0x80;
            //set the block size in bits for the cryptographic operation.
            objrij.BlockSize = 0x80;
            //set the symmetric key that is used for encryption & decryption.
            byte[] passBytes = Encoding.UTF8.GetBytes(Encryptionkey);
            //set the initialization vector (IV) for the symmetric algorithm
            byte[] EncryptionkeyBytes = new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
            int len = passBytes.Length;
            if (len > EncryptionkeyBytes.Length)
            {
                len = EncryptionkeyBytes.Length;
            }
            Array.Copy(passBytes, EncryptionkeyBytes, len);
            objrij.Key = EncryptionkeyBytes;
            objrij.IV = EncryptionkeyBytes;
            //Creates symmetric AES object with the current key and initialization vector IV.
            ICryptoTransform objtransform = objrij.CreateEncryptor();
            byte[] textDataByte = Encoding.UTF8.GetBytes(textData);
            //Final transform the test string.
            return Convert.ToBase64String(objtransform.TransformFinalBlock(textDataByte, 0, textDataByte.Length));
        }

        public string DecryptData(string EncryptedText, string Encryptionkey)
        {
            RijndaelManaged objrij = new RijndaelManaged();
            objrij.Mode = CipherMode.CBC;
            objrij.Padding = PaddingMode.PKCS7;
            objrij.KeySize = 0x80;
            objrij.BlockSize = 0x80;
            byte[] encryptedTextByte = Convert.FromBase64String(EncryptedText);
            byte[] passBytes = Encoding.UTF8.GetBytes(Encryptionkey);
            byte[] EncryptionkeyBytes = new byte[0x10];
            int len = passBytes.Length;
            if (len > EncryptionkeyBytes.Length)
            {
                len = EncryptionkeyBytes.Length;
            }
            Array.Copy(passBytes, EncryptionkeyBytes, len);
            objrij.Key = EncryptionkeyBytes;
            objrij.IV = EncryptionkeyBytes;
            byte[] TextByte = objrij.CreateDecryptor().TransformFinalBlock(encryptedTextByte, 0, encryptedTextByte.Length);
            return Encoding.UTF8.GetString(TextByte);  //it will return readable string
        }
        #endregion [Encryption Methods]
    }
}
