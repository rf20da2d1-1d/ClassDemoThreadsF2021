using System;

namespace ClassDemoThreads
{
    class Program
    {
        static void Main(string[] args)
        {
            ThreadsWorker worker = new ThreadsWorker();
            worker.Start();


            Console.ReadLine();
            Console.WriteLine("End of story");
        }
    }
}
