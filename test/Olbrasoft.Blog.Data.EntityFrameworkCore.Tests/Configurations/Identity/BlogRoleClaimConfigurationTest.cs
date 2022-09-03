using Olbrasoft.Data.Entities.Identity;
using Xunit;

namespace Olbrasoft.Blog.Data.EntityFrameworkCore.Configurations.Identity
{
    public class BlogRoleClaimConfigurationTest
    {
        [Fact]
        public void Instance_Inherit_From_BogTypeConfiguration_Of_BlogRoleClaim()
        {
            //Arrange
            var type = typeof(BlogTypeConfiguration<RoleClaim>);

            //Act
            var config = new BlogRoleClaimConfiguration();

            //Assert
            Assert.IsAssignableFrom(type,config);
        }
    }
}
