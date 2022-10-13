namespace Olbrasoft.Blog.Data.Commands;
public class PostSaveCommandTest
{
    [Fact]
    public void PostSaveCommand_Inherit_From_CreatorSaveCommand()
    {
        //Arrange
        var dispatcher = CreateExecutor();

        //Act
        var command = new PostSaveCommand(dispatcher);

        //Assert
        Assert.IsAssignableFrom<BlogCommand>(command);
    }

    private static ICommandExecutor CreateExecutor()
    {
        var commandExecutor = new Mock<ICommandExecutor>();
        return commandExecutor.Object;
    }


    [Fact]
    public void PostSaveCommand_CategoryId_Is_Integer()
    {
        //Arrange
        var command = new PostSaveCommand(CreateExecutor());
        
        //Act
        var categoryId = command.CategoryId;

        //Assert
        Assert.IsAssignableFrom<int>(categoryId);

    }

}
