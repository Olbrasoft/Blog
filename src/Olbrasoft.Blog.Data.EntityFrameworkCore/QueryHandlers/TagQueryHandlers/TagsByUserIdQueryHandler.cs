namespace Olbrasoft.Blog.Data.EntityFrameworkCore.QueryHandlers.TagQueryHandlers;

public class TagsByUserIdQueryHandler : BlogDbQueryHandler<Tag, TagsByUserIdQuery, IPagedResult<TagOfUserDto>>
{
    public TagsByUserIdQueryHandler(IProjector projector, BlogDbContext context) : base(projector, context)
    {
    }

    protected override async Task<IPagedResult<TagOfUserDto>> GetResultToHandleAsync(TagsByUserIdQuery query, CancellationToken token)
    {
        var userTags = Where(p => p.CreatorId == query.UserId);

        var userFilteredTags = userTags;

        if (!string.IsNullOrEmpty(query.Search))
        {
            userFilteredTags = userFilteredTags.Where(p => p.Label.Contains(query.Search, StringComparison.CurrentCultureIgnoreCase));
        }

        var tags = ProjectTo<TagOfUserDto>(userFilteredTags.OrderBy(query.OrderByColumnName, query.OrderByDirection))
             .Skip(query.Paging.CalculateSkip())
             .Take(query.Paging.PageSize).ToArrayAsync(token);

        return (await tags).AsPagedResult(await userTags.CountAsync(token), await userFilteredTags.CountAsync(token));
    }
}