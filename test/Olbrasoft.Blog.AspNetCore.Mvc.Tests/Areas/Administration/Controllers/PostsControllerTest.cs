using Microsoft.AspNetCore.Mvc;
using Moq;
using Olbrasoft.Blog.Business;
using Olbrasoft.Data.Paging.DataTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Olbrasoft.Blog.AspNetCore.Mvc.Areas.Administration.Controllers
{
    public class PostsControllerTest
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

        private static PostsController CreateController()
        {
            var categoryServiceMock = new Mock<ICategoryService>();
            var tagServiceMock = new Mock<ITagService>();
            var postServiceMock = new Mock<IPostService>();
            var dataTableOptionBuilderMock = new Mock<IDataTableOptionBuilder>();

            return new PostsController(categoryServiceMock.Object, tagServiceMock.Object, postServiceMock.Object, dataTableOptionBuilderMock.Object);
        }

        [Fact]
        public async Task IndexAsync()
        {
            //Arrange
            var controller = CreateController();

            //Act
            var result = await controller.IndexAsync();

            //Assert
            Assert.IsAssignableFrom<IActionResult>(result);
        }

        [Fact]
        public void Area_Attribute()
        {
            //Arrange
            var attribute = (AreaAttribute)Attribute.GetCustomAttribute(typeof(PostsController), typeof(AreaAttribute));

            //Act
            var rv = attribute.RouteValue;

            //Assert
            Assert.True(rv == "Administration");
        }
    }
}