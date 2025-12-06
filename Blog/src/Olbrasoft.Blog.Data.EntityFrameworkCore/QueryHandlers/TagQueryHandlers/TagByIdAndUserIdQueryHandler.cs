namespace Olbrasoft.Blog.Data.EntityFrameworkCore.QueryHandlers.TagQueryHandlers;

public class TagByIdAndUserIdQueryHandler(IProjector projector, BlogDbContext context) : BlogDbQueryHandler<Tag, TagByIdAndUserIdQuery, TagSmallDto>(projector, context)
{
    protected override async Task<TagSmallDto> GetResultToHandleAsync(TagByIdAndUserIdQuery query, CancellationToken token)
        => await ProjectTo<TagSmallDto>(t => t.CreatorId == query.UserId && t.Id == query.Id).FirstAsync(token);

}