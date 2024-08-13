namespace Olbrasoft.Blog.Data.FreeSql.CommandHandlers.NestedCommentCommandHandlers;

public class NestedCommentSaveComandHandler(IMapper mapper, BlogFreeSqlDbContext context) : BlogDbCommandHandler<NestedCommentSaveCommand, NestedComment>(mapper, context)
{
    protected override async Task<bool> GetResultToHandleAsync(NestedCommentSaveCommand command, CancellationToken token)
    {
        return await SaveAsync(CreateEntityFromCommand(command), token) == 1;
    }
}