public partial class LeetcodeBase
{
    public (int, int) MaxArea(int[] height)
    {
        if (height.Length < 2) return (0, 0);

        int maxArea = 0;
        (int, int) result = (0, 0);

        for(int j = 1; j< height.Length; j++)
            for(int i = 0; i < j; i++)
            {
                int currentArea = Math.Min(height[j], height[i]) * (j - i);
                if  (currentArea > maxArea)
                {
                    maxArea = currentArea;
                    result = (i, j);
                }
            }
        return result;
    }
}