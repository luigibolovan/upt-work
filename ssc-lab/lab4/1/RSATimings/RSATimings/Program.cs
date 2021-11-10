using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RSATimings
{
    class Program
    {
        static void Main(string[] args)
        {

            RSACryptosys myCryptoSys1024 = new RSACryptosys();
            RSACryptosys myCryptoSys2048 = new RSACryptosys();
            RSACryptosys myCrpytoSys3072 = new RSACryptosys();
            RSACryptosys myCrpytoSys4096 = new RSACryptosys();
            int count = 100;
            //input for encryption = aes.Key;
            AesManaged aes = new AesManaged();
            aes.GenerateKey();           
            
            string input = "my test string;";
            

            Stopwatch timer1024key = Stopwatch.StartNew();
            for(int i = 0; i < count; i++)
            {
                myCryptoSys1024.create(1024);
            }
            timer1024key.Stop();
            long time1024key = timer1024key.ElapsedTicks / (10 * count);

            Stopwatch timer1024encryption = Stopwatch.StartNew();
            byte[] rsa1024Cipher = new byte[1024];
            for (int i = 0; i < count; i++)
            {
                rsa1024Cipher = myCryptoSys1024.encrypt(aes.Key);
            }
            timer1024encryption.Stop();
            long time1024encrpyt = timer1024encryption.ElapsedTicks / (10 * count);

            Stopwatch timer1024decryption = Stopwatch.StartNew();
            byte[] decrypted1024PlainText = new byte[1024];
            for (int i = 0; i < count; i++)
            {
                decrypted1024PlainText = myCryptoSys1024.decrypt(rsa1024Cipher);
            }
            timer1024decryption.Stop();
            long time1024decrypt = timer1024decryption.ElapsedTicks / (10 * count);

            Stopwatch timer1024sign = Stopwatch.StartNew();
            byte[] signature1024rsa = new byte[1024];
            for (int i = 0; i < count; i++)
            {
                signature1024rsa = myCryptoSys1024.signData(Encoding.ASCII.GetBytes(input));
            }
            timer1024sign.Stop();
            long time1024sign = timer1024sign.ElapsedTicks / (10 * count);

            Stopwatch timer1024verify = Stopwatch.StartNew();
            bool data1024Ok = false;
            for (int i = 0; i < count; i++)
            {
                data1024Ok = myCryptoSys1024.isSignatureOk(Encoding.ASCII.GetBytes(input), signature1024rsa);
            }
            timer1024verify.Stop();
            long time1024verify = timer1024verify.ElapsedTicks / (10 * count);

            Console.WriteLine("RSA - 1024");
            Console.WriteLine("Key generation time: " + time1024key + " ms");
            Console.WriteLine("Message to encrypt: " + getHEXStringFromBytes(aes.Key));
            Console.WriteLine("Encryption time: " + time1024encrpyt + " ms" + "\nCipherText: " + getHEXStringFromBytes(rsa1024Cipher));
            Console.WriteLine("Decryption time: " + time1024decrypt + " ms" + "\nPlain text after decryption: " + getHEXStringFromBytes(decrypted1024PlainText));
            Console.WriteLine("Signature generation time: " + time1024sign + " ms" + "\nSignature: " + getHEXStringFromBytes(signature1024rsa));
            Console.WriteLine("Verification: " + data1024Ok + "\nVerification time: " + time1024verify + " ms");
            Console.WriteLine();



            Stopwatch timer2048key = Stopwatch.StartNew();
            for (int i = 0; i < count; i++)
            {
                myCryptoSys2048.create(2048);
            }
            timer2048key.Stop();
            long time2048key = timer2048key.ElapsedTicks / (10 * count);

            byte[] rsa2048Cipher = new byte[2048];
            Stopwatch timer2048encryption = Stopwatch.StartNew();
            for (int i = 0; i < count; i++)
            {
                rsa2048Cipher = myCryptoSys2048.encrypt(aes.Key);
            }
            timer2048encryption.Stop();
            long time2048encrpyt = timer2048encryption.ElapsedTicks / (10 * count);

            Stopwatch timer2048decryption = Stopwatch.StartNew();
            byte[] decrypted2048PlainText = new byte[2048];
            for (int i = 0; i < count; i++)
            {
                decrypted2048PlainText = myCryptoSys2048.decrypt(rsa2048Cipher);
            }
            timer2048decryption.Stop();
            long time2048decrypt = timer2048decryption.ElapsedTicks / (10 * count);

            Stopwatch timer2048sign = Stopwatch.StartNew();
            byte[] signature2048rsa = new byte[2048];
            for (int i = 0; i < count; i++)
            {
                signature2048rsa = myCryptoSys2048.signData(Encoding.ASCII.GetBytes(input));
            }
            timer2048sign.Stop();
            long time2048sign = timer2048sign.ElapsedTicks / (10 * count);

            Stopwatch timer2048verify = Stopwatch.StartNew();
            bool data2048Ok = false;
            for (int i = 0; i < count; i++)
            {
                data2048Ok = myCryptoSys2048.isSignatureOk(Encoding.ASCII.GetBytes(input), signature2048rsa);
            }
            timer2048verify.Stop();
            long time2048verify = timer2048verify.ElapsedTicks / (10 * count);

            Console.WriteLine();
            Console.WriteLine("RSA - 2048");
            Console.WriteLine("Key generation time: " + time2048key + " ms");
            Console.WriteLine("Message to encrypt: " + getHEXStringFromBytes(aes.Key));
            Console.WriteLine("Encryption time: " + time2048encrpyt + " ms" + "\nCipherText: " + getHEXStringFromBytes(rsa2048Cipher));
            Console.WriteLine("Decryption time: " + time2048decrypt + " ms" + "\nPlain text after decryption: " + getHEXStringFromBytes(decrypted2048PlainText));
            Console.WriteLine("Signature generation time: " + time2048sign + " ms" +  "\nSignature: " + getHEXStringFromBytes(signature2048rsa));
            Console.WriteLine("Verification: " + data2048Ok + "\nVerification time: " + time2048verify + " ms");
            Console.WriteLine();

            Stopwatch timer3072key = Stopwatch.StartNew();
            for (int i = 0; i < count; i++)
            {
                myCrpytoSys3072.create(3072);
            }
            timer3072key.Stop();
            long time3072key = timer3072key.ElapsedTicks / (10 * count);


            Stopwatch timer3072encryption = Stopwatch.StartNew();
            byte[] rsa3072Cipher = new byte[3072];
            for (int i = 0; i < count; i++)
            {
                rsa3072Cipher = myCrpytoSys3072.encrypt(aes.Key);
            }
            timer3072encryption.Stop();
            long time3072encrpyt = timer3072encryption.ElapsedTicks / (10 * count);

            Stopwatch timer3072decryption = Stopwatch.StartNew();
            byte[] decrypted3072PlainText = new byte[3072];
            for (int i = 0; i < count; i++)
            {
                decrypted3072PlainText = myCrpytoSys3072.decrypt(rsa3072Cipher);
            }
            timer3072decryption.Stop();
            long time3072decrypt = timer3072decryption.ElapsedTicks / (10 * count);

            Stopwatch timer3072sign = Stopwatch.StartNew();
            byte[] signature3072rsa = new byte[3072];
            for (int i = 0; i < count; i++)
            {
                signature3072rsa = myCrpytoSys3072.signData(Encoding.ASCII.GetBytes(input));
            }
            timer3072sign.Stop();
            long time3072sign = timer3072sign.ElapsedTicks / (10 * count);

            Stopwatch timer3072verify = Stopwatch.StartNew();
            bool data3072Ok = false;
            for (int i = 0; i < count; i++)
            {
                data3072Ok = myCrpytoSys3072.isSignatureOk(Encoding.ASCII.GetBytes(input), signature3072rsa);
            }
            timer3072verify.Stop();
            long time3072verify = timer3072verify.ElapsedTicks / (10 * count);

            Console.WriteLine();
            Console.WriteLine("RSA - 3072");
            Console.WriteLine("Key generation time: " + time3072key + " ms");
            Console.WriteLine("Message to encrypt: " + getHEXStringFromBytes(aes.Key));
            Console.WriteLine("Encryption time: " + time3072encrpyt + " ms" + "\nCipherText: " + getHEXStringFromBytes(rsa3072Cipher));
            Console.WriteLine("Decryption time: " + time3072decrypt + " ms" + "\nPlain text after decryption: " + getHEXStringFromBytes(decrypted3072PlainText));
            Console.WriteLine("Signature generation time: " + time3072sign + " ms" + "\nSignature: " + getHEXStringFromBytes(signature3072rsa));
            Console.WriteLine("Verification: " + data3072Ok + "\nVerification time: " + time3072verify + " ms");
            Console.WriteLine();

            Stopwatch timer4096key = Stopwatch.StartNew();
            for (int i = 0; i < count; i++)
            {
                myCrpytoSys4096.create(4096);
            }
            timer4096key.Stop();
            long time4096key = timer4096key.ElapsedTicks / (10 * count);

            Stopwatch timer4096encryption = Stopwatch.StartNew();
            byte[] rsa4096Cipher = new byte[4096];
            for (int i = 0; i < count; i++)
            {
                rsa4096Cipher = myCrpytoSys4096.encrypt(aes.Key);
            }
            timer4096encryption.Stop();
            long time4096encrpyt = timer4096encryption.ElapsedTicks / (10 * count);

            Stopwatch timer4096decryption = Stopwatch.StartNew();
            byte[] decrypted4096PlainText = new byte[4096];
            for (int i = 0; i < count; i++)
            {
                decrypted4096PlainText = myCrpytoSys4096.decrypt(rsa4096Cipher);
            }
            timer4096decryption.Stop();
            long time4096decrypt = timer4096decryption.ElapsedTicks / (10 * count);

            Stopwatch timer4096sign = Stopwatch.StartNew();
            byte[] signature4096rsa = new byte[4096];
            for (int i = 0; i < count; i++)
            {
                signature4096rsa = myCrpytoSys4096.signData(Encoding.ASCII.GetBytes(input));
            }
            timer4096sign.Stop();
            long time4096sign = timer4096sign.ElapsedTicks / (10 * count);

            Stopwatch timer4096verify = Stopwatch.StartNew();
            bool data4096Ok = false;
            for (int i = 0; i < count; i++)
            {
                data4096Ok = myCrpytoSys4096.isSignatureOk(Encoding.ASCII.GetBytes(input), signature4096rsa);
            }
            timer4096verify.Stop();
            long time4096verify = timer4096verify.ElapsedTicks / (10 * count);

            Console.WriteLine();
            Console.WriteLine("RSA - 4096");
            Console.WriteLine("Key generation time: " + time4096key + " ms");
            Console.WriteLine("Message to encrypt: " + getHEXStringFromBytes(aes.Key));
            Console.WriteLine("Encryption time: " + time4096encrpyt + " ms" + "\nCipherText: " + getHEXStringFromBytes(rsa4096Cipher));
            Console.WriteLine("Decryption time: " + time4096decrypt + " ms" + "\nPlain text after decryption: " + getHEXStringFromBytes(decrypted4096PlainText));
            Console.WriteLine("Signature generation time: " + time4096sign + " ms" + "\nSignature: " + getHEXStringFromBytes(signature4096rsa));
            Console.WriteLine("Verification: " + data4096Ok + "\nVerification time: " + time4096verify + " ms");
            Console.WriteLine();

            Console.ReadKey();

        }

        private static String getHEXStringFromBytes(byte[] msg)
        {
            return BitConverter.ToString(msg).Replace("-", "");               
        }
    }
}
