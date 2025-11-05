public class NewBaseType
{
    public bool IsBadVersion(int version)
    {
        return version >= 3; ;
    }
    
    public int FindBadVersion(int n)
    {
        int left = 1;
        int right = n;

        int cnt = 10000;
        while (left < right)
        {
            if (cnt-- < 0) throw new Exception("infinite loop detected");

            var mid = left + (right - left) / 2;

            if (IsBadVersion(mid))
            {
                if (mid == 1 || (mid - 1 > 0 && !IsBadVersion(mid - 1)))
                {
                    return mid;
                }
                else
                {
                    right = mid;
                }
            } else
            {
                left = mid + 1;
            }
        }

        return left;
    }
}

public partial class LeetcodeBase : NewBaseType
{
    public bool IsBadVersion(int version)
    {
        return version >= 3; ;
    }
}