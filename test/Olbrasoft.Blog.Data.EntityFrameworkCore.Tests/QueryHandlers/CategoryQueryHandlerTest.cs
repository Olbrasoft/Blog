using Olbrasoft.Blog.Data.Dtos;
using Olbrasoft.Blog.Data.Queries;
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
            var type = typeof(Handler<CategoryQuery, CategoryDto>);

            //Act
            var handler = CreateHandler();

            //Assert
            Assert.IsAssignableFrom(type, handler);
        }

        private static CategoryQueryHandler CreateHandler()
        {
            var ctx = new InMemoryDbContextFactory().CreateContext();
            return new CategoryQueryHandler(ctx);
        }

        [Fact]
        public async Task Handle()
        {
            var ctx = new InMemoryDbContextFactory().CreateContext();

            ctx.Categories.Add(new Entities.Category { Id = 3 });
            ctx.SaveChanges();

            //Arrange
            var handler = new CategoryQueryHandler(ctx);
            var query = new CategoryQuery() { Id = 3 };

            //Act
            var result = await handler.Handle(query, default);

            //Assert
            Assert.IsAssignableFrom<CategoryDto>(result);
        }
    }
}