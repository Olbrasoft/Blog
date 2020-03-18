using Olbrasoft.Blog.Data.Dtos;
using Olbrasoft.Data;
using Olbrasoft.Data.Paging;
using Olbrasoft.Paging;
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

        Task<IPagedResult<TagDto>> UserTagsAsync(int userId, IPageInfo paging, string column, OrderDirection direction, string search);

        Task<IPagedResult<TagDto>> OtherUsersTags(int exceptUserId, IPageInfo paging, string column, OrderDirection direction, string search);

        Task<TagDto> UserTagAsync(int id, int userId);

        Task<IEnumerable<TagDto>> Find(string term, IEnumerable<int> exceptTagIds);

        Task<IEnumerable<TagBasicDto>> TagsByIds(IEnumerable<int> ids);
    }
}