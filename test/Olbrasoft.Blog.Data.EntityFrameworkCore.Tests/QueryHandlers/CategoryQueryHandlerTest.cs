using Moq;
using Olbrasoft.Blog.Data.Dtos;
using Olbrasoft.Blog.Data.Dtos.CategoryDtos;
using Olbrasoft.Blog.Data.EntityFrameworkCore.QueryHandlers.CategoryQueryHandlers;
using Olbrasoft.Blog.Data.Queries;
using Olbrasoft.Blog.Data.Queries.CategoryQueries;
using Olbrasoft.Data.Cqrs.EntityFrameworkCore;
using Olbrasoft.Dispatching.Common;
using Olbrasoft.Mapping;
using System.Threading.Tasks;
using Xunit;

namespace Olbrasoft.Blog.Data.EntityFrameworkCore.QueryHandlers
{
    public class CategoryQueryHandlerTest
    {
        [Fact]
        public void Instance_Inherit_From_Handler()
        {
            //Arrange
            var type = typeof(QueryHandler<CategoryQuery, CategoryOfUserDto>);

            //Act
            var handler = CreateHandler();

            //Assert
            Assert.IsAssignableFrom(type, handler);
        }

        private static CategoryQueryHandler CreateHandler()
        {
            var ctx = new InMemoryDbContextFactory().CreateContext();
            var projectorMock = ProjectorMock();

            return new CategoryQueryHandler(projectorMock.Object, ctx);
        }

        private static Mock<IProjector> ProjectorMock()
        {
            return new Mock<IProjector>();
        }
    }
}