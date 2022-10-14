namespace Olbrasoft.Blog.Data.FreeSql.QueryHandlers.TagQueryHandlers;

public class TagsByExceptUserIdQueryHandler : BlogDbQueryHandler<Tag, TagsByExceptUserIdQuery, IPagedResult<TagOfUsersDto>>
{
    public TagsByExceptUserIdQueryHandler(IDataSelector selector) : base(selector)
    {
    }

    public override async Task<IPagedResult<TagOfUsersDto>> HandleAsync(TagsByExceptUserIdQuery query, CancellationToken token)
    {
        ThrowIfQueryIsNullOrCancellationRequested(query, token);

        Select = Select.Where(p => p.CreatorId != query.ExceptUserId);

        var searchSelect = BuildSearchSelect(query.Search, Select);

        return (await searchSelect.OrderByPropertyName(query.OrderByColumnName, query.OrderByDirection.ToBoolean())
                                     .Page(query.Paging.NumberOfSelectedPage, query.Paging.PageSize)
                                     .IncludeMany<PostToTag>(t => t.ToPosts)
            .ToListAsync(s => new TagOfUsersDto { PostCount = s.ToPosts.Count(), Creator = $"{s.Creator.FirstName} {s.Creator.LastName}" }, token)
                         ).AsPagedResult(await Select.CountAsync(token), await searchSelect.CountAsync(token));
    }

    private static ISelect<Tag> BuildSearchSelect(string search, ISelect<Tag> select)
        => !string.IsNullOrEmpty(search) ? select.Where(p => p.Label.ToLower().Contains(search.ToLower())) : select;

}