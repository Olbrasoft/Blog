using System;
using Microsoft.AspNetCore.Identity;
using Olbrasoft.Data.Entities.Identity;

namespace Olbrasoft.Blog.Data.Entities.Identity;

public class BlogUserTokenTest
{
    [Fact]
    public void Instance_Inherits_From_IdentityUserToken_Of_Integer()
    {
        var type = typeof(IdentityUserToken<int>);

        var token = new UserToken();

        Assert.IsAssignableFrom(type, token);
    }

    [Fact]
    public void Instance_Implement_Interface_IHaveCreated()
    {
        var type = typeof(IHaveCreated);

        var token = new UserToken();

        Assert.IsAssignableFrom(type, token);

        token.Created = DateTime.Now;
    }
}