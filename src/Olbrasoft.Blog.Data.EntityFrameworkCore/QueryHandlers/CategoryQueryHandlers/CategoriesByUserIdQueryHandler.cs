namespace Olbrasoft.Blog.Data.EntityFrameworkCore.QueryHandlers.CategoryQueryHandlers
{
    public class CategoriesByUserIdQueryHandler : BlogDbQueryHandler<Category, CategoriesByUserIdQuery, IPagedResult<CategoryOfUserDto>>
    {
        public CategoriesByUserIdQueryHandler(IProjector projector, BlogDbContext context) : base(projector, context)
        {
        }

        public override async Task<IPagedResult<CategoryOfUserDto>> HandleAsync(CategoriesByUserIdQuery query, CancellationToken token)
        {
            var userCategories = EntityQueryable.Where(p => p.CreatorId == query.UserId);

            var filteredCategories = userCategories;

            if (!string.IsNullOrEmpty(query.Search))
            {
                filteredCategories = filteredCategories
                    .Where(p => p.Name.Contains(query.Search) || (!string.IsNullOrEmpty(p.Tooltip) && p.Tooltip.Contains(query.Search)));
            }

            var categories = ProjectTo<CategoryOfUserDto>(filteredCategories.OrderBy(query.OrderByColumnName, query.OrderByDirection))
                .Skip(query.Paging.CalculateSkip())
                .Take(query.Paging.PageSize).ToArrayAsync(token);

            return (await categories).AsPagedResult(await userCategories.CountAsync(token), await filteredCategories.CountAsync(token));
        }
    }
}