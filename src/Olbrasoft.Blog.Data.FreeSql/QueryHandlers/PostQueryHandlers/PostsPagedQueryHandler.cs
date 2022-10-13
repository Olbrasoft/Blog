namespace Olbrasoft.Blog.Data.FreeSql.QueryHandlers.PostQueryHandlers;

public class PostsPagedQueryHandler : BlogDbQueryHandler<Post, PostsPagedQuery, IPagedEnumerable<PostDto>>
{
  
    public PostsPagedQueryHandler(IDataSelector selector) : base(selector)
    {
    }

    public override async Task<IPagedEnumerable<PostDto>> HandleAsync(PostsPagedQuery query, CancellationToken token)
    {
        var filteredSelect = Select;

        if (!string.IsNullOrEmpty(query.Search))
        {
            var adeptToCategoryId = query.Search.ToLower().Replace("searchbycategoryid:", "");

            if (adeptToCategoryId != query.Search.ToLower() && int.TryParse(adeptToCategoryId.Trim(), out int categoryId))
            {
                filteredSelect = filteredSelect.Where(p => p.CategoryId == categoryId);
            }
            else
            {
                var adeptToCreatorId = query.Search.ToLower().Replace("searchbycreatorid:", "");

                if (adeptToCreatorId != query.Search.ToLower() && int.TryParse(adeptToCreatorId.Trim(), out int creatorId))
                {
                    filteredSelect = filteredSelect.Where(p => p.CreatorId == creatorId);
                }
                else
                {
                    var adeptToTagId = query.Search.ToLower().Replace("searchbytagid:", "");

                    if (adeptToTagId != query.Search.ToLower() && int.TryParse(adeptToTagId.Trim(), out int tagId))
                    {
                       filteredSelect.InnerJoin<PostToTag>((p, ptt) => p.Id == ptt.Id && ptt.ToId == tagId);
                    }
                    else filteredSelect = filteredSelect.Where(p => p.Title.Contains(query.Search));
                }
            }
        }

        var posts = await filteredSelect.OrderByDescending(p => p.Created)
               .Page(query.Paging.NumberOfSelectedPage, query.Paging.PageSize)
               .ToListAsync(post => new PostDto { Creator = post.Creator.FirstName + " " + post.Creator.LastName }, token);

        return posts.AsPagedEnumerable((int)await filteredSelect.CountAsync(token));
    }
}