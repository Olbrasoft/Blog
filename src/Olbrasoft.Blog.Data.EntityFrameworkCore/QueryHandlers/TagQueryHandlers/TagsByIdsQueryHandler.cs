namespace Olbrasoft.Blog.Data.EntityFrameworkCore.QueryHandlers.TagQueryHandlers
{
    public class TagsByIdsQueryHandler : BlogDbQueryHandler<Tag, TagsByIdsQuery, IEnumerable<TagSmallDto>>
    {
        public TagsByIdsQueryHandler(IProjector projector, BlogDbContext context) : base(projector, context)
        {
        }

        public override async Task<IEnumerable<TagSmallDto>> HandleAsync(TagsByIdsQuery query, CancellationToken token)
        {
            return await ProjectTo<TagSmallDto>(EntityQueryable.Where(p => query.Ids.Contains(p.Id))).ToArrayAsync(token);
        }
    }
}