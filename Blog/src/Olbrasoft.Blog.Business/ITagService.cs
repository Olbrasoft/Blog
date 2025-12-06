using Olbrasoft.Blog.Data.Dtos.TagDtos;
using Olbrasoft.Data.Paging;
using Olbrasoft.Data.Sorting;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Olbrasoft.Blog.Business;

public interface ITagService
{
    //Task<bool> ExistsAsync();
    //Task<bool> ExistsAsync(string label);
    Task<bool> ExistsAsync(int exceptId, string label, CancellationToken token);
    Task<bool> SaveAsync(int id, string label, int userId, CancellationToken token);
    Task<bool> DeleteAsync(int tagId, int userId, CancellationToken token);
    Task<IEnumerable<TagSmallDto>> TagsByIds(IEnumerable<int> ids, CancellationToken token);
    Task<IEnumerable<TagSmallDto>> TagsAsync(CancellationToken token);
    Task<TagSmallDto> UserTagAsync(int id, int userId, CancellationToken token);
    Task<IEnumerable<TagSmallDto>> FindAsync(string term, IEnumerable<int> exceptTagIds, CancellationToken token);
    Task<IEnumerable<TagSmallDto>> TagsByPostIdAsync(int postId, CancellationToken token);
    Task<IPagedResult<TagOfUserDto>> TagsByUserIdAsync(int userId,
                                                       IPageInfo paging,
                                                       string column,
                                                       OrderDirection direction,
                                                       string search,
                                                       CancellationToken token);
    Task<IPagedResult<TagOfUsersDto>> TagsByExceptUserIdAsync(int exceptUserId,
                                                              IPageInfo paging,
                                                              string column,
                                                              OrderDirection direction,
                                                              string search,
                                                              CancellationToken token);

}