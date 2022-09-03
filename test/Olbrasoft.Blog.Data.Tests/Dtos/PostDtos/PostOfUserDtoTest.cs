using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Olbrasoft.Blog.Data.Dtos.PostDtos;
public class PostOfUserDtoTest
{
    [Fact]
    public void PostOfUserDto_Inherits_From_SmallDto()
    {
        //Arrange
        var type = typeof(SmallDto);

        //Act
        var dto = new PostOfUserDto();

        //Assert
        Assert.IsAssignableFrom(type, dto);
    }

    [Fact]
    public void PostOfUserDto_Have_Property_CategoryId_Type_Integer()
    {
        //Arrange
        var dto= new PostOfUserDto();

        //Act
        var categoryId = dto.CategoryId;

        //Assert
        Assert.IsType<int>(categoryId);
    }

    [Fact]
    public void PostOfUserDto_Have_Property_Created_Type_DateTimeOffset()
    {
        //Arrange
        var dto = new PostOfUserDto();

        //Act
        var created = dto.Created;

        //Assert
        Assert.IsType<DateTimeOffset>(created);
    }
}
