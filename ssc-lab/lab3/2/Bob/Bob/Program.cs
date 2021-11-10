using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Bob
{
    /**
     * 
     * Bob's main job
     * @input: the received file from Alice. its authenticity will be checked by Bob
     * @output: is the file authentic or corrupted
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            FileHandler myFileHandler = new FileHandler();
            HmacHandler myHMACHandler = new HmacHandler("SHA-256 --- Supports also SHA-512 and MD5");

            string projectRootPath  = Directory.GetCurrentDirectory() + FileHandler.GO_TO_ROOT;
            string key              = myFileHandler.getFileContent("key");
            string receivedMAC      = myFileHandler.getFileContent("mac");
            
            Console.Write("File name: ");
            String fileName = Console.ReadLine();

            Console.Write("\nChecking authenticity...\n\n");
            if(myHMACHandler.isFileAuthentic(projectRootPath + fileName, key, receivedMAC))
            {
                Console.Write("File is authentic\n");
            }
            else
            {
                Console.Write("File corrupted");
            }

            Console.ReadKey();
        }
    }
}
