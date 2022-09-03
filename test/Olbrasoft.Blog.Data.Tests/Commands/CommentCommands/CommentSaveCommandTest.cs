namespace Olbrasoft.Blog.Data.Commands.CommentCommands;
public class CommentSaveCommandTest
{
    [Fact]
    public void CommentSaveCommand_Inherit_From_()
    {
        //Arrange
        Mock<IDispatcher> dispatchingMock = CreateDispatchinkMock();

        //Act
        var command = new CommentSaveCommand(dispatchingMock.Object);

        //Assert
        Assert.IsAssignableFrom<CreatorSaveCommand>(command);

    }

    private static Mock<IDispatcher> CreateDispatchinkMock()
    {
        return new Mock<IDispatcher>();
    }

    [Fact]
    public void CommantSaveCommand_Have_Propperty_PostId_With_Default_Value_Zero()
    {
        //Arrange
        var command = new CommentSaveCommand(CreateDispatchinkMock().Object);

        //Act
        var postId = command.PostId;

        //Assert
        Assert.True(postId == 0);

    }

}
