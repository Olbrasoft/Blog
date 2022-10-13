using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Olbrasoft.Blog.Data.FreeSql.Tests.QueryHandlers.TagQueryHandlers;
public class TagsByLabelContainsQueryHandlerTests
{
    [Fact]
    public void Typeof_TagsByLabelContainsQueryHandler_IsPublicShouldBeTrue()
    {
        // Arrange
        var sut = typeof(TagsByLabelContainsQueryHandler);
        // Act
        var isPublic = sut.IsPublic;
        // Assert
        isPublic.Should().BeTrue();
    }

    [Fact]
    public void Typeof_TagsByLAbelContainsQueryHandler_AssemblyShouldBeSameAsExpected()
    {
        // Arrange
        var expected = typeof(BlogDbQueryHandler<,>).Assembly;
        // Act
        var sut = typeof(TagsByLabelContainsQueryHandler).Assembly;
        // Assert
        sut.Should().BeSameAs(expected);
    }

    [Fact]
    public void TagsByLabelContainsQueryHandler_MockSelectorAs1stParam_ShouldBeAssingableToExpected()
    {
        // Arrange
        var expected = typeof(BlogDbQueryHandler<Tag, TagsByLabelContainsQuery, IEnumerable<TagSmallDto>>);
        var mockSelector = new Mock<IDataSelector>();
        mockSelector.Setup(s => s.Select<Tag>()).Returns(new Mock<ISelect<Tag>>().Object);
        // Act
        var sut = new TagsByLabelContainsQueryHandler(selector: mockSelector.Object);
        // Assert
        sut.Should().BeAssignableTo(expected);  
    }

    [Fact]
    public async Task HandleAsync_NullTagsByLabelContainsQuery_ShouldThrowExactlyAsyncArgumentNullExceptionAsync()
    {
        // Arrange
        var mockSelector = new Mock<IDataSelector>();
        mockSelector.Setup(s => s.Select<Tag>()).Returns(new Mock<ISelect<Tag>>().Object);
        var sut = new TagsByLabelContainsQueryHandler(selector: mockSelector.Object);
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
        TagsByLabelContainsQuery query = null;
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
        // Act
#pragma warning disable CS8604 // Possible null reference argument.
        var act = () => sut.HandleAsync(query, default);
#pragma warning restore CS8604 // Possible null reference argument.

        // Assert
        await act.Should().ThrowExactlyAsync<ArgumentNullException>();
    }

    [Fact]
    public async void HandleAsync_TagsByLabelContainsQueryAs1stParamAndDefaultTokenAs2stParam_ReturnsShouldBeSameAsExpected()
    {
        // Arrange
        var expected = Task.FromResult(new List<TagSmallDto>());
        var query = new TagsByLabelContainsQuery(new Mock<IDispatcher>().Object);
                        
        var mockToListSelect = new Mock<ISelect<Tag>>();
        mockToListSelect.Setup(s => s.ToListAsync<TagSmallDto>(It.IsAny<CancellationToken>())).Returns(expected);
        
        var mockTakeSelect = new Mock<ISelect<Tag>>();
        mockTakeSelect.Setup(s=>s.Take(6)).Returns(mockToListSelect.Object);

        var mockWhereSelect = new Mock<ISelect<Tag>>();
        mockWhereSelect.Setup(s => s.Where(It.IsAny<Expression<Func<Tag, bool>>>())).Returns(mockTakeSelect.Object);

        var mockSelector = new Mock<IDataSelector>();
        mockSelector.Setup(s => s.Select<Tag>()).Returns(mockWhereSelect.Object);

        var sut = new TagsByLabelContainsQueryHandler(mockSelector.Object);

        // Act
        var result = await sut.HandleAsync(query, default);

        // Assert
        result.Should().BeSameAs(await expected);
    }


}
