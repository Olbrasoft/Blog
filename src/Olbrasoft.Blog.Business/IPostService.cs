using Olbrasoft.Blog.Data.Dtos;
using Olbrasoft.Data.Paging;
using Olbrasoft.Paging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Olbrasoft.Blog.Business
{
    public interface IPostService
    {
        Task<bool> SaveAsync(string title, string content, int categoryId, int userId = 0, IEnumerable<int> tagIds = null, int id = 0);

        Task<IPagedResult<PostDto>> PostsAsync(IPageInfo paging);

        Task<PostDetailDto> PostAsync(int id);  
    }
}