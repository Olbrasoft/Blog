namespace Olbrasoft.Blog.Data.FreeSql.CommandHandlers.NestedCommentCommandHandlers;

public class NestedCommentSaveComandHandler : BlogDbCommandHandler<NestedCommentSaveCommand, NestedComment>
{
    public NestedCommentSaveComandHandler(IMapper mapper, BlogFreeSqlDbContext context) : base(mapper, context)
    {
    }

    protected override async Task<bool> GetResultToHandleAsync(NestedCommentSaveCommand command, CancellationToken token)
    {
        await Entities.AddOrUpdateAsync(MapTo<NestedComment>(command), token);

        return await SaveOneEntityAsync(token) ;
    }
}