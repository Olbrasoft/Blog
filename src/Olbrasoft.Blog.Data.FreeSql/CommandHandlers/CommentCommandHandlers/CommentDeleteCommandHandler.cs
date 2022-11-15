namespace Olbrasoft.Blog.Data.FreeSql.CommandHandlers.CommentCommandHandlers;

public class CommentDeleteCommandHandler : BlogDbCommandHandler<CommentDeleteCommand, Comment>
{
    public CommentDeleteCommandHandler(IMapper mapper, IDbContextProxy proxy) : base(mapper, proxy)
    {
    }

    public override async Task<bool> HandleAsync(CommentDeleteCommand command, CancellationToken token)
    {
        ThrowIfCommandIsNullOrCancellationRequested(command, token);

        await Entities.RemoveAsync(c => c.Id == command.Id && (c.CreatorId == command.CreatorId || command.CreatorId == 0), token);

        return await SaveChangesAsync(token);
    }
}