namespace ClassLibrary.DSAClassLib;
public partial class DsaSolution
{
    public int[] NewMethod(int[] nums, int target)
    {
        return nums;
    }

    protected static void Swap<T>(T[] arr, int i, int j) where T : IComparable
    {
        T tmp = arr[i];
        arr[i] = arr[j];
        arr[j] = tmp;
    }
}
