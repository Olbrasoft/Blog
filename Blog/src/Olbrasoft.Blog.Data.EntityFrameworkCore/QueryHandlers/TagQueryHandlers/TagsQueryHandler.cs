namespace Olbrasoft.Blog.Data.EntityFrameworkCore.QueryHandlers.TagQueryHandlers;

public class TagsQueryHandler(IProjector projector, BlogDbContext context) : BlogDbQueryHandler<Tag, TagsQuery, IEnumerable<TagSmallDto>>(projector, context)
{
    protected override async Task<IEnumerable<TagSmallDto>> GetResultToHandleAsync(TagsQuery query, CancellationToken token)
        => await ProjectTo<TagSmallDto>(OrderBy(p => p.Label)).ToArrayAsync(token);
}