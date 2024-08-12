namespace Olbrasoft.Blog.Data.Queries.TagQueries;

public class TagsQuery : BaseQuery<IEnumerable<TagSmallDto>>
{
    public TagsQuery(IQueryProcessor processor) : base(processor)
    {
    }

    public TagsQuery(IMediator mediator) : base(mediator)
    {
    }
}