using Microsoft.AspNetCore.Identity;
using System;

namespace Olbrasoft.Blog.Data.Entities.Identity;

public class BlogUserToRoleTest
{
    [Fact]
    public void Instance_Inherit_From_IdentityUserRole_Of_Integer()
    {
        var type = typeof(IdentityUserRole<int>);

        var userRole = new BlogUserToRole();

        Assert.IsAssignableFrom(type, userRole);
    }

    [Fact]
    public void Instance_Implement_Interface_IHaveCreated()
    {
        var type = typeof(IHaveCreated);

        var userRole = new BlogUserToRole();

        Assert.IsAssignableFrom(type, userRole);

        userRole.Created = DateTime.Now;
    }

    [Fact]
    public void Have_User()
    {
        //Arrange
        var userRole = new BlogUserToRole { User = new BlogUser() };

        //Act
        var user = userRole.User;

        //Assert
        Assert.IsAssignableFrom<BlogUser>(user);
    }

    [Fact]
    public void Have_Role()
    {
        //Arrange
        var userRole = new BlogUserToRole { Role= new BlogRole()};
        
        //Act
        var role = userRole.Role;
        
        //Assert
        Assert.IsAssignableFrom<BlogRole>(role);
    }

}