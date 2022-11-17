namespace Olbrasoft.Blog.Data.FreeSql.QueryHandlers.TagQueryHandlers
{
    public class TagExistsQueryHandler : BlogDbQueryHandler<Tag, TagExistsQuery>
    {
        public TagExistsQueryHandler(IConfigure<Tag> configurator, BlogFreeSqlDbContext context) : base(configurator, context)
        {
        }

        protected override async Task<bool> GetResultToHandleAsync(TagExistsQuery query, CancellationToken token)
        {
            return !string.IsNullOrEmpty(query.Label)
                ? query.ExceptId == 0
                    ? await Select.AnyAsync(p => p.Label == query.Label, token)
                    : await Select.AnyAsync(p => p.Id != query.ExceptId && p.Label == query.Label, token)
                : await Select.AnyAsync(token);
        }
    }
}