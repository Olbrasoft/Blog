namespace Olbrasoft.Blog.Data.EntityFrameworkCore.QueryHandlers.CategoryQueryHandlers
{
    public class CategoriesQueryHandler : BlogDbQueryHandler<Category, CategoriesQuery, IEnumerable<CategorySmallDto>>
    {
        public CategoriesQueryHandler(IProjector projector, BlogDbContext context) : base(projector, context)
        {
        }

        public override async Task<IEnumerable<CategorySmallDto>> HandleAsync(CategoriesQuery query, CancellationToken token)
        {
            return await ProjectTo<CategorySmallDto>(Entities).OrderBy(p => p.Name).ToArrayAsync(token);
        }
    }
}