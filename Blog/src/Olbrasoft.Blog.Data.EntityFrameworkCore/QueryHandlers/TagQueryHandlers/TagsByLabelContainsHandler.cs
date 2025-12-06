namespace Olbrasoft.Blog.Data.EntityFrameworkCore.QueryHandlers.TagQueryHandlers;

public class TagsByLabelContainsHandler(IProjector projector, BlogDbContext context) : BlogDbQueryHandler<Tag, TagsByLabelContainsQuery, IEnumerable<TagSmallDto>>(projector, context)
{
    protected override async Task<IEnumerable<TagSmallDto>> GetResultToHandleAsync(TagsByLabelContainsQuery query, CancellationToken token)
        => await ProjectTo<TagSmallDto>(t => t.Label.Contains(query.Text) && !query.ExceptTagIds.Contains(t.Id))
            .Take(6)
            .ToArrayAsync(token);
}