namespace Olbrasoft.Blog.Data.Dtos.CommentDtos;
public class NestedCommentDtoTest
{
    [Fact]
    public void NestedCommentDto_Inherit_From_SmallDto()
    {
        //Arrange

        //Act
        var comment = new NestedCommentDto();

        //Assert
        Assert.IsAssignableFrom<SmallDto>(comment);

    }

    [Fact]
    public void NestedCommentDto_Have_Property_CreatorId_Type_Integer()
    {
        //Arrange
        var comment = new NestedCommentDto();

        //Act
        var creattorId = comment.CreatorId;

        //Assert
        Assert.IsType<int>(creattorId);

    }

}
