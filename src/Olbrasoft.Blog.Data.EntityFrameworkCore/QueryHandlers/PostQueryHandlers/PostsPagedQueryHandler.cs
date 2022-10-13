namespace Olbrasoft.Blog.Data.EntityFrameworkCore.QueryHandlers.PostQueryHandlers
{
    public class PostsPagedQueryHandler : BlogDbQueryHandler<Post, PostsPagedQuery, IPagedEnumerable<PostDto>>
    {
        public PostsPagedQueryHandler(IProjector projector, BlogDbContext context) : base(projector, context)
        {
        }

        public override async Task<IPagedEnumerable<PostDto>> HandleAsync(PostsPagedQuery query, CancellationToken token)
        {
            var filteredEntities = Entities;

            if (!string.IsNullOrEmpty(query.Search))
            {
                var adeptToCategoryId = query.Search.ToLower().Replace("searchbycategoryid:", "");

                if (adeptToCategoryId != query.Search.ToLower() && int.TryParse(adeptToCategoryId.Trim(), out int categoryId))
                {
                    filteredEntities = Entities.Where(p => p.CategoryId == categoryId);
                }
                else
                {
                    var adeptToCreatorId = query.Search.ToLower().Replace("searchbycreatorid:", "");

                    if (adeptToCreatorId != query.Search.ToLower() && int.TryParse(adeptToCreatorId.Trim(), out int creatorId))
                    {
                        filteredEntities = Entities.Where(p => p.CreatorId == creatorId);
                    }
                    else
                    {
                        var adeptToTagId = query.Search.ToLower().Replace("searchbytagid:", "");
                        if (adeptToTagId != query.Search.ToLower() && int.TryParse(adeptToTagId.Trim(), out int tagId))
                        {
                            var toTags = Entities.SelectMany(p => p.ToTags);
                            filteredEntities = toTags.Where(p => p.ToId == tagId).Select(p => p.Post);
                        }
                        else

                            filteredEntities = Entities.Where(p => p.Title.Contains(query.Search));
                    }
                }
            }

            var posts = await ProjectTo<PostDto>(filteredEntities.OrderByDescending(p => p.Created))
                .Skip(query.Paging.CalculateSkip())
                .Take(query.Paging.PageSize).ToArrayAsync(token);

            return posts.AsPagedEnumerable(await filteredEntities.CountAsync());
        }
    }
}