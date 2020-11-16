using Moq;
using Olbrasoft.Blog.Data.Dtos.CategoryDtos;
using Olbrasoft.Blog.Data.Queries.CategoryQueries;
using Olbrasoft.Data.Paging;
using Olbrasoft.Dispatching.Common;
using Xunit;

namespace Olbrasoft.Blog.Data.Queries
{
    public class CategoriesByUserIdQueryTest
    {
        [Fact]
        public void Instance_Implement_Interface_IRequest_Of()
        {
            //Arrange
            var type = typeof(IRequest<IPagedResult<CategoryOfUserDto>>);
            var dispatcherMock = new Mock<IDispatcher>();

            //Act
            var query = new CategoryQueries.CategoriesByUserIdQuery(dispatcherMock.Object);

            //Assert
            Assert.IsAssignableFrom(type, query);
        }

        [Fact]
        public void Have_Paging()
        {
            var dispatcherMock = new Mock<IDispatcher>();
            //Arrange
            var query = new CategoriesByUserIdQuery(dispatcherMock.Object);

            //Act
            var paging = query.Paging;

            //Assert
            Assert.IsAssignableFrom<IPageInfo>(paging);
        }
    }
}