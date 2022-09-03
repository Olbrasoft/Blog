using Microsoft.EntityFrameworkCore;
using Olbrasoft.Blog.Data.Dtos.CommentDtos;
using Olbrasoft.Blog.Data.Entities;
using Olbrasoft.Blog.Data.Queries.CommentQueries;
using Olbrasoft.Data.Cqrs.EntityFrameworkCore;
using Olbrasoft.Mapping;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Olbrasoft.Blog.Data.EntityFrameworkCore.QueryHandlers.CommentQueryHandlers
{
    public class CommentsByPostIdQueryHandler : BlogDbQueryHandler<Comment, CommentsByPostIdQuery, IEnumerable<CommentDto>>
    {
        public CommentsByPostIdQueryHandler(IProjector projector, BlogDbContext context) : base(projector, context)
        {
        }

        public override async Task<IEnumerable<CommentDto>> HandleAsync(CommentsByPostIdQuery query, CancellationToken token)
        {
            return await ProjectTo<CommentDto>(Entities.Where(p => p.PostId == query.PostId).OrderByDescending(p => p.Created)).ToArrayAsync(token);
        }
    }
}