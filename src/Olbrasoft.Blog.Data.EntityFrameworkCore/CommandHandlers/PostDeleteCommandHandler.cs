namespace Olbrasoft.Blog.Data.EntityFrameworkCore.CommandHandlers;
public class PostDeleteCommandHandler(BlogDbContext context) : BlogDbCommandHandler<PostDeleteCommand, Post>(context)
{
    protected override async Task<bool> GetResultToHandleAsync(PostDeleteCommand command, CancellationToken token)
    {
        return await  DeleteAsync(p => p.Id == command.Id && p.CreatorId == command.CreatorId ,token) == 1;
    }
}
