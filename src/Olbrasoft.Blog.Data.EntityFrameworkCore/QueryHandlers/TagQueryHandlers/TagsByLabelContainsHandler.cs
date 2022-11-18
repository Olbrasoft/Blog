namespace Olbrasoft.Blog.Data.EntityFrameworkCore.QueryHandlers.TagQueryHandlers
{
    public class TagsByLabelContainsHandler : BlogDbQueryHandler<Tag, TagsByLabelContainsQuery, IEnumerable<TagSmallDto>>
    {
        public TagsByLabelContainsHandler(IProjector projector, BlogDbContext context) : base(projector, context)
        {
        }

        protected override async Task<IEnumerable<TagSmallDto>> GetResultToHandleAsync(TagsByLabelContainsQuery query, CancellationToken token)
        {
            return await ProjectTo<TagSmallDto>(Queryable.Where(p => p.Label.Contains(query.Text) && !query.ExceptTagIds.Contains(p.Id)))
                .Take(6)
                .ToArrayAsync(token);
        }
    }
}