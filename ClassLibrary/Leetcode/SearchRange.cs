using System.Security.Cryptography.X509Certificates;

public partial class LeetcodeBase
{
    
    public int[] SearchRangeV2(int[] nums, int target)
    {
        var result = new int[] { -1, -1 };
        if (nums.Length == 0) return result;

        result[0] = FindLeft(nums, target);
        result[1] = FindRight(nums, target);

        return result;
    }

    private static int FindLeft(int[] nums, int target)
    { // 0,1,2,3,4,5 : 4
        int mid = -1;
        int left = 0; //0 
        int right = nums.Length - 1; //5

        while (left <= right)
        {
            mid = left + (right - left) / 2; //2=(5-0)/2 **//
 
            if (nums[mid] == target)
            {
                if (mid == 0 || nums[mid - 1] < target)
                {
                    return mid;
                }
                right = mid - 1;
            }
            if (nums[mid] < target)
            {
                left = mid + 1;  //3 
            }
            else 
                right = mid - 1;
        }

        return mid;
    }

    private static int FindRight(int[] nums, int target)
    {
        int mid = -1;
        int left = 0;
        int right = nums.Length - 1;
        
        while (left <= right)
        {
            mid = left + (right - left) / 2;

            if (nums[mid] == target)
            {
                if (mid == nums.Length - 1 || nums[mid + 1] > target)
                {
                    return mid;
                }
                left = mid + 1;
            }
            if (nums[mid] > target)
            {
                right = mid - 1;
            }
            else 
                left = mid + 1;
        }

        return mid;
    }

    public int[] SearchRangeV1(int[] nums, int target) {
        int left; 
        int right = nums.Length - 1;
        var result = new int[] { -1, -1 };
        if (nums.Length == 0) return result;
        
        for (left = 0; left <= right; left++)
        {
            if (nums[left] == target)
            {
                result[0] = left;
                for (right = nums.Length-1; right >= left; right--)
                {
                    if (nums[right] == target)
                    {
                        result[1] = right;
                        return result;
                    }
                }
            }
        }
        return result;
    }
}
