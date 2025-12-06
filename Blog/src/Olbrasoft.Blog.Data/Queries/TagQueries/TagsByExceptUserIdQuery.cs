namespace Olbrasoft.Blog.Data.Queries.TagQueries;

public class TagsByExceptUserIdQuery : ExceptUserIdQuery<IPagedResult<TagOfUsersDto>>
{
    public TagsByExceptUserIdQuery(IQueryProcessor processor) : base(processor)
    {
    }

    public TagsByExceptUserIdQuery(IMediator mediator) : base(mediator)
    {
    }
}