namespace Olbrasoft.Blog.Data.FreeSql.Tests.QueryHandlers.TagQueryHandlers;

public class TagsByLabelContainsQueryHandler(BlogFreeSqlDbContext context) : BlogDbQueryHandler<Tag, TagsByLabelContainsQuery, IEnumerable<TagSmallDto>>(context)
{
    protected override async Task<IEnumerable<TagSmallDto>> GetResultToHandleAsync(TagsByLabelContainsQuery query, CancellationToken token)
    {
        var tagsSelect = Select;

        tagsSelect = query.ExceptTagIds.Any()
            ? Select.Where(p => p.Label.Contains(query.Text) && !query.ExceptTagIds.Contains(p.Id))
            : (tagsSelect = Select.Where(p => p.Label.Contains(query.Text)));

        return await tagsSelect.Take(6).ToListAsync<TagSmallDto>(token);
    }
}