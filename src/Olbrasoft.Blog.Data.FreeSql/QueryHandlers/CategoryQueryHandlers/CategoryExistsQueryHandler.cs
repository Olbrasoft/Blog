namespace Olbrasoft.Blog.Data.FreeSql.QueryHandlers.CategoryQueryHandlers;

public class CategoryExistsQueryHandler : BlogDbQueryHandler<Category, CategoryExistsQuery>
{
    public CategoryExistsQueryHandler(IConfigure<Category> configurator, BlogFreeSqlDbContext context) : base(configurator, context)
    {
    }

    protected override async Task<bool> GetResultToHandleAsync(CategoryExistsQuery query, CancellationToken token)
    {

        return string.IsNullOrEmpty(query.Name)
            ? await Select.AnyAsync(token)
            : query.ExceptId == null || query.ExceptId == 0
                ? await Select.AnyAsync(p => p.Name == query.Name, token)
                : await Select.AnyAsync(p => p.Id != query.ExceptId && p.Name == query.Name, token);
    }
}