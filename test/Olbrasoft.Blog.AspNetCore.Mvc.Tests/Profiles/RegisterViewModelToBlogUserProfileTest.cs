using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Olbrasoft.Blog.AspNetCore.Mvc.Areas.Identity.Models;
using Olbrasoft.Blog.AspNetCore.Mvc.Models;
using Olbrasoft.Blog.Data.Entities.Identity;
using Olbrasoft.Mapping.AutoMapper;
using Xunit;

namespace Olbrasoft.Blog.AspNetCore.Mvc.Profiles
{
    public class RegisterViewModelToBlogUserProfileTest
    {

        [Fact]
        public void Inherit_From_GenericProfile()
        {
            //Arrange
            var type = typeof(GenericProfile<RegisterViewModel,BlogUser>);

            //Act
            var profile = new RegisterViewModelToBlogUserProfile();

            //Assert
            Assert.IsAssignableFrom(type, profile);
        }

    }
}
