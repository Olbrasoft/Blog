using Olbrasoft.Blog.Data.Entities.Identity;
using Xunit;

namespace Olbrasoft.Blog.Data.EntityFrameworkCore.Configurations.Identity
{
    public class BlogUserConfigurationTest
    {
        [Fact]
        public void Instance_Inherit_From_BlogIdentityConfiguration()
        {
            var type = typeof(BlogTypeConfiguration<BlogUser>);

            var configuration = new BlogUserConfiguration();

            Assert.IsAssignableFrom(type, configuration);
        }
    }
}