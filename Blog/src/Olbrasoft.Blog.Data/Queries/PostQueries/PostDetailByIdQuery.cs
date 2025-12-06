namespace Olbrasoft.Blog.Data.Queries.PostQueries;

public class PostDetailByIdQuery : ByIdQuery<PostDetailDto>
{
    public PostDetailByIdQuery(IQueryProcessor processor) : base(processor)
    {
    }

    public PostDetailByIdQuery(IMediator mediator) : base(mediator)
    {
    }
}