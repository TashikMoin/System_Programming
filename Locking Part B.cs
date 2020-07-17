﻿using System;
using System.Threading;

namespace MultiThreading
{
    class Program
    {
        static void Task_Without_Lock(object Name_)
        {
            string Name = (string)Name_;
            Console.Write("Name : ");
            Thread.Sleep(5000);
            Console.WriteLine("{0} ", Name);
        }
        void Task_With_Lock(object Name_)
        {
            string Name = (string)Name_;
            lock (this) // Critical Section
            /* Lock(this) means, lock that object by which this method is called to be executed. We can lock also lock
               other objects too. For E.g lock( Name ) { } */
            {
                Console.Write("Name : ");
                Thread.Sleep(5000);
                Console.WriteLine("{0} ", Name);
            }

            /* We can also have nested lock blocks
               for e.g,
                 lock(X)
                 {
                     lock(Y)
                     {}
                 }
            */
        }




        static void Main(string[] args)
        {
            Console.WriteLine("Executing Without Lock");
            Thread First = new Thread(Task_Without_Lock);
            Thread Second = new Thread(Task_Without_Lock);
            Thread Third = new Thread(Task_Without_Lock);
            First.Start("John");
            Second.Start("George");
            Third.Start("Jack");
            First.Join();
            Second.Join();
            Third.Join();
            Program Obj = new Program();
            Thread Fourth = new Thread(Obj.Task_With_Lock);
            Thread Fifth = new Thread(Obj.Task_With_Lock);
            Thread Sixth = new Thread(Obj.Task_With_Lock);
            Console.WriteLine("\n\nExecuting With Lock");
            Fourth.Start("John");
            Fifth.Start("George");
            Sixth.Start("Jack");
            Fourth.Join();
            Fifth.Join();
            Sixth.Join();
        }
    }
}
