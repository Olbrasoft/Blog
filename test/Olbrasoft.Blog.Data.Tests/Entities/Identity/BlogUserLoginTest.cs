using System;
using Microsoft.AspNetCore.Identity;
using Olbrasoft.Data.Entities.Identity;

namespace Olbrasoft.Blog.Data.Entities.Identity;

public class BlogUserLoginTest
{
    [Fact]
    public void Instance_Inherits_From_IdentityUserLogin_Of_Integer()
    {
        var type = typeof(IdentityUserLogin<int>);

        var login = new UserLogin();

        Assert.IsAssignableFrom(type, login);
    }

    [Fact]
    public void Instance_Implement_Interface_IHaveCreated()
    {
        var type = typeof(IHaveCreated);

        var login = new UserLogin();

        Assert.IsAssignableFrom(type, login);
    }

    [Fact]
    public void Created()
    {
        var awesomeCreated = DateTime.Now;

        var login = new UserLogin { Created = awesomeCreated };

        Assert.Equal(expected: awesomeCreated, actual: login.Created);
    }
}