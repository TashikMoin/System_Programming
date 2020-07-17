﻿using System;
using System.Threading;

namespace MultiThreading
{
    class Program
    {
        public static long FirstValue;
        public long SecondValue;
        static void Task_Without_Lock(object ThreadNumber_)
        {
            string ThreadNumber = (string)ThreadNumber_;
            Thread.CurrentThread.Name = "Thread # " + ThreadNumber;
            Console.WriteLine("... {0} Started Execution ... ", Thread.CurrentThread.Name);
            for (long i = 0; i < 10000000; ++i)
            {
                FirstValue++;
                /* 
                 Its Final Value Should Be 3000000 But It Will Give An Incorrect Value Because Multiple Threads Accessing The Same
                 Block Of Code ( Critical SEction At The Same Time ).The Reason Behind The Incorrect Output Is That The Expressions
                 Like Increment Does 2 Operations ( Increment + Assignment ) When We Do FirstValue++; This Means That,
                 FirstValue = FirstValue + 1 ; At This Point Multiple Threads Will Be Executing This Same Statement At The Same
                 Time. Let Suppose FirstValue Variable Has Some Value "500" And There Are 3 Threads Executing This Function Or
                 This Piece Of Code So When FirstThread Will Be Executing It, It Will First Ask The Previous Value Of FirstValue
                 Variable That Is 500 So There Will Be Something Like This Be Happening,
                                       FirstValue = 500 + 1 ; Remember : Assignment Is Not Done Yet.
                 At The Same Time SecondThread & ThirdThread Both Will Do The Same Thing Because The Value Of FirstValue Is Still
                 500 And None Of The Thread Has Done Any Assignment Operations So When Multiple Threads Will Do The Same Assignment
                 Like FirstValue = 500 + 1 ;   -----> FirstValue = 501 Means We Are Assigning The Same Value Multiple Times
                 And That Is The Reason We Are Getting This Incorrect & Unexpected Incremented Value And This Is The Reason We
                 Use Locking To Avoid Other Threads To Enter The Critical Section ( Same Piece Of Code / Same Resources ) To Access
                 At The Same Time
                */
            }
            Console.WriteLine("... {0} Ending Its Execution ... ", Thread.CurrentThread.Name);
        }

        public void Task_With_Lock(object ThreadNumber_)
        {
            string ThreadNumber = (string)ThreadNumber_;
            Thread.CurrentThread.Name = "Thread # " + ThreadNumber;
            Console.WriteLine("... {0} Started Execution ... ", Thread.CurrentThread.Name);
            lock (this)  
            {
                for (long i = 0; i < 10000000; ++i)
                {
                    SecondValue++;
                }
            }
            Console.WriteLine("... {0} Ending Its Execution ... ", Thread.CurrentThread.Name);
        }

        static void Main(string[] args)
        {
            Thread Main = Thread.CurrentThread;
            Console.WriteLine("... {0} Thread Started Its Execution ...", Thread.CurrentThread.Name);
            Thread First = new Thread(Task_Without_Lock);
            Thread Second = new Thread(Task_Without_Lock);
            Thread Third = new Thread(Task_Without_Lock);
            First.Start("1");
            Second.Start("2");
            Third.Start("3");
            First.Join();
            Second.Join();
            Third.Join();
            Console.WriteLine("First Value Without Using Lock : {0} [ Computational Errors ] ", FirstValue);
            Program Obj = new Program();
            Thread Fourth = new Thread(Obj.Task_With_Lock);
            Thread Fifth = new Thread(Obj.Task_With_Lock);
            Thread Sixth = new Thread(Obj.Task_With_Lock);
            Fourth.Start();
            Fifth.Start();
            Sixth.Start();
            Fourth.Join();
            Fifth.Join();
            Sixth.Join();
            Console.WriteLine("Second Value With Locking : {0} [ No Computational Errors ]", Obj.SecondValue);
            Console.WriteLine("... Main Thread Has Done It's Work ...");

        }
    }
}
