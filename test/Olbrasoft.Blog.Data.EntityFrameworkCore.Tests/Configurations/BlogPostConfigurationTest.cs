using Olbrasoft.Blog.Data.Entities;
using Xunit;

namespace Olbrasoft.Blog.Data.EntityFrameworkCore.Configurations
{
    public class BlogPostConfigurationTest
    {
        [Fact]
        public void Inherit_from_BlogTypeConfiguration()
        {
            //Arrange
            var type = typeof(BlogTypeConfiguration<Post>);

            //Act
            var config = new BlogPostConfiguration();
            
            //Assert
            Assert.IsAssignableFrom(type, config);


        }
    }
}
