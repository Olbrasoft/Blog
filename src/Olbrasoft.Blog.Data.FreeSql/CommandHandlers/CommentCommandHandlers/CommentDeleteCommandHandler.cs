namespace Olbrasoft.Blog.Data.FreeSql.CommandHandlers.CommentCommandHandlers;

public class CommentDeleteCommandHandler : BlogDbCommandHandler<CommentDeleteCommand, Comment>
{
    public CommentDeleteCommandHandler(BlogFreeSqlDbContext context) : base(context)
    {
    }

    protected override async Task<bool> GetResultToHandleAsync(CommentDeleteCommand command, CancellationToken token)
    {
        await Entities.RemoveAsync(c => c.Id == command.Id && (c.CreatorId == command.CreatorId || command.CreatorId == 0), token);

        return await SaveOneEntityAsync(token);
    }
}