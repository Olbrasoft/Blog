using Moq;
using Olbrasoft.Blog.Data.Commands;
using Olbrasoft.Data.Cqrs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Olbrasoft.Blog.Data.EntityFrameworkCore.CommandHandlers
{
    public class TagSaveCommandHandlerTest
    {
        [Fact]
        public void Inherit_From_Handler()
        {
            //Arrange
            var type = typeof(CommandHandler<TagSaveCommand, bool>);

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