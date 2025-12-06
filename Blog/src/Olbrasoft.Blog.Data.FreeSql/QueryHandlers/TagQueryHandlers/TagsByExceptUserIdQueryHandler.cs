namespace Olbrasoft.Blog.Data.FreeSql.QueryHandlers.TagQueryHandlers;

public class TagsByExceptUserIdQueryHandler (BlogFreeSqlDbContext context) : BlogDbQueryHandler<Tag, TagsByExceptUserIdQuery, IPagedResult<TagOfUsersDto>>(context)
{
    protected override async Task<IPagedResult<TagOfUsersDto>> GetResultToHandleAsync(TagsByExceptUserIdQuery query, CancellationToken token)
    {

        var filteredTags = GetWhere(p => p.CreatorId != query.ExceptUserId);

        var tagsSelect = BuildSearchSelect(query.Search, filteredTags);

        return (await tagsSelect.OrderByPropertyName(query.OrderByColumnName, query.OrderByDirection.ToBoolean())
                                     .Page(query.Paging.NumberOfSelectedPage, query.Paging.PageSize)
                                     .IncludeMany(t => t.Posts)
            .ToListAsync(s => new TagOfUsersDto { PostCount = s.Posts.Count(), Creator = $"{s.Creator.FirstName} {s.Creator.LastName}" }, token)
                         ).AsPagedResult(await filteredTags.CountAsync(token), await tagsSelect.CountAsync(token));
    }

    private static ISelect<Tag> BuildSearchSelect(string search, ISelect<Tag> tags)
        => !string.IsNullOrEmpty(search) ? tags.Where(p => p.Label.Contains(search, StringComparison.CurrentCultureIgnoreCase)) : tags;

}