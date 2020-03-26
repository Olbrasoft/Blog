using Olbrasoft.Blog.Data.Dtos.CategoryDtos;
using Olbrasoft.Blog.Data.Queries.TagQueries;
using Olbrasoft.Data.Paging;
using Olbrasoft.Dispatching;

namespace Olbrasoft.Blog.Data.Queries.CategoryQueries
{
    public class CategoriesByExceptUserIdQuery : ItemsExceptUserIdQuery<IPagedResult<CategoryOfUsersDto>>
    {
        public CategoriesByExceptUserIdQuery(IDispatcher dispatcher) : base(dispatcher)
        {
        }
    }
}