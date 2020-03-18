using Microsoft.EntityFrameworkCore;
using Olbrasoft.Blog.Data.Dtos;
using Olbrasoft.Blog.Data.Entities;
using Olbrasoft.Blog.Data.Queries.CategoryQueries;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Olbrasoft.Blog.Data.EntityFrameworkCore.QueryHandlers.CategoryQueryHandlers
{
    public class CategoriesQueryHandler : Olbrasoft.Data.Cqrs.EntityFrameworkCore.QueryHandler<Category, CategoriesQuery, IEnumerable<CategorySmallDto>>
    {
        public CategoriesQueryHandler(BlogDbContext context) : base(context)
        {
        }

        public override async Task<IEnumerable<CategorySmallDto>> HandleAsync(CategoriesQuery query, CancellationToken token)
        {
            return await Entities.Select(p => new CategorySmallDto { Id = p.Id, Name = p.Name }).OrderBy(p => p.Name).ToArrayAsync();
        }
    }
}