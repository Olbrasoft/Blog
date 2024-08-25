namespace Olbrasoft.Blog.Data.EntityFrameworkCore.CommandHandlers.CommentCommandHandlers;

public class CommentDeleteCommandHandler(IMapper mapper, BlogDbContext context) : BlogDbCommandHandler<CommentDeleteCommand, Comment>(mapper, context)
{
    protected override async Task<bool> GetResultToHandleAsync(CommentDeleteCommand command, CancellationToken token)
        => command.CreatorId == 0
            ? await DeleteAsync(new Comment { Id = command.Id }, token) == 1
            : await DeleteAsync(c => c.Id == command.Id && c.CreatorId == command.CreatorId, token) == 1;
}