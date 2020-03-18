using Microsoft.EntityFrameworkCore;
using Olbrasoft.Blog.Data.Dtos;
using Olbrasoft.Blog.Data.Entities;
using Olbrasoft.Blog.Data.Queries.TagQueries;
using Olbrasoft.Data.Cqrs.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Olbrasoft.Blog.Data.EntityFrameworkCore.QueryHandlers.TagQueryHandlers
{
    public class TagsWhereLabelContainsTextQueryHandler : QueryHandler<Tag, TagsWhereLabelContainsTextQuery, IEnumerable<TagDto>>
    {
        public TagsWhereLabelContainsTextQueryHandler(BlogDbContext context) : base(context)
        {
        }

        public override async Task<IEnumerable<TagDto>> HandleAsync(TagsWhereLabelContainsTextQuery query, CancellationToken token)
        {
            return await Entities.Where(p => p.Label.Contains(query.Text) && !query.ExceptTagIds.Contains(p.Id)).Take(6)
                .Select(p => new TagDto { Id = p.Id, Label = p.Label }).ToArrayAsync(token);
        }
    }
}