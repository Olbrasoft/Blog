using Olbrasoft.Blog.Data.Dtos;
using Olbrasoft.Data.Paging;
using Olbrasoft.Dispatching;

namespace Olbrasoft.Blog.Data.Queries.TagQueries
{
    public class TagsExceptUserIdQuery : ItemsExceptUserIdQuery<IPagedResult<TagDto>>
    {
        public TagsExceptUserIdQuery(IDispatcher dispatcher) : base(dispatcher)
        {
        }
    }
}