namespace Olbrasoft.Blog.Data.Entities;

public class PostToTagTest
{
    [Fact]
    public void Instance_Inherit_From_CreationInfo()
    {
        //Arrange
        var type = typeof(CreationInfo);

        //Act
        var postTag = new PostToTag();

        //Assert
        Assert.IsAssignableFrom(type, postTag);
    }

    [Fact]
    public void Instance_Have_ToId()
    {
        //Arrange
        var postToTag = new PostToTag();

        //Act
        var toId = postToTag.ToId;

        //Assert

        Assert.IsAssignableFrom<int>(toId);

    }

    [Fact]
    public void Instance_Have_Post()
    {
        //Arrange
        var postToTag = new PostToTag() { Post = new Post() };

        //Act
        var post = postToTag.Post;

        //Assert
        Assert.IsAssignableFrom<Post>(post);

    }

    [Fact]
    public void Instance_Have_Tag()
    {
        //Arrange
        var postToTag = new PostToTag() { Tag = new Tag() };

        //Act
        var tag = postToTag.Tag;

        //Assert
        Assert.IsAssignableFrom<Tag>(tag);
    }
}
