namespace Olbrasoft.Blog.Data.EntityFrameworkCore.QueryHandlers.CommentQueryHandlers;

public class CommentTextForEditingQueryHandler(IProjector projector, BlogDbContext context) : BlogDbQueryHandler<Comment, CommentTextForEditingQuery, string>(projector, context)
{
    protected override async Task<string> GetResultToHandleAsync(CommentTextForEditingQuery query, CancellationToken token)
        => await Where(c => c.Id == query.Id && (c.CreatorId == query.CreatorId || query.CreatorId == 0))
                                .Select(c => c.Text)
                                .FirstAsync(token);
}