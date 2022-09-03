using Olbrasoft.Blog.Data.Dtos.TagDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Olbrasoft.Blog.Data.Queries.TagQueries;
public class TagsWhereLabelContainsTextQueryTest
{
    [Fact]
    public void TagsWhereLabelContainsTextQuery_Inherits_From_Request_Of_IEnumerable_Of_()
    {
        //Arrange
        var dm = new Mock<IDispatcher>();

        //Act
        var query = new TagsWhereLabelContainsTextQuery(dm.Object);

        //Assert
        Assert.IsAssignableFrom<Request<IEnumerable<TagSmallDto>>>(query);
    }

}
