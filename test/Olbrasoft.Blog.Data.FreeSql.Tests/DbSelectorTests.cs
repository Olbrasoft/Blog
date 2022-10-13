namespace Olbrasoft.Blog.Data.FreeSql.Tests;
public class DbSelectorTests
{
    [Fact]
    public void Typeof_DbSelector_IsPublic()
    {
        // Arrange
        var sut = typeof(DbSelector);
        // Act
        var isPublic = sut.IsPublic;
        // Assert
        isPublic.Should().BeTrue();
    }

    [Fact]
    public void Typeof_DbSelector_AssemblyShouldBeSameAsExpected()
    {
        // Arrange
        var expected = typeof(IDataSelector).Assembly;
        // Act
        var sut = typeof(DbSelector).Assembly;
        // Assert
        sut.Should().BeSameAs(expected);
    }

    [Fact]
    public void DbSelector_MockSetProvider_ShouldBeAssingableToExpected()
    {
        // Arrange
        var expected = typeof(IDataSelector);
        var mockSetProvider = new Mock<IDbSetProvider>();
        // Act
        var sut = new DbSelector(provider: mockSetProvider.Object);

        // Assert
        sut.Should().BeAssignableTo(expected);
    }

    [Fact]
    public void Select_WithGenericType_ReturnsSelectShouldBeSameAsExpected()
    {
        // Arrange
        var expected = new Mock<ISelect<object>>().Object;
        
        var set = new FakeDbSet<object>(expected);
        
        var mockProvider = new Mock<IDbSetProvider>();
        mockProvider.Setup(p => p.Set<object>()).Returns(set);
        
        var sut = new DbSelector(mockProvider.Object);

        // Act
        var result = sut.Select<object>();

        // Assert
        result.Should().BeSameAs(expected);
    }
}
