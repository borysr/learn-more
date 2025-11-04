using System.Formats.Asn1;

public partial class LeetcodeBase
{

    public (int, int, int) MaxArea(int[] height)
    {
        if (height.Length < 2) return (0, 0, 0);

        int maxArea = 0;
        (int, int, int) result = (0, 0, 0);
        int left = 0, right = height.Length - 1;

        while (left < right)
        {
            int currentArea = Math.Min(height[left], height[right]) * (right - left);

            if (currentArea > maxArea)
            {
                maxArea = currentArea;
                result = (left, right, maxArea);
            }

            if (height[left] < height[right])
                left++;
            else
                right--;
           
        }
        return result;
    }

    public (int, int, int) MaxArea_V1(int[] height)
    {
        if (height.Length < 2) return (0, 0, 0);

        int maxArea = 0;
        (int, int, int) result = (0, 0, 0);

        for(int j = 1; j< height.Length; j++)
            for(int i = 0; i < j; i++)
            {
                int currentArea = Math.Min(height[j], height[i]) * (j - i);
                if  (currentArea > maxArea)
                {
                    maxArea = currentArea;
                    result = (i, j, maxArea);
                }
            }
        return result;
    }
}