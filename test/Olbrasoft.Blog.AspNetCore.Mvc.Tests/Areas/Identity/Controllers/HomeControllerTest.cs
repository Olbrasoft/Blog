using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Olbrasoft.Blog.AspNetCore.Mvc.Areas.Identity.Controllers
{
    public class HomeControllerTest
    {
        [Fact]
        public void Instance_Inherit_From_Controller()
        {
            //Arrange
            var type = typeof(Controller);

            //Act
            var controller = new Olbrasoft.Blog.AspNetCore.Mvc.Areas.Identity.Controllers.HomeController();

            //Assert
            Assert.IsAssignableFrom(type, controller);

        }
        


    }
}
