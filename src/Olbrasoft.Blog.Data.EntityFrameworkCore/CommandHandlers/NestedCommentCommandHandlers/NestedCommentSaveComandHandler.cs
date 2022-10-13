namespace Olbrasoft.Blog.Data.EntityFrameworkCore.CommandHandlers.NestedCommentCommandHandlers
{
    public class NestedCommentSaveComandHandler : BlogDbCommandHandler<NestedCommentSaveCommand, NestedComment>
     {
        public NestedCommentSaveComandHandler(IMapper mapper, BlogDbContext context) : base(mapper, context)
        {
       
        }
              
        public override async Task<bool> HandleAsync(NestedCommentSaveCommand command, CancellationToken token)
        {
            if (command.Id == 0 && command.CommentId > 0)
            {
                await Entities.AddAsync(MapTo<NestedComment>(command), token);
            }
            else
            {
                var comment = await Entities.FirstOrDefaultAsync(p => p.Id == command.Id && p.CreatorId == command.CreatorId, token);

                if (comment == null)
                {
                    throw new Exception("Comment not found or you do not have permission to Edit");
                }

                comment.Text = command.Text;

                Entities.Update(comment);
            }
            return await Context.SaveChangesAsync(token) == 1;
        }
    }
}