using Microsoft.AspNetCore.Http;
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
        Task<bool> SaveAsync(IFormFile? image, string title, string content, int categoryId, int userId, IEnumerable<int> tagIds, int id, bool deleteDefaultImage, CancellationToken token);

        Task<IPagedEnumerable<PostDto>> PostsAsync(string search, IPageInfo paging, CancellationToken token);

        Task<PostDetailDto> PostAsync(int id, CancellationToken token);

        Task<IPagedResult<PostOfUserDto>> PostsByUserIdAsync(int userId,int exceptPostId, IPageInfo paging, string column, OrderDirection direction, string search, CancellationToken token);

        Task<PostEditDto> PostForEditingByIdAsync(int id, CancellationToken token);

        Task<BlogImage> GetDefaultImageAsync(int postId, string extension, CancellationToken token);

        Task<bool> CheckDefaultImage(int postId, string fileNameAndExtension );

        Task<bool> DeletePostAsync(int postId,int creatorId , CancellationToken token);
    }
}