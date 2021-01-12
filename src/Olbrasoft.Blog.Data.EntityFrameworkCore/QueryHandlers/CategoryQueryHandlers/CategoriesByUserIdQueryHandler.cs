using Microsoft.EntityFrameworkCore;
using Olbrasoft.Blog.Data.Dtos.CategoryDtos;
using Olbrasoft.Blog.Data.Entities;
using Olbrasoft.Blog.Data.Queries.CategoryQueries;
using Olbrasoft.Data.Cqrs.EntityFrameworkCore;
using Olbrasoft.Data.Linq.Expressions;
using Olbrasoft.Data.Paging;
using Olbrasoft.Mapping;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Olbrasoft.Blog.Data.EntityFrameworkCore.QueryHandlers.CategoryQueryHandlers
{
    public class CategoriesByUserIdQueryHandler : BlogDbQueryHandler<Category, CategoriesByUserIdQuery, IPagedResult<CategoryOfUserDto>>
    {
        public CategoriesByUserIdQueryHandler(IProjector projector, IDbContextFactory<BlogDbContext> factory) : base(projector, factory)
        {
        }

        public override async Task<IPagedResult<CategoryOfUserDto>> HandleAsync(CategoriesByUserIdQuery query, CancellationToken token)
        {
            var userCategories = Entities.Where(p => p.CreatorId == query.UserId);

            var filteredCategories = userCategories;

            if (!string.IsNullOrEmpty(query.Search))
            {
                filteredCategories = filteredCategories.Where(p => p.Name.ToLower().Contains(query.Search.ToLower()) || p.Tooltip.ToLower().Contains(query.Search.ToLower()));
            }

            var categories = ProjectTo<CategoryOfUserDto>(filteredCategories.OrderBy(query.OrderByColumnName, query.OrderByDirection))
                .Skip(query.Paging.CalculateSkip())
                .Take(query.Paging.PageSize);

            return new PagedResult<CategoryOfUserDto>(await categories.ToArrayAsync(token))
            {
                TotalCount = await userCategories.CountAsync(token),

                FilteredCount = await filteredCategories.CountAsync(token)
            };
        }
    }
}