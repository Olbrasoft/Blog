using Olbrasoft.Blog.Data.Dtos.CommentDtos;
using Olbrasoft.Dispatching.Common;
using System.Collections.Generic;

namespace Olbrasoft.Blog.Data.Queries.CommentQueries
{
    public class CommentsByPostIdQuery : Request<IEnumerable<CommentDto>>
    {
        public CommentsByPostIdQuery(IDispatcher dispatcher) : base(dispatcher)
        {
        }

        public int PostId { get; set; }
    }
}