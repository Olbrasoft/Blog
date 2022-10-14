namespace Olbrasoft.Blog.Data.FreeSql.Tests.QueryHandlers.TagQueryHandlers;

public class TagsByUserIdQueryHandler : BlogDbQueryHandler<Tag, TagsByUserIdQuery, IPagedResult<TagOfUserDto>>
{
    public TagsByUserIdQueryHandler(IDataSelector selector) : base(selector)
    {
    }

    public async override Task<IPagedResult<TagOfUserDto>> HandleAsync(TagsByUserIdQuery query, CancellationToken token)
    {
        ThrowIfQueryIsNullOrCancellationRequested(query, token);

        var userTagsSelect = Select.Where(p => p.CreatorId == query.UserId);

        if (!string.IsNullOrEmpty(query.Search))
            Select = Select.Where(p => p.Label.ToLower().Contains(query.Search.ToLower()));

        Select = Select.OrderByPropertyName(query.OrderByColumnName, query.OrderByDirection.ToBoolean())
                      .Page(query.Paging.NumberOfSelectedPage, query.Paging.PageSize)
                      .IncludeMany<PostToTag>(t => t.ToPosts);

        return (await Select.ToListAsync(s => new TagOfUserDto { PostCount = s.ToPosts.Count() }, token))
            .AsPagedResult( await Select.CountAsync(token), await userTagsSelect.CountAsync(token));
    }
}