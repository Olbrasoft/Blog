
namespace Olbrasoft.Blog.Data.EntityFrameworkCore.QueryHandlers.TagQueryHandlers;

public class TagsByPostIdQueryHandler(IProjector projector, BlogDbContext context) : BlogDbQueryHandler<PostToTag, TagsByPostIdQuery, IEnumerable<TagSmallDto>>(projector, context)
{
    protected override async Task<IEnumerable<TagSmallDto>> GetResultToHandleAsync(TagsByPostIdQuery query, CancellationToken token)
        => await ProjectTo<TagSmallDto>(Where(ptt => ptt.Id == query.PostId).Include(p => p.Tag)).ToArrayAsync(token);
}