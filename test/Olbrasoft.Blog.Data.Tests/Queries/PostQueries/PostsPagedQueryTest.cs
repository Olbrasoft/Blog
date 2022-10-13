using Olbrasoft.Blog.Data.Dtos.PostDtos;

namespace Olbrasoft.Blog.Data.Queries.PostQueries;
public class PostsPagedQueryTest
{
    [Fact]
    public void PostsPagedQuery_Inherits_From_PagedQuery_Of_IPagedEnumerable_Of_PostDto()
    {
        //Arrange
        var processorMock = new Mock<IQueryProcessor>();

        //Act
        var query = new PostsPagedQuery(processorMock.Object);

        //Assert
        Assert.IsAssignableFrom<BaseQuery<IPagedEnumerable<PostDto>>>(query);
    }

    [Fact]
    public void Ctor_Dispatcher_PagingShouldBeAssingabletoPageInfo()
    {
        // Arrange
        var dispatcher = new Mock<IDispatcher>().Object;
        // Act
        var sut = new PostsPagedQuery(dispatcher);
        // Assert
        sut.Paging.Should().BeAssignableTo<PageInfo>();  
    }


}
