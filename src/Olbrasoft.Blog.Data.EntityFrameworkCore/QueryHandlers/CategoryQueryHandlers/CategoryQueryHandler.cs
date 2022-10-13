namespace Olbrasoft.Blog.Data.EntityFrameworkCore.QueryHandlers.CategoryQueryHandlers
{
    public class CategoryQueryHandler : BlogDbQueryHandler<Category, CategoryQuery, CategoryOfUserDto>
    {
        public CategoryQueryHandler(IProjector projector, BlogDbContext context) : base(projector, context)
        {
        }

        public override async Task<CategoryOfUserDto> HandleAsync(CategoryQuery query, CancellationToken token)
        {
            return await ProjectTo<CategoryOfUserDto>(Entities.Where(p => p.Id == query.Id)).FirstOrDefaultAsync(token);
        }
    }
}