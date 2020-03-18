using Microsoft.EntityFrameworkCore;
using Olbrasoft.Blog.Data.Dtos;
using Olbrasoft.Blog.Data.Entities;
using Olbrasoft.Blog.Data.Queries.TagQueries;
using Olbrasoft.Data.Cqrs.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Olbrasoft.Blog.Data.EntityFrameworkCore.QueryHandlers.TagQueryHandlers
{
    public class TagByIdAndUserIdQueryHandler : QueryHandler<Tag, TagByIdAndUserIdQuery, TagDto>
    {
        public TagByIdAndUserIdQueryHandler(BlogDbContext context) : base(context)
        {
        }

        public override async Task<TagDto> HandleAsync(TagByIdAndUserIdQuery query, CancellationToken token)
        {
            var tag = await Entities.Select(tag => new { tag.Id, tag.Label, tag.CreatorId }).FirstOrDefaultAsync(p => p.Id == query.Id && p.CreatorId == query.UserId);

            if (tag != null)
                return new TagDto { Id = tag.Id, Label = tag.Label };

            throw new Exception("Tag not found");
        }
    }
}