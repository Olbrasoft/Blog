namespace Olbrasoft.Blog.Data.Queries.TagQueries;

public class TagsQuery : BaseQuery<IEnumerable<TagSmallDto>>
{
    public TagsQuery(IQueryProcessor processor) : base(processor)
    {
    }

    public TagsQuery(IDispatcher dispatcher) : base(dispatcher)
    {
    }
}