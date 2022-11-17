namespace Olbrasoft.Blog.Data.FreeSql.QueryHandlers.CategoryQueryHandlers;

public class CategoriesByUserIdQueryHandler : BlogDbQueryHandler<Category, CategoriesByUserIdQuery, IPagedResult<CategoryOfUserDto>>
{
    public CategoriesByUserIdQueryHandler(IConfigure<Category> configurator, BlogFreeSqlDbContext context) : base(configurator, context)
    {
    }

    protected override async Task<IPagedResult<CategoryOfUserDto>> GetResultToHandleAsync(CategoriesByUserIdQuery query, CancellationToken token)
    {
        var userCategory = GetWhere(p => p.CreatorId == query.UserId);

        Select = BuildSearchSelect(query.Search, userCategory);

        return (await Select.OrderByPropertyName(query.OrderByColumnName, query.OrderByDirection.ToBoolean())
             .Page(query.Paging.NumberOfSelectedPage, query.Paging.PageSize)
             .ToListAsync<CategoryOfUserDto>(token))
             .AsPagedResult(await userCategory.CountAsync(token), await Select.CountAsync(token));
    }

    private static ISelect<Category> BuildSearchSelect(string search, ISelect<Category> sourceSelect)
       => !string.IsNullOrEmpty(search)
        ? sourceSelect.Where(p => p.Name.Contains(search) || (!string.IsNullOrEmpty(p.Tooltip) && p.Tooltip.Contains(search)))
        : sourceSelect;
}


