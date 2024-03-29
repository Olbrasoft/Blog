﻿namespace Olbrasoft.Blog.Data.Queries.CategoryQueries;

public class CategoryExistsQueryTest
{
    [Fact]
    public void Instance_Implement_Interface_IRequest_Of_True()
    {
        //Arrange
        var type = typeof(BaseQuery<bool>);

        //Act
        var query = CreateQuery();

        //Assert
        Assert.IsAssignableFrom(type, query);
    }

    [Fact]
    public void Name()
    {
        //Arrange
        var query = CreateQuery();

        //Act
        var name = query.Name;

        //Assert
        Assert.IsAssignableFrom<string>(name);
    }

    private static CategoryExistsQuery CreateQuery()
    {
        var procesorMock = new Mock<IQueryProcessor>();

        return new CategoryExistsQuery(procesorMock.Object) { ExceptId = 0 };
    }

    [Fact]
    public void ExceptId()
    {
        //Arrange
        var query = CreateQuery();

        //Act
        var id = query.ExceptId;

        //Assert
        Assert.IsAssignableFrom<int?>(id);
    }
}