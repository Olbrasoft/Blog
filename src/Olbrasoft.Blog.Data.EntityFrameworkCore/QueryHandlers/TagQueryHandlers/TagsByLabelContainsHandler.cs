﻿namespace Olbrasoft.Blog.Data.EntityFrameworkCore.QueryHandlers.TagQueryHandlers
{
    public class TagsByLabelContainsHandler : BlogDbQueryHandler<Tag, TagsByLabelContainsQuery, IEnumerable<TagSmallDto>>
    {
        public TagsByLabelContainsHandler(IProjector projector, BlogDbContext context) : base(projector, context)
        {
        }

       public override async Task<IEnumerable<TagSmallDto>> HandleAsync(TagsByLabelContainsQuery query, CancellationToken token)
        {
            return await ProjectTo<TagSmallDto>(Entities.Where(p => p.Label.Contains(query.Text) && !query.ExceptTagIds.Contains(p.Id)))
                .Take(6)
                .ToArrayAsync(token);
        }
    }
}