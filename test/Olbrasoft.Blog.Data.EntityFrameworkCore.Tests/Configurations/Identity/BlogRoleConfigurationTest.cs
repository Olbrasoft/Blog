using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Olbrasoft.Blog.Data.Entities.Identity;
using Xunit;

namespace Olbrasoft.Blog.Data.EntityFrameworkCore.Configurations.Identity
{
    public class BlogRoleConfigurationTest
    {
        [Fact]
        public void Instance_Inherit_From_BlogTypeConfiguration_Of_BlogRole()
        {
            var type = typeof(BlogTypeConfiguration<BlogRole>);

            var config = new BlogRoleConfiguration();

            Assert.IsAssignableFrom(type,config);
        }
    }
}
