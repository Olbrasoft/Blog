
namespace Olbrasoft.Blog.Data.EntityFrameworkCore.QueryHandlers.TagQueryHandlers;

public class TagsByPostIdQueryHandler : BlogDbQueryHandler<PostToTag, TagsByPostIdQuery, IEnumerable<TagSmallDto>>
{
    public TagsByPostIdQueryHandler(IProjector projector, BlogDbContext context) : base(projector, context)
    {
    }

    protected override async Task<IEnumerable<TagSmallDto>> GetResultToHandleAsync(TagsByPostIdQuery query, CancellationToken token)
    {

        return await ProjectTo<TagSmallDto>(Entities.Where(ptt => ptt.Id == query.PostId).Include(p => p.Tag)).ToArrayAsync(token);


    }
}