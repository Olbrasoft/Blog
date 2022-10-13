namespace Olbrasoft.Blog.Data.Dtos.TagDtos;
public class TagSmallDtoTest
{
    [Fact]
    public void TagSmallDto_Inherits_From_SmallDto()
    {
        //Arrange
        var type = typeof(SmallDto);

        //Act
        var dto = new TagSmallDto();
        
        //Assert
        Assert.IsAssignableFrom(type, dto);
    }
}
