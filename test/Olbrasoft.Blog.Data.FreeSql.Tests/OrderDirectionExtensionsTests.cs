using Olbrasoft.Data.Sorting;
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
    public void ToBoolean_OrderDirectionAsc_ResultShouldBeTrue()
    {
        // Arrange
        var direction = OrderDirection.Asc;
        // Act
        bool result =  OrderDirectionExtensions.ToBoolean(direction: direction);    
        // Assert
        result.Should().BeTrue();   
    }

    [Fact]
    public void ToBoolean_OredrDirectionDesc_ResultShouldBeFalse()
    {
        // Arrange
        var direction = OrderDirection.Desc;
        // Act
        bool result = OrderDirectionExtensions.ToBoolean(direction: direction);
        // Assert
        result.Should().BeFalse();
    }



}
