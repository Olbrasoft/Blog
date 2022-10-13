namespace Olbrasoft.Blog.Data.Queries.CategoryQueries;
public class CategoriesQueryTest
{

    [Fact]
    public void CategoriesQuery_Inherit_From_Request_Of_IEnumerable_Of_CategorySmallDto()
    {
        //Arrange
        var processorMock = new Mock<IQueryProcessor>();

        //Act
        var query = new CategoriesQuery(processorMock.Object);

        //Assert
        Assert.IsAssignableFrom<BaseQuery<IEnumerable<CategorySmallDto>>>(query);
    }

}
