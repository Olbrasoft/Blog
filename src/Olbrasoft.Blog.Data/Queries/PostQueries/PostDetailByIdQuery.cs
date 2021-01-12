using Olbrasoft.Blog.Data.Dtos.PostDtos;
using Olbrasoft.Data.Cqrs.Requests;
using Olbrasoft.Dispatching.Common;

namespace Olbrasoft.Blog.Data.Queries.PostQueries
{
    public class PostDetailByIdQuery : ByIdRequest<PostDetailDto>
    {
        public PostDetailByIdQuery(IDispatcher dispatcher) : base(dispatcher)
        {
        }
    }
}