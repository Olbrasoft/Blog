using Microsoft.EntityFrameworkCore;
using Olbrasoft.Blog.Data.Dtos;
using Olbrasoft.Blog.Data.Entities;
using Olbrasoft.Blog.Data.Queries.PostQueries;
using Olbrasoft.Data.Cqrs.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Olbrasoft.Blog.Data.EntityFrameworkCore.QueryHandlers.PostQueryHandlers
{
    public class PostDetailByIdQueryHandler : QueryHandler<Post, PostDetailByIdQuery, PostDetailDto>
    {
        public PostDetailByIdQueryHandler(BlogDbContext context) : base(context)
        {
        }

        public override async Task<PostDetailDto> HandleAsync(PostDetailByIdQuery query, CancellationToken token)
        {
            var post = await Entities.FirstOrDefaultAsync(p => p.Id == query.Id);

            if (post != null)
                return new PostDetailDto
                {
                    Id = post.Id,
                    Title = post.Title,
                    Content = post.Content,
                    Created = post.Created,
                    CreatorId = post.CreatorId
                };

            throw new Exception("Not Founf");
        }
    }
}