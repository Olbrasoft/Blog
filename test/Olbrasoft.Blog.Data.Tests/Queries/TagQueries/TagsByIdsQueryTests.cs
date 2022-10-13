namespace Olbrasoft.Blog.Data.Queries.TagQueries;
public class TagsByIdsQueryTests
{
    [Fact]
    public void Ctor_Dispatcher_ShouldBeAssingableToExpected()
    {
        // Arrange
        var expected = typeof(BaseQuery<IEnumerable<TagSmallDto>>);
        var dispatcher = new Mock<IDispatcher>().Object;
        // Act
        var sut = new TagsByIdsQuery(dispatcher);
        // Assert
        sut.Should().BeAssignableTo(expected);
    }
}
