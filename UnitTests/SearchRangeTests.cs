namespace UnitTests
{
    public class SearchRangeTests
    {
        [Theory]
        [InlineData(new int[] { }, 0, new int[] { -1, -1})]
        public void Test1(int[] arr, int item,  int[] expected)
        {
            var sut = new LeetcodeSolution { };
            var actual = sut. SearchRange(arr, item);
            Assert.True(false);
        }
    }
}