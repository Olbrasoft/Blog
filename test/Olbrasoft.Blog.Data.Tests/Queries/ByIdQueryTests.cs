using Olbrasoft.Blog.Data.Dtos;

namespace Olbrasoft.Blog.Data.Queries;
public class ByIdQueryTests
{
    [Fact]
    public void TypeOf_ByIdQuery_IsPublicShoulddBeTrue()
    {
        // Arrange
        var sut = typeof(ByIdQuery<object>);
        // Act
        var isPublic = sut.IsPublic;

        // Assert
        isPublic.Should().BeTrue();
       
    }

    [Fact]
    public void TypeOf_ByIdQuery_ShouldBeAbstract()
    {
        // Arrange
        var sut = typeof(ByIdQuery<object>);
        // Act

        // Assert
        sut.Should().BeAbstract();
    }

    [Fact]
    public void TypeOf_ByIdQuery_AssemblyShouldBeSameAsExpected()
    {
        // Arrange
        var expected = typeof(SmallDto).Assembly;
        // Act
        var sut = typeof(ByIdQuery<object>).Assembly;

        // Assert
        sut.Should().BeSameAs(expected);    
    }

    [Fact]
    public void ByIdQuery_Processor_ShouldBeAssingableToBaseQuery()
    {
        // Arrange
        var processor = new Mock<IQueryProcessor>().Object;
        // Act
        var sut = new Mock<ByIdQuery<object>>(processor).Object;
        // Assert
        sut.Should().BeAssignableTo<BaseQuery<object>>();

    }

    [Fact]
    public void ByIdQuery_Dispatcher_ShouldBeAssingableToBaseQuery()
    {
        // Arrange
        var dispatcher = new Mock<IDispatcher>().Object;
        // Act
        var sut = new Mock<ByIdQuery<object>>(dispatcher).Object;
        // Assert
        sut.Should().BeAssignableTo<BaseQuery<object>>();

    }

    [Fact]
    public void MockByIdQuery_MockProcessor_IdShouldBeEmpty()
    {
        // Arrange
        var processor = new Mock<IQueryProcessor>().Object;
        // Act
        var sut = new Mock<ByIdQuery<object>>(processor).Object;

        // Assert
        sut.Id.Should().Be(0);
    }
}
