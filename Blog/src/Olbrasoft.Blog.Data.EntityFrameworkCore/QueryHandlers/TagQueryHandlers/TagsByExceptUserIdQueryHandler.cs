namespace Olbrasoft.Blog.Data.EntityFrameworkCore.QueryHandlers.TagQueryHandlers;

public class TagsByExceptUserIdQueryHandler(IProjector projector, BlogDbContext context) : BlogDbQueryHandler<Tag, TagsByExceptUserIdQuery, IPagedResult<TagOfUsersDto>>(projector, context)
{
    protected override async Task<IPagedResult<TagOfUsersDto>> GetResultToHandleAsync(TagsByExceptUserIdQuery query, CancellationToken token)
    {
        var userTags = Where(p => p.CreatorId != query.ExceptUserId);

        var filteredUserTags = userTags;

        if (!string.IsNullOrEmpty(query.Search))
        {
            filteredUserTags = filteredUserTags.Where(p => p.Label.Contains(query.Search, StringComparison.CurrentCultureIgnoreCase));
        }

        var tags = ProjectTo<TagOfUsersDto>(filteredUserTags.OrderBy(query.OrderByColumnName, query.OrderByDirection))
            .Skip(query.Paging.CalculateSkip()).Take(query.Paging.PageSize).ToArrayAsync(token);

        return (await tags)
            .AsPagedResult(
            await userTags.CountAsync(token),
            await filteredUserTags.CountAsync(token));
    }
}