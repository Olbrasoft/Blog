namespace Olbrasoft.Blog.Data.Queries.TagQueries;

public class TagsByLabelContainsQuery : BaseQuery<IEnumerable<TagSmallDto>>
{
    public string Text { get; set; } = string.Empty;
    public IEnumerable<int> ExceptTagIds { get; set; } = Enumerable.Empty<int>();

    public TagsByLabelContainsQuery(IQueryProcessor processor) : base(processor)
    {
    }

    public TagsByLabelContainsQuery(IMediator mediator) : base(mediator)
    {
    }
}