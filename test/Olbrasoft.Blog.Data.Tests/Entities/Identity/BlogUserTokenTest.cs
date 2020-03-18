using System;
using Microsoft.AspNetCore.Identity;
using Xunit;

namespace Olbrasoft.Blog.Data.Entities.Identity
{
    public class BlogUserTokenTest
    {
        [Fact]
        public void Instance_Inherits_From_IdentityUserToken_Of_Integer()
        {
            var type = typeof(IdentityUserToken<int>);

            var token = new BlogUserToken();

            Assert.IsAssignableFrom(type, token);
        }

        [Fact]
        public void Instance_Implement_Interface_IHaveCreated()
        {
            var type = typeof(IHaveCreated);

            var token = new BlogUserToken();
            
            Assert.IsAssignableFrom(type, token);

            token.Created = DateTime.Now;
        }
    }
}