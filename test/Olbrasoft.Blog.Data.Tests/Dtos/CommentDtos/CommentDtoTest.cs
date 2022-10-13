namespace Olbrasoft.Blog.Data.Dtos.CommentDtos;
public class CommentDtoTest
{

    [Fact]
    public void CommentDto_Inherit_From_NestedCommentDto()
    {
        //Arrange

        //Act
        var comment = new CommentDto();

        //Assert
        Assert.IsAssignableFrom<NestedCommentDto>(comment);
    }

}
