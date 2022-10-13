namespace Olbrasoft.Blog.Data.Queries;
public class ExceptUserIdQueryTests
{
    [Fact]
    public void TypeOf_ExpectUserIdQuery_IsAbstractShouldBeTrue()
    {
        // Arrange
        var sut = typeof(ExceptUserIdQuery<>);
        // Act
        var isAbstract = sut.IsAbstract;
        // Assert
        isAbstract.Should().BeTrue();
    }

    [Fact]
    public void MockExpectUserIdQuery_MockQueryProcessor_ObjectShouldBeAssingableToExpected()
    {
        // Arrange
        var expected = typeof(PagedQuery<object>);
        var processor = new Mock<IQueryProcessor>().Object;
        // Act
        var sut = new Mock<ExceptUserIdQuery<object>>(processor).Object;

        // Assert
        sut.Should().BeAssignableTo(expected);
    }

}
