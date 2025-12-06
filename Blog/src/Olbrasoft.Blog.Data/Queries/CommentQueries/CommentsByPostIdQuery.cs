using Olbrasoft.Blog.Data.Dtos.CommentDtos;

namespace Olbrasoft.Blog.Data.Queries.CommentQueries;

public class CommentsByPostIdQuery : BaseQuery<IEnumerable<CommentDto>>
{
    public int PostId { get; set; }

    public CommentsByPostIdQuery(IQueryProcessor processor) : base(processor)
    {
    }

    public CommentsByPostIdQuery(IMediator mediator) : base(mediator)
    {
    }
}