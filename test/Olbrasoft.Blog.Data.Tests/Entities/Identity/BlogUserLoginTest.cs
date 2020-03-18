using System;
using Microsoft.AspNetCore.Identity;
using Xunit;

namespace Olbrasoft.Blog.Data.Entities.Identity
{
    public class BlogUserLoginTest
    {
        [Fact]
        public void Instance_Inherits_From_IdentityUserLogin_Of_Integer()
        {
            var type = typeof(IdentityUserLogin<int>);

            var login = new BlogUserLogin();

            Assert.IsAssignableFrom(type, login);
        }

        [Fact]
        public void Instance_Implement_Interface_IHaveCreated()
        {
            var type = typeof(IHaveCreated);

            var login = new BlogUserLogin();

            Assert.IsAssignableFrom(type, login);
        }

        [Fact]
        public void Created()
        {
            var awesomeCreated = DateTime.Now;

            var login = new BlogUserLogin { Created = awesomeCreated };

            Assert.Equal(expected: awesomeCreated, actual: login.Created);
        }

    }
}