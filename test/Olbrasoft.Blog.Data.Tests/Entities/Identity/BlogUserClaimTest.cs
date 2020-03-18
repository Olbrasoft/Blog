using System;
using Microsoft.AspNetCore.Identity;
using Xunit;

namespace Olbrasoft.Blog.Data.Entities.Identity
{
    public class BlogUserClaimTest
    {
        [Fact]
        public void Instance_Inherits_From_IdentityUserClaim_Of_Integer()
        {
            var type = typeof(IdentityUserClaim<int>);

            var claim = new BlogUserClaim();

            Assert.IsAssignableFrom(type, claim);
        }

        [Fact]
        public void Instance_Implement_Interface_IHaveCreated()
        {
            var type = typeof(IHaveCreated);

            var claim = new BlogUserClaim();

            Assert.IsAssignableFrom(type, claim);

            claim.Created = DateTime.Now;
        }
    }
}