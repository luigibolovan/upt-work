using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Runtime.InteropServices.WindowsRuntime;
using System.IO;

namespace ECB_Encryption
{
    class Program
    {
        static void Main(string[] args)
        {
            ConversionHelper converter = new ConversionHelper();
            SymmetricAlgorithm algo = Aes.Create();
            algo.KeySize = 128;
            algo.Mode = CipherMode.ECB;
            algo.Padding = PaddingMode.Zeros;

            algo.GenerateIV();
            algo.GenerateKey();

            string keyString = converter.convertByteArrayToHEXString(algo.Key);
            string ivString = converter.convertByteArrayToHEXString(algo.IV);

            Console.WriteLine("Aes ECB encryption");
            Console.Write("KEY: " + keyString + "\n");
            Console.Write("IV: " + ivString + "\n");
            Console.Write("Blocksize: " + algo.BlockSize + "\n");


            string input1 = "Lorem ipsum abracadabra arbadacarba";
            string input2 = "Lorem ipsum abracadabra arbadacarba consectetur adipiscing elit, sed do eiusmod tempor incididunt";

            byte[] input1Byte = converter.convertStringToByteArray(input1);
            byte[] encryptedInput1Bytes = encrypt(input1Byte, algo);
            Console.WriteLine("Enc/rypted 1:" + converter.convertByteArrayToHEXString(encryptedInput1Bytes));

            byte[] input2Byte = converter.convertStringToByteArray(input2);
            byte[] encryptedInput2Bytes = encrypt(input2Byte, algo);
            Console.WriteLine("Encrypted 2 :" + converter.convertByteArrayToHEXString(encryptedInput2Bytes));

            Console.ReadKey();
        }

        static byte[] encrypt(byte[] message, SymmetricAlgorithm algorithm)
        {
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, algorithm.CreateEncryptor(), CryptoStreamMode.Write);

            cs.Write(message, 0, message.Length);
            cs.Close();

            return ms.ToArray();
        }
    }
}
