using System.Collections.Generic;

namespace Olbrasoft.Blog.Data.Queries.CategoryQueries;
public class CategoriesQueryTest
{

    [Fact]
    public void CategoriesQuery_Inherit_From_Request_Of_IEnumerable_Of_CategorySmallDto()
    {
        //Arrange
        var dispatcherMock = new Mock<IDispatcher>();

        //Act
        var query = new CategoriesQuery(dispatcherMock.Object);

        //Assert
        Assert.IsAssignableFrom<Request<IEnumerable<CategorySmallDto>>>(query);
    }

}
