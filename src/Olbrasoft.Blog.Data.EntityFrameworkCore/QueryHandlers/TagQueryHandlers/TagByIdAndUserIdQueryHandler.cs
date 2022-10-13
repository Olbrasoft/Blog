namespace Olbrasoft.Blog.Data.EntityFrameworkCore.QueryHandlers.TagQueryHandlers
{
    public class TagByIdAndUserIdQueryHandler : BlogDbQueryHandler<Tag, TagByIdAndUserIdQuery, TagSmallDto>
    {
        public TagByIdAndUserIdQueryHandler(IProjector projector, BlogDbContext context) : base(projector, context)
        {
        }

        public override async Task<TagSmallDto> HandleAsync(TagByIdAndUserIdQuery query, CancellationToken token)
        {
            return await ProjectTo<TagSmallDto>(Entities.Where(p => p.CreatorId == query.UserId && p.Id == query.Id)).FirstOrDefaultAsync(token);
        }

    }
}