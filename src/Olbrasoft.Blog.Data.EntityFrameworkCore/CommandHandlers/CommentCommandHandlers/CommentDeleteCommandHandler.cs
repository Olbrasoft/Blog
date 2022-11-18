namespace Olbrasoft.Blog.Data.EntityFrameworkCore.CommandHandlers.CommentCommandHandlers
{
    public class CommentDeleteCommandHandler : BlogDbCommandHandler<CommentDeleteCommand, Comment>
    {
        public CommentDeleteCommandHandler(IMapper mapper, BlogDbContext context) : base(mapper, context)
        {
        }

        protected override async Task<bool> GetResultToHandleAsync(CommentDeleteCommand command, CancellationToken token)
        {
            var comment = await Entities.Where(p => p.Id == command.Id && (p.CreatorId == command.CreatorId || command.CreatorId == 0)).FirstAsync(token);
           
            return (await RemoveAndSaveAsync(comment, token) == CommandStatus.Deleted);
        }
    }
}