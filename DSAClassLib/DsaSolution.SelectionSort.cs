public partial class DsaSolution
{
    public void SelectionSort<T>(T[] arr) where T : IComparable {
        for (int i = 0; i < arr.Length; i++)
        {
            int minIdx = i;
            T minVal = arr[i];
            for (int j = i + 1; j < arr.Length; j++)
            {
                if (arr[j].CompareTo(minVal) < 0)
                {
                    minIdx = j;
                    minVal = arr[j];
                }
            }
            Swap(arr, i, minIdx);
        }
    }
}
