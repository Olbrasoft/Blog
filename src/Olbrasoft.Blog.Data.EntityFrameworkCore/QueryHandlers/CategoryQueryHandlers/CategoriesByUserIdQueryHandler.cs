using Microsoft.EntityFrameworkCore;
using Olbrasoft.Blog.Data.Dtos.CategoryDtos;
using Olbrasoft.Blog.Data.Entities;
using Olbrasoft.Blog.Data.Queries.CategoryQueries;
using Olbrasoft.Data.Cqrs.EntityFrameworkCore;
using Olbrasoft.Extensions.Linq;
using Olbrasoft.Data.Paging;
using Olbrasoft.Mapping;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Olbrasoft.Extensions.Paging;
using System;

namespace Olbrasoft.Blog.Data.EntityFrameworkCore.QueryHandlers.CategoryQueryHandlers
{
    public class CategoriesByUserIdQueryHandler : BlogDbQueryHandler<Category, CategoriesByUserIdQuery, IPagedResult<CategoryOfUserDto>>
    {
        public CategoriesByUserIdQueryHandler(IProjector projector, BlogDbContext context) : base(projector, context)
        {
        }

        public override async Task<IPagedResult<CategoryOfUserDto>> HandleAsync(CategoriesByUserIdQuery query, CancellationToken token)
        {
            var userCategories = Entities.Where(p => p.CreatorId == query.UserId);

            var filteredCategories = userCategories;

            if (!string.IsNullOrEmpty(query.Search))
            {
                filteredCategories = filteredCategories.Where(p => p.Name.Contains(query.Search) || p.Tooltip.Contains(query.Search));
            }

           

            var categories = ProjectTo<CategoryOfUserDto>(filteredCategories.OrderBy(query.OrderByColumnName, query.OrderByDirection))
                .Skip(query.Paging.CalculateSkip())
                .Take(query.Paging.PageSize).ToArrayAsync(token);
                    
            return (await categories).AsPagedResult(await userCategories.CountAsync(token), await filteredCategories.CountAsync(token));
        }
    }
}