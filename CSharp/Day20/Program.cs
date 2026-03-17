using System;
using System.Diagnostics;
using System.Runtime.ConstrainedExecution;

//class Program
//{
//    static void Main()
//    {
//        Process currentProcess = Process.GetCurrentProcess();
//        System.Console.WriteLine("Current Process ID: " + currentProcess.Id);
//        System.Console.WriteLine("Process Name: " + currentProcess.ProcessName);
//    }
//}



//using System;
//using System.Threading;

//class Program
//{
//    static void Main()
//    {
//        // Create a new thread
//        Thread worker = new Thread(DoWork);

//        // Start the thread
//        worker.Start();

//        Console.WriteLine("Main thread continues...");

//        // Optional: Wait for worker thread to finish
//        worker.Join();
//        Console.WriteLine("Main thread finished");
//    }

//    static void DoWork()
//    {
//        for (int i = 1; i <= 5; i++)
//        {
//            Console.WriteLine("Worker thread: " + i);
//            Thread.Sleep(500); // Simulate work
//        }
//    }
//}


//class Program
//{
//    static void Main()
//    {
//        Process.Start("notpad.exe");
//    }
//}


//class Program
//{
//    static int counter = 0;
//    static void Main()
//    {
//        Thread t1 = new Thread(Increment);
//        Thread t2 = new Thread(Increment);

//        t1.Start();
//        t2.Start();
//        t1.Join();
//        t2.Join();
//        Console.WriteLine("Final Counter Value" + counter);
//        static void Increment()
//        {

//            for (int i = 0; i < 100000; i++)
//            {
//                lock (lockObj) ;
//                counter += 1;
//            }
//        }
//    }
//}

using System;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        Task t1 = Task.Run(() => Console.WriteLine("Task 1"));
        Task t2 = Task.Run(() => Console.WriteLine("Task 2"));

        Task.WhenAll(t1, t2)
            .ContinueWith(t => Console.WriteLine("All tasks completed"))
            .Wait();   // ⬅ ensures completion

        Console.WriteLine("Main method finished");
    }
}
