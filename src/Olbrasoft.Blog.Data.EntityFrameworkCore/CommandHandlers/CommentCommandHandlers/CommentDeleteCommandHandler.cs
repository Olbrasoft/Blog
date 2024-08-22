namespace Olbrasoft.Blog.Data.EntityFrameworkCore.CommandHandlers.CommentCommandHandlers
{
    public class CommentDeleteCommandHandler : BlogDbCommandHandler<CommentDeleteCommand, Comment>
    {
        public CommentDeleteCommandHandler(IMapper mapper, BlogDbContext context) : base(mapper, context)
        {
        }

        protected override async Task<bool> GetResultToHandleAsync(CommentDeleteCommand command, CancellationToken token)
        {
            var comment = new Comment { Id = command.Id};

            if(command.CreatorId > 0)
             comment = await GetWhere(p => p.Id == command.Id && p.CreatorId == command.CreatorId ).FirstAsync(token);

            return (await DeleteAsync(comment, token) == 1);
        }
    }
}