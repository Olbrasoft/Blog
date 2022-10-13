using Olbrasoft.Blog.Data.Dtos.PostDtos;

namespace Olbrasoft.Blog.Data.Queries.PostQueries;
public class PostDetailByIdQueryTests
{
    [Fact]
    public void Ctor_Dispatcher_ShouldBeAssingableToExpected()
    {
        // Arrange
        var expected = typeof(ByIdQuery<PostDetailDto>);
        var dispatcher = new Mock<IDispatcher>().Object;
        // Act
        var sut = new PostDetailByIdQuery(dispatcher);
        // Assert
        sut.Should().BeAssignableTo(expected);

    }
}
