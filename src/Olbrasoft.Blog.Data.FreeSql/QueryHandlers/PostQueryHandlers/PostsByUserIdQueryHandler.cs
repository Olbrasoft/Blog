using Olbrasoft.Data.Cqrs.FreeSql;

namespace Olbrasoft.Blog.Data.FreeSql.QueryHandlers.PostQueryHandlers;

public class PostsByUserIdQueryHandler : BlogDbQueryHandler<Post, PostsByUserIdQuery, IPagedResult<PostOfUserDto>>
{
    public PostsByUserIdQueryHandler(IConfigure<Post> configurator, BlogFreeSqlDbContext context) : base(configurator, context)
    {
    }

    public override async Task<IPagedResult<PostOfUserDto>> HandleAsync(PostsByUserIdQuery query, CancellationToken token)
    {
        var userPostsSelect = Select.Where(p => p.CreatorId == query.UserId);

        if (!string.IsNullOrEmpty(query.Search))
        {
            Select = Select.Where(p => p.Title.ToLower().Contains(query.Search.ToLower()) || p.Content.ToLower().Contains(query.Search.ToLower()));
        }

        return (await Select.OrderByPropertyName(query.OrderByColumnName, query.OrderByDirection.ToBoolean()).Page(query.Paging.NumberOfSelectedPage, query.Paging.PageSize)
            .ToListAsync(p => new PostOfUserDto { CategoryName = p.Category.Name }, token))
            .AsPagedResult(await userPostsSelect.Where(p => p.CreatorId == query.UserId).CountAsync(token), await Select.CountAsync(token));
    }
}