﻿using System;
using System.Threading;
using System.Diagnostics;
using System.Runtime.ExceptionServices;
using System.Runtime.CompilerServices;

namespace MultiThreading
{
    class Thread_Priority
    {
        public Thread_Priority()
        {}
        public void Task()
        {
            Stopwatch Time = new Stopwatch();
            Time.Start();
            for( long i = 0; i < 10000000000 ; ++i )
            {
                /* Some Code */
            }
            Time.Stop();
            Console.WriteLine("... {0} With Priority Level {1} Took {2} MiliSeconds To Execute The Same Function ...", Thread.CurrentThread.Name, Thread.CurrentThread.Priority, Time.ElapsedMilliseconds);
        }
        static void Main(string[] args)
        {
            Console.WriteLine("... Please Wait ...");
            Thread_Priority Obj = new Thread_Priority();
            Thread First = new Thread(Obj.Task);
            First.Name = " Thread # 1 ";
            First.Priority = ThreadPriority.Lowest;
            Thread Second = new Thread(Obj.Task);
            Second.Name = " Thread # 2 ";
            Second.Priority = ThreadPriority.BelowNormal;
            Thread Third = new Thread(Obj.Task);
            Third.Name = " Thread # 3 ";
            Third.Priority = ThreadPriority.Normal;
            Thread Fourth = new Thread(Obj.Task);
            Fourth.Name = " Thread # 4 ";
            Fourth.Priority = ThreadPriority.AboveNormal;
            Thread Fifth = new Thread(Obj.Task);
            Fifth.Name = " Thread # 5 ";
            Fifth.Priority = ThreadPriority.Highest;

            First.Start();
            Second.Start();
            Third.Start();
            Fourth.Start();
            Fifth.Start();

            First.Join();
            Second.Join();
            Third.Join();
            Fourth.Join();
            Fifth.Join();
            

            
        }
    }
}
