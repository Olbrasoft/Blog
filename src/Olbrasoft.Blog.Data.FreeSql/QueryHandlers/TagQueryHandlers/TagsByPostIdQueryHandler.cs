namespace Olbrasoft.Blog.Data.FreeSql.Tests.QueryHandlers.TagQueryHandlers;

public class TagsByPostIdQueryHandler : BlogDbQueryHandler<PostToTag, TagsByPostIdQuery, IEnumerable<TagSmallDto>>
{
    public TagsByPostIdQueryHandler(IConfigure<PostToTag> configurator, BlogFreeSqlDbContext context) : base(configurator, context)
    {
    }

    protected override async Task<IEnumerable<TagSmallDto>> GetResultToHandleAsync(TagsByPostIdQuery query, CancellationToken token)
    {
        
        
        return await Select.Where(ptt => ptt.Id == query.PostId)
                             .Include(p => p.Tag)
                             .ToListAsync(p => new TagSmallDto { Id = p.Tag.Id, Label = p.Tag.Label }, token);
    }
}