using Olbrasoft.Blog.Data.Dtos.PostDtos;


namespace Olbrasoft.Blog.Data.Queries.PostQueries;
public class PostByIdQueryTests
{
    [Fact]          
    public void Ctor_Dispatcher_ShouldBeAssingableToExpected()
    {
        // Arrange
        var expected = typeof(ByIdQuery<PostEditDto>);
        var dispatcher = new Mock<IDispatcher>().Object;
        // Act
        var sut = new PostByIdQuery(dispatcher);
        // Assert
        sut.Should().BeAssignableTo(expected);
    }
    
}
