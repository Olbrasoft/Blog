namespace Olbrasoft.Blog.Data.FreeSql.CommandHandlers.CommentCommandHandlers;

public class CommentDeleteCommandHandler(BlogFreeSqlDbContext context) : BlogDbCommandHandler<CommentDeleteCommand, Comment>(context)
{
    protected override async Task<bool> GetResultToHandleAsync(CommentDeleteCommand command, CancellationToken token)
    {
        return await DeleteAsync(c => c.Id == command.Id && (c.CreatorId == command.CreatorId || command.CreatorId == 0), token) == 1;
    }
}