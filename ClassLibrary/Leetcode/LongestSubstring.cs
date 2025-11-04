public partial class LeetcodeBase
{
    public int LengthOfLongestSubstring(string s)
    {
        // Sliding window + HashMap
        // Add each char to the map with its index
        // If the char already exists, move the left pointer to the right of the 
        // previous index
        int l = 0;
        int r = 0;
        int res = 0;
        var map = new Dictionary<char, int>();

        for (int i = 0; i < s.Length; ++i)
        {
            if (map.ContainsKey(s[i]))
            {
                l = Math.Max(l, map[s[i]] + 1);
            }
            r++;
            map[s[i]] = i;
            res = Math.Max(res, r - l);
        }
        return res;
    }
}