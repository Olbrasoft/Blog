namespace Olbrasoft.Blog.Data.FreeSql.Tests.QueryHandlers.TagQueryHandlers;

public class TagsByPostIdQueryHandler : BlogDbQueryHandler<PostToTag, TagsByPostIdQuery, IEnumerable<TagSmallDto>>
{
    public TagsByPostIdQueryHandler(IDbSetProvider setOwner) : base(setOwner)
    {
    }

    public override async Task<IEnumerable<TagSmallDto>> HandleAsync(TagsByPostIdQuery query, CancellationToken token)
    {
        ThrowIfQueryIsNullOrCancellationRequested(query, token);
        
        return await Select.Where(ptt => ptt.Id == query.PostId)
                             .Include(p => p.Tag)
                             .ToListAsync(p => new TagSmallDto { Id = p.Tag.Id, Label = p.Tag.Label }, token);
    }
}