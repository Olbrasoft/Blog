using Olbrasoft.Blog.Data.Dtos.CategoryDtos;
using Olbrasoft.Data.Paging;
using Olbrasoft.Dispatching.Common;

namespace Olbrasoft.Blog.Data.Queries.CategoryQueries
{
    public class CategoriesByUserIdQuery : ItemsByUserIdQuery<IPagedResult<CategoryOfUserDto>>
    {
        public CategoriesByUserIdQuery(IDispatcher dispatcher) : base(dispatcher)
        {
        }
    }
}