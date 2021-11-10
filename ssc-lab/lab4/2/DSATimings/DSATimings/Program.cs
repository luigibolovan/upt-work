using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DSATimings
{
    class Program
    {
        static void Main(string[] args)
        {
            MyDSA DSA1024 = new MyDSA();
            MyDSA DSA640 = new MyDSA();
            MyDSA DSA768 = new MyDSA();
            MyDSA DSA512 = new MyDSA();
            int count = 100;

            string input = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, " +
                           "sed do eiusmod tempor incididunt ut labore et dolore magna aliqua";


            Stopwatch timer1024key = Stopwatch.StartNew();
            for (int i = 0; i < count; i++)
            {
                DSA1024.create(1024);
            }
            timer1024key.Stop();
            long key1024time = timer1024key.ElapsedTicks / (10 * count);

            Stopwatch timer1024sign = Stopwatch.StartNew();
            byte[] signature1024 = new byte[1024];
            for (int i = 0; i < count; i++)
            {
                signature1024 = DSA1024.signData(Encoding.ASCII.GetBytes(input));
            }
            timer1024sign.Stop();
            long sign1024time = timer1024sign.ElapsedTicks / (10 * count);

            Stopwatch timer1024verify = Stopwatch.StartNew();
            bool data1024OK = false;
            for (int i = 0; i < count; i++)
            {
                data1024OK = DSA1024.isSignatureOk(Encoding.ASCII.GetBytes(input), signature1024);
            }
            timer1024verify.Stop();
            long verify1024time = timer1024verify.ElapsedTicks / (10 * count);

            Console.WriteLine();
            Console.WriteLine("DSA 1024");
            Console.WriteLine("Key generation time:" + key1024time + " ms");
            Console.WriteLine("Signing time: " + sign1024time + " ms");
            Console.WriteLine("Verification time: " + verify1024time + " ms");
            Console.WriteLine("Verification: " + data1024OK);

            Stopwatch timer640key = Stopwatch.StartNew();
            for (int i = 0; i < count; i++)
            {
                DSA640.create(640);
            }
            timer640key.Stop();
            long key640time = timer640key.ElapsedTicks / (10 * count);

            Stopwatch timer640sign = Stopwatch.StartNew();

            byte[] signature640 = new byte[640];
            for (int i = 0; i < count; i++)
            {
                signature640 = DSA640.signData(Encoding.ASCII.GetBytes(input));
            }
            timer640sign.Stop();
            long sign640time = timer640sign.ElapsedTicks / (10 * count);

            Stopwatch timer640verify = Stopwatch.StartNew();
            bool data640OK = false;
            for (int i = 0; i < count; i++)
            {
                data640OK = DSA640.isSignatureOk(Encoding.ASCII.GetBytes(input), signature640);
            }
            timer640verify.Stop();
            long verify640time = timer640verify.ElapsedTicks / (10 * count);

            Console.WriteLine();
            Console.WriteLine("DSA 640");
            Console.WriteLine("Key generation time:" + key640time + " ms");
            Console.WriteLine("Signing time: " + sign640time + " ms");
            Console.WriteLine("Verification time: " + verify640time + " ms");
            Console.WriteLine("Verification: " + data640OK);


            Stopwatch timer768key = Stopwatch.StartNew();
            for (int i = 0; i < count; i++)
            {
                DSA768.create(768);
            }
            timer768key.Stop();
            long key768time = timer768key.ElapsedTicks / (10 * count);

            Stopwatch timer678sign = Stopwatch.StartNew();
            byte[] signature768 = new byte[768];
            for (int i = 0; i < count; i++)
            {
                signature768 = DSA768.signData(Encoding.ASCII.GetBytes(input));
            }
            timer678sign.Stop();
            long sign768time = timer678sign.ElapsedTicks / (10 * count);

            Stopwatch timer768verify = Stopwatch.StartNew();
            bool data768OK = false;
            for (int i = 0; i < count; i++)
            {
                data768OK = DSA768.isSignatureOk(Encoding.ASCII.GetBytes(input), signature768);
            }
            timer768verify.Stop();
            long verify768time = timer768verify.ElapsedTicks / (10 * count);


            Console.WriteLine();
            Console.WriteLine("DSA 768");
            Console.WriteLine("Key generation time:" + key768time + " ms");
            Console.WriteLine("Signing time: " + sign768time + " ms");
            Console.WriteLine("Verification time: " + verify768time + " ms");
            Console.WriteLine("Verification: " + data768OK);


            Stopwatch timer512key = Stopwatch.StartNew();
            for (int i = 0; i < count; i++)
            {
                DSA512.create(512);
            }
            timer512key.Stop();
            long key512time = timer512key.ElapsedTicks / (10 * count);

            Stopwatch timer512sign = Stopwatch.StartNew();
            byte[] signature512 = new byte[512];
            for (int i = 0; i < count; i++)
            {
               signature512 = DSA512.signData(Encoding.ASCII.GetBytes(input));
            }
            timer512sign.Stop();
            long sign512time = timer512sign.ElapsedTicks / (10 * count);

            Stopwatch timer512verify = Stopwatch.StartNew();
            bool data512OK = false;
            for (int i = 0; i < count; i++)
            {
                data512OK = DSA512.isSignatureOk(Encoding.ASCII.GetBytes(input), signature512);
            }
            timer512verify.Stop();
            long verify512time = timer512verify.ElapsedTicks / (10 * count);

            Console.WriteLine();
            Console.WriteLine("DSA 512");
            Console.WriteLine("Key generation time:" + key512time + " ms");
            Console.WriteLine("Signing time: " + sign512time + " ms");
            Console.WriteLine("Verification time: " + verify512time + " ms");
            Console.WriteLine("Verification: " + data512OK);


            Console.ReadKey();
        }
    }
}
