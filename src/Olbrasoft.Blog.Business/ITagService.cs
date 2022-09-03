using Olbrasoft.Blog.Data.Dtos.TagDtos;
using Olbrasoft.Data;
using Olbrasoft.Data.Paging;
using Olbrasoft.Data.Sorting;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Olbrasoft.Blog.Business
{
    public interface ITagService
    {
        Task<bool> ExistsAsync();

        Task<bool> ExistsAsync(string label);

        Task<bool> ExistsAsync(int exceptId, string label);

        Task<bool> SaveAsync(int id, string label, int userId);

        Task<IPagedResult<TagOfUserDto>> TagsByUserIdAsync(int userId, IPageInfo paging, string column, OrderDirection direction, string search);

        Task<IPagedResult<TagOfUsersDto>> TagsByExceptUserIdAsync(int exceptUserId, IPageInfo paging, string column, OrderDirection direction, string search);

        Task<TagSmallDto> UserTagAsync(int id, int userId);

        Task<IEnumerable<TagSmallDto>> FindAsync(string term, IEnumerable<int> exceptTagIds);

        Task<IEnumerable<TagSmallDto>> TagsByIds(IEnumerable<int> ids);

        Task<IEnumerable<TagSmallDto>> TagsAsync();
    }
}