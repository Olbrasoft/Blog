using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Olbrasoft.Blog.AspNetCore.Mvc.Areas.Administration.Models
{
    public class LoginViewModelTest
    {
        [Fact]
        public void Have_Email()
        {
            //Arrange
            var model = new LoginViewModel();

            //Act
            var email = model.Email;

            //Assert
            Assert.IsAssignableFrom<string>(email);
        }

        [Fact]
        public void Have_Password()
        {
            //Arrange
            var model = new LoginViewModel();

            //Act
            var password = model.Password;

            //Assert
            Assert.IsAssignableFrom<string>(password);
        }
    }
}