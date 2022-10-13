namespace Olbrasoft.Blog.Data.Queries.CategoryQueries;

public class CategoryQueryTest
{
    [Fact]
    public void Instance_Implement_Interface_IRequest_Of_CategoryDto()
    {
        //Arrange
        var type = typeof(BaseQuery<CategoryOfUserDto>);

        //Act
        var query = CreateQuery();

        //Assert
        Assert.IsAssignableFrom(type, query);
    }

    private static CategoryQuery CreateQuery()
    {
        var processorMock = new Mock<IQueryProcessor>();

        return new CategoryQuery(processorMock.Object);
    }

    [Fact]
    public void Have_Id()
    {
        //Arrange
        var query = CreateQuery();

        //Act
        var id = query.Id;

        //Assert
        Assert.IsAssignableFrom<int>(id);
    }

    [Fact]
    public void Ctor_Dispatcher_ShouldByAssingableToByIdQuery()
    {
        // Arrange
        var dispatcher = new Mock<IDispatcher>().Object;
        // Act
        var sut = new CategoryQuery(dispatcher);
        // Assert
        sut.Should().BeAssignableTo<ByIdQuery<CategoryOfUserDto>>();
    }

}