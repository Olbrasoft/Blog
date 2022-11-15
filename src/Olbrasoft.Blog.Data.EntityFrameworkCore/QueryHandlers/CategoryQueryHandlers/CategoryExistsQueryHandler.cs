namespace Olbrasoft.Blog.Data.EntityFrameworkCore.QueryHandlers.CategoryQueryHandlers
{
    public class CategoryExistsQueryHandler : BlogDbQueryHandler<Category, CategoryExistsQuery>
    {
        public CategoryExistsQueryHandler(IProjector projector, BlogDbContext context) : base(projector, context)
        {
        }

        public override async Task<bool> HandleAsync(CategoryExistsQuery query, CancellationToken token)
        {

            ThrowIfQueryIsNullOrCancellationRequested(query, token);

            if (string.IsNullOrEmpty(query.Name))
            {
                return await EntityQueryable.AnyAsync(token);
            }

            if (query.ExceptId == null || query.ExceptId == 0)
            {
                return await EntityQueryable.AnyAsync(p => p.Name == query.Name, token); ;
            }

            return await EntityQueryable.AnyAsync(p => p.Id != query.ExceptId && p.Name == query.Name, token);
        }
    }
}