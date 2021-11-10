using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;

namespace Alice
{
    /**
     * 
     * Helper class used for
     *  - choosing the hash function
     *  - calculating the tag(using a given key)
     *  - checking if a received file is authentic or not based on the mac received
     * 
     */
    class HmacHandler
    {
        private HMAC mHMAC;
        public HmacHandler(String hashFunction)
        {
            if (hashFunction.CompareTo("MD5") == 0)
            {
                mHMAC = new HMACMD5();
            }
            else if (hashFunction.CompareTo("SHA-512") == 0)
            {
                mHMAC = new HMACSHA512();
            }
            else
            {
                mHMAC = new HMACSHA256();
            }
        }

        public HMAC getHMACObj()
        {
            return mHMAC;
        }

        public byte[] getFileHMAC(String path, String key)
        {
            FileStream fileStream = new FileStream(path, FileMode.Open);
            fileStream.Position = 0;

            mHMAC.Key = Encoding.ASCII.GetBytes(key);
            byte[] tagByteArray = mHMAC.ComputeHash(fileStream);

            return tagByteArray;
        }
        
        public bool isFileAuthentic(String path, String key, String mac)
        {
            byte[] receivedFileTag = getFileHMAC(path, key);
            string receivedFileTagString = BitConverter.ToString(receivedFileTag);
            receivedFileTagString = receivedFileTagString.Replace("-", "");

            if (receivedFileTagString.CompareTo(mac) == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
