namespace Olbrasoft.Blog.Data.FreeSql.QueryHandlers.CategoryQueryHandlers;

public class CategoriesByExceptUserIdQueryHandler : BlogDbQueryHandler<Category, CategoriesByExceptUserIdQuery, IPagedResult<CategoryOfUsersDto>>
{
    public CategoriesByExceptUserIdQueryHandler(IConfigure<Category> configurator, BlogFreeSqlDbContext context) : base(configurator, context)
    {
    }

    protected override async Task<IPagedResult<CategoryOfUsersDto>> GetResultToHandleAsync(CategoriesByExceptUserIdQuery query, CancellationToken token)
    {
        var exceptUserCategories = Select.Where(p => p.CreatorId != query.ExceptUserId);

        Select = BuildSearchSelect(query.Search, exceptUserCategories);

        return (await Select.OrderByPropertyName(query.OrderByColumnName, query.OrderByDirection.ToBoolean())
            .Page(query.Paging.NumberOfSelectedPage, query.Paging.PageSize)
            .ToListAsync(c => new CategoryOfUsersDto { Creator = $"{c.Creator.FirstName} {c.Creator.LastName}" }, token))
            .AsPagedResult(await exceptUserCategories.CountAsync(token), await Select.CountAsync(token));
    }

    private static ISelect<Category> BuildSearchSelect(string search, ISelect<Category> sourceSelect)
            => !string.IsNullOrEmpty(search)
                ? sourceSelect.Where(p => p.Name.Contains(search, StringComparison.Ordinal)
                                    || (!string.IsNullOrEmpty(p.Tooltip) && p.Tooltip.Contains(search, StringComparison.Ordinal)))
                : sourceSelect;
}