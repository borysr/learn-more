public class MoveZeros
{
    public void MoveZeroes(int[] nums)
    {
        var j = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] != 0)
            {
                nums[j++] = nums[i];
            }
        }
        for (int i = j; i < nums.Length; i++)
        {
            nums[i] = 0;
        }
    }
}
