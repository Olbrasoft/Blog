using Olbrasoft.Blog.Data.Dtos;
using Olbrasoft.Data.Paging;
using Olbrasoft.Dispatching;

namespace Olbrasoft.Blog.Data.Queries.CategoryQueries
{
    public class CategoriesByUserIdQuery : ItemsByUserIdQuery<IPagedResult<CategoryOfUserDto>>
    {
        public CategoriesByUserIdQuery(IDispatcher dispatcher) : base(dispatcher)
        {
        }
    }
}