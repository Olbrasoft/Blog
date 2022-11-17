namespace Olbrasoft.Blog.Data.FreeSql.QueryHandlers.PostQueryHandlers;

public class PostsPagedQueryHandler : BlogDbQueryHandler<Post, PostsPagedQuery, IPagedEnumerable<PostDto>>
{

    public PostsPagedQueryHandler(IConfigure<Post> configurator, BlogFreeSqlDbContext context) : base(configurator, context)
    {
    }

    protected override async Task<IPagedEnumerable<PostDto>> GetResultToHandleAsync(PostsPagedQuery query, CancellationToken token)
    {
        var whereSelect = BuildWhereSelect(Select, query);

        var posts = await GetEnumerableAsync<PostDto>(whereSelect.OrderByDescending(p => p.Created).Page(query.Paging.NumberOfSelectedPage, query.Paging.PageSize), token);

        var ids = posts.Select(p => p.Id);

        var postToTags = await Context.Orm.Select<PostToTag, Tag>()
            .InnerJoin((ptt, t) => ptt.ToId == t.Id)
            .Where((ptt, t) => ids.Contains(ptt.Id))
            .ToListAsync((ptt, t) => new { PostId = ptt.Id, TagId = t.Id, t.Label }, token);

        foreach (var post in posts)
        {
            foreach (var tag in postToTags)
            {
                if (post.Id == tag.PostId) post.Tags.Add(new TagSmallDto { Id = tag.TagId, Label = tag.Label });
            }
        }

        return posts.AsPagedEnumerable(await whereSelect.CountAsync(token));
    }

    private static ISelect<Post> BuildWhereSelect(ISelect<Post> sourceSelect, PostsPagedQuery query)
        => string.IsNullOrEmpty(query.Search)
            ? sourceSelect
            : TrySearchBy(query.Search, "searchbycategoryid:", out int categoryId)
            ? sourceSelect.Where(p => p.CategoryId == categoryId)
            : TrySearchBy(query.Search, "searchbycreatorid:", out int creatorId)
                ? sourceSelect.Where(p => p.CreatorId == creatorId)
                : TrySearchBy(query.Search, "searchbytagid:", out int tagId)
                    ? sourceSelect.Where(p => (p.Tags.Select(t => t.Id).ToList()).Contains(tagId))
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