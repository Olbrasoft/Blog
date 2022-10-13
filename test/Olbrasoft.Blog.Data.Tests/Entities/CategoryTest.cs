using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Olbrasoft.Blog.Data.Entities;

public class CategoryTest
{
    [Fact]
    public void Instance_Have_Name()
    {
        //Arrange
        var category = new Category();

        //Act
        var name = category.Name;

        //Assert
        Assert.IsAssignableFrom<string>(name);
    }

    [Fact]
    public void Instance_Inherit_From_CreationInfo()
    {
        //Arrange
        var type = typeof(CreationInfo);

        //Act
        var category = new Category();

        //Assert
        Assert.IsAssignableFrom(type, category);
    }

    [Fact]
    public void Instance_Have_Posts()
    {
        //Arrange
        Category category = CreateCategory();

        //Act
        var posts = category.Posts;

        //Assert
        Assert.IsAssignableFrom<IEnumerable<Post>>(posts);
    }

    private static Category CreateCategory()
    {
        return new Category();
    }

    [Fact]
    public void Name_StringLength_Attribute()
    {
        //Arrange
        var property = typeof(Category).GetProperty("Name");

        //Act
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning disable CS8604 // Possible null reference argument.
        var attribute = (StringLengthAttribute)property.GetCustomAttribute(typeof(StringLengthAttribute));
#pragma warning restore CS8604 // Possible null reference argument.
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

        //Assert
#pragma warning disable CS8602 // Dereference of a possibly null reference.
        Assert.True(attribute.MaximumLength == 25);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
    }
            
    [Fact]
    public void Name_IsRequired()
    {
        //Arrange
        var property = typeof(Category).GetProperty("Name");

        //Act
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning disable CS8604 // Possible null reference argument.
        var attribute = (RequiredAttribute)property.GetCustomAttribute(typeof(RequiredAttribute));
#pragma warning restore CS8604 // Possible null reference argument.
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

        //Assert
        Assert.IsAssignableFrom<RequiredAttribute>(attribute);
    }

    [Fact]
    public void Have_Tooltip()
    {
        //Arrange
        var cat = new Category();

        //Act
        var tip = cat.Tooltip;

        //Assert
        Assert.IsType<string>(tip);
    }

    [Fact]
    public void Tooltip_StringLength()
    {
        //Arrange
        var property = typeof(Category).GetProperty(nameof(Category.Tooltip));

        //Act
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning disable CS8604 // Possible null reference argument.
        var attribute = (StringLengthAttribute)property.GetCustomAttribute(typeof(StringLengthAttribute));
#pragma warning restore CS8604 // Possible null reference argument.
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

        //Assert
#pragma warning disable CS8602 // Dereference of a possibly null reference.
        Assert.True(attribute.MaximumLength == 50);
#pragma warning restore CS8602 // Dereference of a possibly null reference.

    }



}