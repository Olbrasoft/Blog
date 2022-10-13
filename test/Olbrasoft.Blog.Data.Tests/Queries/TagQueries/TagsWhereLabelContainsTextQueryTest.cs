namespace Olbrasoft.Blog.Data.Queries.TagQueries;
public class TagsWhereLabelContainsTextQueryTest
{
    [Fact]
    public void TagsWhereLabelContainsTextQuery_Inherits_From_Request_Of_IEnumerable_Of_()
    {
        //Arrange
        var processorMock = new Mock<IQueryProcessor>();

        //Act
        var query = new TagsByLabelContainsQuery(processorMock.Object);

        //Assert
        Assert.IsAssignableFrom<BaseQuery<IEnumerable<TagSmallDto>>>(query);
    }

}
