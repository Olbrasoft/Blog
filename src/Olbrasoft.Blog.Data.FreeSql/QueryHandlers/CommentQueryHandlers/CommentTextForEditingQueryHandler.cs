namespace Olbrasoft.Blog.Data.FreeSql.QueryHandlers.CommentQueryHandlers;

public class CommentTextForEditingQueryHandler(BlogFreeSqlDbContext context) : BlogDbQueryHandler<Comment, CommentTextForEditingQuery, string>(context)
{
    protected override async Task<string> GetResultToHandleAsync(CommentTextForEditingQuery query, CancellationToken token) 
        => await GetWhere(p => p.Id == query.Id && (p.CreatorId == query.CreatorId || query.CreatorId == 0))
            .FirstAsync(c => c.Text, token);
}