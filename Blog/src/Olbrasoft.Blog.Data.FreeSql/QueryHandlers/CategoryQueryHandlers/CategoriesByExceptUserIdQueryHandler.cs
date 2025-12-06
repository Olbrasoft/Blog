namespace Olbrasoft.Blog.Data.FreeSql.QueryHandlers.CategoryQueryHandlers;

public class CategoriesByExceptUserIdQueryHandler(BlogFreeSqlDbContext context) : BlogDbQueryHandler<Category, CategoriesByExceptUserIdQuery, IPagedResult<CategoryOfUsersDto>>(context)
{
    protected override async Task<IPagedResult<CategoryOfUsersDto>> GetResultToHandleAsync(CategoriesByExceptUserIdQuery query, CancellationToken token)
    {
        var exceptUserCategoriesSelect = GetWhere(p => p.CreatorId != query.ExceptUserId);

        var filteredCategoriesSelect = FilterCategoriesBySearch(query.Search, exceptUserCategoriesSelect);

        return (await filteredCategoriesSelect.OrderByPropertyName(query.OrderByColumnName, query.OrderByDirection.ToBoolean())
            .Page(query.Paging.NumberOfSelectedPage, query.Paging.PageSize)
            .ToListAsync(c => new CategoryOfUsersDto { Creator = $"{c.Creator.FirstName} {c.Creator.LastName}" }, token))
            .AsPagedResult(await exceptUserCategoriesSelect.CountAsync(token), await filteredCategoriesSelect.CountAsync(token));
    }

    private static ISelect<Category> FilterCategoriesBySearch(string search, ISelect<Category> initialCategorySelect)
            => !string.IsNullOrEmpty(search)
                ? initialCategorySelect.Where(p => p.Name.Contains(search, StringComparison.Ordinal)
                                    || (!string.IsNullOrEmpty(p.Tooltip) && p.Tooltip.Contains(search, StringComparison.Ordinal)))
                : initialCategorySelect;
}