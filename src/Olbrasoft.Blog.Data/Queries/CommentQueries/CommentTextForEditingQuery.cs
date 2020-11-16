using Olbrasoft.Blog.Data.Dtos.CommentDtos;
using Olbrasoft.Data.Cqrs.Queries;
using Olbrasoft.Dispatching.Common;

namespace Olbrasoft.Blog.Data.Queries.CommentQueries
{
    public class CommentTextForEditingQuery : ByIdQuery<string>
    {
        public CommentTextForEditingQuery(IDispatcher dispatcher) : base(dispatcher)
        {
        }

        public int CreatorId { get; set; }
    }
}