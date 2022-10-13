namespace Olbrasoft.Blog.Data.Queries.TagQueries;

public class TagExistsQuery : BaseQuery<bool>
{
    public int ExceptId { get; set; }
    public string Label { get; set; } = string.Empty;

    public TagExistsQuery(IQueryProcessor processor) : base(processor)
    {
    }

    public TagExistsQuery(IDispatcher dispatcher) : base(dispatcher)
    {
    }

}