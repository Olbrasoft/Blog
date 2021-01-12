using Microsoft.EntityFrameworkCore;
using Olbrasoft.Blog.Data.Dtos.PostDtos;
using Olbrasoft.Blog.Data.Entities;
using Olbrasoft.Blog.Data.Queries.PostQueries;
using Olbrasoft.Data.Linq.Expressions;
using Olbrasoft.Data.Paging;
using Olbrasoft.Mapping;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Olbrasoft.Blog.Data.EntityFrameworkCore.QueryHandlers.PostQueryHandlers
{
    public class PostsByUserIdQueryHandler : BlogDbQueryHandler<Post, PostsByUserIdQuery, IPagedResult<PostOfUserDto>>
    {
        public PostsByUserIdQueryHandler(IProjector projector, IDbContextFactory<BlogDbContext> context) : base(projector, context)
        {
        }

        public override async Task<IPagedResult<PostOfUserDto>> HandleAsync(PostsByUserIdQuery query, CancellationToken token)
        {
            var filteredPosts = Entities.Where(p => p.CreatorId == query.UserId);

            if (!string.IsNullOrEmpty(query.Search))
            {
                filteredPosts = filteredPosts.Where(p => p.Title.ToLower().Contains(query.Search.ToLower()) || p.Content.ToLower().Contains(query.Search.ToLower()));
            }

            var posts = ProjectTo<PostOfUserDto>(filteredPosts.OrderBy(query.OrderByColumnName, query.OrderByDirection))
                 .Skip(query.Paging.CalculateSkip())
                 .Take(query.Paging.PageSize);

            return new PagedResult<PostOfUserDto>(await posts.ToArrayAsync(token))
            {
                TotalCount = await Entities.Where(p => p.CreatorId == query.UserId).CountAsync(),

                FilteredCount = await filteredPosts.CountAsync()
            };
        }
    }
}