using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Olbrasoft.Blog.AspNetCore.Mvc.Areas.Identity.Controllers
{
    public class PostsControllerTest
    {
        [Fact]
        public void Inherit_From_Controller()
        {
            //Arrange
            var type = typeof(Controller);

            //Act
            PostsController controller = CreateController();

            //Assert
            Assert.IsAssignableFrom(type, controller);
        }

        private static PostsController CreateController()
        {
            return new PostsController();
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
        public void Area_Attribute ()
        {
            //Arrange
            var attribute = (AreaAttribute)Attribute.GetCustomAttribute(typeof(PostsController), typeof(AreaAttribute));

            //Act
            var rv = attribute.RouteValue;

            //Assert
            Assert.True(rv == "Identity");

        }



    }
}
