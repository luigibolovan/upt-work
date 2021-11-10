using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EncryptDecrypt
{
    class CryptoHandler
    {
        SymmetricAlgorithm mCryptoAlgorithm;
        public CryptoHandler()
        {
            mCryptoAlgorithm = Aes.Create();
            mCryptoAlgorithm.Padding = PaddingMode.Zeros;
            generateKeyAndIV();
        }

        public void generateKeyAndIV()
        {
            mCryptoAlgorithm.GenerateIV();
            mCryptoAlgorithm.GenerateKey();
        }

        public byte[] Encrypt(byte[] message, byte[] key, byte[] iv)
        {   
            MemoryStream memStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memStream, mCryptoAlgorithm.CreateEncryptor(), CryptoStreamMode.Write);

            cryptoStream.Write(message, 0, message.Length);
            cryptoStream.Close();

            return memStream.ToArray();

        }

        public byte[] Decrypt(byte[] message, byte[] key, byte[] iv)
        {
            byte[] plainTextBytes = new byte[message.Length];

            MemoryStream memStream = new MemoryStream(message);
            CryptoStream cryptoStream = new CryptoStream(memStream, mCryptoAlgorithm.CreateDecryptor(), CryptoStreamMode.Read);

            cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
            cryptoStream.Close();

            return plainTextBytes;
        }
        
        public byte[] getKey()
        {
            return mCryptoAlgorithm.Key;
        }

        public byte[] getIV()
        {
            return mCryptoAlgorithm.IV;
        }
    }
}
