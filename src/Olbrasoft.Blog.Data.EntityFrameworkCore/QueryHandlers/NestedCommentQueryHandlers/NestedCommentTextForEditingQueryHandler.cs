using Olbrasoft.Blog.Data.Queries.NestedCommentQueries;

namespace Olbrasoft.Blog.Data.EntityFrameworkCore.QueryHandlers.NestedCommentQueryHandlers;

public class NestedCommentTextForEditingQueryHandler : BlogDbQueryHandler<NestedComment, NestedCommentTextForEditingQuery, string>
{
    public NestedCommentTextForEditingQueryHandler(IProjector projector, BlogDbContext context) : base(projector, context)
    {
    }

    public override async Task<string> HandleAsync(NestedCommentTextForEditingQuery query, CancellationToken token)
    {
        ThrowIfQueryIsNullOrCancellationRequested(query, token);

        var result = await EntityQueryable
             .Where(p => p.Id == query.Id && (p.CreatorId == query.CreatorId || query.CreatorId == 0))
             .Select(p => p.Text)
             .ToArrayAsync(token);

        return result.Any() ? result.First() : string.Empty;
    }
}