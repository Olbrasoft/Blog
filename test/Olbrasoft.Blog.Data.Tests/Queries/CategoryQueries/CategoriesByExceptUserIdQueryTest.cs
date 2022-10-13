namespace Olbrasoft.Blog.Data.Queries.CategoryQueries;
public class CategoriesByExceptUserIdQueryTest
{

    [Fact]
    public void CategoriesByExceptUserIdQuery_Inherit_From_ItemsExceptUserIdQuery_Of_IPagedResult_Of_CategoryOfUsersDto()
    {
        //Arrange
        var processor = new Mock<IQueryProcessor>();

        //Act
        var query = new CategoriesByExceptUserIdQuery(processor.Object);

        //Assert
        Assert.IsAssignableFrom<ExceptUserIdQuery<IPagedResult<CategoryOfUsersDto>>>(query);
    }

    [Fact]
    public void Ctor_Dispatcher_ShouldBeAssingableExpected()
    {
        // Arrange
        var dispatcher = new Mock<IDispatcher>().Object;
        // Act
        var sut = new CategoriesByExceptUserIdQuery(dispatcher);
        // Assert
        sut.Should().BeAssignableTo<ExceptUserIdQuery<IPagedResult<CategoryOfUsersDto>>>();
    }

}
