using Xunit;

namespace Olbrasoft.Blog.AspNetCore.Mvc.Areas.Identity.Models
{
    public class RegisterViewModelTest
    {
        //[Fact]
        //public void Have_UserName()
        //{
        //    //Arrange
        //    var model = new RegisterViewModel();

        //    //Act
        //    var name = model.UserName;

        //    //Assert
        //    Assert.IsAssignableFrom<string>(name);
        //}

        [Fact]
        public void Have_Email()
        {
            //Arrange
            var model = new RegisterViewModel();

            //Act
            var email = model.Email;

            //Assert
            Assert.IsAssignableFrom<string>(email);
        }

        [Fact]
        public void Have_Password()
        {
            //Arrange
            var model = new RegisterViewModel();

            //Act
            var password = model.Password;

            //Assert
            Assert.IsAssignableFrom<string>(password);
        }

        [Fact]
        public void Have_Confirm_Password()
        {
            //Arrange
            var model = new RegisterViewModel();

            //Act
            var confirmPassword = model.ConfirmPassword;

            //Assert
            Assert.IsAssignableFrom<string>(confirmPassword);
        }

        [Fact]
        public void Have_FirstName()
        {
            //Arrange
            var model = new RegisterViewModel();

            //Act
            var name = model.FirstName;

            //Assert
            Assert.IsAssignableFrom<string>(name);
        }

        [Fact]
        public void Have_LastName()
        {
            //Arrange
            var model = new RegisterViewModel();

            //Act
            var name = model.LastName;

            //Assert
            Assert.IsAssignableFrom<string>(name);
        }
    }
}