using System;
using System.Threading;

namespace MultiThreading
{
    class Program
    {
        static void Task1()
        {
            Thread.CurrentThread.Name = "Thread # 1";
            Console.WriteLine("Current Thread Name : {0} ", Thread.CurrentThread.Name);
            for (int i = 0; i < 20; ++i)
            {
                Console.WriteLine("... Performing Task1 ...");
                Thread.Sleep(3000); // Used For Current Thread Sleep
            }

            Console.WriteLine("... Thread1 Has Done It's Work ...");
        }

        static void Task2()
        {
            Thread.CurrentThread.Name = "Thread # 2";
            Console.WriteLine("Current Thread Name : {0} ", Thread.CurrentThread.Name);
            for (int i = 0; i < 20; ++i)
            {
                Console.WriteLine("... Performing Task2 ...");
                Thread.Sleep(1500); // Used For Current Thread Sleep
            }
            Console.WriteLine("... Thread2 Has Done It's Work ...");
        }

        static void Task3()
        {
            Thread.CurrentThread.Name = "Thread # 3";
            Console.WriteLine("Current Thread Name : {0} ", Thread.CurrentThread.Name);
            for (int i = 0; i < 20; ++i)
            {
                Console.WriteLine("... Performing Task3 ...");
                Thread.Sleep(1000); // Used For Current Thread Sleep
            }
            Console.WriteLine("... Thread3 Has Done It's Work ...");
        }
        static void Main(string[] args)
        {
            Thread Main = Thread.CurrentThread;
            /* Thread.CurrentThread Property Returns The Reference Of Current Thread.Here We Are Storing Reference Of Current 
               Thread In Our Newly Created Thread Reference Variable. */
            Main.Name = "Main Thread"; // Equivalent Statement -> Thread.CurrentThread.Name = "Main Thread";
            Console.WriteLine("Current Thread Name : {0} ", Thread.CurrentThread.Name);
            Thread Thread_For_Task1 = new Thread(Task1);
            Thread Thread_For_Task2 = new Thread(Task2);
            Thread Thread_For_Task3 = new Thread(Task3);
            /* Creating 3 Threads For 3 Different Tasks */
            Thread_For_Task1.Start();
            Thread_For_Task2.Start();
            Thread_For_Task3.Start();
            if(Thread_For_Task1.IsAlive) // Property To Check Whether A Thread Has Done It's Work Or Not.
            {
                Console.WriteLine("Thread#1 Still Doing Its Work");
            }
            Console.WriteLine("... Main Thread Has Done It's Work ...");
            /* In C# Even If The Main Thread Has Done It's Work, The Remaining Threads Will Still Have An Active Status
            And They Will Be Doing Their Work */
            /* 
               If We Want Main Thread To Finish It's Execution At Last Then We Use Join Method For Every Thread Created
               By Main Thread.
               Example :-
               ThreadX.Start() ;
               // Main Thread Doing Some Work
               ThreadX.Join() ; // Calling Join Method So That Main Thread Will Wait Here Until ThreadX Completes It's Execution.
            if(!Thread_For_Task1.IsAlive)
            {
                Console.WriteLine("Thread#1 Now Has Finished Its Work");
            }
               Console.WriteLine("Main Thread Exiting") ; // This Will Execute After ThreadX Completes It's Execution.
            */


        }
    }
}
