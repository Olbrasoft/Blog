using Olbrasoft.Blog.Data.Commands.TagCommands;

namespace Olbrasoft.Blog.Data.Commands;

public class TagSaveCommandTest
{
    [Fact]
    public void Instance_Implement_Interface_IRequest_Of_Bool()
    {
        //Arrange
        var type = typeof(BaseCommand<bool>);

        //Act
        var cmd = CreateCommand();

        //Assert
        Assert.IsAssignableFrom(type, cmd);
    }

    private static TagSaveCommand CreateCommand()
    {
        var dispatcherMock = new Mock<ICommandExecutor>();

        return new TagSaveCommand(dispatcherMock.Object);
    }

    [Fact]
    public void Have_Id()
    {
        //Arrange
        var cmd = CreateCommand();

        //Act
        var id = cmd.Id;

        //Assert
        Assert.IsAssignableFrom<int>(id);
    }

    [Fact]
    public void Have_Label()
    {
        //Arrange
        var cmd = CreateCommand();

        //Act
        var label = cmd.Label;

        //Assert
        Assert.IsAssignableFrom<string>(label);
    }

    [Fact]
    public void Have_UserId()
    {
        //Arrange
        var cmd = CreateCommand();

        //Act
        var id = cmd.CreatorId;

        //Assert
        Assert.IsAssignableFrom<int>(id);
    }
}