namespace Olbrasoft.Blog.Data.EntityFrameworkCore.QueryHandlers.CategoryQueryHandlers
{
    public class CategoryExistsQueryHandler : BlogDbQueryHandler<Category, CategoryExistsQuery>
    {
        public CategoryExistsQueryHandler(IProjector projector, BlogDbContext context) : base(projector, context)
        {
        }

        protected override async Task<bool> GetResultToHandleAsync(CategoryExistsQuery query, CancellationToken token)
        {
            if (string.IsNullOrEmpty(query.Name))
            {
                return await Queryable.AnyAsync(token);
            }

            if (query.ExceptId == null || query.ExceptId == 0)
            {
                return await Queryable.AnyAsync(p => p.Name == query.Name, token); ;
            }

            return await Queryable.AnyAsync(p => p.Id != query.ExceptId && p.Name == query.Name, token);
        }
    }
}