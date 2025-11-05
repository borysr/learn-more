namespace UnitTests;
public class MissingNumberTests()
{
    [Theory]
    [InlineData(new[] { 3, 0, 1 }, 2)]
    [InlineData(new[] { 0, 1 }, 2)]
    public void MissingNumber_Success(int[] nums, int expected)
    {
        // Arrange
        var sut = new LeetcodeBase();

        // Act
        var result = sut.MissingNumber(nums);

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(new[] { 3, 0, 1 }, 2)]
    [InlineData(new[] { 0, 1 }, 2)]
    public void MissingNumber_Success1(int[] nums, int expected)
    {
        // Arrange
        var sut = new LeetcodeBase();

        // Act
        var result = sut.MissingNumber1(nums);

        // Assert
        Assert.Equal(expected, result);
    }

}