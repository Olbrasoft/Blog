namespace Olbrasoft.Blog.Data.FreeSql.CommandHandlers.NestedCommentCommandHandlers;

public class NestedCommentDeleteCommandHandler(BlogFreeSqlDbContext context) : BlogDbCommandHandler<NestedCommentDeleteCommand, NestedComment>(context)
{
    protected override async Task<bool> GetResultToHandleAsync(NestedCommentDeleteCommand command, CancellationToken token)
    {
       return await DeleteAsync(nc => nc.Id == command.Id && (nc.CreatorId == command.CreatorId || command.CreatorId == 0), token) == 1;
    }
}