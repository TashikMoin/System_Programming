#include<stdio.h>
#include<unistd.h>
#include<wait.h>
#include<stdlib.h>

int main()
{
    // Start Of Parent Process
    pid_t Id ; // Struct To Get Process ID
    Id = fork() ; 
    /* A Child Process Will Be Created Similar To The Parent Process.Both Parent & Child Will Start
    Their Concurrent Execution From The Line Where Fork Is Called. To The Child Process Or Inside 
    The Child Process Fork Will Be Returning 0 And Withing The Parent Process Scope Fork Will Be 
    Returning A +VE Value. The Child Process Will Start Its Execution From The Point Fork Is Called
    & The Code Before Fork Is Not Executed By Child Process It Can Only Be Executed By Parent Process */
    if( Id == 0 ) 
    /* Means We Are Checking If Its A Child Process Then Do This.. Because For Child Processes, 
    Fork Returns 0 */
    {
        char c ;
        for(int i = 0 ; i < 5000 ; ++i )
        {
            printf("... I Am Child Process ...") ;
            scanf( "%c" , &c ) ;
            if( i < 0 )
            {
                break ;
            }
        }
        exit(0) ; // Termination Of Child
    }
    else if ( Id > 0 )
    /* Checking If The Current Process/Scope Is Of Parent Process Then Do This..
    So That We Can Divide Our Tasks Within Parent/Child Processes & Execute Them Concurrently */
    {
        char c ;
        for(int i = 0 ; i < 5000 ; ++i )
        {
            printf("... I Am Parent Process ...") ;
            scanf( "%c" , &c ) ;
            if( c == 'q' )
            {
                break ;
            }
        }
        wait(NULL) ;
        /* It Will Wait Until All Its Children Execute Completely.. And The Remaining 
        Code Of Parent After The Wait Function Call Will Be Executed By The Parent Process */
        printf("... Child Has Done It's Work ...") ;
        exit(0) ; // Termination Of Parent Process
    }
    else
    {
        printf("!!! Child Isn't Created Successfully !!!") ;
    }
    return 0 ;
}