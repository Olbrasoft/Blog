using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using Moq;
using Olbrasoft.Blog.Business;
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

            var postServiceMock = new Mock<IPostService>();

            var categoryServiceMock = new Mock<ICategoryService>();

            var tagServiceMock = new Mock<ITagService>();

            var commentServiceMock = new Mock<ICommentService>();

            var stringLocalizer = new Mock<IStringLocalizer<HomeController>>();

            //Act
            var controller = new HomeController(loggerMock.Object, postServiceMock.Object, categoryServiceMock.Object, tagServiceMock.Object, commentServiceMock.Object, stringLocalizer.Object);

            //Assert
            Assert.IsAssignableFrom(type, controller);
        }
    }
}