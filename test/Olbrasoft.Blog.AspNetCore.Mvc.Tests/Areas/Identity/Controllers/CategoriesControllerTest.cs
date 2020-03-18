using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Olbrasoft.Blog.AspNetCore.Mvc.Areas.Identity.Models;
using Olbrasoft.Blog.Business;
using System.Reflection;
using System.Security.Claims;
using System.Threading.Tasks;
using Xunit;

namespace Olbrasoft.Blog.AspNetCore.Mvc.Areas.Identity.Controllers
{
    public class CategoriesControllerTest
    {
        [Fact]
        public void Inherit_From_Controller()
        {
            //Arrange
            var type = typeof(Controller);

            //Act
            CategoriesController controller = CreateController();

            //Assert
            Assert.IsAssignableFrom(type, controller);
        }

        private static CategoriesController CreateController()
        {
            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name, "example name"),
                new Claim(ClaimTypes.NameIdentifier, "1"),
                new Claim("custom-claim", "example claim value"),
            }, "mock"));

            var serviceMock = new Mock<ICategoryService>();
            serviceMock.Setup(p => p.ExistsAsync()).Returns(Task.FromResult(false));
            //var fakeUserManager = new FakeUserManager();

            serviceMock.Setup(p => p.SaveAsync(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>()))
                .Returns(Task.FromResult(true));

            var controller = new CategoriesController(serviceMock.Object);
            controller.ControllerContext = new ControllerContext();
            controller.ControllerContext.HttpContext = new DefaultHttpContext { User = user };
            return controller;
        }

        [Fact]
        public void Index()
        {
            //Arrange
            var controller = CreateController();

            //Act
            var result = controller.Index();

            //Assert
            Assert.IsAssignableFrom<Task<IActionResult>>(result);
        }

        [Fact]
        public async Task Save()
        {
            //Arrange
            var controller = CreateController();
            var model = new CategoriesViewModel();

            //Act
            var result = await controller.Save(model);

            //Assert
            Assert.IsAssignableFrom<IActionResult>(result);
        }

        [Fact]
        public void Save_Have_HttpPostAttribute()
        {
            var method = typeof(CategoriesController).GetMethod("Save");

            //Act
            var attribute = (HttpPostAttribute)method.GetCustomAttribute(typeof(HttpPostAttribute));

            //   Assert.Contains("Attr", attribute.Name);

            //Assert
            Assert.IsAssignableFrom<HttpPostAttribute>(attribute);
        }

        [Fact]
        public async Task Exists()
        {
            //Arrange
            var controller = CreateController();

            //Act
            var result = await controller.NotExists(0, "");

            //Assert
            Assert.IsAssignableFrom<JsonResult>(result);
        }


      


    }
}