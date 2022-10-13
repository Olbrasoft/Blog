namespace Olbrasoft.Blog.Data.EntityFrameworkCore.QueryHandlers.CommentQueryHandlers
{
    public class CommentTextForEditingQueryHandler : BlogDbQueryHandler<Comment, CommentTextForEditingQuery, string>
    {
        public CommentTextForEditingQueryHandler(IProjector projector, BlogDbContext context) : base(projector, context)
        {
        }

        public override async Task<string> HandleAsync(CommentTextForEditingQuery query, CancellationToken token)
        {
            return await Entities.Where(p => p.Id == query.Id && (p.CreatorId == query.CreatorId || query.CreatorId == 0)).Select(p => p.Text).FirstAsync(token);
        }
    }
}