public partial class LeetcodeBase
{
    public int MissingNumber(int[] nums)
    {
        return nums.Length * (nums.Length +1) / 2 - nums.Sum();
    }   

    public int MissingNumber1(int[] nums)
    {
        var map = new Dictionary<int, bool>();

        foreach (int i in nums)
        {
            map[i] = true;
        }

        for (int i = 0; i <= nums.Length; i++)
        {
            if (!map.ContainsKey(i))
            {
                return i;
            }

        }
        return -1;
    }
}