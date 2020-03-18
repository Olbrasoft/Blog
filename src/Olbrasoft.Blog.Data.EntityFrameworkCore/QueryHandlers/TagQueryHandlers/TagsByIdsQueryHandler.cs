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
    public class TagsByIdsQueryHandler : QueryHandler<Tag, TagsByIdsQuery, IEnumerable<TagBasicDto>>
    {
        public TagsByIdsQueryHandler(BlogDbContext context) : base(context)
        {
        }

        public override async Task<IEnumerable<TagBasicDto>> HandleAsync(TagsByIdsQuery query, CancellationToken token)
        {
            return await Entities.Where(p => query.Ids.Contains(p.Id)).Select(p => new TagBasicDto { Id = p.Id, Label = p.Label }).ToArrayAsync();
        }
    }
}