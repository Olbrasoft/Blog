using Olbrasoft.Blog.Data.Dtos.PostDtos;
using Olbrasoft.Data.Paging;
using Olbrasoft.Dispatching.Common;

namespace Olbrasoft.Blog.Data.Queries.PostQueries
{
    public class PostsByUserIdQuery : ItemsByUserIdQuery<IPagedResult<PostOfUserDto>>
    {
        public PostsByUserIdQuery(IDispatcher dispatcher) : base(dispatcher)
        {
        }
    }
}