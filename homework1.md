# Homework 1: The Concurrency Test Lab

**🎯 Objective:**
To build a small console app that proves, with a `Stopwatch`, the performance difference between `Task.WhenAll` (for I/O) and `Parallel.ForEach` (for CPU). This will give you a tangible feel for *why* you use each one.

**🚀 Your Task:**
Create a new C# Console Application (.NET 6 or newer).

---

**📋 Requirements:**

### 1. Create Your "Work" Methods

You need two methods that simulate work.

* **The I/O Simulator (The "Waiting" Task):**
    ```csharp
    // Simulates a 1-second network or database call.
    // It's "async" and uses Task.Delay to *not* block the thread.
    async Task Simulate_IO_Call(int id)
    {
        Console.WriteLine($"Starting I/O task {id}...");
        await Task.Delay(1000); // 1-second non-blocking wait
        Console.WriteLine($"...Finished I/O task {id}");
    }
    ```

* **The CPU Simulator (The "Thinking" Task):**
    ```csharp
    // Simulates a 1-second heavy calculation.
    // This *must* be synchronous and block the thread it's on.
    void Simulate_CPU_Work(int id)
    {
        Console.WriteLine($"Starting CPU task {id}...");
        // A simple, "dumb" loop to waste CPU time.
        // Tweak the upper limit until it takes ~1 second.
        long stop = Environment.TickCount + 1000;
        while (Environment.TickCount < stop) { /* do nothing */ }
        Console.WriteLine($"...Finished CPU task {id}");
    }
    ```

### 2. Implement the "Test Harness" Methods

Now, create three methods to run the tests. Use `System.Diagnostics.Stopwatch` to time each one.

* **Test 1: The *Correct* I/O Test**
    * Create a method `Run_IO_Test_Correct()`.
    * Inside, create a `List<int>` of 10 tasks to run (e.g., `Enumerable.Range(1, 10).ToList()`).
    * Use **`Task.WhenAll`** to execute `Simulate_IO_Call` for all 10 items concurrently.
    * Print the total time.
    > **Expected result: ~1 second.**

* **Test 2: The *Correct* CPU Test**
    * Create a method `Run_CPU_Test_Correct()`.
    * Create a `List<int>` of 10 tasks to run.
    * Use **`Parallel.ForEach`** to execute `Simulate_CPU_Work` for all 10 items in parallel.
    * Print the total time.
    > **Expected result: Depends on your CPU cores.** (e.g., on an 8-core CPU, maybe 2-3 seconds).

* **Test 3: The *Incorrect* I/O Test (The "Anti-Pattern")**
    * Create a method `Run_IO_Test_WRONG()`.
    * Create a `List<int>` of 10 tasks to run.
    * Use **`Parallel.ForEach`** to execute `Simulate_IO_Call` (the *async* method).
    * Print the total time.
    > **Expected result: Very slow.** (e.g., on an 8-core CPU, it might still take ~10 seconds because the threads get blocked).
    > *Note: You'll get a compiler warning about using `async void` in a lambda; for this test, you can ignore it or use `.Wait()` to force the block.*

### 3. Set up `Program.cs`

In your main `Program.cs`, call each test method one by one and print the results clearly.

```csharp
// Make sure your top-level program is async
// (or create a main async method and .Wait() on it)

using System.Diagnostics;

var stopwatch = new Stopwatch();

Console.WriteLine("--- Running Test 1: CORRECT I/O (Task.WhenAll) ---");
stopwatch.Start();
await Run_IO_Test_Correct();
stopwatch.Stop();
Console.WriteLine($"Total time for correct I/O: {stopwatch.ElapsedMilliseconds}ms\n");

stopwatch.Reset();
Console.WriteLine("--- Running Test 2: CORRECT CPU (Parallel.ForEach) ---");
stopwatch.Start();
Run_CPU_Test_Correct(); // This one isn't async
stopwatch.Stop();
Console.WriteLine($"Total time for correct CPU: {stopwatch.ElapsedMilliseconds}ms\n");

stopwatch.Reset();
Console.WriteLine("--- Running Test 3: WRONG I/O (Parallel.ForEach) ---");
stopwatch.Start();
Run_IO_Test_WRONG(); // This one isn't async
stopwatch.Stop();
Console.WriteLine($"Total time for WRONG I/O: {stopwatch.ElapsedMilliseconds}ms\n");

// --- Define your test methods here (or in a separate class) ---
// (e.g., as local functions if using top-level statements)

async Task Run_IO_Test_Correct()
{
    var tasks = Enumerable.Range(1, 10).Select(i => Simulate_IO_Call(i));
    await Task.WhenAll(tasks);
}

void Run_CPU_Test_Correct()
{
    var items = Enumerable.Range(1, 10);
    Parallel.ForEach(items, (i) => Simulate_CPU_Work(i));
}

void Run_IO_Test_WRONG()
{
    var items = Enumerable.Range(1, 10);
    // This is the anti-pattern.
    // Note: To make this "work" you must force the block.
    Parallel.ForEach(items, (i) =>
    {
        Simulate_IO_Call(i).Wait(); // Forcing the block
    });
}

async Task Simulate_IO_Call(int id)
{
    Console.WriteLine($"Starting I/O task {id}...");
    await Task.Delay(1000); // 1-second non-blocking wait
    Console.WriteLine($"...Finished I/O task {id}");
}

void Simulate_CPU_Work(int id)
{
    Console.WriteLine($"Starting CPU task {id}...");
    // A simple, "dumb" loop to waste CPU time.
    long stop = Environment.TickCount + 1000;
    while (Environment.TickCount < stop) { /* do nothing */ }
    Console.WriteLine($"...Finished CPU task {id}");
}
