namespace Olbrasoft.Blog.Data.Queries.CategoryQueries;

public class CategoriesByUserIdQueryTest
{
    [Fact]
    public void Instance_Implement_Interface_IRequest_Of()
    {
        //Arrange
        var type = typeof(IRequest<IPagedResult<CategoryOfUserDto>>);
        var processorMock = new Mock<IQueryProcessor>();

        //Act
        var query = new CategoriesByUserIdQuery(processorMock.Object);

        //Assert
        Assert.IsAssignableFrom(type, query);
    }

    [Fact]
    public void Have_Paging()
    {
        var processorMock = new Mock<IQueryProcessor>();
        //Arrange
        var query = new CategoriesByUserIdQuery(processorMock.Object);

        //Act
        var paging = query.Paging;

        //Assert
        Assert.IsAssignableFrom<IPageInfo>(paging);
    }

    [Fact]
    public void Ctor_Dispatcher_ShouldBeAssingableToExpected()
    {
        // Arrange
        var expected = typeof(ByUserIdQuery<IPagedResult<CategoryOfUserDto>>);
        var dispatcher = new Mock<IDispatcher>().Object;
        // Act
        var sut = new CategoriesByUserIdQuery(dispatcher);
        // Assert
        sut.Should().BeAssignableTo(expected);

    }
}