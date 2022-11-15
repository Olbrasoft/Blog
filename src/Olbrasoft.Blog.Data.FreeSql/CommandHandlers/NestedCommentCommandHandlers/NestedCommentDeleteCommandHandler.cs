namespace Olbrasoft.Blog.Data.FreeSql.CommandHandlers.NestedCommentCommandHandlers;

public class NestedCommentDeleteCommandHandler : BlogDbCommandHandler<NestedCommentDeleteCommand, NestedComment>
{
    public NestedCommentDeleteCommandHandler(IMapper mapper, IDbContextProxy proxy) : base(mapper, proxy)
    {
    }

    public override async Task<bool> HandleAsync(NestedCommentDeleteCommand command, CancellationToken token)
    {
        ThrowIfCommandIsNullOrCancellationRequested(command, token);

        await Entities
            .RemoveAsync(nc => nc.Id == command.Id && (nc.CreatorId == command.CreatorId || command.CreatorId == 0), token);

        return await SaveChangesAsync(token);
    }
}