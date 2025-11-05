namespace UnitTests;
public class BadVersionTests
{
    [Theory]
    [InlineData(3, 3)]
    public void FindBadVersion_Success(int badVersion, int expected)
    {
        // Arrange
        var sut = new LeetcodeBase();

        // Act
        var result = sut.FindBadVersion(badVersion);

        // Assert
        Assert.Equal(expected, result);
    }
}
