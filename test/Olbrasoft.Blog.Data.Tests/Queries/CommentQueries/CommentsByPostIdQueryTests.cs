using Olbrasoft.Blog.Data.Dtos.CommentDtos;

namespace Olbrasoft.Blog.Data.Queries.CommentQueries;
public class CommentsByPostIdQueryTests
{
    [Fact]
    public void CommentsByPostIdQuery_Processor_ShouldByAssingableToBaseQuery()
    {
        // Arrange
        var processor = new Mock<IQueryProcessor>().Object;
        // Act
        var sut = new CommentsByPostIdQuery(processor);
        // Assert
        sut.Should().BeAssignableTo<BaseQuery<IEnumerable<CommentDto>>>();
    }

    [Fact]
    public void CommentsByPostIdQuery_Dispatcher_ShouldBeSameAsExpected()
    {
        // Arrange
        var expected = new Mock<IDispatcher>().Object;

        // Act
        var sut = new CommentsByPostIdQuery(expected);
        // Assert
        sut.Dispatcher.Should().BeSameAs(expected);
    }

}
