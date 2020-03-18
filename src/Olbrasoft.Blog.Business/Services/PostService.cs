using MediatR;
using Olbrasoft.Blog.Data.Commands;
using Olbrasoft.Blog.Data.Dtos;
using Olbrasoft.Blog.Data.Queries.PostQueries;
using Olbrasoft.Data.Paging;
using Olbrasoft.Dispatching;
using Olbrasoft.Paging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Olbrasoft.Blog.Business.Services
{
    public class PostService : Service, IPostService
    {
        public PostService(IDispatcher dispatcher) : base( dispatcher)
        {
        }

        public async Task<PostDetailDto> PostAsync(int id)
        {
            var query = new PostDetailByIdQuery(Dispatcher) { Id = id };

            return await query.ExecuteAsync();
        }

        public async Task<IPagedResult<PostDto>> PostsAsync(IPageInfo paging)
        {
            var query = new PostsPagedQuery(Dispatcher) { Paging = paging };

            return await query.ExecuteAsync();
        }

        public async Task<bool> SaveAsync(string title, string content, int categoryId, int userId = 0, IEnumerable<int> tagIds = null, int id = 0)
        {
            var command = new PostSaveCommand(Dispatcher)
            {
                Id = id,
                CategoryId = categoryId,
                Content = content,
                TagIds = tagIds,
                Title = title,
                UserId = userId
            };

            return await command.ExecuteAsync();
        }
    }
}