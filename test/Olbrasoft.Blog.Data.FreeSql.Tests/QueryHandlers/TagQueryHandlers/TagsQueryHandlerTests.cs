using Olbrasoft.Blog.Data.FreeSql.QueryHandlers.TagQueryHandlers;
using Xunit;

namespace Olbrasoft.Blog.Data.FreeSql.Tests.QueryHandlers.TagQueryHandlers;
public class TagsQueryHandlerTests
{
    [Fact]
    public void TagsQueryHandler_MockSelector_ShouldBeAssingableToExpected()
    {
        // Arrange
        var expected = typeof(BlogDbQueryHandler<Tag, TagsQuery, IEnumerable<TagSmallDto>>);
        var mockSelector = new Mock<IDataSelector>(); 

        // Act
        var sut = new TagsQueryHandler(mockSelector.Object);

        // Assert
        sut.Should().BeAssignableTo(expected);
    }

    [Fact]
    public async void HandleAsync_NullTagsQuery_ShouldThrowExactlyArgumentNullException()
    {
        // Arrange
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
        TagsQuery query = null;
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
        var mockSelector = new Mock<IDataSelector>();
        var sut = new TagsQueryHandler(mockSelector.Object);

        // Act
#pragma warning disable CS8604 // Possible null reference argument.
        var act = () => sut.HandleAsync(query, default);
#pragma warning restore CS8604 // Possible null reference argument.

        // Assert
        await act.Should().ThrowExactlyAsync<ArgumentNullException>();
    }


    [Fact]
    public async void HandleAsync_TagsQueryAs1stParamDefaultTokenAs2stParam_ReturnsShouldBeSameAsExpected()
    {
        // Arrange
        var expected = Task.FromResult( new List<TagSmallDto>());

        var query = new TagsQuery(new Mock<IDispatcher>().Object);

        var mockListSelect = new Mock<ISelect<Tag>>();
        mockListSelect.Setup(s => s.ToListAsync<TagSmallDto>(It.IsAny<CancellationToken>())).Returns(expected);
        
        var mockSelectorSelect = new Mock<ISelect<Tag>>();
        mockSelectorSelect.Setup(s => s.OrderBy<string>(It.IsAny<Expression<Func<Tag, string>>>())).Returns(mockListSelect.Object);

        var mockSelector = new Mock<IDataSelector>();
        mockSelector.Setup(s => s.Select<Tag>()).Returns(mockSelectorSelect.Object);

        var sut = new TagsQueryHandler(mockSelector.Object);
        // Act
        var result = await sut.HandleAsync(query,default);

        // Assert
        result.Should().BeSameAs(await expected);
    }

}
