using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Olbrasoft.Blog.Business;
using Olbrasoft.Data.Paging.DataTables;
using System;
using Xunit;

namespace Olbrasoft.Blog.AspNetCore.Mvc.Areas.Administration.Controllers
{
    public class TagsControllerTest
    {
        [Fact]
        public void Inherit_From_Controller()
        {
            //Arrange
            var type = typeof(Controller);

            //Act
            var controller = CreateController();

            //Assert
            Assert.IsAssignableFrom(type, controller);
        }

        private static TagsController CreateController()
        {
            var serviceMock = new Mock<ITagService>();
            var dataTableBuilder = new Mock<IDataTableOptionBuilder>();

            return new TagsController(serviceMock.Object, dataTableBuilder.Object);
        }

        [Fact]
        public async System.Threading.Tasks.Task IndexAsync()
        {
            //Arrange
            var controller = CreateController();

            //Act
            var result = await controller.IndexAsync();

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
            Assert.True(rv == "Administration");
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