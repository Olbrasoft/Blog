using IGeekFan.AspNetCore.Identity.FreeSql;
using Olbrasoft.Blog.Data.Entities.Identity;
using Olbrasoft.Data.Entities.Identity;

namespace Olbrasoft.Blog.Data.FreeSql.Tests;
public class BlogFreeSqlDbContextTests
{
    [Fact]
    public void TypeOf_BlogFreeSqlDbContext_IsPublicShouldBeTrue()
    {
        // Arrange
        var sut = typeof(BlogFreeSqlDbContext);
        // Act
        var isPublic = sut.IsPublic;
        // Assert
        isPublic.Should().BeTrue();
    }

    [Fact]
    public void TypeOf_BlogFreeSqlDbContext_AssemblyNameShouldBeSameAsExpected()
    {
        // Arrange
        var sut = typeof(BlogFreeSqlDbContext);
        // Act
        var assembly = sut.Assembly;
        // Assert
        assembly.FullName.Should().NotContain("Test");
    }

    [Fact]
    public void Ctor_WithoutParams_ShouldBeAssingableToExpected()
    {
        // Arrange
        var expected = typeof(IdentityDbContext<BlogUser, BlogRole, int, UserClaim, BlogUserToRole, UserLogin, RoleClaim, UserToken>);
        // Act
        var sut = new BlogFreeSqlDbContext();

        // Assert
        sut.Should().BeAssignableTo(expected);

    }
     
}
