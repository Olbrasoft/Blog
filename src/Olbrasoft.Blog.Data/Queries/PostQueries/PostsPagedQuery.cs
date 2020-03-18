using Olbrasoft.Blog.Data.Dtos;
using Olbrasoft.Data.Cqrs;
using Olbrasoft.Data.Paging;
using Olbrasoft.Dispatching;

namespace Olbrasoft.Blog.Data.Queries.PostQueries
{
    public class PostsPagedQuery : PagedQuery<IPagedResult<PostDto>>
    {
        public PostsPagedQuery(IDispatcher dispatcher) : base(dispatcher)
        {
        }
    }
}