namespace Olbrasoft.Blog.Data.FreeSql.QueryHandlers.TagQueryHandlers;

public class TagsQueryHandler : BlogDbQueryHandler<Tag, TagsQuery, IEnumerable<TagSmallDto>>
{
    public TagsQueryHandler(IConfigure<Tag> configurator, BlogFreeSqlDbContext context) : base(configurator, context)
    {
    }

    protected override async Task<IEnumerable<TagSmallDto>> GetResultToHandleAsync(TagsQuery query, CancellationToken token)
    {
       

        return await Select.OrderBy(a => a.Label).ToListAsync<TagSmallDto>(token);
    }

 
}