using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
