using Olbrasoft.Data.Cqrs;
using Xunit;

namespace Olbrasoft.Blog.Data.FreeSql.Tests.QueryHandlers;
public class BlogDbQueryHandlerTests
{

    [Fact]
    public void PingBoolDbQueryHandler_MockSetProvider_ShouldBeAssingableToExpected()
    {
        // Arrange
        var expected = typeof(BlogDbQueryHandler<object, BaseQuery<bool>>);
        var mockDbSetProvider = new Mock<IDbSetProvider>();
        mockDbSetProvider.Setup(p => p.Set<object>()).Returns(new FakeDbSet<object>());
        
        // Act
        var sut = new PingBoolDbQueryHandler(DbSetProvider: mockDbSetProvider.Object);

        // Assert
        sut.Should().BeAssignableTo(expected);
    }

    [Fact]
    public void PingDbQueryHandler_MockSetProvider_ShouldBeAssingableToExpected()
    {
        // Arrange
        var expected = typeof(BlogDbQueryHandler<object, BaseQuery<object>, object>);
        var mockDbSetProvider = new Mock<IDbSetProvider>();
        mockDbSetProvider.Setup(p => p.Set<object>()).Returns(new FakeDbSet<object>());
        // Act
        var sut = new PingDbQueryHandler( mockDbSetProvider.Object);
        // Assert
        sut.Should().BeAssignableTo(expected);
    }

    [Fact]
    public void BlogDbQueryHandler_NullSetProvider_ShouldBeThrowArgumentNullException()
    {
        // Arrange
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
        IDbSetProvider nullSet = null;
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
        // Act
#pragma warning disable CS8604 // Possible null reference argument.
        var act = () => new PingDbQueryHandler(nullSet);
#pragma warning restore CS8604 // Possible null reference argument.
                              // Assert
        act.Should().ThrowExactly<ArgumentNullException>();
    }

    [Fact]
    public void BlogDbQueryHandler_MockSetProvider_ShouldBeAssingableToExpected()
    {
        // Arrange
        var expected = typeof(IRequestHandler<BaseQuery<object>, object>);

        var mockDbSetProvider = new Mock<IDbSetProvider>();
        mockDbSetProvider.Setup(p => p.Set<object>()).Returns(new FakeDbSet<object>());

        var mockHandler = new Mock<BlogDbQueryHandler<object, BaseQuery<object>, object>>(mockDbSetProvider.Object);

        // Act
        var sut = mockHandler.Object;

        // Assert
        sut.Should().BeAssignableTo(expected);
    }

    [Fact]
    public void ThrowIfQueryIsNullOrCancellationRequested_NullQueryAs1stParam_ShouldBeThrowExactlyArgumentNullException()
    {
        // Arrange
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
        BaseQuery<object> query = null;
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

        // Act
#pragma warning disable CS8604 // Possible null reference argument.
        Action act = () => PingDbQueryHandler.ThrowIf(query:query,default );
#pragma warning restore CS8604 // Possible null reference argument.

        // Assert
        act.Should().ThrowExactly<ArgumentNullException>();
    }

    [Fact]
    public void ThrowIfQueryIsNullOrCancellationRequested_MockQueryAndTokenCancellationRequested_ShouldBeThrowExactly()
    {
        // Arrange
        var mockDispatcher = new Mock<IDispatcher>();
        var mockQuery = new Mock<BaseQuery<object>>(mockDispatcher.Object);

        var cts = new CancellationTokenSource();
        cts.Cancel();

        // Act
        Action act = () => PingDbQueryHandler.ThrowIf( mockQuery.Object, cts.Token);

        // Assert
        act.Should().ThrowExactly<OperationCanceledException>();
    }

    [Fact]
    public void PingDbQueryHandler_NullDbSelector_ShouldThrowExactlyArgumentNullExeption()
    {
        // Arrange
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
        IDataSelector selector = null;
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
        // Act
#pragma warning disable CS8604 // Possible null reference argument.
        Action act = () => new PingDbQueryHandler(selector);
#pragma warning restore CS8604 // Possible null reference argument.
                              // Assert
        act.Should().Throw<ArgumentNullException>();
    }

    [Fact]
    public void BlogDbQueryHanlder_MockDbSelecor_SelectShouldBeSameAsExpected()
    {
        // Arrange
        var expected = new Mock<ISelect<object>>().Object;
        var mockSelector = new Mock<IDataSelector>();  
        mockSelector.Setup(s=>s.Select<object>()).Returns(expected);

        // Act
        var sut = new PingDbQueryHandler(mockSelector.Object);

        // Assert
        sut.Select.Should().BeSameAs(expected);
    }

}
