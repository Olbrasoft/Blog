namespace Olbrasoft.Blog.Data.EntityFrameworkCore.QueryHandlers.CommentQueryHandlers
{
    public class CommentTextForEditingQueryHandler : BlogDbQueryHandler<Comment, CommentTextForEditingQuery, string>
    {
        public CommentTextForEditingQueryHandler(IProjector projector, BlogDbContext context) : base(projector, context)
        {
        }

        protected override async Task<string> GetResultToHandleAsync(CommentTextForEditingQuery query, CancellationToken token)
            => await Entities.Where(p => p.Id == query.Id && (p.CreatorId == query.CreatorId || query.CreatorId == 0))
                                    .Select(p => p.Text)
                                    .FirstAsync(token);
    }
}