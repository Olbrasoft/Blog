using Olbrasoft.Blog.Data.Dtos;
using Olbrasoft.Data.Sorting;

namespace Olbrasoft.Blog.Data.Queries;
public class PagedQueryTests
{
    [Fact]
    public void TypeOf_BlogPagedQuery_IsPublicShouldByTrue()
    {
        // Arrange
        var sut = typeof(PagedQuery<>);
        // Act
        var isPublic = sut.IsPublic;
        // Assert
        isPublic.Should().BeTrue();

    }

    [Fact]
    public void TypeOf_BlogPagedQuery_AssemblyShouldBeSameAsExpected()
    {
        // Arrange
        var expected = typeof(SmallDto).Assembly;
        // Act
        var sut = typeof(PagedQuery<>).Assembly;

        // Assert
        sut.Should().BeSameAs(expected);
    }

    [Fact]
    public void TypeOf_BlogPagedQuery_IsAbstracShouldBeTrue()
    {
        // Arrange
        var sut = typeof(PagedQuery<>);
        // Act
        var isAbstract = sut.IsAbstract;
        // Assert
        isAbstract.Should().BeTrue();

    }


    [Fact]
    public void MockBlogPagedQuery_MockProcessorAsParam_ObjectShouldBeAssingableToExpected()
    {
        // Arrange
        var expected = typeof(BaseQuery<object>);
        var mockProcessor = new Mock<IQueryProcessor>();

        // Act
        var sut = new Mock<PagedQuery<object>>(mockProcessor.Object);

        // Assert
        sut.Object.Should().BeAssignableTo(expected);

    }

    [Fact]
    public void MockBlogPagedQuery_MockProcessorAsParam_PagingBeAssingableToExpected()
    {
        // Arrange
        var expected = typeof(PageInfo);
        var mockProcessor = new Mock<IQueryProcessor>();
        // Act
        var sut = new Mock<PagedQuery<object>>(mockProcessor.Object);

        // Assert
        sut.Object.Paging.Should().BeAssignableTo(expected);

    }

    [Fact]
    public void MockBlogPagedQuery_MockProcessorAsParam_SearchShouldBeStringEmpty()
    {
        // Arrange
        var mockProcessor = new Mock<IQueryProcessor>();
        // Act
        var sut = new Mock<PagedQuery<object>>(mockProcessor.Object);

        // Assert
        sut.Object.Search.Should().Be(string.Empty);
    }

    [Fact]
    public void MockBlogPagedQuery_MockProcessorAsParam_OrderByColumnNameShouldBeStringEmpty()
    {
        // Arrange
        var mockProcessor = new Mock<IQueryProcessor>();
        // Act
        var sut = new Mock<PagedQuery<object>>(mockProcessor.Object);

        // Assert
        sut.Object.OrderByColumnName.Should().Be(string.Empty);
    }

    [Fact]
    public void MockBlogPagedQuery_MockProcessorAsParam_OrderByDirectionShouldBeExpected()
    {
        // Arrange
        var expected = OrderDirection.Asc;
        var mockProcessor = new Mock<IQueryProcessor>();
        // Act
        var sut = new Mock<PagedQuery<object>>(mockProcessor.Object);

        // Assert
        sut.Object.OrderByDirection.Should().Be(expected);
    }

    [Fact]
    public void MockPagedQuery_Dispatcher_ShouldBeAssingableToExpected()
    {
        // Arrange
        var dis = new Mock<IDispatcher>().Object;
        // Act
        var sut = new Mock<PagedQuery<object>>(dis).Object;
        // Assert
        sut.Should().BeAssignableTo<BaseQuery<object>>();
    }


}

