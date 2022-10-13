namespace Olbrasoft.Blog.Data.FreeSql.Tests.QueryHandlers.TagQueryHandlers;
public class TagsByPostIdQueryHandlerTests
{
    [Fact]
    public void Typeof_TagsByPostIdQueryHandler_IsPublicShouldBeTrue()
    {
        // Arrange
        var sut = typeof(TagsByPostIdQueryHandler);

        // Act
        var isPublic = sut.IsPublic;

        // Assert
        isPublic.Should().BeTrue();
    }

    [Fact]
    public void Typeof_TagsByPostIdQueryHandler_AssemblyShouldBeSameAsExpected()
    {
        // Arrange
        var expected = typeof(BlogDbQueryHandler<,>).Assembly;
        // Act
        var sut = typeof(TagsByPostIdQueryHandler).Assembly;
        // Assert
        sut.Should().BeSameAs(expected);
    }

    [Fact]
    public void Ctor_MockFreeSql_ShouldBeAssingableToExpected()
    {
        // Arrange
        var expected = typeof(IRequestHandler<TagsByPostIdQuery, IEnumerable<TagSmallDto>>);
        var dbSet = new FakeDbSet<PostToTag>(new Mock<ISelect<PostToTag>>().Object);

        var mockDbSetProvider = new Mock<IDbSetProvider>();
        mockDbSetProvider.Setup(p => p.Set<PostToTag>()).Returns(dbSet);

        // Act
        var sut = new TagsByPostIdQueryHandler(mockDbSetProvider.Object);

        // Assert
        sut.Should().BeAssignableTo(expected);
    }

    [Fact]
    public async void HandleAsync_NullQuery_ShouldBeThrowAsyncExactlyArgumentNUllException()
    {
        var dbSet = new FakeDbSet<PostToTag>(new Mock<ISelect<PostToTag>>().Object);

        var mockDbSetProvider = new Mock<IDbSetProvider>();
        mockDbSetProvider.Setup(p => p.Set<PostToTag>()).Returns(dbSet);
        var sut = new TagsByPostIdQueryHandler(mockDbSetProvider.Object);

#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
        TagsByPostIdQuery query = null;
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

        // Act
#pragma warning disable CS8604 // Possible null reference argument.
        var act = () => sut.HandleAsync(query, default);
#pragma warning restore CS8604 // Possible null reference argument.

        // Assert
        await act.Should().ThrowExactlyAsync<ArgumentNullException>().WithParameterName(nameof(query));
    }

    [Fact]
    public async Task HandleAsync_TagsByPostIdQuery_ResultShouldBeSameAsExpectedAsync()
    {
        // Arrange
        var expected = Task.FromResult(new List<TagSmallDto>());

        var mockInclude = new Mock<ISelect<PostToTag>>();
        mockInclude.Setup(p => p.ToListAsync<TagSmallDto>(It.IsAny<Expression<Func<PostToTag, TagSmallDto>>>(), It.IsAny<CancellationToken>()))
            .Returns(expected);

        var mockWhere = new Mock<ISelect<PostToTag>>();
               
        mockWhere.Setup(p => p.Include(It.IsAny<Expression<Func<PostToTag, Tag>>>()))
            .Returns(mockInclude.Object);

        var mockSelect = new Mock<ISelect<PostToTag>>();
        mockSelect.Setup(p => p.Where(It.IsAny<Expression<Func<PostToTag, bool>>>()))
            .Returns(mockWhere.Object);

        var mockDbSetProvider = new Mock<IDbSetProvider>();
        mockDbSetProvider.Setup(p => p.Set<PostToTag>())
            .Returns(new FakeDbSet<PostToTag>(mockSelect.Object));

        var mockDispatcher = new Mock<IDispatcher>();
        var query = new TagsByPostIdQuery(mockDispatcher.Object);

        var sut = new TagsByPostIdQueryHandler(mockDbSetProvider.Object);

        // Act
        var result = sut.HandleAsync(query, default);

        // Assert
        (await result).Should().BeSameAs((await expected).AsEnumerable()); ;
    }

}
