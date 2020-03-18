using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Olbrasoft.Blog.Data.Entities.Identity;
using Xunit;

namespace Olbrasoft.Blog.Data.EntityFrameworkCore.Configurations.Identity
{
    public class BlogRoleClaimConfigurationTest
    {
        [Fact]
        public void Instance_Inherit_From_BogTypeConfiguration_Of_BlogRoleClaim()
        {
            //Arrange
            var type = typeof(BlogTypeConfiguration<BlogRoleClaim>);

            //Act
            var config = new BlogRoleClaimConfiguration();

            //Assert
            Assert.IsAssignableFrom(type,config);
        }
    }
}
