namespace Olbrasoft.Blog.Data.FreeSql.CommandHandlers.CommentCommandHandlers;

public class CommentSaveCommandHandler : BlogDbCommandHandler<CommentSaveCommand, Comment>
{
    public CommentSaveCommandHandler(IMapper mapper, BlogFreeSqlDbContext context) : base(mapper, context)
    {
    }

    protected override async Task<bool> GetResultToHandleAsync(CommentSaveCommand command, CancellationToken token)
    {
        await Entities.AddOrUpdateAsync(MapTo<Comment>(command), token);

        return await SaveOneEntityAsync(token);
    }
}