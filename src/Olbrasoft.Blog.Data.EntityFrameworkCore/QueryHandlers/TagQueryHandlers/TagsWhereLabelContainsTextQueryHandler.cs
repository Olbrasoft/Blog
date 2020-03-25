using Microsoft.EntityFrameworkCore;
using Olbrasoft.Blog.Data.Dtos;
using Olbrasoft.Blog.Data.Entities;
using Olbrasoft.Blog.Data.Queries.TagQueries;
using Olbrasoft.Data.Cqrs.EntityFrameworkCore;
using Olbrasoft.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Olbrasoft.Blog.Data.EntityFrameworkCore.QueryHandlers.TagQueryHandlers
{
    public class TagsWhereLabelContainsTextQueryHandler : DbQueryHandler<Tag, TagsWhereLabelContainsTextQuery, IEnumerable<TagSmallDto>>
    {
        public TagsWhereLabelContainsTextQueryHandler(IProjector projector, BlogDbContext context) : base(projector, context)
        {
        }

        public override async Task<IEnumerable<TagSmallDto>> HandleAsync(TagsWhereLabelContainsTextQuery query, CancellationToken token)
        {
            return await ProjectTo<TagSmallDto>(Entities.Where(p => p.Label.Contains(query.Text) && !query.ExceptTagIds.Contains(p.Id)))
                .Take(6)
                .ToArrayAsync(token);
        }
    }
}