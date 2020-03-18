using Olbrasoft.Blog.Data.Entities.Identity;
using Xunit;

namespace Olbrasoft.Blog.Data.EntityFrameworkCore.Configurations.Identity
{
    public class BlogUserLoginConfigurationTest
    {
        [Fact]
        public void Instance_Inherit_From_BlogTypeConfiguration_Of_BlogUserLogin()
        {
            //Arrange
            var type = typeof(BlogTypeConfiguration<BlogUserLogin>);

            //Act
            var config = new BlogUserLoginConfiguration();

            //Assert
            Assert.IsAssignableFrom(type, config);
        }
    }
}