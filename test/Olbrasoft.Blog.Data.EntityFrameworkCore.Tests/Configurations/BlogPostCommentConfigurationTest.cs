using Olbrasoft.Blog.Data.Entities;
using Xunit;

namespace Olbrasoft.Blog.Data.EntityFrameworkCore.Configurations
{
    public class BlogPostCommentConfigurationTest
    {
        [Fact]
        public void Inherit_From_BlogTypeConfiguration_Of_BlogPostComment()
        {
            //Arrange
            var type = typeof(BlogTypeConfiguration<Comment>);

            //Act
            var config = new CommentConfiguration();

            //Assert
            Assert.IsAssignableFrom(type, config);
        }
    }
}