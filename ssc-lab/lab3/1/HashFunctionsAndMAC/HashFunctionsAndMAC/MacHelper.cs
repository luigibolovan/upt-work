using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HashFunctionsAndMAC
{
    class MacHelper
    {
        private HMAC mHMAC;
        public MacHelper(String hashFunction)
        {
            if (hashFunction.CompareTo("MD5") == 0)
            {
                mHMAC = new HMACMD5();
            }
            if (hashFunction.CompareTo("SHA1") == 0)
            {
                mHMAC = new HMACSHA1();
            }
            if (hashFunction.CompareTo("RIPEMD") == 0)
            {
                mHMAC = new HMACRIPEMD160();
            }
            if (hashFunction.CompareTo("SHA256") == 0)
            {
                mHMAC = new HMACSHA256();
            }
            if (hashFunction.CompareTo("SHA384") == 0)
            {
                mHMAC = new HMACSHA384();
            }
            if (hashFunction.CompareTo("SHA512") == 0)
            {
                mHMAC = new HMACSHA512();
            }
        }

        public byte[] getTag(byte[] input, byte[] key)
        {
            mHMAC.Key = key;
            return mHMAC.ComputeHash(input);
        }

        public bool isAuthentic(byte[] message, byte[] mac, byte[] key)
        {
            mHMAC.Key = key;
            if (equalByteArrays(mHMAC.ComputeHash(message), mac, mHMAC.HashSize / 8))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool equalByteArrays(byte[] arr1, byte[] arr2, int size)
        {
            for(int i = 0; i < size; i++)
            {
                if(arr1[i] != arr2[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
