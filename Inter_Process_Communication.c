#include<stdio.h>
#include<unistd.h>
#include<wait.h>
#include<stdlib.h>
#include <sys/types.h>

int main()
{
    int FileDescripter[2] ;
    /* Since Both The Processes, Parent & Child Will Have Their Own Copy Of Data, And If
    We Change Values In 1 Process Data, It Will Not Effect The Data Of Other Process Because
    Both Have Different Data,Files & Stacks.Now We Want To Communicate Or We Want To Pass
    Some Data Or Information From 1 Process To Another Then We Use Pipes For This Type Of 
    Communication Between The Processes. We Made A FileDescripter Of Length 2. The [0] 
    Subscript Represents Writing/Sending Data From 1 Process To Another Process Through The 
    Pipe & [1] Subscript Represents Reading/Receiving Means Accepting The Data Which Was 
    Sent By Other Process Earlier */
    pipe(FileDescripter) ; // Creating A Pipe With Declared FileDescripter
    pid_t Id ; 
    Id = fork() ; 
    /* We Now Have 2 Processes Running Concurrently With Different Process IDs And We
    Now Want To Send Some Information/Data From 1 Process To Another So Let Suppose We
    Did Some Computation In Child Process And The Parent Is Dependant Of That Computation
    So We Waited Until Child Completes It's Computation With Wait(NULL) So That Parent Should
    Wait Until Child Completes That Computation And When The Computation Is Done By Child
    We Want To Send It To The Parent Process So We Have To Use Write System Call With 
    FileDescripter[0] Means Writing/Sending Data/Information From Child To Parent Process And
    Similarly We Will Be Using Read System Call To Receive That Data OR To Read That Data 
    In A Variable That Was Sent By Other Process. We Can Also Send Data From PArent Process To
    Child Process But There Can Be Computational Erros Because Both The Processes Are Running
    Concurrently And We Can't Wait For Parent Process Within The Child Process Scope That Is
    Why When Sending Message/Data From Parent To Child We Have To Make Sure Things Like
    These Do Not Happen */

    if( Id == 0 ) 
    {
        // Child Process Scope
        float Circumference, Radius = 2.5 ;
        Circumference = 2*(3.14)*Radius ;
        write(FileDescripter[1], &Circumference , sizeof(float) ) ;
        /* [1] Of FileDescripter Is Indicating That We Are Sending The Data/Result From Child
        After Computation To Parent Process */
        exit(0) ; // Termination Of Child
    }
    else if ( Id > 0 )
    {
        float Result = 0.0000 ;
        printf("The Result Before Recieving Value From Child Process = %f \n" , Result ) ;
        read(FileDescripter[0], &Result, sizeof(float) ) ; 
        /* [0] Of FileDescripter Represents That We Are Recieving/Reading The Data That Was Sent 
        By The Child Process Earlier Inside The Result Variable  */
        wait(NULL) ;
        printf("The Result After Recieving Value From Child Process = %f \n" , Result ) ;
        // Printing The Received Value
        exit(0) ; // Termination Of Parent Process
    }
    else
    {
        printf("!!! Child Isn't Created Successfully !!!") ;
    }
    return 0 ;
}