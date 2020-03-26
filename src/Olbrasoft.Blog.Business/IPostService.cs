using Olbrasoft.Blog.Data.Dtos.PostDtos;
using Olbrasoft.Data;
using Olbrasoft.Data.Paging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Olbrasoft.Blog.Business
{
    public interface IPostService
    {
        Task<bool> SaveAsync(string title, string content, int categoryId, int userId = 0, IEnumerable<int> tagIds = null, int id = 0);

        Task<IBasicPagedResult<PostDto>> PostsAsync(IPageInfo paging);

        Task<PostDetailDto> PostAsync(int id);
        
        Task<IPagedResult<PostOfUserDto>> PostsByUserIdAsync(int userId, IPageInfo paging, string column, OrderDirection direction, string search);

        Task<PostEditDto> PostForEditingByIdAsync(int id);
    }
}