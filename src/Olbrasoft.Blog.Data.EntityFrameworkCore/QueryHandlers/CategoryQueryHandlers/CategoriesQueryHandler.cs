﻿namespace Olbrasoft.Blog.Data.EntityFrameworkCore.QueryHandlers.CategoryQueryHandlers
{
    public class CategoriesQueryHandler : BlogDbQueryHandler<Category, CategoriesQuery, IEnumerable<CategorySmallDto>>
    {
        public CategoriesQueryHandler(IProjector projector, BlogDbContext context) : base(projector, context)
        {
        }

        protected override async Task<IEnumerable<CategorySmallDto>> GetResultToHandleAsync(CategoriesQuery query, CancellationToken token)
        {
            return await ProjectTo<CategorySmallDto>(Queryable).OrderBy(p => p.Name).ToArrayAsync(token);
        }
    }
}