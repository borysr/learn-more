namespace UnitTests;

public class LongestSubstringTests
{
    [Theory]
    [InlineData("", 0)]
    [InlineData("aaaaa", 1)]
    [InlineData("abcaabcdaeaa", 5)]
    [InlineData("abcaabcabcbcd", 3)]
    [InlineData("abcabcbb", 3)]
    [InlineData("pwwkew", 3)]
    public void Test1(string input, int expected)
    {
        // Arrange
        var sut = new LeetcodeSolution();

        // Act
        var actual = sut.LengthOfLongestSubstring(input);

        // Assert
        Assert.Equal(expected, actual);
    }
}