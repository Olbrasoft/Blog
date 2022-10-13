namespace Olbrasoft.Blog.Data.Queries.CommentQueries;
public class CommentTextForEditingQueryTests
{
    [Fact]
    public void CommentTextForEditingQuery_Dispatcher_ShouldBeAssingableToByIdQuery()
    {
        // Arrange
        var dispatcher = new Mock<IDispatcher>().Object;
        // Act
        var sut = new CommentTextForEditingQuery(dispatcher);

        // Assert
        sut.Should().BeAssignableTo<ByIdQuery<string>>();

    }
}
