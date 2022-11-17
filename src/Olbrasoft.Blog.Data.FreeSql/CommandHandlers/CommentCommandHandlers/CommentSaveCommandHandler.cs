namespace Olbrasoft.Blog.Data.FreeSql.CommandHandlers.CommentCommandHandlers;

public class CommentSaveCommandHandler : BlogDbCommandHandler<CommentSaveCommand, Comment>
{
    public CommentSaveCommandHandler(IMapper mapper, BlogFreeSqlDbContext context) : base(mapper, context)
    {
    }

    public override async Task<bool> HandleAsync(CommentSaveCommand command, CancellationToken token)
    {

        ThrowIfCommandIsNullOrCancellationRequested(command, token);

        //if (command.Id == 0 && command.PostId > 0)
        //{
        //    await Entities.AddAsync(MapTo<Comment>(command), token);
        //}
        //else
        //{
        //    var comment = await Entities.FirstOrDefaultAsync(p => p.Id == command.Id && p.CreatorId == command.CreatorId, token);

        //    if (comment == null)
        //    {
        //        throw new Exception("Comment not found or you do not have permission");
        //    }

        //    comment.Text = command.Text;

        //    Entities.Update(comment);
        //}

        await Entities.AddOrUpdateAsync(MapTo<Comment>(command), token);

        return await SaveOneEntityAsync(token);
    }
}