namespace Olbrasoft.Blog.Data.FreeSql.QueryHandlers.CommentQueryHandlers;

public class CommentTextForEditingQueryHandler : BlogDbQueryHandler<Comment, CommentTextForEditingQuery, string>
{
    public CommentTextForEditingQueryHandler(BlogFreeSqlDbContext context) : base(context)
    {
    }

    protected override async Task<string> GetResultToHandleAsync(CommentTextForEditingQuery query, CancellationToken token) 
        => await GetWhere(p => p.Id == query.Id && (p.CreatorId == query.CreatorId || query.CreatorId == 0))
            .FirstAsync(c => c.Text, token);
}