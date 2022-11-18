namespace Olbrasoft.Blog.Data.EntityFrameworkCore.QueryHandlers.TagQueryHandlers
{
    public class TagsByIdsQueryHandler : BlogDbQueryHandler<Tag, TagsByIdsQuery, IEnumerable<TagSmallDto>>
    {
        public TagsByIdsQueryHandler(IProjector projector, BlogDbContext context) : base(projector, context)
        {
        }

        protected override async Task<IEnumerable<TagSmallDto>> GetResultToHandleAsync(TagsByIdsQuery query, CancellationToken token)
        {
            return await ProjectTo<TagSmallDto>(Queryable.Where(p => query.Ids.Contains(p.Id))).ToArrayAsync(token);
        }
    }
}