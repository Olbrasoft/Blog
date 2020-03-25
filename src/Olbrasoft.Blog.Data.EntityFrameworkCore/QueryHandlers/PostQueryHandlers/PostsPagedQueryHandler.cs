using Microsoft.EntityFrameworkCore;
using Olbrasoft.Blog.Data.Dtos;
using Olbrasoft.Blog.Data.Entities;
using Olbrasoft.Blog.Data.Queries.PostQueries;
using Olbrasoft.Data.Cqrs.EntityFrameworkCore;
using Olbrasoft.Data.Paging;
using Olbrasoft.Mapping;
using Olbrasoft.Paging;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Olbrasoft.Blog.Data.EntityFrameworkCore.QueryHandlers.PostQueryHandlers
{
    public class PostsPagedQueryHandler : DbQueryHandler<Post, PostsPagedQuery, IBasicPagedResult<PostDto>>
    {
        public PostsPagedQueryHandler(IProjector projector, BlogDbContext context) : base(projector, context)
        {
        }

        public override async Task<IBasicPagedResult<PostDto>> HandleAsync(PostsPagedQuery query, CancellationToken token)
        {
            var posts = await ProjectTo<PostDto>(Entities).OrderByDescending(p => p.Created)
                .Skip(query.Paging.CalculateSkip())
                .Take(query.Paging.PageSize).ToArrayAsync(token);

            return new BasicPagedResult<PostDto>
            {
                Records = posts,

                TotalCount = Entities.Count()
            };
        }
    }
}