using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncryptDecrypt
{
    class Program
    {
        static void Main(string[] args)
        {
            string message, option;
            CryptoHandler myCryptoHandler = new CryptoHandler();
            ConvertHandler mConversionHandler = new ConvertHandler();

            Console.Write("Enter your message: ");
            message = Console.ReadLine();

            Console.Write("Encrpyt/Decrypt?(e/d)");
            option = Console.ReadLine();
            switch (option)
            {
                case "e":
                    byte[] messageBytes = Encoding.ASCII.GetBytes(message);
                    byte[] encryptedMessage = myCryptoHandler.Encrypt(messageBytes, myCryptoHandler.getKey(), myCryptoHandler.getIV());
                    string toPrint = mConversionHandler.convertByteArrayToHEXString(encryptedMessage);

                    Console.Write("\nEncrypted message\n\n");
                    Console.WriteLine(toPrint + "\n");
                    break;
                case "d":
                    byte[] receivedMessage = mConversionHandler.convertHEXStringToByteArray(message);
                    byte[] decryptedMessage = myCryptoHandler.Decrypt(receivedMessage, myCryptoHandler.getKey(), myCryptoHandler.getIV());
                    string decryptedHEXString = mConversionHandler.convertByteArrayToHEXString(decryptedMessage);

                    byte[] decryptedBytes = mConversionHandler.convertHEXStringToByteArray(decryptedHEXString);
                    string decryptedString = Encoding.ASCII.GetString(decryptedBytes);


                    Console.Write("\nDecrypted message \n\n");
                    Console.WriteLine(decryptedString + "\n");
                    break;
                default:
                    Console.WriteLine("Invalid option");
                    return;
            }

            Console.Write("Press any key...");
            Console.ReadKey();
        }
    }
}
