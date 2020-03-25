using Microsoft.EntityFrameworkCore;
using Olbrasoft.Blog.Data.Dtos;
using Olbrasoft.Blog.Data.Entities;
using Olbrasoft.Blog.Data.Queries.CategoryQueries;
using Olbrasoft.Data.Cqrs.EntityFrameworkCore;
using Olbrasoft.Data.Linq.Expressions;
using Olbrasoft.Data.Paging;
using Olbrasoft.Mapping;
using Olbrasoft.Paging;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Olbrasoft.Blog.Data.EntityFrameworkCore.QueryHandlers.CategoryQueryHandlers
{
    public class CategoriesByExceptUserIdQueryHandler : DbQueryHandler<Category, CategoriesByExceptUserIdQuery, IPagedResult<CategoryOfUsersDto>>
    {
        public CategoriesByExceptUserIdQueryHandler(IProjector projector, BlogDbContext context) : base(projector, context)
        {
        }

        public override async Task<IPagedResult<CategoryOfUsersDto>> HandleAsync(CategoriesByExceptUserIdQuery query, CancellationToken token)
        {
            var exceptUserCategories = Entities.Where(p => p.CreatorId != query.ExceptUserId);

            var filteredCategories = exceptUserCategories;

            if (!string.IsNullOrEmpty(query.Search))
            {
                filteredCategories = filteredCategories.Where(p => p.Name.ToLower().Contains(query.Search.ToLower()) || p.Tooltip.ToLower().Contains(query.Search.ToLower()));
            }

            var categories = ProjectTo<CategoryOfUsersDto>(filteredCategories.OrderBy(query.OrderByColumnName, query.OrderByDirection))
                .Skip(query.Paging.CalculateSkip())
                .Take(query.Paging.PageSize);

            return new PagedResult<CategoryOfUsersDto>
            {
                Records = await categories.ToArrayAsync(token),

                TotalCount = await exceptUserCategories.CountAsync(token),

                FilteredCount = await filteredCategories.CountAsync(token)
            };
        }
    }
}