using Olbrasoft.Data.Cqrs.FreeSql;

namespace Olbrasoft.Blog.Data.FreeSql.QueryHandlers.CategoryQueryHandlers;

public class CategoriesQueryHandler : BlogDbQueryHandler<Category, CategoriesQuery, IEnumerable<CategorySmallDto>>
{
    public CategoriesQueryHandler(IConfigure<Category> configurator, BlogFreeSqlDbContext context) : base(configurator, context)
    {
    }

    public override async Task<IEnumerable<CategorySmallDto>> HandleAsync(CategoriesQuery query, CancellationToken token)
    {
        return await Select.OrderBy(cat => cat.Name).ToListAsync<CategorySmallDto>(token);
    }
}