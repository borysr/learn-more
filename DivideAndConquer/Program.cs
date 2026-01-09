// running in thread checking for items, ?get/print count?


int SumSegemnt(int[] arr, int start, int end)
{
    int sum = 0;
    for (int i = start; i < end; i++)
    {
        sum += arr[i];
        Thread.Sleep(100);
    }

    return sum;
}

int[] array = {1, 2, 3, 4, 5,  6, 7, 8, 9, 10};
int sum1 = 0, sum2 = 0, sum3 = 0, sum4 = 0;
int numOfThreads = 4;
int segLength = array.Length/numOfThreads;

Thread[] ta = new Thread[numOfThreads];

ta[0] = new Thread(() =>
{
    sum1 = SumSegemnt(array, 0, segLength);
});

ta[1] = new Thread(() =>
{
    sum2 = SumSegemnt(array, segLength, 2*segLength);
});

ta[2] = new Thread(() =>
{
    sum3 = SumSegemnt(array, 2*segLength, 3*segLength);
});

ta[3] = new Thread(() =>
{
    sum4 = SumSegemnt(array, 3*segLength, array.Length);
});

var startTime = DateTime.Now;
foreach (Thread t in ta) { t.Start(); }
foreach (Thread t in ta) { t.Join(); }

var sum = sum1 + sum2 + sum3 + sum4;

var endTime = DateTime.Now;

var timeSpan = endTime - startTime;

Console.WriteLine($"the sum is {sum}; time: {timeSpan.TotalMilliseconds}");