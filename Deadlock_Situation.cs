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
        /* 
           Creating First_Resource Here Because In Threads We Can Either Pass Single Arguments Or We Can Pass Arrays, Collections etc
           But We Can Not Pass Multiple Arguments In Threads At The Same Time That Is Why Assuming That Manage Resource Already
           Has Access To The From Resource. In Simple Words, Assume That Our Thread Got Both From/To Resources In Thread Function
           To Work.
        */

        public Manage(Resource Account_)
        {
            this.First_Resource = Account_;
        }
        public void Deadlock(object Second_Account_)
        {
            Resource Second_Resource = (Resource)Second_Account_; // Object To Resource Conversion
            lock (this.First_Resource)
            // Means First Process Is Using It's Resources Already & They Are Now Locked And Can Not Be Given/Assigned To Other Threads.
            {
                Console.WriteLine("... Thread Started Sleeping ...");
                Thread.Sleep(5000);
                Console.WriteLine("... Thread Woke Up ...");
                lock (Second_Resource)
                /* 
                  We Can Not Enter Inside This Lock Because Both The Threads Has Locked Their Resources And These Resources 
                  Are In Use With Their Respective Threads Under A Lock That Is Why Here The Deadlock Arises Because Thread1 
                  Needs A Resource From Thread2 & Thread2 Needs A Resource From Thread1 Both Have Locked Their Resources And 
                  Waiting For Each Other To Release These Resources But These Resources Can Not Be Released Until A Thread 
                  Completes It's Execution But Here We Can See Both Threads Are Waiting For Each Other To Complete Their 
                  Execution & Hence The Deadlock Occurs.
                */
                {
                    Console.WriteLine(" ... Control Reaches Inside Second Lock ...");
                }
            }

        }




        static void Main(string[] args)
        {
            Console.WriteLine("... Main Thread Starting Its Execution ...");
            Resource First_Resource = new Resource(1);
            Resource Second_Resource = new Resource(2);
            Manage Obj1 = new Manage(First_Resource); // Passing First_Resource To Manage Class's First Obj To Manage It.
            Manage Obj2 = new Manage(Second_Resource); // Passing Second_Resource To Manage Class's Second Obj To Manage It.
            Thread First = new Thread(Obj1.Deadlock);
            Thread Second = new Thread(Obj2.Deadlock);
            First.Start(Obj2.First_Resource); // Obj2's From Resource == Second_Resource For Manage Obj1.
            Second.Start(Obj1.First_Resource); // Obj1's From Resource == Second_Resource For Manage Obj2.
            // Passing Required Resources
            First.Join();
            Second.Join();
            Console.WriteLine("... Main Thread Ending Its Execution ..."); // This Will Never Be Executed Because Of The Deadlock
        }
    }
}
