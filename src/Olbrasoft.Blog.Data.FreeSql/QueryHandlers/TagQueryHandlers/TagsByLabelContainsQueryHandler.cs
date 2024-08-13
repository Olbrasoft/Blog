namespace Olbrasoft.Blog.Data.FreeSql.Tests.QueryHandlers.TagQueryHandlers;

public class TagsByLabelContainsQueryHandler(BlogFreeSqlDbContext context) : BlogDbQueryHandler<Tag, TagsByLabelContainsQuery, IEnumerable<TagSmallDto>>(context)
{
    protected override async Task<IEnumerable<TagSmallDto>> GetResultToHandleAsync(TagsByLabelContainsQuery query, CancellationToken token)
    {
        ISelect<Tag> tags;

        tags = query.ExceptTagIds.Any()
            ? GetWhere(p => p.Label.Contains(query.Text, StringComparison.InvariantCultureIgnoreCase) && !query.ExceptTagIds.Contains(p.Id))
            : (tags = GetWhere(p => p.Label.Contains(query.Text, StringComparison.InvariantCultureIgnoreCase)));

        return await tags.Take(6).ToListAsync<TagSmallDto>(token);
    }
}