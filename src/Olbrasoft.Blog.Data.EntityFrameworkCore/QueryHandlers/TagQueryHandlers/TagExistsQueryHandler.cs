namespace Olbrasoft.Blog.Data.EntityFrameworkCore.QueryHandlers.TagQueryHandlers
{
    public class TagExistsQueryHandler : BlogDbQueryHandler<Tag, TagExistsQuery>
    {
        public TagExistsQueryHandler(IProjector projector, BlogDbContext context) : base(projector, context)
        {
           
        }

        public override async Task<bool> HandleAsync(TagExistsQuery query, CancellationToken token)
        {

            ThrowIfQueryIsNullOrCancellationRequested(query, token);

            if (string.IsNullOrEmpty(query.Label))
            {
                return await EntityQueryable.AnyAsync( token);
            }

            if (query.ExceptId == 0)
            {
                return await EntityQueryable.AnyAsync(p => p.Label == query.Label, token);
            }

            return await EntityQueryable.AnyAsync(p => p.Id != query.ExceptId && p.Label == query.Label, token);
        }
    }
}