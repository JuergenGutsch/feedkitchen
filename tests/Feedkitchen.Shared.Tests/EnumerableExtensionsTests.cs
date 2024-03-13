using FeedKitchen.Shared.Extensions;

namespace FeedKitchen.Shared.Tests;

public class EnumerableExtensionsTests
{
    [Fact]
    public void ForEach_Action_Test()
    {
        // Arrange
        var list = new List<int> { 1, 2, 3 };
        var expected = new List<int> { 2, 3, 4 };
        var actual = new List<int>();

        // Act
        list.ForEach(item => actual.Add(item + 1));

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void ForEach_Func_Test()
    {
        // Arrange
        var list = new List<int> { 1, 2, 3 };
        var expected = new List<int> { 2, 3, 4 };

        // Act
        var actual = list.ForEach(item => item + 1);

        // Assert
        Assert.Equal(expected, actual);
    }
}
