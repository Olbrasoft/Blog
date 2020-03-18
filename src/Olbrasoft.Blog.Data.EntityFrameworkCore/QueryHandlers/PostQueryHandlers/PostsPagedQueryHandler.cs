using Microsoft.EntityFrameworkCore;
using Olbrasoft.Blog.Data.Dtos;
using Olbrasoft.Blog.Data.Entities;
using Olbrasoft.Blog.Data.Queries.PostQueries;
using Olbrasoft.Data.Cqrs.EntityFrameworkCore;
using Olbrasoft.Data.Paging;
using Olbrasoft.Paging;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Olbrasoft.Blog.Data.EntityFrameworkCore.QueryHandlers.PostQueryHandlers
{
    public class PostsPagedQueryHandler : QueryHandler<Post, PostsPagedQuery, IPagedResult<PostDto>>
    {
        public PostsPagedQueryHandler(BlogDbContext context) : base(context)
        {
        }

        public override async Task<IPagedResult<PostDto>> HandleAsync(PostsPagedQuery query, CancellationToken token)
        {
            var posts = await Entities.OrderByDescending(p => p.Created)
                .Skip(query.Paging.CalculateSkip())
                .Take(query.Paging.PageSize)
                .Select(p => new { p.Id, p.Title, p.Content, p.Created, p.CreatorId })
                .ToArrayAsync();

            return new PagedResult<PostDto>
            {
                Records = posts.Select(p => new PostDto { Id = p.Id, Title = p.Title, Content = p.Content, Created = p.Created, CreatorId = p.CreatorId }),
                TotalCount = Entities.Count()
            };
        }
    }
}