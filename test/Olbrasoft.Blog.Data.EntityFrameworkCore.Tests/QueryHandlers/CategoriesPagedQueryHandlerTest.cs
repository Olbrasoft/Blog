using Olbrasoft.Blog.Data.Dtos;
using Olbrasoft.Blog.Data.Queries;
using Olbrasoft.Paging;
using System.Threading.Tasks;
using Xunit;

namespace Olbrasoft.Blog.Data.EntityFrameworkCore.QueryHandlers
{
    public class CategoriesPagedQueryHandlerTest
    {
        [Fact]
        public void Inherit_From_Handler_Of_CategoriesPagedQuery_Comma_IResultWithTotelCount_Of_CategoryDto()
        {
            //Arrange
            var type = typeof(Handler<CategoriesPagedQuery, IResultWithTotalCount<CategoryDto>>);

            //Act
            var handler = CreateHandler();

            //Assert
            Assert.IsAssignableFrom(type, handler);
        }

        private static CategoriesPagedQueryHandler CreateHandler()
        {
            var context = new InMemoryDbContextFactory().CreateContext();

            return new CategoriesPagedQueryHandler(context);
        }

        [Fact]
        public async Task HandleAsync()
        {
            //Arrange
            var handler = CreateHandler();
            var query = new CategoriesPagedQuery();

            //Act
            var result = await handler.Handle(query, default);

            //Assert
            Assert.IsAssignableFrom<IResultWithTotalCount<CategoryDto>>(result);
        }
    }
}