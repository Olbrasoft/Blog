namespace Olbrasoft.Blog.Data.EntityFrameworkCore.QueryHandlers.PostQueryHandlers;


/// <summary>
/// Handles the paged query for retrieving posts.
/// </summary>
public class PostsPagedQueryHandler : BlogDbQueryHandler<Post, PostsPagedQuery, IPagedEnumerable<PostDto>>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="PostsPagedQueryHandler"/> class.
    /// </summary>
    /// <param name="projector">The projector.</param>
    /// <param name="context">The blog database context.</param>
    public PostsPagedQueryHandler(IProjector projector, BlogDbContext context) : base(projector, context)
    {
    }

    /// <summary>
    /// Gets the paged result of posts based on the specified query.
    /// </summary>
    /// <param name="query">The paged query.</param>
    /// <param name="token">The cancellation token.</param>
    /// <returns>The paged result of posts.</returns>
    protected override async Task<IPagedEnumerable<PostDto>> GetResultToHandleAsync(PostsPagedQuery query, CancellationToken token)
    {
        var resultQueryable = BuildResultQueryable(Entities, query.Search);

        var posts = await ProjectTo<PostDto>(resultQueryable.OrderByDescending(p => p.Created))
            .Skip(query.Paging.CalculateSkip())
            .Take(query.Paging.PageSize).ToArrayAsync(token);

        return posts.AsPagedEnumerable(await resultQueryable.CountAsync(token));
    }

    /// <summary>
    /// Builds the queryable result based on the specified post queryable and search criteria.
    /// </summary>
    /// <param name="postQueryable">The post queryable.</param>
    /// <param name="search">The search criteria.</param>
    /// <returns>The queryable result.</returns>
    private static IQueryable<Post> BuildResultQueryable(IQueryable<Post> postQueryable, string search)
        => string.IsNullOrEmpty(search)
            ? postQueryable
            : TrySearchBy(search, "searchbycategoryid:", out int categoryId)
                ? postQueryable.Where(p => p.CategoryId == categoryId)
                : TrySearchBy(search, "searchbycreatorid:", out int creatorId)
                    ? postQueryable.Where(p => p.CreatorId == creatorId)
                    : TrySearchBy(search, "searchbytagid:", out int tagId)
                        ? postQueryable.Include(p => p.Tags).Where(p => p.Tags.Select(t => t.Id).Contains(tagId))
                        : postQueryable.Where(p => p.Title.Contains(search));

    /// <summary>
    /// Tries to search by the specified criteria and extracts the entity ID.
    /// </summary>
    /// <param name="search">The search criteria.</param>
    /// <param name="searchBy">The search by criteria.</param>
    /// <param name="entityId">The extracted entity ID.</param>
    /// <returns><c>true</c> if the search criteria is valid and the entity ID is extracted; otherwise, <c>false</c>.</returns>
    private static bool TrySearchBy(string search, string searchBy, out int entityId)
    {
        var adeptToId = search.ToLower().Replace(searchBy, "");
        if (!adeptToId.Equals(search, StringComparison.CurrentCultureIgnoreCase) && int.TryParse(adeptToId.Trim(), out int id))
        {
            entityId = id;
            return true;
        }
        entityId = 0;
        return false;
    }
}
