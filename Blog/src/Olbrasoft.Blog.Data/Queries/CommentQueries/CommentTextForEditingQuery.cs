namespace Olbrasoft.Blog.Data.Queries.CommentQueries;

public class CommentTextForEditingQuery : ByIdQuery<string>
{
    public int CreatorId { get; set; }

    public CommentTextForEditingQuery(IQueryProcessor processor) : base(processor)
    {
    }

    public CommentTextForEditingQuery(IMediator mediator) : base(mediator)
    {
    }

}