namespace UnitTests
{
    public class SearchRangeTests
    {
        [Theory]
//        [InlineData(new int[] { }, 0, new int[] { -1, -1 })]
        [InlineData(new int[] { 0, 1, 2, 3, 4, 5 }, 4, new int[] { 4, 4 })]
 //       [InlineData(new int[] { 0, 1, 4, 4, 4, 5 }, 4, new int[] { 2, 4 })]
        public void TestV2(int[] arr, int item, int[] expected)
        {
            var sut = new LeetcodeBase { };
            var actual = sut.SearchRangeV2(arr, item);
            Assert.Equal(expected, actual);
        }
        
        [Theory]
        [InlineData(new int[] { }, 0, new int[] { -1, -1})]
        [InlineData(new int[] {0,1,2,3,4,5 }, 4, new int[] { 4, 4})]
        [InlineData(new int[] {0,1,4,4,4,5 }, 4, new int[] { 2, 4})]
        public void TestV1(int[] arr, int item,  int[] expected)
        {
            var sut = new LeetcodeBase { };
            var actual = sut.SearchRangeV1(arr, item);
            Assert.Equal(expected, actual);
        }
    }
}