namespace Olbrasoft.Blog.Data.EntityFrameworkCore.CommandHandlers.CommentCommandHandlers
{
    public class CommentSaveCommandHandler : BlogDbCommandHandler<CommentSaveCommand,  Comment>
    {
        public CommentSaveCommandHandler(IMapper mapper, BlogDbContext context) : base(mapper, context)
        {
        }

        protected override async Task<bool> GetResultToHandleAsync(CommentSaveCommand command, CancellationToken token)
        {
            if (command.Id == 0 && command.PostId > 0)
            {
                await Entities.AddAsync(MapTo<Comment>(command), token);
            }
            else
            {
                var comment = await Entities.FirstOrDefaultAsync(p => p.Id == command.Id && p.CreatorId == command.CreatorId, token);

                if (comment == null)
                {
                    throw new Exception("Comment not found or you do not have permission");
                }

                comment.Text = command.Text;

                Entities.Update(comment);
            }

            return await Context.SaveChangesAsync(token) == 1;
        }
    }
}