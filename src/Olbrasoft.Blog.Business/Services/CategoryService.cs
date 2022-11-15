using Olbrasoft.Blog.Data.Commands;
using Olbrasoft.Blog.Data.Dtos.CategoryDtos;
using Olbrasoft.Blog.Data.Queries.CategoryQueries;
using Olbrasoft.Data.Cqrs;
using Olbrasoft.Data.Paging;
using Olbrasoft.Data.Sorting;
using Olbrasoft.Dispatching;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Olbrasoft.Blog.Business.Services
{
    public class CategoryService : Service, ICategoryService
    {
        public CategoryService(IDispatcher dispatcher) : base(dispatcher)
        {
           
        }

        public async Task<IEnumerable<CategorySmallDto>> CategoriesAsync(CancellationToken token = default) 
            => await new CategoriesQuery(Dispatcher).ToResultAsync(token);

        public async Task<IPagedResult<CategoryOfUsersDto>> CategoriesByExceptUserIdAsync(int exceptUserId,
                                                                                          IPageInfo paging,
                                                                                          string column,
                                                                                          OrderDirection direction,
                                                                                          string search,
                                                                                          CancellationToken token = default)
            => await new CategoriesByExceptUserIdQuery(Dispatcher)
            {
                ExceptUserId = exceptUserId,
                Paging = paging,
                OrderByColumnName = column,
                OrderByDirection = direction,
                Search = search

            }.ToResultAsync(token);


        public async Task<IPagedResult<CategoryOfUserDto>> CategoriesByUserIdAsync(int userId,
                                                                                   IPageInfo paging,
                                                                                   string column,
                                                                                   OrderDirection direction,
                                                                                   string search,
                                                                                   CancellationToken token = default)
            => await new CategoriesByUserIdQuery(Dispatcher)
            {
                UserId = userId,
                Paging = paging,
                OrderByColumnName = column,
                OrderByDirection = direction,
                Search = search

            }.ToResultAsync(token);


        public async Task<CategoryOfUserDto> CategoryAsync(int id, CancellationToken token = default)
            => await new CategoryQuery(Dispatcher) { Id = id }.ToResultAsync(token);


        public async Task<bool> ExistsAsync(int ExceptId = 0, string name = "", CancellationToken token = default)
            => await new CategoryExistsQuery(Dispatcher) { ExceptId = ExceptId, Name = name }.ToResultAsync(token);


        public async Task<bool> SaveAsync(int Id, string name, string tooltip, int userId, CancellationToken token = default)

            => await new CategorySaveCommand(Dispatcher)
            {
                Id = Id,
                Name = name,
                Tooltip = tooltip,
                CreatorId = userId

            }.ToResultAsync(token: token);
    }
}