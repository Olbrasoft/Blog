namespace Olbrasoft.Blog.Data.FreeSql.QueryHandlers.TagQueryHandlers;

public class TagsQueryHandler : BlogDbQueryHandler<Tag, TagsQuery, IEnumerable<TagSmallDto>>
{
    public TagsQueryHandler(IDataSelector selector) : base(selector)
    {
    }

    public override async Task<IEnumerable<TagSmallDto>> HandleAsync(TagsQuery query, CancellationToken token)
    {
        ThrowIfQueryIsNullOrCancellationRequested(query, token);

        return await Select.OrderBy(a => a.Label).ToListAsync<TagSmallDto>(token);
    }
}