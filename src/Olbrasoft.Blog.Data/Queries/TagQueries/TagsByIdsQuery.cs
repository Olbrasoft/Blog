namespace Olbrasoft.Blog.Data.Queries.TagQueries;

public class TagsByIdsQuery : BaseQuery<IEnumerable<TagSmallDto>>
{

    public TagsByIdsQuery(IQueryProcessor processor) : base(processor)
    {
    }

    public TagsByIdsQuery(IMediator mediator) : base(mediator)
    {
    }

    public IEnumerable<int> Ids { get; set; } = Enumerable.Empty<int>();
}


