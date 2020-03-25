using Olbrasoft.Blog.Data.Commands;
using Olbrasoft.Blog.Data.Dtos;
using Olbrasoft.Blog.Data.EntityFrameworkCore.QueryHandlers.PostQueryHandlers;
using Olbrasoft.Blog.Data.Queries.PostQueries;
using Olbrasoft.Data;
using Olbrasoft.Data.Paging;
using Olbrasoft.Dispatching;
using Olbrasoft.Paging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Olbrasoft.Blog.Business.Services
{
    public class PostService : Service, IPostService
    {
        public PostService(IDispatcher dispatcher) : base(dispatcher)
        {
        }

        public async Task<PostDetailDto> PostAsync(int id) => await new PostDetailByIdQuery(Dispatcher) { Id = id }.ExecuteAsync();

        public async Task<PostEditDto> PostForEditingByIdAsync(int id)
        {
            return await new PostByIdQuery(Dispatcher) { Id = id }.ExecuteAsync();
        }

        public async Task<IBasicPagedResult<PostDto>> PostsAsync(IPageInfo paging)
        {
            return await new PostsPagedQuery(Dispatcher) { Paging = paging }.ExecuteAsync();
        }

        public async Task<IPagedResult<PostOfUserDto>> PostsByUserIdAsync(int userId, IPageInfo paging, string column, OrderDirection direction, string search)
        {
            var query = new PostsByUserIdQuery(Dispatcher)
            {
                UserId = userId,
                Paging = paging,
                OrderByColumnName = column,
                OrderByDirection = direction,
                Search = search
            };

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
                CreatorId = userId
            };

            return await command.ExecuteAsync();
        }
    }
}