using Moq;
using Olbrasoft.Blog.Data.Commands;
using Olbrasoft.Dispatching;
using Xunit;

namespace Olbrasoft.Blog.Data.EntityFrameworkCore.CommandHandlers
{
    public class TagSaveCommandHandlerTest
    {
        [Fact]
        public void Inherit_From_Handler()
        {
            //Arrange
            var type = typeof(IRequestHandler<TagSaveCommand, bool>);

            //Act
            var handler = CreateHandler();

            //Assert
            Assert.IsAssignableFrom(type, handler);
        }

        private static TagSaveCommandHandler CreateHandler()
        {
            var ctx = new InMemoryDbContextFactory().CreateContext();
            var mapperMock = new Mock<Mapping.IMapper>();

            return new TagSaveCommandHandler(mapperMock.Object, ctx);
        }
    }
}