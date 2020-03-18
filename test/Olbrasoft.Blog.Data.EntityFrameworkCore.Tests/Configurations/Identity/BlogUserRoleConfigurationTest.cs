using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Olbrasoft.Blog.Data.Entities.Identity;
using Xunit;

namespace Olbrasoft.Blog.Data.EntityFrameworkCore.Configurations.Identity
{
    public class BlogUserRoleConfigurationTest
    {
        [Fact]
        public void Instance_Inherit_BlogTypeConfiguration_Of_BlogUserRole()
        {
            //Arrange
            var type = typeof(BlogTypeConfiguration<BlogUserToRole>);

            //Act
            var config = new BlogUserRoleConfiguration();

            //Assert
            Assert.IsAssignableFrom(type,config);
        }
    }
}
