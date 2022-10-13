namespace Olbrasoft.Blog.Data.Commands.CommentCommands;
public class NestedCommentDeleteCommandTest
{
    [Fact]
    public void NestedCommentDeleteCommand_Inherit_From_()
    {
        //Arrange
        var dm = new Mock<ICommandExecutor>();

        //Act
        var command = new NestedCommentDeleteCommand(dm.Object);

        //Assert
        Assert.IsAssignableFrom<BlogCommand>(command);
    }
}
