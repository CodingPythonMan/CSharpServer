using System;
using System.Threading;
using System.Threading.Tasks;

namespace ServerCore
{ 
    class Program
    {
        static ThreadLocal<string> ThreadName = new ThreadLocal<string>();
        
        static void WhoAmI()
        {
            ThreadName.Value = $"My Name is {Thread.CurrentThread.ManagedThreadId}";

            Thread.Sleep(1000);

            Console.WriteLine(ThreadName.Value);
        }

        static void Main(string[] args)
        {
            Parallel.Invoke(WhoAmI, WhoAmI, WhoAmI, WhoAmI, WhoAmI, WhoAmI, WhoAmI, WhoAmI);
        }
    }
}