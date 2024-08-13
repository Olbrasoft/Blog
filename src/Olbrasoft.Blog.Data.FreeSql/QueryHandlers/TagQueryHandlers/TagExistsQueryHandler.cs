namespace Olbrasoft.Blog.Data.FreeSql.QueryHandlers.TagQueryHandlers
{
    public class TagExistsQueryHandler(BlogFreeSqlDbContext context) : BlogDbQueryHandler<Tag, TagExistsQuery>(context)
    {
        protected override async Task<bool> GetResultToHandleAsync(TagExistsQuery query, CancellationToken token)
        {
            return !string.IsNullOrEmpty(query.Label)
                ? query.ExceptId == 0
                    ? await ExistsAsync(p => p.Label == query.Label, token)
                    : await ExistsAsync(p => p.Id != query.ExceptId && p.Label == query.Label, token)
                : await ExistsAsync(token);
        }
    }
}