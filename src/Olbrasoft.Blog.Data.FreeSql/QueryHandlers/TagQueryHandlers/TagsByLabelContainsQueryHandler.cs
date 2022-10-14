namespace Olbrasoft.Blog.Data.FreeSql.Tests.QueryHandlers.TagQueryHandlers;

public class TagsByLabelContainsQueryHandler : BlogDbQueryHandler<Tag, TagsByLabelContainsQuery, IEnumerable<TagSmallDto>>
{
    public TagsByLabelContainsQueryHandler(IDataSelector selector) : base(selector)
    {
    }

    public override async Task<IEnumerable<TagSmallDto>> HandleAsync(TagsByLabelContainsQuery query, CancellationToken token)
    {
        ThrowIfQueryIsNullOrCancellationRequested(query, token);

        Select = query.ExceptTagIds.Any() 
            ? Select.Where(p => p.Label.Contains(query.Text) && !query.ExceptTagIds.Contains(p.Id)) 
            : Select = Select.Where(p => p.Label.Contains(query.Text));

        return await Select.Take(6).ToListAsync<TagSmallDto>(token);
    }
}