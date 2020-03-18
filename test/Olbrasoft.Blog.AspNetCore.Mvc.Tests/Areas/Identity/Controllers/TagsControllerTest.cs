using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Olbrasoft.Blog.Business;
using System;
using Xunit;

namespace Olbrasoft.Blog.AspNetCore.Mvc.Areas.Identity.Controllers
{
    public class TagsControllerTest
    {
        [Fact]
        public void Inherit_From_Controller()
        {
            //Arrange
            var type = typeof(Controller);

            //Act
            TagsController controller = CreateController();

            //Assert
            Assert.IsAssignableFrom(type, controller);
        }

        private static TagsController CreateController()
        {
            var serviceMock = new Mock<ITagService>();

            return new TagsController(serviceMock.Object);
        }

        [Fact]
        public void Index()
        {
            //Arrange
            var controller = CreateController();

            //Act
            var result = controller.Index();

            //Assert
            Assert.IsAssignableFrom<IActionResult>(result);
        }

        [Fact]
        public void Attribute_Area()
        {
            //Arrange
            var attribute = (AreaAttribute)Attribute.GetCustomAttribute(typeof(TagsController), typeof(AreaAttribute));

            //Act
            var rv = attribute.RouteValue;

            //Assert
            Assert.True(rv == "Identity");
        }

        [Fact]
        public void Authorize_Attribute()
        {
            //Arrange
            var controllerType = typeof(TagsController);
            var attributeType = typeof(AuthorizeAttribute);

            //Act
            var attribute = (AuthorizeAttribute)Attribute.GetCustomAttribute(controllerType, attributeType);

            //Assert
            Assert.NotNull(attribute);
        }


    }
}
