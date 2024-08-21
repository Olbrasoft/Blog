namespace Olbrasoft.Blog.Data.EntityFrameworkCore.QueryHandlers.PostQueryHandlers;


/// <summary>
/// Handles the query to retrieve posts by user ID.
/// </summary>
public class PostsByUserIdQueryHandler : BlogDbQueryHandler<Post, PostsByUserIdQuery, IPagedResult<PostOfUserDto>>
{
    public PostsByUserIdQueryHandler(IProjector projector, BlogDbContext context) : base(projector, context)
    {
    }

    /// <summary>
    /// Retrieves the result to handle asynchronously.
    /// </summary>
    /// <param name="query">The query to retrieve posts by user ID.</param>
    /// <param name="token">The cancellation token.</param>
    /// <returns>The paged result of posts by user ID.</returns>
    protected override async Task<IPagedResult<PostOfUserDto>> GetResultToHandleAsync(PostsByUserIdQuery query, CancellationToken token)
    {
        var filteredPosts = Entities.Where(p => p.CreatorId == query.UserId);

        if (!string.IsNullOrEmpty(query.Search))
        {
            filteredPosts = filteredPosts.Where(p => p.Title.ToLower().Contains(query.Search.ToLower()) || p.Content.ToLower().Contains(query.Search.ToLower()));
        }

        var posts = ProjectTo<PostOfUserDto>(filteredPosts.OrderBy(query.OrderByColumnName, query.OrderByDirection))
             .Skip(query.Paging.CalculateSkip())
             .Take(query.Paging.PageSize);

        return (await posts.ToArrayAsync(token)).AsPagedResult(await Entities.Where(p => p.CreatorId == query.UserId).CountAsync(), await filteredPosts.CountAsync());
    }
}
