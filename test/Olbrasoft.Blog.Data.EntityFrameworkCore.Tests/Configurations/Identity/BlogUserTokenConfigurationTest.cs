using Olbrasoft.Blog.Data.Entities.Identity;
using Xunit;

namespace Olbrasoft.Blog.Data.EntityFrameworkCore.Configurations.Identity
{
    public class BlogUserTokenConfigurationTest
    {
        [Fact]
        public void Instance_Inherit_From_BlogTypeConfiguration_Of_BlogUserToken()
        {
            //Arrange
            var type = typeof(BlogTypeConfiguration<BlogUserToken>);

            //Act
            var config = new BlogUserTokenConfiguration();

            //Assert
            Assert.IsAssignableFrom(type, config);
        }
    }
}