using Olbrasoft.Blog.Data.Dtos.CommentDtos;

namespace Olbrasoft.Blog.Data.EntityFrameworkCore.QueryHandlers.CommentQueryHandlers
{
    public class CommentsByPostIdQueryHandler : BlogDbQueryHandler<Comment, CommentsByPostIdQuery, IEnumerable<CommentDto>>
    {
        public CommentsByPostIdQueryHandler(IProjector projector, BlogDbContext context) : base(projector, context)
        {
        }

        public override async Task<IEnumerable<CommentDto>> HandleAsync(CommentsByPostIdQuery query, CancellationToken token)
        {
            return await ProjectTo<CommentDto>(Entities.Where(p => p.PostId == query.PostId).OrderByDescending(p => p.Created)).ToArrayAsync(token);
        }
    }
}