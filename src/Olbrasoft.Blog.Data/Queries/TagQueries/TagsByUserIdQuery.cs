using Olbrasoft.Blog.Data.Dtos.TagDtos;
using Olbrasoft.Data.Paging;
using Olbrasoft.Dispatching.Common;

namespace Olbrasoft.Blog.Data.Queries.TagQueries
{
    public class TagsByUserIdQuery : ItemsByUserIdQuery<IPagedResult<TagOfUserDto>>
    {
        public TagsByUserIdQuery(IDispatcher dispatcher) : base(dispatcher)
        {
        }
    }
}