public partial class DsaSolution
{
    public void BubleSort<T>(T[] arr) where T : IComparable {
        for (int i = 0; i < arr.Length; i++)
        {
            bool isAnyChange = false;
            for (int j = 0; j < arr.Length - 1; j++)
            {
                if (arr[j].CompareTo(arr[j + 1]) > 0)
                {
                    isAnyChange = true;
                    Swap(arr, j, j + 1);
                }
            }
            if (!isAnyChange)
            {
                break;
            }
        }
    }
}
