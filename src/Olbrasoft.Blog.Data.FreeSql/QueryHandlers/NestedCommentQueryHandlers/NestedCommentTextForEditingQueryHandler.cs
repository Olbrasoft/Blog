using Olbrasoft.Blog.Data.Queries.NestedCommentQueries;

namespace Olbrasoft.Blog.Data.FreeSql.QueryHandlers.NestedCommentQueryHandlers;

public class NestedCommentTextForEditingQueryHandler : BlogDbQueryHandler<NestedComment, NestedCommentTextForEditingQuery, string>
{
    public NestedCommentTextForEditingQueryHandler(BlogFreeSqlDbContext context) : base(context)
    {
    }

    public override async Task<string> HandleAsync(NestedCommentTextForEditingQuery query, CancellationToken token)
    {
        return await Select.Where(p => p.Id == query.Id && (p.CreatorId == query.CreatorId || query.CreatorId == 0)).Select(p => p.Text).FirstAsync(token);
    }
}