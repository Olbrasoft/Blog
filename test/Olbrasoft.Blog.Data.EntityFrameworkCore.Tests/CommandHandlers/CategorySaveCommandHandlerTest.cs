using Microsoft.EntityFrameworkCore;
using Moq;
using Olbrasoft.Blog.Data.Commands;
using Olbrasoft.Data.Cqrs;
using Xunit;

namespace Olbrasoft.Blog.Data.EntityFrameworkCore.CommandHandlers
{
    public class CategorySaveCommandHandlerTest
    {
        [Fact]
        public void Inherit_From_Handler()
        {
            //Arrange
            var type = typeof(CommandHandler<CategorySaveCommand, bool>);

            //Act
            var handler = CreateHandler();

            //Assert
            Assert.IsAssignableFrom(type, handler);
        }

        private static CategorySaveCommandHandler CreateHandler()
        {
            var ctx = new InMemoryDbContextFactory().CreateContext();
            var mapperMock = new Mock<Mapping.IMapper>();

            return new CategorySaveCommandHandler(mapperMock.Object, ctx);
        }
    }
}