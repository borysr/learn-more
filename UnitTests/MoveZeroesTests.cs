namespace UnitTests;

public class MoveZeroesTests
{
    [Theory]
    [InlineData(new int[] { 0 }, new int[] { 0 })]
    [InlineData(new int[] { 1, 0 }, new int[] { 1, 0 })]
    [InlineData(new int[] { 0, 1 }, new int[] { 1, 0 })]
    [InlineData(new int[] { 0, 1, 0, 3, 12 }, new int[] { 1, 3, 12, 0, 0 })]
    [InlineData(new int[] { 0, 0, 1 }, new int[] { 1, 0, 0 })]
    [InlineData(new int[] { 1, 0, 2, 0, 3 }, new int[] { 1, 2, 3, 0, 0 })]
    public void Test1(int[] input, int[] expected)
    {
        // Arrange
        var moveZeros = new MoveZeros();

        // Act
        moveZeros.MoveZeroes(input);

        // Assert
        Assert.Equal(expected, input);
    }
}