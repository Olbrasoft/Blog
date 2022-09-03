using Olbrasoft.Blog.Data.Entities;
using Xunit;

namespace Olbrasoft.Blog.Data.EntityFrameworkCore.Configurations
{
    public class BlogPostToTagConfigurationTest
    {
        [Fact]
        public void Inherit_From_BlogTypeConfiguration_Of_BlogPostToTag()
        {
            //Arrange
            var type = typeof(BlogTypeConfiguration<PostToTag>);

            //Act
            var config = new BlogPostToTagConfiguration();    

            //Assert
            Assert.IsAssignableFrom(type, config);
        }
    }
}
