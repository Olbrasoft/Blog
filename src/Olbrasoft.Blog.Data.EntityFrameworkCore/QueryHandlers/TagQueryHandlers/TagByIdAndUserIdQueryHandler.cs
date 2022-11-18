namespace Olbrasoft.Blog.Data.EntityFrameworkCore.QueryHandlers.TagQueryHandlers
{
    public class TagByIdAndUserIdQueryHandler : BlogDbQueryHandler<Tag, TagByIdAndUserIdQuery, TagSmallDto>
    {
        public TagByIdAndUserIdQueryHandler(IProjector projector, BlogDbContext context) : base(projector, context)
        {
        }

        protected override async Task<TagSmallDto> GetResultToHandleAsync(TagByIdAndUserIdQuery query, CancellationToken token)
        {
            return await ProjectTo<TagSmallDto>(Queryable.Where(p => p.CreatorId == query.UserId && p.Id == query.Id)).FirstAsync(token);
        }

    }
}