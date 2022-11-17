namespace Olbrasoft.Blog.Data.FreeSql.Tests.QueryHandlers.TagQueryHandlers;

public class TagsByLabelContainsQueryHandler : BlogDbQueryHandler<Tag, TagsByLabelContainsQuery, IEnumerable<TagSmallDto>>
{
    public TagsByLabelContainsQueryHandler(IConfigure<Tag> configurator, BlogFreeSqlDbContext context) : base(configurator, context)
    {
    }

    protected override async Task<IEnumerable<TagSmallDto>> GetResultToHandleAsync(TagsByLabelContainsQuery query, CancellationToken token)
    {
        

        Select = query.ExceptTagIds.Any() 
            ? Select.Where(p => p.Label.Contains(query.Text) && !query.ExceptTagIds.Contains(p.Id)) 
            : Select = Select.Where(p => p.Label.Contains(query.Text));

        return await Select.Take(6).ToListAsync<TagSmallDto>(token);
    }
}