namespace Olbrasoft.Blog.Data.Queries.TagQueries;
public class TagsByPostIdQueryTests
{
    [Fact]
    public void TypeOf_TagsByPostIdQuery_IsPublicShouldBeTrue()
    {
        // Arrange
        var sut = typeof(TagsByPostIdQuery);
        // Act
        var isPublic = sut.IsPublic;
        // Assert
        isPublic.Should().BeTrue();

    }

    [Fact]
    public void TypeOf_TagsByPostIdQuery_AssemblyShouldBeSameAsExpected()
    {
        // Arrange
        var expected = typeof(ByIdQuery<>).Assembly;
        // Act
        var sut = typeof(TagsByPostIdQuery).Assembly;
        // Assert
        sut.Should().BeSameAs(expected);
    }

    [Fact]
    public void Ctor_WithOutParams_ShouldBeAssingableToExpected()
    {
        // Arrange
        var expected = typeof(BaseQuery<IEnumerable<TagSmallDto>>);
        // Act
        var sut = new TagsByPostIdQuery(new Mock<IDispatcher>().Object);
        // Assert
        sut.Should().BeAssignableTo(expected);
    }

    [Fact]
    public void Ctor_WithoutParams_PostIdShouldBeIntMinValue()
    {
        // Arrange
        var sut = new TagsByPostIdQuery(new Mock<IDispatcher>().Object);
        // Act
        int postId = sut.PostId;
        // Assert
        postId.Should().Be(int.MinValue);
    }
}
