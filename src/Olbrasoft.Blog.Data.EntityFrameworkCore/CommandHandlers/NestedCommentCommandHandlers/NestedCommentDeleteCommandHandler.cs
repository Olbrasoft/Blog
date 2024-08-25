namespace Olbrasoft.Blog.Data.EntityFrameworkCore.CommandHandlers.NestedCommentCommandHandlers;
public class NestedCommentDeleteCommandHandler(IMapper mapper, BlogDbContext context) : BlogDbCommandHandler<NestedCommentDeleteCommand, NestedComment>(mapper, context)
{
    protected override async Task<bool> GetResultToHandleAsync(NestedCommentDeleteCommand command, CancellationToken token) =>
        command.CreatorId == 0
            ? await DeleteAsync(new NestedComment { Id = command.Id }, token) == 1
            : await DeleteAsync(p => p.Id == command.Id && p.CreatorId == command.CreatorId, token) == 1;
}