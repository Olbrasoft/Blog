using Olbrasoft.Blog.Data.Dtos.CategoryDtos;
using Olbrasoft.Data.Paging;
using Olbrasoft.Data.Sorting;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Olbrasoft.Blog.Business
{
    public interface ICategoryService
    {
        Task<bool> ExistsAsync(int ExceptId , string name );

        Task<bool> SaveAsync(int Id, string name, string tooltip, int userId);

        Task<IPagedResult<CategoryOfUserDto>> CategoriesByUserIdAsync(int userId, IPageInfo paging, string column, OrderDirection direction, string search);

        Task<IPagedResult<CategoryOfUsersDto>> CategoriesByExceptUserIdAsync(int ExceptUserId, IPageInfo paging, string column, OrderDirection direction, string search);

        Task<CategoryOfUserDto> CategoryAsync(int Id);

        Task<IEnumerable<CategorySmallDto>> CategoriesAsync(CancellationToken token);
    }
}