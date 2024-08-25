namespace Olbrasoft.Blog.Data.EntityFrameworkCore.QueryHandlers.CategoryQueryHandlers;

public class CategoriesQueryHandler(IProjector projector, BlogDbContext context) : BlogDbQueryHandler<Category, CategoriesQuery, IEnumerable<CategorySmallDto>>(projector, context)
{
    protected override async Task<IEnumerable<CategorySmallDto>> GetResultToHandleAsync(CategoriesQuery query, CancellationToken token)
        => await ProjectTo<CategorySmallDto>(OrderBy(p => p.Name)).ToArrayAsync(token);
}