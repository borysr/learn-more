int[] array = Enumerable.Range(1, 10).ToArray();

int sum = 0;
object lockSum = new object();

Parallel.For(
    0,
    array.Length,
<<<<<<< HEAD
    () => 0, // any type can be used - i.e. new Dictionary<string, string>() 
=======
    () => 0,
>>>>>>> 0b6542b67ec2aedaa4f58c0f0778838f268a9d28
    (i, state, tls) =>  // tls - thread local storage, to not lock shared var sum too much
    {
        tls += array[i];
        return tls;
    },
    tls =>
    {
<<<<<<< HEAD
        lock (lockSum) // one lock per thread to update shared sum
=======
        lock (lockSum)
>>>>>>> 0b6542b67ec2aedaa4f58c0f0778838f268a9d28
        {
            sum += tls;
            Console.WriteLine($"The task id: {Task.CurrentId}");
        }        
    }
);

Console.WriteLine($"The sum is {sum}");

Console.ReadLine();