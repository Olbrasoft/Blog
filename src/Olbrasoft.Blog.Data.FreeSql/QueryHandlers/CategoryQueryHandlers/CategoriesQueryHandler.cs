namespace Olbrasoft.Blog.Data.FreeSql.QueryHandlers.CategoryQueryHandlers;

public class CategoriesQueryHandler : BlogDbQueryHandler<Category, CategoriesQuery, IEnumerable<CategorySmallDto>>
{
    public CategoriesQueryHandler(BlogFreeSqlDbContext context) : base(context)
    {
    }

    protected override async Task<IEnumerable<CategorySmallDto>> GetResultToHandleAsync(CategoriesQuery query, CancellationToken token) 
        => await GetOrderBy(cat => cat.Name).ToListAsync<CategorySmallDto>(token);
}