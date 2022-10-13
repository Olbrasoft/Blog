namespace Olbrasoft.Blog.Data.Queries.PostQueries;

public class PostsByUserIdQuery : ByUserIdQuery<IPagedResult<PostOfUserDto>>
{
    public PostsByUserIdQuery(IQueryProcessor processor) : base(processor)
    {
    }

    public PostsByUserIdQuery(IDispatcher dispatcher) : base(dispatcher)
    {
    }
}