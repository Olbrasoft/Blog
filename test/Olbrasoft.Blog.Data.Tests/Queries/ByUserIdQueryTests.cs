namespace Olbrasoft.Blog.Data.Queries;
public class ByUserIdQueryTests
{
    [Fact]
    public void TypeOf_ByUserIdQuery_IsAbstractShouldBeTrue()
    {
        // Arrange
        var sut = typeof(ByUserIdQuery<>);
        // Act
        var isAbstract = sut.IsAbstract;
        // Assert
        isAbstract.Should().BeTrue();

    }


    [Fact]
    public void MockByUserIdQuery_MockQueryProcessor_ShouldBeAssingableToExpected()
    {
        // Arrange
        var mockProcessor = new Mock<IQueryProcessor>();
        var expected = typeof(PagedQuery<object>);
        // Act
        var sut = new Mock<ByUserIdQuery<object>>(mockProcessor.Object).Object;
        // Assert
        sut.Should().BeAssignableTo(expected);
    }

    [Fact]
    public void MockByUserIdQuery_Dispatcher_ShouldBeAssingableToExpected()
    {
        // Arrange
        var expected = typeof(PagedQuery<object>);
        var dispatcher = new Mock<IDispatcher>().Object;
        // Act
        var sut = new Mock<ByUserIdQuery<object>>(dispatcher).Object;
        // Assert
        sut.Should().BeAssignableTo(expected);  

    }

}
