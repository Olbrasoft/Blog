namespace Olbrasoft.Blog.Data.Dtos.PostDtos;
public class PostEditDtoTest
{
    [Fact]
    public void PostEditDto_Inherits_From_SmallDto()
    {
        //Arrange

        //Act
        var dto = new PostEditDto();

        //Assert
        Assert.IsAssignableFrom<SmallDto>(dto);

    }

    [Fact]
    public void PostEditDto_Have_Property_CategoryId_Type_Integer()
    {
        //Arrange
        var dto = new PostEditDto();

        //Act
        var categoryId = dto.CategoryId;

        //Assert
        Assert.IsType<int>(categoryId);
    }
}
