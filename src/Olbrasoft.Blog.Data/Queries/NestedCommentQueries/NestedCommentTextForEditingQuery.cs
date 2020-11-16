using Olbrasoft.Blog.Data.Queries.CommentQueries;
using Olbrasoft.Dispatching.Common;

namespace Olbrasoft.Blog.Data.Queries.NestedCommentQueries
{
    public class NestedCommentTextForEditingQuery : CommentTextForEditingQuery
    {
        public NestedCommentTextForEditingQuery(IDispatcher dispatcher) : base(dispatcher)
        {
        }
    }
}