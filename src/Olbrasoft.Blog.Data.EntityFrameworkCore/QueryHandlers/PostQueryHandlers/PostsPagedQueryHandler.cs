namespace Olbrasoft.Blog.Data.EntityFrameworkCore.QueryHandlers.PostQueryHandlers;

public class PostsPagedQueryHandler : BlogDbQueryHandler<Post, PostsPagedQuery, IPagedEnumerable<PostDto>>
{
    public PostsPagedQueryHandler(IProjector projector, BlogDbContext context) : base(projector, context)
    {
    }

    protected override async Task<IPagedEnumerable<PostDto>> GetResultToHandleAsync(PostsPagedQuery query, CancellationToken token)
    {
        var resultQueryable = BuildResultQueryable(Queryable, query.Search);

        var posts = await ProjectTo<PostDto>(resultQueryable.OrderByDescending(p => p.Created))
            .Skip(query.Paging.CalculateSkip())
            .Take(query.Paging.PageSize).ToArrayAsync(token);

        return posts.AsPagedEnumerable(await resultQueryable.CountAsync(token));
    }


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




    private static bool TrySearchBy(string search, string searchBy, out int entityId)
    {
        var adeptToId = search.ToLower().Replace(searchBy, "");
        if (adeptToId != search.ToLower() && int.TryParse(adeptToId.Trim(), out int id))
        {
            entityId = id;
            return true;
        }
        entityId = 0;
        return false;
    }
}