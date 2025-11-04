using System.Runtime.InteropServices.Marshalling;

namespace UnitTests;

public class MaxAreaTests
{
    [Theory]
    [InlineData(new[] { 5, 9, 2, 4 }, new[] { 0, 3 })]
    [InlineData(new[] { 1, 100, 2 }, new[] { 0, 2 })]
    public void ReturnsIndicesOfContainerWithMostWater(int[] heights, int[] expected)
    {
        // Arrange
        var sut = new LeetcodeBase();

        // Act
        var result = sut.MaxArea(heights);

        // Assert
        Assert.Equal((expected[0], expected[1]), result);
    }
}
