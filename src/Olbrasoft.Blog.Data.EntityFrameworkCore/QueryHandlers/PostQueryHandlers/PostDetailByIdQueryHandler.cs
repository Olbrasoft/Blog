using Microsoft.EntityFrameworkCore;
using Olbrasoft.Blog.Data.Dtos.PostDtos;
using Olbrasoft.Blog.Data.Entities;
using Olbrasoft.Blog.Data.Queries.PostQueries;
using Olbrasoft.Data.Cqrs.EntityFrameworkCore;
using Olbrasoft.Mapping;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Olbrasoft.Blog.Data.EntityFrameworkCore.QueryHandlers.PostQueryHandlers
{
    public class PostDetailByIdQueryHandler : BlogDbQueryHandler<Post, PostDetailByIdQuery, PostDetailDto>
    {
        public PostDetailByIdQueryHandler(IProjector projector, BlogDbContext context) : base(projector, context)
        {
        }

        public override async Task<PostDetailDto> HandleAsync(PostDetailByIdQuery query, CancellationToken token)
        {
            return await ProjectTo<PostDetailDto>(Entities.Where(p => p.Id == query.Id)).FirstOrDefaultAsync(token);
        }
    }
}