using Olbrasoft.Data.Entities.Identity;
using Xunit;

namespace Olbrasoft.Blog.Data.EntityFrameworkCore.Configurations.Identity
{
    public class BlogUserClaimConfigurationTest
    {
        [Fact]
        public void Instance_Inherit_From_BlogTypeConfiguration_Of_BlogUserClaim()
        {
            //Arrange
            var type = typeof(BlogTypeConfiguration<UserClaim>);

            //Act
            var config = new BlogUserClaimConfiguration();

            //Assert
            Assert.IsAssignableFrom(type, config);
        }
    }
}