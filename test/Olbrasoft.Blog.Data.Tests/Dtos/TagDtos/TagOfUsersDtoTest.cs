namespace Olbrasoft.Blog.Data.Dtos.TagDtos;
public class TagOfUsersDtoTest
{
    [Fact]
    public void TagOfUsersDto_Inherits_From_TagOfUserDto()
    {
        //Arrange
        var type = typeof(TagOfUserDto);

        //Act
        var dto = new TagOfUsersDto();

        //Assert
        Assert.IsAssignableFrom(type, dto);

    }

    [Fact]
    public void TagOfUsersDto_Have_Property_CreatorId_Type_Integer()
    {
        //Arrange
        var dto = new TagOfUsersDto();

        //Act
        var creatorId = dto.CreatorId;

        //Assert
        Assert.IsType<int>(creatorId);
    }

}
