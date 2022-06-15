using System;
using System.Threading;

namespace ServerCore
{
    class Program
    {
        static void MainThread()
        {
            while (true)
            {
                Console.WriteLine("Hello Thread!");
            }
        }

        static void Main(string[] args)
        {
            Thread t = new Thread(MainThread);
            t.Name = "Test Thread";
            t.IsBackground = true;
            t.Start();
            Console.WriteLine("Waiting for Thread!");

            t.Join();
            Console.WriteLine("Hello World!");
        }
    }
}