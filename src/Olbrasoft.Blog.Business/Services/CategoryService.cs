using Olbrasoft.Blog.Data.Commands;
using Olbrasoft.Blog.Data.Dtos;
using Olbrasoft.Blog.Data.Queries.CategoryQueries;
using Olbrasoft.Data;
using Olbrasoft.Data.Paging;
using Olbrasoft.Dispatching;
using Olbrasoft.Paging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Olbrasoft.Blog.Business.Services
{
    public class CategoryService : Service, ICategoryService
    {
        public CategoryService(IDispatcher dispatcher) : base(dispatcher)
        {
        }

        public async Task<IEnumerable<CategorySmallDto>> CategoriesAsync()
        {
            var query = new CategoriesQuery(Dispatcher);

            return await query.ExecuteAsync();
        }

        public async Task<IPagedResult<CategoryOfUsersDto>> CategoriesByExceptUserIdAsync(int exceptUserId, IPageInfo paging, string column, OrderDirection direction, string search)
        {
            var query = new CategoriesByExceptUserIdQuery(Dispatcher)
            {
                ExceptUserId = exceptUserId,
                Paging = paging,
                OrderByColumnName = column,
                OrderByDirection = direction,
                Search = search
            };

            return await query.ExecuteAsync();
        }

        public async Task<IPagedResult<CategoryOfUserDto>> CategoriesByUserIdAsync(int userId, IPageInfo paging, string column, OrderDirection direction, string search)
        {
            var query = new CategoriesByUserIdQuery(Dispatcher)
            {
                UserId = userId,
                Paging = paging,
                OrderByColumnName = column,
                OrderByDirection = direction,
                Search = search
            };

            return await query.ExecuteAsync();
        }

    
        public async Task<CategoryOfUserDto> CategoryAsync(int id)
        {
            return await new CategoryQuery(Dispatcher) { Id = id }.ExecuteAsync();
        }

        public async Task<bool> ExistsAsync(int ExceptId = 0, string name = null)
        {
            var query = new CategoryExistsQuery(Dispatcher) { ExceptId = ExceptId, Name = name };
            return await query.ExecuteAsync();
        }

        public async Task<bool> SaveAsync(int Id, string name, string tooltip, int userId)
        {
            var command = new CategorySaveCommand(Dispatcher)
            {
                Id = Id,
                Name = name,
                Tooltip = tooltip,
                CreatorId = userId
            };
            return await command.ExecuteAsync();
        }
    }
}