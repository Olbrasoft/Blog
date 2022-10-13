﻿using Olbrasoft.Data.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Olbrasoft.Blog.Data.FreeSql.Tests.QueryHandlers.TagQueryHandlers;
public class TagsByUserIdQueryHandlerTests
{
    [Fact]
    public void Typeof_TagsByUserIdQuery_IsPublicShouldBeTrue()
    {
        // Arrange
        var sut = typeof(TagsByUserIdQueryHandler);
        // Act
        var isPublic = sut.IsPublic;
        // Assert
        isPublic.Should().BeTrue();

    }

    [Fact]
    public void Typeof_TagsByUserIdQueryHandler_AssemblyShouldBeSameAsExpected()
    {
        // Arrange
        var expected = typeof(BlogDbQueryHandler<,>).Assembly;

        // Act
        var sut= typeof(TagsByUserIdQueryHandler).Assembly;

        // Assert
        sut.Should().BeSameAs(expected);
    }

    [Fact]
    public void TagsByUserIdQueryHandler_TagsByUserIdQueryAs1stParamAndDefaultTokenAs2stParam_ShouldBeAssingableToExpected()
    {
        // Arrange           
        var expected = typeof(BlogDbQueryHandler<Tag, TagsByUserIdQuery, IPagedResult<TagOfUserDto>>);
        var query = new TagsByUserIdQuery(new Mock<IDispatcher>().Object);
        
        var mockSelector = new Mock<IDataSelector>();
        mockSelector.Setup(s => s.Select<Tag>()).Returns(new Mock<ISelect<Tag>>().Object);

        // Act
        var sut = new TagsByUserIdQueryHandler(selector: mockSelector.Object);
        // Assert
        sut.Should().BeAssignableTo(expected);    
    }

    [Fact]
    public async void HandleAsync_NullTagsByUserIdQueryAs1stParamAndDefaultTokenAs2stParam_ShouldThrowAsyncExactlyArgumentNullException()
    {
        // Arrange
        TagsByUserIdQuery query = null;
        var mockSelector = new Mock<IDataSelector>();
        mockSelector.Setup(s => s.Select<Tag>()).Returns(new Mock<ISelect<Tag>>().Object);
        var sut = new TagsByUserIdQueryHandler(selector: mockSelector.Object);

        // Act
        var act = () => sut.HandleAsync(query, default);

        // Assert
        await act.Should().ThrowExactlyAsync<ArgumentNullException>();
    }


   
}
