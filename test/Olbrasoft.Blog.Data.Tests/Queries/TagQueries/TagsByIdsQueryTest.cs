using Olbrasoft.Blog.Data.Dtos.TagDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Olbrasoft.Blog.Data.Queries.TagQueries;
public class TagsByIdsQueryTest
{
    [Fact]
    public void TagsByIdsQuery_Inherits_From_Request_Of_IEnumerable_Of_TagSmallDto()
    {
        //Arrange
        var dm = new Mock<IDispatcher>();

        //Act
        var query = new TagsByIdsQuery(dm.Object);

        //Assert
        Assert.IsAssignableFrom<Request<IEnumerable<TagSmallDto>>>(query);
    }
}
