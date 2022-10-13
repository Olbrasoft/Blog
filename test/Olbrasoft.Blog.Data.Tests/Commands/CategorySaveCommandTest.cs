namespace Olbrasoft.Blog.Data.Commands;

public class CategorySaveCommandTest
{
    [Fact]
    public void Implement_Interface_ICommand_Of_Bool()
    {
        //Arrange
        var type = typeof(BaseCommand<bool>);

        //Act
        var cmd = CreateCommand();

        //Assert
        Assert.IsAssignableFrom(type, cmd);
    }

    private static CategorySaveCommand CreateCommand()
    {
        var dispatcherMock = new Mock<ICommandExecutor>();

        return new CategorySaveCommand(dispatcherMock.Object) { Id = 0 };
    }

    [Fact]
    public void Id()
    {
        //Arrange
        var cmd = CreateCommand();

        //Act
        var id = cmd.Id;

        //Assert
        Assert.IsAssignableFrom<int?>(id);
    }

    [Fact]
    public void Name()
    {
        //Arrange
        var cmd = CreateCommand();

        //Act
        var name = cmd.Name;

        //Assert
        Assert.IsAssignableFrom<string>(name);
    }

    [Fact]
    public void Tooltip()
    {
        //Arrange
        var cmd = CreateCommand();

        //Act
        var tip = cmd.Tooltip;

        //Assert
        Assert.IsAssignableFrom<string>(tip);
    }

    [Fact]
    public void UserId()
    {
        //Arrange
        var cmd = CreateCommand();

        //Act
        var id = cmd.CreatorId;

        //Assert
        Assert.IsAssignableFrom<int>(id);
    }
}