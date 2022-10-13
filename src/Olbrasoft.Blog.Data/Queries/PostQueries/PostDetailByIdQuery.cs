namespace Olbrasoft.Blog.Data.Queries.PostQueries;

public class PostDetailByIdQuery : ByIdQuery<PostDetailDto>
{
    public PostDetailByIdQuery(IQueryProcessor processor) : base(processor)
    {
    }

    public PostDetailByIdQuery(IDispatcher dispatcher) : base(dispatcher)
    {
    }
}