using MediatR;
using Olbrasoft.Blog.Data.Queries;
using System.Threading.Tasks;
using Xunit;

namespace Olbrasoft.Blog.Data.EntityFrameworkCore.QueryHandlers
{
    public class CategoryExistsQueryHandlerTest
    {
        [Fact]
        public void Instance_Implemen_Interface_IRequestHandler_Of_CategoryQuery_Comma_Bool()
        {
            //Arrange
            var type = typeof(IRequestHandler<CategoryExistsQuery, bool>);

            //Act
            var handler = CreateHandler();

            //Assert
            Assert.IsAssignableFrom(type, handler);
        }

        private static CategoryExistsQueryHandler CreateHandler()
        {
            var context = new InMemoryDbContextFactory().CreateContext();

            return new CategoryExistsQueryHandler(context);
        }

        [Fact]
        public async Task Handle()
        {
            //Arrange
            var handler = CreateHandler();
            var query = new CategoryExistsQuery() { Name = "NotExist" };

            //Act
            var result = await handler.Handle(query, default);

            //Assert
            Assert.False(result);
        }

        [Fact]
        public async Task HandleEmpty()
        {
            //Arrange
            var handler = CreateHandler();
            var query = new CategoryExistsQuery() { Name = string.Empty };

            //Act
            var result = await handler.Handle(query, default);

            //Assert
            Assert.IsAssignableFrom<bool>(result);
        }

        [Fact]
        public async Task HandleExceptId()
        {
            //Arrange
            var handler = CreateHandler();
            var query = new CategoryExistsQuery() { ExceptId = 1, Name = "NotExist" };

            //Act
            var result = await handler.Handle(query, default);

            //Assert
            Assert.IsAssignableFrom<bool>(result);
        }

        [Fact]
        public void Inherit_From_Handler()
        {
            //Arrange
            var type = typeof(Handler<CategoryExistsQuery, bool>);

            //Act
            var handler = CreateHandler();

            //Assert
            Assert.IsAssignableFrom(type, handler);
        }
    }
}