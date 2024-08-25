namespace Olbrasoft.Blog.Data.EntityFrameworkCore.CommandHandlers.NestedCommentCommandHandlers;

public class NestedCommentSaveComandHandler(IMapper mapper, BlogDbContext context) : BlogDbCommandHandler<NestedCommentSaveCommand, NestedComment>(mapper, context)
{
    protected override async Task<bool> GetResultToHandleAsync(NestedCommentSaveCommand command, CancellationToken token) =>
        await SaveAsync(CreateEntity(command), token) == 1;
}