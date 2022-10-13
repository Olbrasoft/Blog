namespace Olbrasoft.Blog.Data.EntityFrameworkCore.CommandHandlers.NestedCommentCommandHandlers
{
    public class NestedCommentDeleteCommandHandler : BlogDbCommandHandler<NestedCommentDeleteCommand,  NestedComment>
    {
        public NestedCommentDeleteCommandHandler(IMapper mapper, BlogDbContext context) : base(mapper, context)
        {
        }

        public override async Task<bool> HandleAsync(NestedCommentDeleteCommand command, CancellationToken token)
        {
            var comment = await Entities.Where(p => p.Id == command.Id && (p.CreatorId == command.CreatorId || command.CreatorId == 0)).FirstAsync(token);

            Entities.Remove(comment);

            return (await Context.SaveChangesAsync(token) == 1);
        }
    }
}