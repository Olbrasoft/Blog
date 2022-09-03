using Microsoft.EntityFrameworkCore;
using Olbrasoft.Blog.Data.Dtos.CategoryDtos;
using Olbrasoft.Blog.Data.Entities;
using Olbrasoft.Blog.Data.Queries.CategoryQueries;
using Olbrasoft.Extensions.Linq;
using Olbrasoft.Data.Paging;
using Olbrasoft.Extensions.Paging;
using Olbrasoft.Mapping;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using System;

namespace Olbrasoft.Blog.Data.EntityFrameworkCore.QueryHandlers.CategoryQueryHandlers
{
    public class CategoriesByExceptUserIdQueryHandler : BlogDbQueryHandler<Category, CategoriesByExceptUserIdQuery, IPagedResult<CategoryOfUsersDto>>
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
                filteredCategories = filteredCategories.Where(p => p.Name.Contains(query.Search, System.StringComparison.Ordinal) || p.Tooltip.Contains(query.Search, System.StringComparison.Ordinal));
            }

            var categories = ProjectTo<CategoryOfUsersDto>(filteredCategories.OrderBy(query.OrderByColumnName, query.OrderByDirection))
                .Skip(query.Paging.CalculateSkip())
                .Take(query.Paging.PageSize).ToArrayAsync(token);
                     

            return (await categories).AsPagedResult(await exceptUserCategories.CountAsync(token), await filteredCategories.CountAsync(token));

        }
    }
}