namespace Olbrasoft.Blog.Data.FreeSql.QueryHandlers.CategoryQueryHandlers
{
    public class CategoryQueryHandler(BlogFreeSqlDbContext context) : BlogDbQueryHandler<Category, CategoryQuery, CategoryOfUserDto>(context)
    {
        protected override async Task<CategoryOfUserDto> GetResultToHandleAsync(CategoryQuery query, CancellationToken token)
            => await GetOneOrNullAsync<CategoryOfUserDto>(p => p.Id == query.Id, token);
    }
}