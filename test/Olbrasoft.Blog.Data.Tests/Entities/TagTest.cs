using System.Collections.Generic;

namespace Olbrasoft.Blog.Data.Entities;

public class TagTest
{
    [Fact]
    public void Instance_Have_Label()
    {
        //Arrange
        var tag = new Tag();

        //Act
        var label = tag.Label;

        //Assert
        Assert.IsAssignableFrom<string>(label);
    }

    [Fact]
    public void Instance_Inherit_From_CreationInfo()
    {
        //Arrange
        var type = typeof(CreationInfo);

        //Act
        var tag = new Tag();

        //Assert
        Assert.IsAssignableFrom(type, tag);
    }

    [Fact]
    public void Instance_Have_ToPosts()
    {
        //Arrange
        var tag = new Tag();

        //Act
        var toPosts = tag.ToPosts;

        //Assert
        Assert.IsAssignableFrom<IEnumerable<PostToTag>>(toPosts);
    }
}