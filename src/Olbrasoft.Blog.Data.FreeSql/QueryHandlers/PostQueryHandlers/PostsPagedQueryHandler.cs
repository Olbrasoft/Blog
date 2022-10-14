namespace Olbrasoft.Blog.Data.FreeSql.QueryHandlers.PostQueryHandlers;

public class PostsPagedQueryHandler : BlogDbQueryHandler<Post, PostsPagedQuery, IPagedEnumerable<PostDto>>
{
    public PostsPagedQueryHandler(IDataSelector selector) : base(selector)
    {
    }

    public override async Task<IPagedEnumerable<PostDto>> HandleAsync(PostsPagedQuery query, CancellationToken token)
    {
        ThrowIfQueryIsNullOrCancellationRequested(query, token);

        var resultSelect = BuildResultSelect(Select, query);

        var posts = await resultSelect.OrderByDescending(p => p.Created)
               .Page(query.Paging.NumberOfSelectedPage, query.Paging.PageSize)
               .ToListAsync(post => new PostDto { Creator = post.Creator.FirstName + " " + post.Creator.LastName }, token);

        return posts.AsPagedEnumerable(await resultSelect.CountAsync(token));
    }

    private static ISelect<Post> BuildResultSelect(ISelect<Post> sourceSelect, PostsPagedQuery query) => string.IsNullOrEmpty(query.Search)
            ? sourceSelect
            : TrySearchBy(query.Search, "searchbycategoryid:", out int categoryId)
            ? sourceSelect.Where(p => p.CategoryId == categoryId)
            : TrySearchBy(query.Search, "searchbycreatorid:", out int creatorId)
                ? sourceSelect.Where(p => p.CreatorId == creatorId)
                : TrySearchBy(query.Search, "searchbytagid:", out int tagId)
                    ? sourceSelect.InnerJoin<PostToTag>((p, ptt) => p.Id == ptt.Id && ptt.ToId == tagId)
                    : sourceSelect.Where(p => p.Title.Contains(query.Search));

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