namespace Olbrasoft.Blog.Data.FreeSql.QueryHandlers.CommentQueryHandlers;

public class CommentsByPostIdQueryHandler : BlogDbQueryHandler<Comment, CommentsByPostIdQuery, IEnumerable<CommentDto>>
{
    public CommentsByPostIdQueryHandler(BlogFreeSqlDbContext context) : base( context)
    {
    }

    public override async Task<IEnumerable<CommentDto>> HandleAsync(CommentsByPostIdQuery query, CancellationToken token) 
        => await Select.Where(p => p.PostId == query.PostId).OrderByDescending(c => c.Created).ToListAsync<CommentDto>(token);
}