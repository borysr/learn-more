using System.Runtime.InteropServices.Marshalling;

namespace UnitTests;

public class MaxAreaTests
{
    [Theory]
    [InlineData(new[] { 5, 9, 2, 4 }, new[] { 0, 3, 12 })]
    [InlineData(new[] { 1, 100, 2 }, new[] { 0, 2, 2 })]
    [InlineData(new[] { 1,8,6,3,5,7 }, new[] { 1, 5, 28 })]

    public void ReturnsIndicesOfContainerWithMostWater(int[] heights, int[] expected)
    {
        // Arrange
        var sut = new LeetcodeBase();

        // Act
        var result = sut.MaxArea(heights);

        // Assert
        Assert.Equal((expected[0], expected[1], expected[2]), result);
    }
    [Theory]
    [InlineData(new[] { 5, 9, 2, 4 }, new[] { 0, 3, 12 })]
    [InlineData(new[] { 1, 100, 2 }, new[] { 0, 2, 2 })]
    [InlineData(new[] { 1,8,6,3,5,7 }, new[] { 1, 5, 28 })]
    public void ReturnsIndicesOfContainerWithMostWaterV1(int[] heights, int[] expected)
    {
        // Arrange
        var sut = new LeetcodeBase();

        // Act
        var result = sut.MaxArea_V1(heights);

        // Assert
        Assert.Equal((expected[0], expected[1], expected[2]), result);
    }
}
