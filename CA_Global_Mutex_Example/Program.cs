// run two different instances to see that lock does not work, 
// but global mutex does

string filePath = "counter.txt";

// object fileLock = new object();
// for (int i = 0; i < 100000; i++)
// {
//     lock (fileLock)
//     {
//         int counter = ReadCounter(filePath);
//         counter++;
//         WriteCounter(filePath, counter);
//     }
// }

using (var mutex = new Mutex(false, $"GlobalFileMutex:{filePath}"))
{
    for (int i = 0; i < 100000; i++)
    {
        
    mutex.WaitOne();
    try
        {
            int counter = ReadCounter(filePath);
            counter++;
            WriteCounter(filePath, counter);
        } finally
        {
            mutex.ReleaseMutex();
        }
    }
}

System.Console.WriteLine($"Final counter value: {ReadCounter(filePath)}");

int ReadCounter(string path)
{
    using (var stream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Read, FileShare.ReadWrite))
    using (var reader = new StreamReader(stream))
    {
        string content = reader.ReadToEnd();
        if (int.TryParse(content, out int result))
        {
            return result;
        }
        return 0;
    }
}

void WriteCounter(string path, int counter)
{
    using (var stream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.ReadWrite))
    using (var writer = new StreamWriter(stream))
    {
        writer.Write(counter.ToString());
    }
}
