using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices.ComTypes;
using System.Threading;
using System.Threading.Tasks;

namespace ClassDemoThreads
{
    internal class ThreadsWorker
    {
        public ThreadsWorker()
        {
        }

        public void Start()
        {

            DemoThreads();
            //DemoTask();
            //DemoParallel();
            //DemoAsyncAwait();

            Console.WriteLine("slut");
        }

        private void DemoAsyncAwait()
        {
            Task<List<String>> task = GetTekstAsync();
            bool b = task.IsCompleted;
            if (!b) Console.WriteLine("venter på resultat");
            foreach (string s in task.Result)
            {
                Console.WriteLine(s);
            }
        }

        private void DemoParallel()
        {
            Parallel.For(1, 5, (i) => Udskriv("Parallel " + i));

            for (int i = 1; i < 5; i++)
            {
                Console.WriteLine(i);
            }
        }

        private void DemoTask()
        {
            Task t1 = Task.Run(() => Udskriv("Task 1"));
            Task t2 = Task.Run(() => Udskriv("Task 2"));
            Task t3 = Task.Run(() => Udskriv("Task 3"));

        }

        private void DemoThreads()
        {
            Thread t1 = new Thread(() => Udskriv("Thread" + 1));
            Thread t2 = new Thread(() => Udskriv("Thread" + 2));
            Thread t3 = new Thread(() => Udskriv("Thread" + 3));

            t1.Start(); 
            t2.Start(); 
            t3.Start();

            t1.Join();
        }



        private void Udskriv(String header)
        {
            for (int i = 0; i < 30; i++)
            {
                Console.WriteLine($"{header}: {i}");
            }
        }

        private async Task<List<String>> GetTekstAsync()
        {
            List<String> liste = new List<string>();
            StreamReader reader = new StreamReader(File.OpenRead(@"M:\intpub\AsyncDemo.txt"));

            while (!reader.EndOfStream)
            {
                liste.Add(await reader.ReadLineAsync());
            }
            Thread.Sleep(100);
            return liste;
        } 
    }
}