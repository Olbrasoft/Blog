namespace Olbrasoft.Blog.Data.FreeSql.QueryHandlers.CategoryQueryHandlers
{
    public class CategoryQueryHandler : BlogDbQueryHandler<Category, CategoryQuery, CategoryOfUserDto>
    {
        public CategoryQueryHandler(IDataSelector selector) : base(selector)
        {
        }

        public override async Task<CategoryOfUserDto> HandleAsync(CategoryQuery query, CancellationToken token)
        {
            ThrowIfQueryIsNullOrCancellationRequested(query, token);

            return await Select.Where(p => p.Id == query.Id).FirstAsync<CategoryOfUserDto>(token);
        }
    }
}