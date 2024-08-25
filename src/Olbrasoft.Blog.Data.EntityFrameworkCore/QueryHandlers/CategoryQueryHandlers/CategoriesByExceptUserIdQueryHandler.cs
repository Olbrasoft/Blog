namespace Olbrasoft.Blog.Data.EntityFrameworkCore.QueryHandlers.CategoryQueryHandlers;

public class CategoriesByExceptUserIdQueryHandler(IProjector projector, BlogDbContext context) : BlogDbQueryHandler<Category, CategoriesByExceptUserIdQuery, IPagedResult<CategoryOfUsersDto>>(projector, context)
{
    protected override async Task<IPagedResult<CategoryOfUsersDto>> GetResultToHandleAsync(CategoriesByExceptUserIdQuery query, CancellationToken token)
    {
        var exceptUserCategories = Where(p => p.CreatorId != query.ExceptUserId);

        var filteredCategories = exceptUserCategories;

        if (!string.IsNullOrEmpty(query.Search))
        {
            filteredCategories = filteredCategories
                .Where(p => p.Name.Contains(query.Search, StringComparison.Ordinal) || (!string.IsNullOrEmpty(p.Tooltip) && p.Tooltip.Contains(query.Search, System.StringComparison.Ordinal)));
        }

        var categories = ProjectTo<CategoryOfUsersDto>(filteredCategories.OrderBy(query.OrderByColumnName, query.OrderByDirection))
            .Skip(query.Paging.CalculateSkip())
            .Take(query.Paging.PageSize).ToArrayAsync(token);

        return (await categories).AsPagedResult(await exceptUserCategories.CountAsync(token), await filteredCategories.CountAsync(token));
    }
}