using Olbrasoft.Blog.Data.Dtos;
using Olbrasoft.Data.Paging;
using Olbrasoft.Dispatching;

namespace Olbrasoft.Blog.Data.Queries.TagQueries
{
    public class TagsByUserIdQuery : ItemsByUserIdQuery<IPagedResult<TagDto>>
    {
        public TagsByUserIdQuery(IDispatcher dispatcher) : base(dispatcher)
        {
        }
    }
}