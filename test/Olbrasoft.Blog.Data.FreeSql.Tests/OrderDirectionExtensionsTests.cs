using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Olbrasoft.Blog.Data.FreeSql.Tests;
public class OrderDirectionExtensionsTests
{
    [Fact]
    public void Typeof_OrderDirectionExtensions_IsPublicShouldBeTrue()
    {
        // Arrange
        var sut = typeof(OrderDirectionExtensions);
        // Act
        var isPublic = sut.IsPublic;

        // Assert
        isPublic.Should().BeTrue();
    }

    [Fact]
    public void Typeof_OredrDirectionExtewsions_ShouldBeStatic()
    {
        // Arrange
        var sut = typeof(OrderDirectionExtensions);
        // Act

        // Assert
        sut.Should().BeStatic();
    }

    [Fact]
    public void ToBoolean_NullOrderDirection_ShouldThrowExactlyArgumentNullException()
    {
        // Arrange

        // Act

        // Assert

    }

}
