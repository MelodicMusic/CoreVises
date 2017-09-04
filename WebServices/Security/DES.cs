using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace WebServices.Security
{
    public class DES
    {

        private byte[] key;
        private byte[] initialVector;

        public DES()
        {
            this.key = Encoding.UTF8.GetBytes("Aplicada");
            this.initialVector = Encoding.ASCII.GetBytes("01234567");
        }

        public string Encrypt(String data)
        {


            byte[] dataBytes = Encoding.ASCII.GetBytes(data);

            DESCryptoServiceProvider desCryptoServiceProvider = new DESCryptoServiceProvider();

            desCryptoServiceProvider.KeySize = 64;
            desCryptoServiceProvider.BlockSize = 64;

            MemoryStream memoryStream = new MemoryStream();


            using (CryptoStream cryptoStream = new CryptoStream(memoryStream, desCryptoServiceProvider.CreateEncryptor(key, initialVector), CryptoStreamMode.Write))
            {
                StreamWriter streamWriter = new StreamWriter(cryptoStream);
                streamWriter.Write(data);
                streamWriter.Flush();
                cryptoStream.FlushFinalBlock();
                string finalEncryption = Convert.ToBase64String(memoryStream.GetBuffer(), 0, (int)memoryStream.Length);

                return finalEncryption;

            }
        }

        public string Decrypt(string encryptedData)
        {

            string finalDecryption = string.Empty;
            byte[] encryptedDataBytes = Encoding.ASCII.GetBytes(encryptedData);

            DESCryptoServiceProvider desCryptoServiceProvider = new DESCryptoServiceProvider();

            desCryptoServiceProvider.KeySize = 64;
            desCryptoServiceProvider.BlockSize = 64;

            MemoryStream memoryStream = new MemoryStream(Convert.FromBase64String(encryptedData));

            using (CryptoStream cryptoStream = new CryptoStream(memoryStream, desCryptoServiceProvider.CreateDecryptor(key, initialVector), CryptoStreamMode.Read))
            {
                StreamReader streamReader = new StreamReader(cryptoStream);
                finalDecryption = streamReader.ReadToEnd();

                return finalDecryption;


            }
       
        }

    }
}