using Microsoft.EntityFrameworkCore;
using Olbrasoft.Blog.Data.Dtos.PostDtos;
using Olbrasoft.Blog.Data.Entities;
using Olbrasoft.Data.Cqrs.EntityFrameworkCore;
using Olbrasoft.Mapping;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Olbrasoft.Blog.Data.EntityFrameworkCore.QueryHandlers.PostQueryHandlers
{
    public class PostByIdQueryHandler : BlogDbQueryHandler<Post, PostByIdQuery, PostEditDto>
    {
        public PostByIdQueryHandler(IProjector projector, IDbContextFactory<BlogDbContext> context) : base(projector, context)
        {
        }

        public override async Task<PostEditDto> HandleAsync(PostByIdQuery query, CancellationToken token)
        {
            return await ProjectTo<PostEditDto>(Entities.Where(p => p.Id == query.Id)).FirstOrDefaultAsync(token);
        }
    }
}