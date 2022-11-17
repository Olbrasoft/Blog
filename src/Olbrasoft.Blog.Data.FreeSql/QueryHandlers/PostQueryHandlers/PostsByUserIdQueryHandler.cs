namespace Olbrasoft.Blog.Data.FreeSql.QueryHandlers.PostQueryHandlers;

public class PostsByUserIdQueryHandler : BlogDbQueryHandler<Post, PostsByUserIdQuery, IPagedResult<PostOfUserDto>>
{
    public PostsByUserIdQueryHandler(IConfigure<Post> configurator, BlogFreeSqlDbContext context) : base(configurator, context)
    {
    }

    protected override async Task<IPagedResult<PostOfUserDto>> GetResultToHandleAsync(PostsByUserIdQuery query, CancellationToken token)
    {
        Select = Select.Where(p => p.CreatorId == query.UserId);

        var resultSelect = Select;

        if (!string.IsNullOrEmpty(query.Search))
        {
           resultSelect = resultSelect.Where(p => p.Title.ToLower().Contains(query.Search.ToLower()) || p.Content.ToLower().Contains(query.Search.ToLower()));
        }

        return (await resultSelect.OrderByPropertyName(query.OrderByColumnName, query.OrderByDirection.ToBoolean()).Page(query.Paging.NumberOfSelectedPage, query.Paging.PageSize)
            .ToListAsync(p => new PostOfUserDto { CategoryName = p.Category.Name }, token))
            .AsPagedResult( await Select.CountAsync(token), await resultSelect.CountAsync(token));
    }
}