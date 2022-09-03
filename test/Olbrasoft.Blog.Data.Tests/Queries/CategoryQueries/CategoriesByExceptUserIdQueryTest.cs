namespace Olbrasoft.Blog.Data.Queries.CategoryQueries;
public class CategoriesByExceptUserIdQueryTest
{

    [Fact]
    public void CategoriesByExceptUserIdQuery_Inherit_From_ItemsExceptUserIdQuery_Of_IPagedResult_Of_CategoryOfUsersDto()
    {
        //Arrange
        var dispatcherMock = new Mock<IDispatcher>();

        //Act
        var query = new CategoriesByExceptUserIdQuery(dispatcherMock.Object);

        //Assert
        Assert.IsAssignableFrom<ItemsExceptUserIdQuery<IPagedResult<CategoryOfUsersDto>>>(query);
    }

}
