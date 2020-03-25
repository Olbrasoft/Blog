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
    public class TagsByIdsQueryHandler : DbQueryHandler<Tag, TagsByIdsQuery, IEnumerable<TagSmallDto>>
    {
        public TagsByIdsQueryHandler(IProjector projector, BlogDbContext context) : base(projector, context)
        {
        }

        public override async Task<IEnumerable<TagSmallDto>> HandleAsync(TagsByIdsQuery query, CancellationToken token)
        {
            return await ProjectTo<TagSmallDto>(Entities.Where(p => query.Ids.Contains(p.Id))).ToArrayAsync(token);
        }
    }
}