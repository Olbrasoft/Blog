using Microsoft.EntityFrameworkCore;
using Olbrasoft.Blog.Data.Entities;
using Olbrasoft.Blog.Data.Queries.CategoryQueries;
using Olbrasoft.Data.Cqrs.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Olbrasoft.Blog.Data.EntityFrameworkCore.QueryHandlers.CategoryQueryHandlers
{
    public class CategoryExistsQueryHandler : BlogDbQueryHandler<Category, CategoryExistsQuery>
    {
        public CategoryExistsQueryHandler(BlogDbContext context) : base(context)
        {
        }

        public override async Task<bool> HandleAsync(CategoryExistsQuery query, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(query.Name))
            {
                return await Entities.AnyAsync();
            }

            if (query.ExceptId == null || query.ExceptId == 0)
            {
                return await Entities.AnyAsync(p => p.Name == query.Name);
            }

            return await Entities.AnyAsync(p => p.Id != query.ExceptId && p.Name == query.Name);
        }
    }
}