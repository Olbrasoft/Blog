namespace Olbrasoft.Blog.Data.EntityFrameworkCore.QueryHandlers.PostQueryHandlers;


/// <summary>
/// Handles the query to retrieve posts by user ID.
/// </summary>
public class PostsByUserIdQueryHandler(IProjector projector, BlogDbContext context) : BlogDbQueryHandler<Post, PostsByUserIdQuery, IPagedResult<PostOfUserDto>>(projector, context)
{

    /// <summary>
    /// Retrieves the result to handle asynchronously.
    /// </summary>
    /// <param name="query">The query to retrieve posts by user ID.</param>
    /// <param name="token">The cancellation token.</param>
    /// <returns>The paged result of posts by user ID.</returns>
    protected override async Task<IPagedResult<PostOfUserDto>> GetResultToHandleAsync(PostsByUserIdQuery query, CancellationToken token)
    {
        var userPosts = Where(p => p.CreatorId == query.UserId);

        var filteredPosts = userPosts;

        query.Search = query.Search.ToLower();

        if (!string.IsNullOrEmpty(query.Search))
        {
            filteredPosts = filteredPosts.Where(p => p.Title.Contains(query.Search) || p.Content.Contains(query.Search));
        }

        var posts = ProjectTo<PostOfUserDto>(filteredPosts.OrderBy(query.OrderByColumnName, query.OrderByDirection))
              .Skip(query.Paging.CalculateSkip())
              .Take(query.Paging.PageSize);

        var result = (await posts.ToArrayAsync(token)).AsPagedResult(await userPosts.CountAsync(token), await filteredPosts.CountAsync(token));

        return result;
    }
}
