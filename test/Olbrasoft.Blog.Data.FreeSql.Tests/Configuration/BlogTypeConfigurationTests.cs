using FreeSql.Extensions.EfCoreFluentApi;

namespace Olbrasoft.Blog.Data.FreeSql.Tests.Configuration;
public class BlogTypeConfigurationTests
{
    [Fact]
    public void TypeOf_BlogTypeConfiguration_IsPublicShouldBeTrue()
    {
        // Arrange
        var sut = typeof(BlogTypeConfiguration<>);
        // Act
        var isPublic = sut.IsPublic;
        // Assert
        isPublic.Should().BeTrue();
    }

    [Fact]
    public void TypeOf_BlogTypeConfiguration_AssemblyShouldBeSameAsExpected()
    {
        // Arrange
        var expected = typeof(BlogFreeSqlDbContext).Assembly;
        // Act
        var sut = typeof(BlogTypeConfiguration<>).Assembly;

        // Assert
        sut.Should().BeSameAs(expected);    
    }

    [Fact]
    public void TypeOf_BlogTypeConfiguration_IsAbstractShouldBeTrue()
    {
        // Arrange
        var sut = typeof(BlogTypeConfiguration<>);
        // Act
        var isAbstaract = sut.IsAbstract;
        // Assert
        isAbstaract.Should().BeTrue();

    }

    [Fact]
    public void MockBlogTypeConfiguration_WithoutParams_ShouldBeAssingableToExpected()
    {
        // Arrange
        var expected = typeof(IEntityTypeConfiguration<object>);
        // Act
        var sut = new Mock<BlogTypeConfiguration<object>>().Object;
        // Assert
        sut.Should().BeAssignableTo(expected);
    }



}
