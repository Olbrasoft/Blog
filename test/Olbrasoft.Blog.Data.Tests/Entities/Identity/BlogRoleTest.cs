using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Olbrasoft.Blog.Data.Entities.Identity;

public class BlogRoleTest
{
    [Fact]
    public void Instance_Inherits_From_IdentityRole_Of_Integer()
    {
        var type = typeof(IdentityRole<int>);

        var role = new BlogRole();

        Assert.IsAssignableFrom(type, role);
    }

    [Fact]
    public void Created()
    {
        var awesomeCreated = DateTime.Now;

        var role = new BlogRole { Created = awesomeCreated };

        Assert.Equal(expected: awesomeCreated, actual: role.Created);
    }

    [Fact]
    public void Instance_Implement_Interface_IHaveCreated()
    {
        var type = typeof(IHaveCreated);

        var role = new BlogRole();

        Assert.IsAssignableFrom(type, role);
    }

    [Fact]
    public void Have_ToUsers()
    {
        //Arrange
        var role = new BlogRole();

        //Act
        var toUsers = role.ToUsers;

        //Assert
        Assert.IsAssignableFrom<IEnumerable<BlogUserToRole>>(toUsers);
    }
}