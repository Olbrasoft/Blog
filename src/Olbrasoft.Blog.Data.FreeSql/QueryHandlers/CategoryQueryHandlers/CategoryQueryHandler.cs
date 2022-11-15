using Olbrasoft.Data.Cqrs.FreeSql;

namespace Olbrasoft.Blog.Data.FreeSql.QueryHandlers.CategoryQueryHandlers
{
    public class CategoryQueryHandler : BlogDbQueryHandler<Category, CategoryQuery, CategoryOfUserDto>
    {
        public CategoryQueryHandler(IConfigure<Category> configurator, BlogFreeSqlDbContext context) : base(configurator, context)
        {
        }

        public override async Task<CategoryOfUserDto> HandleAsync(CategoryQuery query, CancellationToken token)
        {
            ThrowIfQueryIsNullOrCancellationRequested(query, token);

            return await Select.Where(p => p.Id == query.Id).FirstAsync<CategoryOfUserDto>(token);
        }
    }
}