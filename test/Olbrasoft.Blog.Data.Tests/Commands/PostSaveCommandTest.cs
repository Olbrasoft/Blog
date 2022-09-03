namespace Olbrasoft.Blog.Data.Commands;
public class PostSaveCommandTest
{
    [Fact]
    public void PostSaveCommand_Inherit_From_CreatorSaveCommand()
    {
        //Arrange
        var dispatcher = CreateDispatcher();

        //Act
        var command = new PostSaveCommand(dispatcher);

        //Assert
        Assert.IsAssignableFrom<CreatorSaveCommand>(command);
    }

    private static IDispatcher CreateDispatcher()
    {
        var dispatcherMock = new Mock<IDispatcher>();
        return dispatcherMock.Object;
    }


    [Fact]
    public void PostSaveCommand_CategoryId_Is_Integer()
    {
        //Arrange
        var command = new PostSaveCommand(CreateDispatcher());

        //Act
        var categoryId = command.CategoryId;

        //Assert
        Assert.IsAssignableFrom<int>(categoryId);

    }

}
