using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Olbrasoft.Blog.AspNetCore.Mvc.Areas.Administration.Controllers
{
    public class HomeControllerTest
    {
        [Fact]
        public void Instance_Inherit_From_Controller()
        {
            //Arrange
            var type = typeof(Controller);

            //Act
            var controller = new Controllers.HomeController();

            //Assert
            Assert.IsAssignableFrom(type, controller);
        }
    }
}