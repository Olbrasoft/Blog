namespace Olbrasoft.Blog.Data.EntityFrameworkCore.QueryHandlers.TagQueryHandlers;
public class TagsByIdsQueryHandler(IProjector projector, BlogDbContext context) : BlogDbQueryHandler<Tag, TagsByIdsQuery, IEnumerable<TagSmallDto>>(projector, context)
{
    protected override async Task<IEnumerable<TagSmallDto>> GetResultToHandleAsync(TagsByIdsQuery query, CancellationToken token)
    {

        return await ProjectTo<TagSmallDto>(p => query.Ids.Contains(p.Id)).ToArrayAsync(token);


    }
}


