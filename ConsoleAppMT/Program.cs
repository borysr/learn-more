// See https://aka.ms/new-console-template for more information

void WriteThreadId()
{
    for (int i = 0; i < 100; i++)
    {
        Console.WriteLine($"Thread {Thread.CurrentThread.Name} {Thread.CurrentThread.ManagedThreadId}");
        // Thread.Sleep(50);
    }
}


Thread thr1 = new Thread(WriteThreadId );
Thread thr2 = new Thread(WriteThreadId);
thr2.Priority = ThreadPriority.Lowest;
thr1.Name = "Thread1";
thr1.Priority = ThreadPriority.Highest;
thr2.Name = "Thread2";

Thread.CurrentThread.Priority = ThreadPriority.Normal;
Thread.CurrentThread.Name = "Main";

thr1.Start();
thr2.Start();

WriteThreadId();

// Console.ReadLine();