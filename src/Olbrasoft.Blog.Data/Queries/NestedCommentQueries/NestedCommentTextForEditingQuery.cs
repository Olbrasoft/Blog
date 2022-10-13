using Olbrasoft.Blog.Data.Queries.CommentQueries;

namespace Olbrasoft.Blog.Data.Queries.NestedCommentQueries;

public class NestedCommentTextForEditingQuery : CommentTextForEditingQuery
{
    public NestedCommentTextForEditingQuery(IQueryProcessor processor) : base(processor)
    {
    }

    public NestedCommentTextForEditingQuery(IDispatcher dispatcher) : base(dispatcher)
    {
    }
}