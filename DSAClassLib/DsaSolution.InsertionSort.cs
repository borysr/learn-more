public partial class DsaSolution
{
    public void InsertionSort<T>(T[] arr) where T : IComparable {
        for (int i = 1; i < arr.Length; i++)
        {
            int j = i;
            while (j > 0 && arr[j].CompareTo(arr[j - 1]) < 0)
            {
                Swap(arr, j, j - 1);
                j--;
            }
        }
    }
}
