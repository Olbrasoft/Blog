using Microsoft.EntityFrameworkCore;
using Olbrasoft.Blog.Data.Dtos;
using Olbrasoft.Blog.Data.Entities;
using Olbrasoft.Blog.Data.Queries.CategoryQueries;
using Olbrasoft.Data.Cqrs.EntityFrameworkCore;
using Olbrasoft.Mapping;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Olbrasoft.Blog.Data.EntityFrameworkCore.QueryHandlers.CategoryQueryHandlers
{
    public class CategoriesQueryHandler : DbQueryHandler<Category, CategoriesQuery, IEnumerable<CategorySmallDto>>
    {
        public CategoriesQueryHandler(IProjector projector, BlogDbContext context) : base(projector, context)
        {
        }

        public override async Task<IEnumerable<CategorySmallDto>> HandleAsync(CategoriesQuery query, CancellationToken token)
        {
            return await ProjectTo<CategorySmallDto>(Entities).OrderBy(p => p.Name).ToArrayAsync(token);
        }
    }
}