using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

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
