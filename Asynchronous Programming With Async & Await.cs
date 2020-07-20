﻿using System;
using System.Threading;
using System.Threading.Tasks;

namespace MultiThreading
{
    class Program
    {

        static async void MakeTea()
        {
            // Note : Async Methods Can Only Have Void , Task , Task<T> As Their Return Types.
            /* Code Before Await Is Executed By The Caller Thread & The Code After The Await KeyWord Is Executed By A Newly
               Created Worker Thread By The Compiler. The Caller/Main Thread Goes Back To The Place From Where It Calls This Task
               And Executes The Remaining Code Of It .
            */
            Console.WriteLine("... Started Preparing Tea With Thread Id : {0} ", Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("... Adding Sugar,Tea Powder In Milk With Thread Id : {0} ...\n\n", Thread.CurrentThread.ManagedThreadId);
            await Task.Delay(3000);
            Console.WriteLine("... Waiting For Tea To Get Ready With Thread Id : {0} ...", Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(5000);
            Console.WriteLine("... Tea Is Ready With Thread Id : {0} ...", Thread.CurrentThread.ManagedThreadId);
        }

        static async void MakeEggs()
        {
            // Note : Async Methods Can Only Have Void , Task , Task<T> As Their Return Types.
            /* Code Before Await Is Executed By The Caller Thread & The Code After The Await KeyWord Is Executed By A Newly
               Created Worker Thread By The Compiler. The Caller/Main Thread Goes Back To The Place From Where It Calls This Task
               And Executes The Remaining Code Of It .
            */
            Console.WriteLine("... Started Preparing Eggs With Thread Id : {0} ", Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("... Adding Oil & Waiting For It To Become Hot With Thread Id : {0} ...", Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("... Adding Eggs To Fry With Thread Id : {0} ...", Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("... Adding Salt & Blackpepper With Thread Id : {0} ...\n\n", Thread.CurrentThread.ManagedThreadId);
            await Task.Delay(3000);
            Console.WriteLine("... Waiting For Eggs To Get Ready With Thread Id : {0} ...", Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(3000);
            Console.WriteLine("... Eggs Are Ready With Thread Id : {0} ...", Thread.CurrentThread.ManagedThreadId);
        }
        static async void MakeJuice()
        {
            // Note : Async Methods Can Only Have Void , Task , Task<T> As Their Return Types.
            /* Code Before Await Is Executed By The Caller Thread & The Code After The Await KeyWord Is Executed By A Newly
               Created Worker Thread By The Compiler. The Caller/Main Thread Goes Back To The Place From Where It Calls This Task
               And Executes The Remaining Code Of It .
            */
            Console.WriteLine("... Started Preparing Juice With Thread Id : {0} ", Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("... Adding Milk,Fruits In Juicer With Thread Id : {0} ...\n\n", Thread.CurrentThread.ManagedThreadId);
            await Task.Delay(3000);
            Console.WriteLine("... Waiting For Juicer To Make Juice With Thread Id : {0} ...", Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(4000);
            Console.WriteLine("... Juice Is Ready With Thread Id : {0} ...", Thread.CurrentThread.ManagedThreadId);
        }


        static void Main(string[] args)
        {
            /* Creating Breakfast Asynchronously To Avoid Blocking Time */
            Console.WriteLine("... Started Making Breakfast With The Main Thread With Thread Id : {0} ...", Thread.CurrentThread.ManagedThreadId);
            MakeTea();
            MakeEggs();
            MakeJuice();
            /*  Note : In Synchronous Code We Can Not Avoid Blocking Because The Code Is Executed Sequentially. But Here In
            Asynchronous, All The Tasks Are Started By The Main Thread But During The Process If Any Task Requires Any Extra Time To 
            Complete, For e.g Here When We Were Preparing Tea, After Adding Sugar,Tea Power,Water & Milk , The Tea Needs To Be 
            Cooked For Some Time & We Do Not Want To Wait/Block App Here We Want To Utilize This Time So We Called Await Here So 
            That The Remaining Tea Can Be Cooked On A Separate Thread. The Await Keyword Creates A Worker Thread That Performs 
            The Remaining Task And Sends The Main Thread Back To Execute Or To Perform/Execute Other Code/Tasks In The 
            Main/CallingFunction. We( The Main Thread ) Can Start Other Work/Task While Our Tea Is Being Prepared. That Is 
            How We Do Asynchronous Execution Of Our Code. The Main Difference Between Creating Threads And Async Is That In 
            Threads We Start Every Work With A Separate Thread But Here We Started Everything With The Main Thread But When 
            The Task Needs To Wait For Sometime We Left It For Another Thread And We Started Another Task.. So That We Can 
            Do Asynchronous Execution Of Our Code. In Async Methods, The Statements Written Before The Await Keyword Are Run By 
            The Calling Thread Of The Task And The Statements After Await Are Executed By A Newly Created Worker Thread That 
            Handles The Remaining Task Itself.
            */

            Thread.Sleep(20000);
            /* Sleeping The Main Thread Because It Is Free & It May Run Other Statements Without The Completion Of The Breakfast
            And Our Program May End Its Execution */
            Console.WriteLine("... Breakfast Is Ready With Thread Id : {0} ...", Thread.CurrentThread.ManagedThreadId);
        }
    }
}
