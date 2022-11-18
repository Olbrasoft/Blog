namespace Olbrasoft.Blog.Data.EntityFrameworkCore.QueryHandlers.TagQueryHandlers
{
    public class TagExistsQueryHandler : BlogDbQueryHandler<Tag, TagExistsQuery>
    {
        public TagExistsQueryHandler(IProjector projector, BlogDbContext context) : base(projector, context)
        {
           
        }

        protected override async Task<bool> GetResultToHandleAsync(TagExistsQuery query, CancellationToken token)
        {

            if (string.IsNullOrEmpty(query.Label))
            {
                return await Queryable.AnyAsync( token);
            }

            if (query.ExceptId == 0)
            {
                return await Queryable.AnyAsync(p => p.Label == query.Label, token);
            }

            return await Queryable.AnyAsync(p => p.Id != query.ExceptId && p.Label == query.Label, token);
        }
    }
}