using System;

namespace Olbrasoft.Blog.Data.Dtos.PostDtos;
public class PostDtoTest
{
    [Fact]
    public void PostDto_Inherits_From_SmallDto()
    {
        //Arrange

        //Act
        var dto = new PostDto();

        //Assert
        Assert.IsAssignableFrom<SmallDto>(dto);
    }


    [Fact]
    public void PostDto_Have_Property_Created_Type_DateTimeOffset()
    {
        //Arrange
        var dto = new PostDto();

        //Act
        var created = dto.Created;

        //Assert
        Assert.IsType<DateTimeOffset>(created);
    }

    [Fact]
    public void PostDto_Have_Property_CreatorId_Type_Integer()
    {
        //Arrange
        var dto = new PostDto();

        //Act
        var creatorId = dto.CreatorId;

        //Assert
        Assert.IsType<int>(creatorId);
    }

}
