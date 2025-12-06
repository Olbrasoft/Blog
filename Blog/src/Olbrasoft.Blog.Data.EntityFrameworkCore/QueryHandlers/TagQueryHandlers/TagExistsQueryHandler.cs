namespace Olbrasoft.Blog.Data.EntityFrameworkCore.QueryHandlers.TagQueryHandlers;

public class TagExistsQueryHandler(IProjector projector, BlogDbContext context) : BlogDbQueryHandler<Tag, TagExistsQuery>(projector, context)
{
    protected override async Task<bool> GetResultToHandleAsync(TagExistsQuery query, CancellationToken token)
        => !string.IsNullOrEmpty(query.Label)
            ? query.ExceptId == 0
                ? await AnyAsync(p => p.Label == query.Label, token)
                : await AnyAsync(p => p.Id != query.ExceptId && p.Label == query.Label, token)
            : await AnyAsync(token);
}