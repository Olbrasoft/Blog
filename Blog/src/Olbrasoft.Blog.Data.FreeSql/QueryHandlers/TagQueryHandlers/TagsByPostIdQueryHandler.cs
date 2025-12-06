namespace Olbrasoft.Blog.Data.FreeSql.QueryHandlers.TagQueryHandlers;

public class TagsByPostIdQueryHandler(BlogFreeSqlDbContext context) : BlogDbQueryHandler<PostToTag, TagsByPostIdQuery, IEnumerable<TagSmallDto>>(context)
{
    protected override async Task<IEnumerable<TagSmallDto>> GetResultToHandleAsync(TagsByPostIdQuery query, CancellationToken token)
    {

        return await GetWhere(ptt => ptt.Id == query.PostId)
                             .Include(p => p.Tag)
                             .ToListAsync(p => new TagSmallDto { Id = p.Tag.Id, Label = p.Tag.Label }, token);
    }
}