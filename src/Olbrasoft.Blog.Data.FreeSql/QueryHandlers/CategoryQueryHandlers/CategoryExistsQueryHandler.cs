namespace Olbrasoft.Blog.Data.FreeSql.QueryHandlers.CategoryQueryHandlers;

public class CategoryExistsQueryHandler(BlogFreeSqlDbContext context) : BlogDbQueryHandler<Category, CategoryExistsQuery>(context)
{
    protected override async Task<bool> GetResultToHandleAsync(CategoryExistsQuery query, CancellationToken token)
    {
        return string.IsNullOrEmpty(query.Name)
            ? await ExistsAsync(token)
            : query.ExceptId == null || query.ExceptId == 0
                ? await ExistsAsync(p => p.Name == query.Name, token)
                : await ExistsAsync(p => p.Id != query.ExceptId && p.Name == query.Name, token);
    }
}