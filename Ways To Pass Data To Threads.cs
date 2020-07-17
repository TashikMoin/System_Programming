﻿using System;
using System.Threading;

namespace MultiThreading
{
    class Program
    {
        static void Task_With_No_Arguments()
        {
            for (long i = 0; i < 1000000000; ++i)
            { /* Some Work */ }
        }

        static void Task_With_Arguments(object x)
        {
            int Arg = Convert.ToInt32(x); // Use Convert Methods Or Directly Cast Like This --> (int)x; 
            Console.WriteLine(Arg);
            for (long i = 0; i < 1000000000; ++i)
            { /* Some Work */ }
        }
        static void Main(string[] args)
        {
            // Passing Data To Threads
            ThreadStart Function_Deligate_No_Args = new ThreadStart(Task_With_No_Arguments);
            ParameterizedThreadStart Function_Deligate_With_Args = new ParameterizedThreadStart(Task_With_Arguments);
            ParameterizedThreadStart Function_Deligate = delegate (object str) { Task_With_Arguments(str); };
            // Note : ParameterizedThreadStart allows only 1 parameter. This one parameter can be an array,collection etc
            /*
             
               Equivalent Statements Of Above Two Statements

            ThreadStart / ParameterizedThreadStart Function_Deligate = new ThreadStart/ParameterizedThreadStart(Task_With_OR_Without_Arguments);
                              OR
            ThreadStart / Parameterized Function_Deligate = Task_With_No_Arguments / Task_With_Arguments ;
                              OR
            ThreadStart Function_Deligate = delegate() { Task_With_No_Arguments(); } ;
                              OR
            ParameterizedThreadStart Function_Deligate = delegate(object str) { Task_With_Arguments(str); };
                              OR
            ThreadStart Function_Deligate_No_Args = () => Task_With_No_Arguments();
                              OR
            ParameterizedThreadStart Function_Deligate_With_Args = (object str) => Task_With_Arguments(str);
                              OR
            ThreadStart  Function_Deligate_With_No_Args = () => { // Function Code // } ;
                              OR
            ParameterizedThreadStart Function_Deligate_With_Args_ = (object str) =>
            { string s = Convert.ToString(str); Console.WriteLine(str); };


            */

            /* In ParameterizedThreadStart Deligate, The Parameter Should Be Of Object Type. We Have To Explicitly Cast The Object
               Type Into Our Required Type Inside The Function Body 
            */
            Thread First = new Thread(Function_Deligate_No_Args);
            Thread Second = new Thread(Task_With_No_Arguments);
            Thread Third = new Thread(Function_Deligate_With_Args);
            Thread Fourth = new Thread(Task_With_Arguments);
            /* 
               The Thread Constructor Requires A Delegate. When We Provide Function Names To This Constructor, A Delegate Is 
               Created By The CLR At Backend For Us That Matches With The Signature Of Our Method. If Our Method Has Any Parameters,
               Then The CLR Will Create A ParameterizedThreadStart Delegate Similar To The Delegate That We Are Passing To "Third"
               Thread Constructor And If Our Method Has No Parameters Then It Will Create A ThreadStart Delegate Similar To The 
               Delegate That We Are Passing In First Thread Constructor As An Argument 
            */
            First.Start();
            Second.Start(); // The Arguments Are Sent At The Time Of Starting Thread.
            Third.Start(10);
            Fourth.Start(10); // The Arguments Are Sent At The Time Of Starting Thread.
            /*
            Thread First = new Thread(Function_Deligate) ;
            */
        }
    }
}
