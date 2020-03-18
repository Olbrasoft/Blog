using Microsoft.AspNetCore.Identity;
using System;
using Xunit;

namespace Olbrasoft.Blog.Data.Entities.Identity
{
    public class BlogRoleClaimTest
    {
        [Fact]
        public void Instance_Inherits_From_IdentityRoleClaim_of_Integer()
        {
            var type = typeof(IdentityRoleClaim<int>);

            var claim = new BlogRoleClaim();

            Assert.IsAssignableFrom(type, claim);
        }

        [Fact]
        public void Instance_Implement_Interface_IHaveCreated()
        {
            var type = typeof(IHaveCreated);

            var claim = new BlogRoleClaim();

            Assert.IsAssignableFrom(type, claim);
        }

        [Fact]
        public void Created()
        {
            var awesomeCreated = DateTime.Now;

            var claim = new BlogRoleClaim { Created = awesomeCreated };

            Assert.Equal(expected: awesomeCreated, actual: claim.Created);
        }
    }
}