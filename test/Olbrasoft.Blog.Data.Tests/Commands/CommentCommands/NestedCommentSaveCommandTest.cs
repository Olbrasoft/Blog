namespace Olbrasoft.Blog.Data.Commands.CommentCommands;
public class NestedCommentSaveCommandTest
{
    [Fact]
    public void NestedCommentSaveCommand_Inherit_From_CreatorSaveCommand()
    {
        var dm = CreateDispatcherMock();

        //Act
        var command = new NestedCommentSaveCommand(dm.Object);

        //Assert
        Assert.IsAssignableFrom<BlogCommand>(command);

    }

    private static Mock<ICommandExecutor> CreateDispatcherMock()
    {
        //Arrange
        return new Mock<ICommandExecutor>();
    }

    [Fact]
    public void NestedCommentSaveCommand_Have_Property_CommentId_Type_Integer()
    {
        //Arrange
        var command = new NestedCommentSaveCommand(CreateDispatcherMock().Object);

        //Act
        var commentId = command.CommentId;

        //Assert
        Assert.IsAssignableFrom<int>(commentId);
    }

}
