namespace Olbrasoft.Blog.Data.FreeSql.CommandHandlers.NestedCommentCommandHandlers;

public class NestedCommentSaveComandHandler : BlogDbCommandHandler<NestedCommentSaveCommand, NestedComment>
{
    public NestedCommentSaveComandHandler(IMapper mapper, BlogFreeSqlDbContext context) : base(mapper, context)
    {
    }

    public override async Task<bool> HandleAsync(NestedCommentSaveCommand command, CancellationToken token)
    {
        //if (command.Id == 0 && command.CommentId > 0)
        //{
        //    await Entities.AddAsync(MapTo<NestedComment>(command), token);
        //}
        //else
        //{
        //    var comment = await Entities.Select.Where(p => p.Id == command.Id && p.CreatorId == command.CreatorId).FirstAsync(token);

        //    comment.Text = command.Text;

        //    Entities.Update(comment);
        //}
        ThrowIfCommandIsNullOrCancellationRequested(command, token);

        await Entities.AddOrUpdateAsync(MapTo<NestedComment>(command), token);

        return await SaveOneEntityAsync(token) ;
    }
}