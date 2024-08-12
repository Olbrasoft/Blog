namespace Olbrasoft.Blog.Data.EntityFrameworkCore.QueryHandlers.CategoryQueryHandlers
{
    public class CategoryQueryHandler : BlogDbQueryHandler<Category, CategoryQuery, CategoryOfUserDto>
    {
        public CategoryQueryHandler(IProjector projector, BlogDbContext context) : base(projector, context)
        {
        }

        protected override async Task<CategoryOfUserDto> GetResultToHandleAsync(CategoryQuery query, CancellationToken token)
        {
            return await ProjectTo<CategoryOfUserDto>(Entities.Where(p => p.Id == query.Id)).FirstAsync(token);
        }
    }
}