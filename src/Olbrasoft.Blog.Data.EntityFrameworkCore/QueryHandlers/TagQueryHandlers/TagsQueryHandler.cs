namespace Olbrasoft.Blog.Data.EntityFrameworkCore.QueryHandlers.TagQueryHandlers
{
    public class TagsQueryHandler : BlogDbQueryHandler<Tag, TagsQuery, IEnumerable<TagSmallDto>>
    {
        public TagsQueryHandler(IProjector projector, BlogDbContext context) : base(projector, context)
        {
        }

        public override async Task<IEnumerable<TagSmallDto>> HandleAsync(TagsQuery query, CancellationToken token)
        {
            return await ProjectTo<TagSmallDto>(Entities.OrderBy(p => p.Label)).ToArrayAsync(token);
        }
    }
}