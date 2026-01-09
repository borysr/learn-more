// See https://aka.ms/new-console-template for more information
Queue<string> queue1 = new Queue<string>();

Thread thread1 = new Thread(MonitorQueue);
thread1.Start();

Console.WriteLine("======= Hello! ========");
while (true)
{
    string? input = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(input))
    {
        break;
    }
    Console.WriteLine($"You entered {input} ");
    queue1.Enqueue(input);
}

while (queue1.Count > 0)
{
    Thread.Sleep(1000);
}

thread1.Interrupt();

Console.WriteLine("======= Bye-bye! ========");


void MonitorQueue()
{
    while (true)
    {
        if (queue1.Count > 0)
        {
            Thread thread2 = new Thread(ProcessInput);
            thread2.Start();
            Thread.Sleep(100);
        }
    } 
}

void ProcessInput()
{
    Console.WriteLine($"\nQueue length : {queue1.Count}");
    var str = queue1.Dequeue();
    Thread.Sleep(2000);
    Console.WriteLine($"\nProcessing input: {str}");
}