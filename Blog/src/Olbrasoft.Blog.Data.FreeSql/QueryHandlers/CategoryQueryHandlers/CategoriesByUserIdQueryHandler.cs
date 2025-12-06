namespace Olbrasoft.Blog.Data.FreeSql.QueryHandlers.CategoryQueryHandlers;

public class CategoriesByUserIdQueryHandler(BlogFreeSqlDbContext context) : BlogDbQueryHandler<Category, CategoriesByUserIdQuery, IPagedResult<CategoryOfUserDto>>(context)
{
    protected override async Task<IPagedResult<CategoryOfUserDto>> GetResultToHandleAsync(CategoriesByUserIdQuery query, CancellationToken token)
    {
        var userCategories = GetWhere(p => p.CreatorId == query.UserId);

        var categories = BuildCategorySelect(query.Search, userCategories);


        return (await categories.OrderByPropertyName(query.OrderByColumnName, query.OrderByDirection.ToBoolean())
             .Page(query.Paging.NumberOfSelectedPage, query.Paging.PageSize)
             .ToListAsync<CategoryOfUserDto>(token))
             .AsPagedResult(await userCategories.CountAsync(token), await categories.CountAsync(token));
    }

    private static ISelect<Category> BuildCategorySelect(string search, ISelect<Category> sourceSelect)
       => !string.IsNullOrEmpty(search)
        ? sourceSelect.Where(p => p.Name.Contains(search) || (!string.IsNullOrEmpty(p.Tooltip) && p.Tooltip.Contains(search)))
        : sourceSelect;
}


