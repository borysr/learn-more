// See https://aka.ms/new-console-template for more information
Queue<string> queue1 = new Queue<string>();
int maxNumberOfSeats = 5;
int numberOfTickets = 0;

object requestLock = new object();
Console.WriteLine("== Server is running.\n==== Enter 'b' to book seat\n==== Enter 'c' to cancel.\n==== Enter 'exist' to stop========");

Thread monitoringThread = new Thread(MonitorQueue);
monitoringThread.Start();

while (true)
{
    string? input = Console.ReadLine();
    if (input?.ToLower() == "exit") break;
    
    queue1.Enqueue(input);
}

Console.WriteLine("======= Bye-bye! ========");

void MonitorQueue()
{
    while (true)
    {
        if (queue1.Count > 0)
        {
            string? input = queue1.Dequeue();
            Thread processingThread = new Thread(() => ProcessInput(input));
            processingThread.Start();
            Thread.Sleep(100);
        }
    } 
}
void ProcessInput(string input)
{
    if ( Monitor.TryEnter(requestLock, 2000)) {
        Thread.Sleep(3000);
        try
        {
            // Critical section
        switch (input)
        {
            case "c" : 
                if (numberOfTickets>0) {
                        numberOfTickets--;
                        Console.WriteLine(
                            $"Your ticket is cancelled. There are {maxNumberOfSeats-numberOfTickets} seats available.");
                } else {
                    
                    Console.WriteLine($"All teackets are cancelled. There are {maxNumberOfSeats-numberOfTickets} seats available.");
                }
                break;
            case "b" :
                    if (numberOfTickets < maxNumberOfSeats) 
                    {
                        numberOfTickets++; 
                        Console.WriteLine($"Your seat is booked. There are {maxNumberOfSeats-numberOfTickets} seats left.");
                    } else {
                        Console.WriteLine($"All seats are booked. There are no seats available.");
                    }
                    break;
            default :
                    break;
            }
        }
        finally
        {
            Monitor.Exit(requestLock);
        }
    } else
    {
        System.Console.WriteLine("System is busy. Please try again later.");
    }
}