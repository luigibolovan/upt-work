#include <iostream>
#include <fstream>
#include <string.h>
#include <locale>
#include <memory>

#define READ_FILE       std::ifstream
#define WRITE_FILE      std::ofstream
#define READ_WRITE_FILE std::fstream


class SysInterface
{
    public:
        void moveFile(std::string currentPath, std::string newPath);
        void renameFile(std::string currentPath, std::string newPath);
        void removeFile(std::string path);
        void copyFile(std::string currentPath, std::string copyPath);
        //other functions
};

void SysInterface::moveFile(std::string currentPath, std::string newPath)
{
    std::string command = "mv " + currentPath + " " + newPath;
    system(command.c_str());
}

void SysInterface::renameFile(std::string currentPath, std::string newPath)
{
    std::string command = "mv " + currentPath + " " + newPath;
    system(command.c_str());
}

void SysInterface::removeFile(std::string path)
{
    std::string command = "rm " + path;
    system(command.c_str());
}

void SysInterface::copyFile(std::string currentPath, std::string copyPath)
{
    std::string command = "cp " + currentPath + " " + copyPath;
    system(command.c_str());
}


class ContentHandler
{
    public:
        void convertLettersToPseudoBinary(char* charArray, char *outbuffer, long size);                
};

void ContentHandler::convertLettersToPseudoBinary(char* charArray, char *outbuffer, long size)
{
    for (char letter = 0; letter <= size; letter++)
    {
        *(outbuffer + letter) = '0' + (*(charArray + letter) % 2);
    }
}


class FileHandler
{
    private:
        std::string path;
        ContentHandler mContentHandler;

        // item 14: prohibit copying - one handler to a file
        FileHandler(const FileHandler &handler);
        FileHandler& operator=(const FileHandler &handler);


    public:
        FileHandler(std::string pathToFile);
        void lettersToPseudoBinary(void);
        void renameFile(std::string newName);
        void moveFile(std::string newPath);
        void deleteFile(void);
        void copyFile(std::string copyPath);
};

FileHandler::FileHandler(std::string pathToFile) : path(pathToFile) 
{ 
    std::cout << pathToFile << std::endl;
}

void FileHandler::lettersToPseudoBinary()
{
    // open the file in read mode in order to read its content
    READ_FILE file;
    file.open(path, READ_FILE::binary);

    // get file size
    file.seekg(0, file.end);
    int filelength = file.tellg();
    file.seekg(0, file.beg);
    
    char *readBuffer = new char[filelength];
    char *convertedBuffer = new char[filelength];

    // read file content into buffer
    file.read(readBuffer, filelength);

    mContentHandler.convertLettersToPseudoBinary(readBuffer, convertedBuffer, filelength);

    // close file in read mode    
    file.close();


    // open the file once again in write mode
    WRITE_FILE outfile;
    outfile.open(path, WRITE_FILE::out | WRITE_FILE::trunc | WRITE_FILE::binary); // clear content

    // write converted text
    outfile.write(convertedBuffer, filelength);

    // close file
    outfile.close();

    // clean the mess
    delete[] readBuffer;
    delete[] convertedBuffer;
}

void FileHandler::renameFile(std::string newName)
{
    //item 13: use objects to manage resources
    std::auto_ptr<SysInterface> pSys (new SysInterface);
    pSys->renameFile(path, newName);
    path = newName;

    //auto_ptr deleted
}

void FileHandler::moveFile(std::string newPath)
{
    //item 13: use objects to manage resources
    std::auto_ptr<SysInterface> pSys (new SysInterface);
    pSys->moveFile(path, newPath);
    path = newPath;

    //auto_ptr deleted
}

void FileHandler::copyFile(std::string copyPath)
{
    //item 13: use objects to manage resources
    std::auto_ptr<SysInterface> pSys (new SysInterface);
    pSys->copyFile(path, copyPath);

    //auto_ptr deleted
}

void FileHandler::deleteFile(void)
{
    //item 13: use objects to manage resources
    std::auto_ptr<SysInterface> pSys (new SysInterface);
    pSys->removeFile(path);

    //auto_ptr deleted
}



int main()
{
    FileHandler myHandler("../assets/test.txt");
    FileHandler myHandler2("../abc.txt");

    // myHandler2 = myHandler;

    myHandler.lettersToPseudoBinary();

    myHandler.renameFile("../assets/renamed.txt");

    myHandler.copyFile("../assets/renamed_copy.txt");
    
    myHandler.moveFile("../assets/moved/renamed.txt");

    //myHandler.deleteFile();

    return 0;
}