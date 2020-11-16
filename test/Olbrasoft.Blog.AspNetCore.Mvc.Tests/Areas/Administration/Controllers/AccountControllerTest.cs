using Microsoft.AspNetCore.Mvc;
using Moq;
using Olbrasoft.Blog.AspNetCore.Mvc.Areas.Administration.Models;
using Olbrasoft.Mapping;
using System.Threading.Tasks;
using Xunit;

namespace Olbrasoft.Blog.AspNetCore.Mvc.Areas.Administration.Controllers
{
    public class AccountControllerTest
    {
        [Fact]
        public void Inherit_From_Controller()
        {
            //Arrange

            //Act
            var controller = AccountController();

            //Assert
            Assert.IsAssignableFrom<Controller>(controller);
        }

        private static AccountController AccountController()
        {
            var mockMapper = new Mock<IMapper>();

            var controller = new AccountController(mockMapper.Object, new FakeUserManager(), new FakeSignInManager());
            return controller;
        }

        [Fact]
        public void Register()
        {
            //Arrange
            var controller = AccountController();

            //Act
            var result = controller.Register();

            //Assert
            Assert.IsAssignableFrom<IActionResult>(result);
        }

        [Fact]
        public void Register_Model()
        {
            //Arrange
            var controller = AccountController();
            var model = new RegisterViewModel();

            //Act
            var result = controller.Register(model);

            //Assert
            Assert.IsAssignableFrom<Task<IActionResult>>(result);
        }
    }
}