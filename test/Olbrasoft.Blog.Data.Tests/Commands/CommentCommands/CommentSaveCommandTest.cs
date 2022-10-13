namespace Olbrasoft.Blog.Data.Commands.CommentCommands;
public class CommentSaveCommandTest
{
    [Fact]
    public void CommentSaveCommand_Inherit_From_()
    {
        //Arrange
        Mock<ICommandExecutor> dispatchingMock = CreateMock();

        //Act
        var command = new CommentSaveCommand(dispatchingMock.Object);

        //Assert
        Assert.IsAssignableFrom<BlogCommand>(command);

    }

    private static Mock<ICommandExecutor> CreateMock()
    {
        return new Mock<ICommandExecutor>();
    }

    [Fact]
    public void CommantSaveCommand_Have_Propperty_PostId_With_Default_Value_Zero()
    {
        //Arrange
        var command = new CommentSaveCommand(CreateMock().Object);

        //Act
        var postId = command.PostId;

        //Assert
        Assert.True(postId == 0);

    }

}
