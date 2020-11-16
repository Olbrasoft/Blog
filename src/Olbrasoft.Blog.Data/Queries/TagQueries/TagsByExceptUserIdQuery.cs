using Olbrasoft.Blog.Data.Dtos.TagDtos;
using Olbrasoft.Data.Paging;
using Olbrasoft.Dispatching.Common;

namespace Olbrasoft.Blog.Data.Queries.TagQueries
{
    public class TagsByExceptUserIdQuery : ItemsExceptUserIdQuery<IPagedResult<TagOfUsersDto>>
    {
        public TagsByExceptUserIdQuery(IDispatcher dispatcher) : base(dispatcher)
        {
        }
    }
}