using Olbrasoft.Blog.Data.Dtos.CommentDtos;

namespace Olbrasoft.Blog.Data.EntityFrameworkCore.QueryHandlers.CommentQueryHandlers;

public class CommentsByPostIdQueryHandler(IProjector projector, BlogDbContext context) : BlogDbQueryHandler<Comment, CommentsByPostIdQuery, IEnumerable<CommentDto>>(projector, context)
{
    protected override async Task<IEnumerable<CommentDto>> GetResultToHandleAsync(CommentsByPostIdQuery query, CancellationToken token)
        => await ProjectTo<CommentDto>(Where(c => c.PostId == query.PostId)
            .OrderByDescending(p => p.Created)).ToArrayAsync(token);
}