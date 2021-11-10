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
     * Helper class used for
     *  - getting the content of a file from the project's root
     *  - writing to a file within the project's root
     * 
     */
    class FileHandler
    {
        public readonly static string GO_TO_ROOT = "..\\..\\..\\..\\";
        public String getFileContent(String fileName)
        {
            String currentPath = Directory.GetCurrentDirectory() + GO_TO_ROOT;
            String filePath = currentPath + fileName;
            String content = File.ReadAllText(filePath);

            return content;
        }

        public void writeToFile(String fileName, String content)
        {
            String currentPath = Directory.GetCurrentDirectory() + GO_TO_ROOT;

            File.WriteAllText(currentPath + fileName, content);
        }
    }
}
