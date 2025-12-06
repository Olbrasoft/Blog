namespace Olbrasoft.Blog.Data.EntityFrameworkCore.QueryHandlers.CategoryQueryHandlers;

public class CategoryQueryHandler(IProjector projector, BlogDbContext context) : BlogDbQueryHandler<Category, CategoryQuery, CategoryOfUserDto>(projector, context)
{
    protected override async Task<CategoryOfUserDto> GetResultToHandleAsync(CategoryQuery query, CancellationToken token)
        => await ProjectTo<CategoryOfUserDto>(c => c.Id == query.Id).FirstAsync(token);
}