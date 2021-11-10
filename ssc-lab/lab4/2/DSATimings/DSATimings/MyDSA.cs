using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace DSATimings
{
    class MyDSA
    {
        private DSA mDsa;

        
        public void create(int bits)
        {
            // Creates a new ephemeral DSA key with the specified key size.
            mDsa = DSA.Create(bits);
        }
        
        public byte[] signData(byte[] msg)
        {
            HashAlgorithmName sha256 = new HashAlgorithmName("SHA256");
            return mDsa.SignData(msg, sha256);
        }
        
        public bool isSignatureOk(byte[] msg, byte[] signature)
        {
            HashAlgorithmName sha256 = new HashAlgorithmName("SHA256");
            return mDsa.VerifyData(msg, signature, sha256);
        }
    }
}
