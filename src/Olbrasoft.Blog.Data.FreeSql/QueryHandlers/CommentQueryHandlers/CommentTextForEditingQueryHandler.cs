namespace Olbrasoft.Blog.Data.FreeSql.QueryHandlers.CommentQueryHandlers;

public class CommentTextForEditingQueryHandler : BlogDbQueryHandler<Comment, CommentTextForEditingQuery, string>
{
    public CommentTextForEditingQueryHandler(BlogFreeSqlDbContext context) : base(context)
    {
    }

    public override async Task<string> HandleAsync(CommentTextForEditingQuery query, CancellationToken token)
    {
        return await Select.Where(p => p.Id == query.Id && (p.CreatorId == query.CreatorId || query.CreatorId == 0)).Select(p => p.Text).FirstAsync(token);
    }
}