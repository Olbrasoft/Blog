using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace Olbrasoft.Blog.AspNetCore.Mvc.Controllers
{
    public class HomeControllerTest
    {
        [Fact]
        public void Inherit_From_Controller()
        {
            //Arrange
            var type = typeof(Controller);

            var loggerMock = new Mock<ILogger<HomeController>>();

            //Act
            var controller = new HomeController( loggerMock.Object);

            //Assert
            Assert.IsAssignableFrom(type, controller);
        }
    }
}
