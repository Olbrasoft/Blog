using Olbrasoft.Blog.Data.Queries.NestedCommentQueries;

namespace Olbrasoft.Blog.Data.EntityFrameworkCore.QueryHandlers.NestedCommentQueryHandlers;

public class NestedCommentTextForEditingQueryHandler(IProjector projector, BlogDbContext context) : BlogDbQueryHandler<NestedComment, NestedCommentTextForEditingQuery, string>(projector, context)
{
    protected override async Task<string> GetResultToHandleAsync(NestedCommentTextForEditingQuery query, CancellationToken token)
    {
        var result = await Where(n => n.Id == query.Id && (n.CreatorId == query.CreatorId || query.CreatorId == 0))
             .Select(p => p.Text)
             .ToArrayAsync(token);

        return result.Length != 0 ? result.First() : string.Empty;
    }
}