using Microsoft.EntityFrameworkCore;
using Olbrasoft.Blog.Data.Dtos;
using Olbrasoft.Blog.Data.Entities;
using Olbrasoft.Blog.Data.Queries.CategoryQueries;
using Olbrasoft.Data.Cqrs.EntityFrameworkCore;
using Olbrasoft.Data.Paging;
using Olbrasoft.Linq;
using Olbrasoft.Paging;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Olbrasoft.Blog.Data.EntityFrameworkCore.QueryHandlers.CategoryQueryHandlers
{
    public class CategoriesByUserIdQueryHandler : QueryHandler<Category, CategoriesByUserIdQuery, IPagedResult<CategoryOfUserDto>>
    {
        public CategoriesByUserIdQueryHandler(BlogDbContext context) : base(context)
        {
        }

        public override async Task<IPagedResult<CategoryOfUserDto>> HandleAsync(CategoriesByUserIdQuery query, CancellationToken token)
        {
            var userCategories = Entities.Where(p => p.CreatorId == query.UserId);

            if (!string.IsNullOrEmpty(query.Search))
            {
                userCategories = userCategories.Where(p => p.Name.ToLower().Contains(query.Search.ToLower()) || p.Tooltip.ToLower().Contains(query.Search.ToLower()));
            }

            var categories = await userCategories.Select(cat => new
            {
                id = cat.Id,
                name = cat.Name,
                tooltip = cat.Tooltip,
                created = cat.Created,
                postCount = cat.Posts.Count()
            }).OrderBy(query.OrderByColumnName, query.OrderByDirection).Skip(query.Paging.CalculateSkip()).Take(query.Paging.PageSize).ToArrayAsync(token);

            return new PagedResult<CategoryOfUserDto>
            {
                Records = categories.Select(p => new CategoryOfUserDto { Id = p.id, Name = p.name, PostCount = p.postCount, Tooltip = p.tooltip, Created = p.created }),

                TotalCount = await Entities.Where(p => p.CreatorId == query.UserId).CountAsync(),

                FilteredCount = await userCategories.CountAsync()
            };
        }
    }
}