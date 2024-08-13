namespace Olbrasoft.Blog.Data.FreeSql.QueryHandlers.CategoryQueryHandlers;

public class CategoriesQueryHandler(BlogFreeSqlDbContext context) : BlogDbQueryHandler<Category, CategoriesQuery, IEnumerable<CategorySmallDto>>(context)
{
    protected override async Task<IEnumerable<CategorySmallDto>> GetResultToHandleAsync(CategoriesQuery query, CancellationToken token) 
        => await GetOrderBy(cat => cat.Name).ToListAsync<CategorySmallDto>(token);
}