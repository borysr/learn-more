using System.Reflection;

public partial class Solution
{
    public int LengthOfLongestSubstring(string s)
    {
        int l = 0;
        int r = 0;
        int res = 0;
        var map = new Dictionary<char, int>();

        for (int i = 0; i < s.Length; ++i)
        {
            if (map.ContainsKey(s[i]))
            {
                l = Math.Max(l, map[s[i]]+1);
            }
            r++;
            map[s[i]] = i;
            res = Math.Max(res, r - l);
        }
        return res;
    }
}