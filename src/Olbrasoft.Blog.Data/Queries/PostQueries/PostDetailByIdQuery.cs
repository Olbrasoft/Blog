using Olbrasoft.Blog.Data.Dtos;
using Olbrasoft.Data.Cqrs;
using Olbrasoft.Dispatching;

namespace Olbrasoft.Blog.Data.Queries.PostQueries
{
    public class PostDetailByIdQuery : ByIdQuery<PostDetailDto>
    {
        public PostDetailByIdQuery(IDispatcher dispatcher) : base(dispatcher)
        {
        }
    }
}