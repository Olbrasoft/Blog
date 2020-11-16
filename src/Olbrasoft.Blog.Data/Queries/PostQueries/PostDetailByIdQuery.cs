using Olbrasoft.Blog.Data.Dtos.PostDtos;
using Olbrasoft.Data.Cqrs.Queries;
using Olbrasoft.Dispatching.Common;

namespace Olbrasoft.Blog.Data.Queries.PostQueries
{
    public class PostDetailByIdQuery : ByIdQuery<PostDetailDto>
    {
        public PostDetailByIdQuery(IDispatcher dispatcher) : base(dispatcher)
        {
        }
    }
}