using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace RSATimings
{
    class RSACryptosys
    {
        private RSA mRsa;

        public RSACryptosys()
        {
        }

        public void create(int bits)
        {
            // Creates a new ephemeral RSA key with the specified key size.
            mRsa = RSA.Create(bits);
        }

        public byte[] encrypt(byte[] msg)
        {
            return mRsa.Encrypt(msg, RSAEncryptionPadding.OaepSHA256);
        }

        public byte[] decrypt(byte[] msg)
        {
            return mRsa.Decrypt(msg, RSAEncryptionPadding.OaepSHA256);
        }

        public byte[] signData(byte[] msg)
        {
            HashAlgorithmName sha256 = new HashAlgorithmName("SHA256");
            return mRsa.SignData(msg, sha256, RSASignaturePadding.Pkcs1);
        }

        public bool isSignatureOk(byte[] msg, byte[] signature)
        {
            HashAlgorithmName sha256 = new HashAlgorithmName("SHA256");
            return mRsa.VerifyData(msg, signature, sha256, RSASignaturePadding.Pkcs1);
        }
    }
}
