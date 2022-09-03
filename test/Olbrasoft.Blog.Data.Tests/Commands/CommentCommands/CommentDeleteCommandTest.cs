using Olbrasoft.Data.Cqrs.Requests;

namespace Olbrasoft.Blog.Data.Commands.CommentCommands;
public class CommentDeleteCommandTest
{
    [Fact]
    public void CommentDeleteCommand_Inherit_From_()
    {
        //Arrange
        var dm = new Mock<IDispatcher>();

        //Act
        var command = new CommentDeleteCommand(dm.Object);

        //Assert
        Assert.IsAssignableFrom<ByIdAndCreatorIdRequest>(command);
    }
}
