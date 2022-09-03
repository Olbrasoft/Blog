namespace Olbrasoft.Blog.Data.Queries.CommentQueries;

public class CommentTextForEditingQuery : ByIdRequest<string>
{
    public CommentTextForEditingQuery(IDispatcher dispatcher) : base(dispatcher)
    {
    }

    public int CreatorId { get; set; }
}