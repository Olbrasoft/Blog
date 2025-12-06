namespace Olbrasoft.Blog.Data.FreeSql.QueryHandlers.PostQueryHandlers;

public class PostsByUserIdQueryHandler(BlogFreeSqlDbContext context) : BlogDbQueryHandler<Post, PostsByUserIdQuery, IPagedResult<PostOfUserDto>>(context)
{
    protected override async Task<IPagedResult<PostOfUserDto>> GetResultToHandleAsync(PostsByUserIdQuery query, CancellationToken token)
    {
        var filteredPosts = GetWhere(p => p.CreatorId == query.UserId);

        var postsSelect = Select;

        if (!string.IsNullOrEmpty(query.Search))
        {
            postsSelect = GetWhere(p => p.Title.Contains(query.Search, StringComparison.CurrentCultureIgnoreCase) || p.Content.Contains(query.Search, StringComparison.CurrentCultureIgnoreCase));
        }

        return (await postsSelect.OrderByPropertyName(query.OrderByColumnName, query.OrderByDirection.ToBoolean()).Page(query.Paging.NumberOfSelectedPage, query.Paging.PageSize)
            .ToListAsync(p => new PostOfUserDto { CategoryName = p.Category.Name }, token))
            .AsPagedResult(await filteredPosts.CountAsync(token), await postsSelect.CountAsync(token));
    }
}