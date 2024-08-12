namespace Olbrasoft.Blog.Data.FreeSql.QueryHandlers.TagQueryHandlers;

public class TagsQueryHandler(BlogFreeSqlDbContext context) : BlogDbQueryHandler<Tag, TagsQuery, IEnumerable<TagSmallDto>>(context)
{
    protected override async Task<IEnumerable<TagSmallDto>> GetResultToHandleAsync(TagsQuery query, CancellationToken token)
    {
        return await GetOrderBy(a => a.Label).ToListAsync<TagSmallDto>(token);
    }
}