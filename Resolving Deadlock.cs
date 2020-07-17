﻿using System;
using System.Threading;

namespace MultiThreading
{
    class Resource
    {
        public int Id;
        public Resource(int Id_)
        {
            Id = Id_;
        }
    }
    class Manage
    {
        public Resource First_Resource;

        public Manage(Resource Resource_)
        {
            this.First_Resource = Resource_;
        }
        public void Deadlock(object Second_Account_)
        {
            object lockA; // Because locks are allowed only on object types.
            object lockB;
            Resource Second_Resource = (Resource)Second_Account_;
            if (this.First_Resource.Id < Second_Resource.Id)
            {
                lockA = this.First_Resource; lockB = Second_Resource;
            }
            else
            {
                lockA = Second_Resource; lockB = this.First_Resource;
            }

            /* 
               On The Basis Of Some Conditions & Objects LockA & LockB, We Are Here Saying That If The FirstResource's Id Is <
               then The Second Resource Id The LockA Will Be On FirstResource & LockB Will Be On SecondResource But If 
               FirstResource's Id Is > ( It Will Definitely Occur In The Second Threads Case ) Then LockA Will Be SecondResource
               & LockB Will Be FirstResource Due To Which It Will Stop The Thread2 To Even Enter the First Lock Until The 
               FirstThread Does Not Release The Required FirstResource And When It Releases The Required Resource The SecondThread Will
               Enter The FirstLock and Then Enter The Second Lock And Do It's Work & Then Exit.
            */

            Console.WriteLine("Thread Reaches Before The First Lock");
            lock (lockA)
            {
                Console.WriteLine("... Thread Doing Some Work ...");
                Thread.Sleep(7000);
                lock (lockB)
                {
                    Console.WriteLine(" ... Thread Has Done It's Work ...");
                }
            }

        }




        static void Main(string[] args)
        {
            Console.WriteLine("... Main Thread Starting Its Execution ...");
            Resource First_Resource = new Resource(1);
            Resource Second_Resource = new Resource(2);
            Manage Obj1 = new Manage(First_Resource);
            Manage Obj2 = new Manage(Second_Resource);
            Thread First = new Thread(Obj1.Deadlock);
            Thread Second = new Thread(Obj2.Deadlock);
            First.Start(Obj2.First_Resource);
            Second.Start(Obj1.First_Resource);
            // Passing Required Resources
            First.Join();
            Second.Join();
            Console.WriteLine("... Main Thread Ending Its Execution ..."); // This Will Now Execute.
        }
    }
}
