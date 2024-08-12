using FluentAssertions;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Moq;
using Olbrasoft.Blog.AspNetCore.Mvc.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Olbrasoft.Blog.AspNetCore.Mvc.Tests;
public class WebApplicationBuilderExtensionsTests
{
    [Fact]
    public void Should_Static()
    {
        //Arrange
        var type = typeof(WebApplicationBuilderExtensions);

        //Assert
        type.Should().BeStatic();
    }

    [Fact]
    public void Should_Public()
    {
        //Arrange
        var type = typeof(WebApplicationBuilderExtensions);

        //Act
        var isPublic = type.IsPublic;

        //Assert
        isPublic.Should().BeTrue();
    }

    [Fact]
    public void Assembly_ShouldBeSameAs_WebApplicationAssembly()
    {
        //Arrange
        var expected = typeof(HomeController).Assembly;

        //Act
        var assembly = typeof(WebApplicationBuilderExtensions).Assembly;

       //Assert
       assembly.Should().BeSameAs(expected);

    }

    [Fact]
    public void AddServices_Null_ShouldThrowException()
    {
        //Arrange
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
        WebApplicationBuilder builder = null;
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

        //Act
#pragma warning disable CS8604 // Possible null reference argument.
        var act = () => builder.BuildServices();
#pragma warning restore CS8604 // Possible null reference argument.

        //Assert
        act.Should().Throw<ArgumentNullException>();
    }



}
