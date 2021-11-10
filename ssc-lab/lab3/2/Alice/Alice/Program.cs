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
     * Alice's main job
     * @input: a file from project's root. the file contains the message that is being sent to Bob
     * @output: a file within the project's root with the message's tag
     * 
     */
    class Program
    {
        //static string key = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        static void Main(string[] args)
        {
            FileHandler myFileHandler = new FileHandler();
            HmacHandler myCryptoHandler = new HmacHandler("SHA-256; Supports also MD5 and SHA-512");

            string projectRootPath  = Directory.GetCurrentDirectory() + FileHandler.GO_TO_ROOT;
            string key              = myFileHandler.getFileContent("key");
                
            Console.Write("File name: ");
            String fileName = Console.ReadLine();
            
            
            byte[] tag = myCryptoHandler.getFileHMAC(projectRootPath + fileName, key);
            String tagString = BitConverter.ToString(tag);
            tagString = tagString.Replace("-", "");
            Console.Write("\nHMAC\n" + tagString);
            myFileHandler.writeToFile("mac", tagString);


            Console.ReadKey();
        }
    }
}
