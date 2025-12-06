namespace Olbrasoft.Blog.Data.FreeSql.CommandHandlers.CommentCommandHandlers;

public class CommentSaveCommandHandler(IMapper mapper, BlogFreeSqlDbContext context) : BlogDbCommandHandler<CommentSaveCommand, Comment>(mapper, context)
{
    protected override async Task<bool> GetResultToHandleAsync(CommentSaveCommand command, CancellationToken token)
    {
        return await SaveAsync(MapCommandToNewEntity(command), token) == 1;
    }
}