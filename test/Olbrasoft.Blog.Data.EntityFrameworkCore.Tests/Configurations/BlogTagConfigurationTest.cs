using Olbrasoft.Blog.Data.Entities;
using Xunit;

namespace Olbrasoft.Blog.Data.EntityFrameworkCore.Configurations
{
    public class BlogTagConfigurationTest
    {
        [Fact]
        public void Inherit_From_BlogTypeConfiguration_Of_BlogTag()
        {
            //Arrange
            var type = typeof(BlogTypeConfiguration<Tag>);

            //Act
            var config = new BlogTagConfiguration();

            //Assert
            Assert.IsAssignableFrom(type, config);
        }        
    }
}
