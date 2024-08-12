namespace Olbrasoft.Blog.Data.Queries.TagQueries;

public class TagsByPostIdQuery : BaseQuery<IEnumerable<TagSmallDto>>
{
    public TagsByPostIdQuery(IMediator mediator) : base(mediator)
    {
    }

    public int PostId { get; set; } = int.MinValue;
}