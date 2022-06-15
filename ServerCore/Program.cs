using System;
using System.Threading;

namespace ServerCore
{
    class Program
    {
        static void MainThread()
        {
            Console.WriteLine("Hello Thread!");
        }

        static void Main(string[] args)
        {
            Thread t = new Thread(MainThread);
            t.Start();

            Console.WriteLine("Hello World!");
        }
    }
}