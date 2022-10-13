using Olbrasoft.Blog.Data.Dtos.PostDtos;
using Olbrasoft.Data.Paging;
using Olbrasoft.Data.Sorting;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Olbrasoft.Blog.Business
{
    public interface IPostService
    {
        Task<bool> SaveAsync(string title, string content, int categoryId, int userId = 0, IEnumerable<int> tagIds = null, int id = 0);

        Task<IPagedEnumerable<PostDto>> PostsAsync(string search, IPageInfo paging, CancellationToken token);

        Task<PostDetailDto> PostAsync(int id, CancellationToken token);

        Task<IPagedResult<PostOfUserDto>> PostsByUserIdAsync(int userId, IPageInfo paging, string column, OrderDirection direction, string search, CancellationToken token);

        Task<PostEditDto> PostForEditingByIdAsync(int id, CancellationToken token);
    }
}