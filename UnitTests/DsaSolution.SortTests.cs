using System.Globalization;

namespace UnitTests
{
    /// <summary>
    /// SelectionSortTests
    /// </summary>
    public class SelectionSortTests
    {
        [Theory]
        [InlineData(new int[] { 1, 0 }, new int[] { 0, 1 })]
        [InlineData(new int[] { 0, 1 }, new int[] { 0, 1 })]
        [InlineData(new int[] { 4, -12, 0, 1 }, new int[] { -12, 0, 1, 4 })]
        [InlineData(new int[] { -11, 12, -42, 0, 1, 90, 68, 6, -9 }, new int[] { -42, -11, -9, 0, 1, 6, 12, 68, 90 })]

        public void TestIntArraySort(int[] arr, int[] expected)
        {
            var sut = new DsaSolution { };
            sut.SelectionSort(arr);
            Assert.Equal(expected, arr);
        }

        [Theory]
        [InlineData(new string[] { "Bet", "Don", "Mary", "Ann" }, new string[] { "Ann", "Bet", "Don", "Mary" })]
        public void TestStringArraySort(string[] arr, string[] expected)
        {
            var sut = new DsaSolution { };
            sut.SelectionSort(arr);
            Assert.Equal(expected, arr);
        }
    }

    /// <summary>
    /// InsertionSortTests
    /// </summary>
    public class InsertionSortTests
    {
        [Theory]
        [InlineData(new int[] { 1, 0 }, new int[] { 0, 1 })]
        [InlineData(new int[] { 0, 1 }, new int[] { 0, 1 })]
        [InlineData(new int[] { 4, -12, 0, 1 }, new int[] { -12, 0, 1, 4 })]
        [InlineData(new int[] { -11, 12, -42, 0, 1, 90, 68, 6, -9 }, new int[] { -42, -11, -9, 0, 1, 6, 12, 68, 90 })]

        public void TestIntArraySort(int[] arr, int[] expected)
        {
            var sut = new DsaSolution { };
            sut.InsertionSort(arr);
            Assert.Equal(expected, arr);
        }

        [Theory]
        [InlineData(new string[] { "Bet", "Don", "Mary", "Ann" }, new string[] { "Ann", "Bet", "Don", "Mary" })]
        public void TestStringArraySort(string[] arr, string[] expected)
        {
            var sut = new DsaSolution { };
            sut.InsertionSort(arr);
            Assert.Equal(expected, arr);
        }
    }    /// <summary>
    /// BubleSortTests
    /// </summary>
    public class BubleSortTests
    {
        [Theory]
        [InlineData(new int[] { 1, 0 }, new int[] { 0, 1 })]
        [InlineData(new int[] { 0, 1 }, new int[] { 0, 1 })]
        [InlineData(new int[] { 4, -12, 0, 1 }, new int[] { -12, 0, 1, 4 })]
        [InlineData(new int[] { -11, 12, -42, 0, 1, 90, 68, 6, -9 }, new int[] { -42, -11, -9, 0, 1, 6, 12, 68, 90 })]

        public void TestIntArraySort(int[] arr, int[] expected)
        {
            var sut = new DsaSolution { };
            sut.BubleSort(arr);
            Assert.Equal(expected, arr);
        }

        [Theory]
        [InlineData(new string[] { "Bet", "Don", "Mary", "Ann" }, new string[] { "Ann", "Bet", "Don", "Mary" })]
        public void TestStringArraySort(string[] arr, string[] expected)
        {
            var sut = new DsaSolution { };
            sut.BubleSort(arr);
            Assert.Equal(expected, arr);
        }
    }
}