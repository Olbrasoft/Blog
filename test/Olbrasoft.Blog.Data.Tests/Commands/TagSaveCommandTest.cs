using Moq;
using Olbrasoft.Dispatching.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Olbrasoft.Blog.Data.Commands
{
    public class TagSaveCommandTest
    {
        [Fact]
        public void Instance_Implement_Interface_IRequest_Of_Bool()
        {
            //Arrange
            var type = typeof(Dispatching.Common.IRequest<bool>);

            //Act
            var cmd = CreateCommand();

            //Assert
            Assert.IsAssignableFrom(type, cmd);
        }

        private static TagSaveCommand CreateCommand()
        {
            var dispatcherMock = new Mock<IDispatcher>();

            return new TagSaveCommand(dispatcherMock.Object);
        }

        [Fact]
        public void Have_Id()
        {
            //Arrange
            var cmd = CreateCommand();

            //Act
            var id = cmd.Id;

            //Assert
            Assert.IsAssignableFrom<int>(id);
        }

        [Fact]
        public void Have_Label()
        {
            //Arrange
            var cmd = CreateCommand();

            //Act
            var label = cmd.Label;

            //Assert
            Assert.IsAssignableFrom<string>(label);
        }

        [Fact]
        public void Have_UserId()
        {
            //Arrange
            var cmd = CreateCommand();

            //Act
            var id = cmd.CreatorId;

            //Assert
            Assert.IsAssignableFrom<int>(id);
        }
    }
}