namespace Olbrasoft.Blog.Data.Commands;
public class BlogCommandTests
{
    [Fact]
    public void BlogCommand_Dispatcher_ShouldBeAssingableToExpected()
    {
        // Arrange
        var expected = typeof(BaseCommand<bool>);
        var dispatcher = new Mock<IDispatcher>().Object;
        // Act
        var sut = new Mock<BlogCommand>(dispatcher).Object;

        // Assert
        sut.Should().BeAssignableTo(expected);
    }
}
