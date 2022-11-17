namespace Olbrasoft.Blog.Data.FreeSql.Tests.QueryHandlers.TagQueryHandlers;

public class TagsByUserIdQueryHandler : BlogDbQueryHandler<Tag, TagsByUserIdQuery, IPagedResult<TagOfUserDto>>
{
    public TagsByUserIdQueryHandler(IConfigure<Tag> configurator, BlogFreeSqlDbContext context) : base(configurator, context)
    {
    }

    protected async override Task<IPagedResult<TagOfUserDto>> GetResultToHandleAsync(TagsByUserIdQuery query, CancellationToken token)
    {
        

        var userTagsSelect = Select.Where(p => p.CreatorId == query.UserId);

        if (!string.IsNullOrEmpty(query.Search))
            Select = Select.Where(p => p.Label.ToLower().Contains(query.Search.ToLower()));

        var pageTags = await Select.OrderByPropertyName(query.OrderByColumnName, query.OrderByDirection.ToBoolean())
                       .Page(query.Paging.NumberOfSelectedPage, query.Paging.PageSize)
                       .IncludeMany(t => t.Posts).ToListAsync(s => new TagOfUserDto { PostCount = s.Posts.Count }, token);

        return pageTags.AsPagedResult(await Select.CountAsync(token), await userTagsSelect.CountAsync(token));
    }
}