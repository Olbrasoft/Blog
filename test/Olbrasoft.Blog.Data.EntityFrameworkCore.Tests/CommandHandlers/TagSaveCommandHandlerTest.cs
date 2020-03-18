using Olbrasoft.Blog.Data.Commands;
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
            var type = typeof(Handler<TagSaveCommand, bool>);

            //Act
            var handler = CreateHandler();

            //Assert
            Assert.IsAssignableFrom(type, handler);
        }

        private static TagSaveCommandHandler CreateHandler()
        {
            var ctx = new InMemoryDbContextFactory().CreateContext();

            return new TagSaveCommandHandler(ctx);
        }
    }
}
