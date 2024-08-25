namespace Olbrasoft.Blog.Data.EntityFrameworkCore.CommandHandlers.CommentCommandHandlers;

public class CommentSaveCommandHandler(IMapper mapper,
    BlogDbContext context) : BlogDbCommandHandler<CommentSaveCommand, Comment>(mapper, context)
{
    protected override async Task<bool> GetResultToHandleAsync(CommentSaveCommand command, CancellationToken token)
        => await SaveAsync(CreateEntity(command), token) == 1;
}