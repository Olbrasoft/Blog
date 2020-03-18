using Olbrasoft.Blog.Data.Dtos;
using Olbrasoft.Data;
using Olbrasoft.Data.Paging;
using Olbrasoft.Paging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Olbrasoft.Blog.Business
{
    public interface ICategoryService
    {
        Task<bool> ExistsAsync(int ExceptId = 0, string name = null);

        Task<bool> SaveAsync(int Id, string name, string tooltip, int userId);

        Task<IPagedResult<CategoryOfUserDto>> CategoriesByUserIdAsync(int userId, IPageInfo paging, string column, OrderDirection direction, string search);

        Task<IPagedResult<CategoryOfUsersDto>> CategoriesByExceptUserIdAsync(int ExceptUserId, IPageInfo paging, string column, OrderDirection direction, string search);

        Task<CategoryOfUserDto> CategoryAsync(int Id);

        Task<IEnumerable<CategorySmallDto>> CategoriesAsync();
    }
}