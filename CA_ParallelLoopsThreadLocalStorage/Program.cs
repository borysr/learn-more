int[] array = Enumerable.Range(1, 10).ToArray();

int sum = 0;
object lockSum = new object();

Parallel.For(
    0,
    array.Length,
    () => 0, // any type can be used - i.e. new Dictionary<string, string>() 
    (i, state, tls) =>  // tls - thread local storage, to not lock shared var sum too much
    {
        tls += array[i];
        return tls;
    },
    tls =>
    {
        lock (lockSum) // one lock per thread to update shared sum
        {
            sum += tls;
            Console.WriteLine($"The task id: {Task.CurrentId}");
        }        
    }
);

Console.WriteLine($"The sum is {sum}");

Console.ReadLine();