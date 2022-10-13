namespace Olbrasoft.Blog.Data.FreeSql.QueryHandlers.PostQueryHandlers;

public class PostsByUserIdQueryHandler : BlogDbQueryHandler<Post, PostsByUserIdQuery, IPagedResult<PostOfUserDto>>
{
    public PostsByUserIdQueryHandler(IDataSelector selector) : base(selector)
    {
    }

    public override async Task<IPagedResult<PostOfUserDto>> HandleAsync(PostsByUserIdQuery query, CancellationToken token)
    {
        var filteredPostSelect = Select.Where(p => p.CreatorId == query.UserId);

        if (!string.IsNullOrEmpty(query.Search))
        {
            filteredPostSelect = filteredPostSelect.Where(p => p.Title.ToLower().Contains(query.Search.ToLower()) || p.Content.ToLower().Contains(query.Search.ToLower()));
        }

        var orderByDirection = true;
        if (query.OrderByDirection is Olbrasoft.Data.Sorting.OrderDirection.Desc) orderByDirection = false;

        return (await filteredPostSelect.OrderByPropertyName(query.OrderByColumnName, orderByDirection).Page(query.Paging.NumberOfSelectedPage, query.Paging.PageSize)
            .ToListAsync(p => new PostOfUserDto { CategoryName = p.Category.Name }, token))
            .AsPagedResult((int)await Select.Where(p => p.CreatorId == query.UserId).CountAsync(token), (int)await filteredPostSelect.CountAsync(token));
    }
}