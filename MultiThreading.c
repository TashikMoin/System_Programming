#include <pthread.h>
#include <stdio.h>
#include <stdlib.h>
#include <sys/types.h>
#include <unistd.h>

void *Thread_Task(void *__args) 
/* Creating A Function That Will Be Running Concurrently With The Main Function. We Are Creating
This Function So That It Can Be Run By Another Thread And The Main Thread Will Be Executing Main 
Function.  */
{
    while(1)
    {
        printf(".....Another Thread Executing Its Task..... \n") ;
        sleep(1);
    }
}
/* To Run This Code We Have To Link A Dynamic Library And We Have To Run Following Command,
   gcc MultiThreading.c -o MultiThreading -lpthread                */
int main(int argc, char const *argv[]) 
{
    /* Main Thread Executing The Main Function */
    pthread_t Thread_ID ; // Creating A New Thread
    pthread_create( &Thread_ID, NULL, Thread_Task, NULL ) ; 
    /* Binding The New Thread With The Function That Will Be Executed By This Thread. The First
    Argument Inside The pthread_create Function Is Thread Id ( It Should Be The Id Of That Thread 
    Who Will Be Running This Function Concurrently With The Main Thread ). The Second Argument 
    Will Be The Attributes, The Third Argument Is The Name Of The Function That Will Be Running
    By This Thread & The Last & Fourth Argument Is The Argument Values That The Function Takes
    In This Case It Is NULL Because Our Function Expects No Arguments So We Are Sending NULL
    So That The Void Pointer Can Receive It If We Would've To Send Integers,Float Then We Would
    Have Sent Their References To The Void Pointers So That the Functions Can Receive Values.*/

    /* After pthread_create function Is Called The Newly Created Thread Starts Its Execution
    Concurrently With The Main Thread But If The Main Thread Finishes It's Execution Before
    The Newly Created Thread Then Our Entire Program Will Terminate So In Order To Tell The
    Main thread That You Should Wait Until Threads Complete Their Execution Then In Order To
    Tell This To The Main Thread We Use pthread_join function */

    // pthread_join(Thread_ID , NULL); 

    /* For Now Commenting It In Order To Prove That The Execution Of the Thread Is Already 
    Started After The Create Method Is Called & The Function Is Binded With The Thread We Will
    Make Our Main Method Bigger So That It Will End Whenever We Want So We Will Take An Input 
    Here So That We Can See The Output From Newly Created Thread */

    while(1)
    {
        printf(".....Main Thread Executing Its Task..... \n") ;
        sleep(1);
    }
    return 0;
    /* Press Ctrl + C To Terminate The Program */
}