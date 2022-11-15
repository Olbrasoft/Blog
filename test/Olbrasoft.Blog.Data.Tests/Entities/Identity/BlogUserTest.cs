using Microsoft.AspNetCore.Identity;
using System;

namespace Olbrasoft.Blog.Data.Entities.Identity;

public class BlogUserTest
{

    [Fact]
    public void Have_Tags()
    {
        //Arrange
        var user = new BlogUser();

        //Act
        var tags = user.Tags;

        //Assert
        Assert.IsAssignableFrom<IEnumerable<Tag>>(tags);
    }

    [Fact]
    public void Have_Comments()
    {
        //Arrange
        var user = new BlogUser();

        //Act
        var comments = user.Comments;

        //Assert
        Assert.IsAssignableFrom<IEnumerable<Comment>>(comments);
    }

    [Fact]
    public void Have_Categories()
    {
        //Arrange
        var user = new BlogUser();

        //Act
        var categories = user.Categories;

        //Assert
        Assert.IsAssignableFrom<IEnumerable<Category>>(categories);
    }

    [Fact]
    public void Instance_Inherit_From_IdentityUser_Of_Integer()
    {
        var type = typeof(IdentityUser<int>);

        var user = new BlogUser();

        Assert.IsAssignableFrom(type, user);
    }

    [Fact]
    public void Instance_Implement_interface_IHaveCreate()
    {
        var type = typeof(IHaveCreated);

        var user = new BlogUser();

        Assert.IsAssignableFrom(type, user);

        user.Created = DateTime.Now;
    }

    [Fact]
    public void Instance_Have_Posts()
    {
        //Arrange
        var user = new BlogUser();

        //Act
        var posts = user.Posts;

        //Assert
        Assert.IsAssignableFrom<IEnumerable<Post>>(posts);
    }

 

    [Fact]
    public void Have_ToRoles()
    {
        //Arrange
        var type = typeof(IEnumerable<BlogUserToRole>);
        var user = new BlogUser();

        //Act
        var toRoles = user.ToRoles;

        //Assert
        Assert.IsAssignableFrom<IEnumerable<BlogUserToRole>>(toRoles);
    }

    [Fact]
    public void Have_First_Name()
    {
        //Arrange
        var user = new BlogUser();

        //Act
        var name = user.FirstName;

        //Assert
        Assert.IsAssignableFrom<string>(name);
    }

    [Fact]
    public void Have_LastName()
    {
        //Arrange
        var user = new BlogUser();

        //Act
        var name = user.LastName;


        //Assert
        Assert.IsAssignableFrom<string>(name);
        
    }

    [Fact]
    public void Have_ToString()
    {
        //Arrange
        var user = new BlogUser {FirstName = "AwesomeFirstName", LastName = "AwesomeLastName" };

        //Act
        var result = user.ToString();

        //Assert
        Assert.True(result == "AwesomeFirstName AwesomeLastName");
    }


}