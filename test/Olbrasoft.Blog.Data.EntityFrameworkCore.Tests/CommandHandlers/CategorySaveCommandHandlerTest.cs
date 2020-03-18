using Olbrasoft.Blog.Data.Commands;
using System.Threading.Tasks;
using Xunit;

namespace Olbrasoft.Blog.Data.EntityFrameworkCore.CommandHandlers
{
    public class CategorySaveCommandHandlerTest
    {
        [Fact]
        public void Inherit_From_Handler()
        {
            //Arrange
            var type = typeof(Handler<CategorySaveCommand, bool>);

            //Act
            var handler = CreateHandler();

            //Assert
            Assert.IsAssignableFrom(type, handler);
        }

        private static CategorySaveCommandHandler CreateHandler()
        {
            var ctx = new InMemoryDbContextFactory().CreateContext();

            return new CategorySaveCommandHandler(ctx);
        }

        [Fact]
        public async Task Handle()
        {
            //Arrange
            var handler = CreateHandler();
            var cmd = new CategorySaveCommand();


            //Act
            var result = await handler.Handle(cmd, default);

            //Assert
            Assert.IsAssignableFrom<bool>(result);
        }
    }
}