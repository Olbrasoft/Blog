namespace Olbrasoft.Blog.Data.FreeSql.CommandHandlers.NestedCommentCommandHandlers;

public class NestedCommentDeleteCommandHandler : BlogDbCommandHandler<NestedCommentDeleteCommand, NestedComment>
{
    public NestedCommentDeleteCommandHandler(BlogFreeSqlDbContext context) : base(context)
    {
    }

    protected override async Task<bool> GetResultToHandleAsync(NestedCommentDeleteCommand command, CancellationToken token)
    {
        await Entities
            .RemoveAsync(nc => nc.Id == command.Id && (nc.CreatorId == command.CreatorId || command.CreatorId == 0), token);

        return await SaveOneEntityAsync(token);
    }
}