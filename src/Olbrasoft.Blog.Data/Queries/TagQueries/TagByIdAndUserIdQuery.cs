namespace Olbrasoft.Blog.Data.Queries.TagQueries;

public class TagByIdAndUserIdQuery : ByIdQuery<TagSmallDto>
{
    public TagByIdAndUserIdQuery(IQueryProcessor processor) : base(processor)
    {
    }

    public TagByIdAndUserIdQuery(IDispatcher dispatcher) : base(dispatcher)
    {
    }

    public int UserId { get; set; }
}