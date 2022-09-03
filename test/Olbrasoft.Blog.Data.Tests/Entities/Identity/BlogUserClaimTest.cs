using System;
using Microsoft.AspNetCore.Identity;
using Olbrasoft.Data.Entities.Identity;

namespace Olbrasoft.Blog.Data.Entities.Identity;

public class BlogUserClaimTest
{
    [Fact]
    public void Instance_Inherits_From_IdentityUserClaim_Of_Integer()
    {
        var type = typeof(IdentityUserClaim<int>);

        var claim = new UserClaim();

        Assert.IsAssignableFrom(type, claim);
    }

    [Fact]
    public void Instance_Implement_Interface_IHaveCreated()
    {
        var type = typeof(IHaveCreated);

        var claim = new UserClaim();

        Assert.IsAssignableFrom(type, claim);

        claim.Created = DateTime.Now;
    }
}