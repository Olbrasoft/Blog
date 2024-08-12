namespace Olbrasoft.Blog.Data.Queries.TagQueries;

public class TagsByUserIdQuery : ByUserIdQuery<IPagedResult<TagOfUserDto>>
{
    public TagsByUserIdQuery(IQueryProcessor processor) : base(processor)
    {
    }

    public TagsByUserIdQuery(IMediator mediator) : base(mediator)
    {
    }
}