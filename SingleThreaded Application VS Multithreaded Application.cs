﻿using System;
using System.Diagnostics;
using System.Threading;

namespace MultiThreading
{
    class Program
    {
        static void Task1()
        {
            for (long i = 0; i < 1000000000; ++i)
            { /* Some Work */ }
        }

        static void Task2()
        {
            for (long i = 0; i < 1000000000; ++i)
            { /* Some Work */ }
        }

        static void Task3()
        {
            for (long i = 0; i < 1000000000; ++i)
            { /* Some Work */ }
        }
        static void Main(string[] args)
        {
            Stopwatch SingleThreadedTime = new Stopwatch();
            SingleThreadedTime.Start();
            Task1();
            Task2();
            Task3();
            SingleThreadedTime.Stop();
            Console.WriteLine("Single Threaded Application Time Consumption : {0} ", SingleThreadedTime.ElapsedMilliseconds);
            Stopwatch MultiThreadedTime = new Stopwatch();
            MultiThreadedTime.Start();
            Thread First = new Thread(Task1);
            Thread Second = new Thread(Task2);
            Thread Third = new Thread(Task3);
            First.Start();
            Second.Start();
            Third.Start();
            First.Join();
            Second.Join();
            Third.Join();
            MultiThreadedTime.Stop();
            Console.WriteLine("Multi Threaded Application Time Consumption : {0} ", MultiThreadedTime.ElapsedMilliseconds);
        }
    }
}
