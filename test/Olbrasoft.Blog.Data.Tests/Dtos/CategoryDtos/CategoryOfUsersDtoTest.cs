namespace Olbrasoft.Blog.Data.Dtos.CategoryDtos;
public class CategoryOfUsersDtoTest
{
    [Fact]
    public void CategoryOfUsersDto_Inherit_From_()
    {
        //Arrange
        var type = typeof(CategoryOfUserDto);

        //Act
        var dto = new CategoryOfUsersDto();

        //Assert
        Assert.IsAssignableFrom(type, dto);
    }

    [Fact]
    public void CategoryOfUsersDto_Is_Integer()
    {
        //Arrange
        var dto = new CategoryOfUsersDto();

        //Act
        var creatorId = dto.CreatorId;

        //Assert
        Assert.IsAssignableFrom<int>(creatorId);
    }

}
