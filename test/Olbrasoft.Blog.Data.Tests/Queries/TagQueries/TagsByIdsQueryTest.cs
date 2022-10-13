namespace Olbrasoft.Blog.Data.Queries.TagQueries;
public class TagsByIdsQueryTest
{
    [Fact]
    public void TagsByIdsQuery_Inherits_From_Request_Of_IEnumerable_Of_TagSmallDto()
    {
        //Arrange
        var processorMock = new Mock<IQueryProcessor>();

        //Act
        var query = new TagsByIdsQuery(processorMock.Object);

        //Assert
        Assert.IsAssignableFrom<BaseQuery<IEnumerable<TagSmallDto>>>(query);
    }


}
