using Olbrasoft.Blog.Data.Queries.NestedCommentQueries;

namespace Olbrasoft.Blog.Data.FreeSql.QueryHandlers.NestedCommentQueryHandlers;

public class NestedCommentTextForEditingQueryHandler(BlogFreeSqlDbContext context) : BlogDbQueryHandler<NestedComment, NestedCommentTextForEditingQuery, string>(context)
{
    protected override async Task<string> GetResultToHandleAsync(NestedCommentTextForEditingQuery query, CancellationToken token) 
        => await GetWhere(p => p.Id == query.Id && (p.CreatorId == query.CreatorId || query.CreatorId == 0))
            .FirstAsync(nc => nc.Text, token);
}