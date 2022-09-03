using Olbrasoft.Blog.Data.Dtos.PostDtos;
using Olbrasoft.Data.Cqrs.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Olbrasoft.Blog.Data.Queries.PostQueries;
public class PostsPagedQueryTest
{
    [Fact]
    public void PostsPagedQuery_Inherits_From_PagedQuery_Of_IPagedEnumerable_Of_PostDto()
    {
        //Arrange
        var dm = new Mock<IDispatcher>();

        //Act
        var query = new PostsPagedQuery(dm.Object);

        //Assert
        Assert.IsAssignableFrom<PagedQuery<IPagedEnumerable<PostDto>>>(query);
    }
}
