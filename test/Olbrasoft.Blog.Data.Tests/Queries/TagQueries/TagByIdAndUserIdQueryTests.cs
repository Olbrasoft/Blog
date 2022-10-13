namespace Olbrasoft.Blog.Data.Queries.TagQueries;
public class TagByIdAndUserIdQueryTests
{
    [Fact]
    public void Ctor_Dispatcher_ShouldBeAssingableToExpected()
    {
        // Arrange
        var expected = typeof(ByIdQuery<TagSmallDto>);
        var dispatcher = new Mock<IDispatcher>().Object;
        // Act
        var sut = new TagByIdAndUserIdQuery(dispatcher);
        // Assert
        sut.Should().BeAssignableTo(expected);
    }
}
