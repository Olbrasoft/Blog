namespace Olbrasoft.Blog.Data.FreeSql.QueryHandlers.CategoryQueryHandlers
{
    public class CategoryQueryHandler : BlogDbQueryHandler<Category, CategoryQuery, CategoryOfUserDto>
    {
        public CategoryQueryHandler(IConfigure<Category> configurator, BlogFreeSqlDbContext context) : base(configurator, context)
        {
        }

        protected override async Task<CategoryOfUserDto> GetResultToHandleAsync(CategoryQuery query, CancellationToken token) 
            => await GetOneOrNullAsync<CategoryOfUserDto>(p => p.Id == query.Id, token);
    }
}