namespace Olbrasoft.Blog.Data.Queries.TagQueries;

public class TagsByPostIdQuery : BaseQuery<IEnumerable<TagSmallDto>>
{
    public TagsByPostIdQuery(IDispatcher dispatcher) : base(dispatcher)
    {
    }

    public int PostId { get; set; } = int.MinValue;
}