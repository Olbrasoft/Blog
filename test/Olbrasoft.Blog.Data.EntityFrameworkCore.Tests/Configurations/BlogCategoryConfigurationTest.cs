using Olbrasoft.Blog.Data.Entities;
using Xunit;

namespace Olbrasoft.Blog.Data.EntityFrameworkCore.Configurations
{
    public class BlogCategoryConfigurationTest
    {
        [Fact]
        public void Inherit_From_BlogTypeConfiguration_Of_BlogCategory()
        {
            //Arrange
            var type = typeof(BlogTypeConfiguration<Category>);

            //Act
            var config = new BlogCategoryConfiguration();

            //Assert
            Assert.IsAssignableFrom(type,config);
        }
    }
}
