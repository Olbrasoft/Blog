namespace Olbrasoft.Blog.Data.EntityFrameworkCore.QueryHandlers.CategoryQueryHandlers;

public class CategoryExistsQueryHandler(IProjector projector, BlogDbContext context) : BlogDbQueryHandler<Category, CategoryExistsQuery>(projector, context)
{
    protected override async Task<bool> GetResultToHandleAsync(CategoryExistsQuery query, CancellationToken token)
    {
        if (string.IsNullOrEmpty(query.Name))
        {
            return await AnyAsync(token);
        }

        if (query.ExceptId is null or 0)
        {
            return await AnyAsync(p => p.Name == query.Name, token); ;
        }

        return await AnyAsync(p => p.Id != query.ExceptId && p.Name == query.Name, token);
    }
}