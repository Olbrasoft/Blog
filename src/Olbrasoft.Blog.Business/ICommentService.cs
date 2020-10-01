using Olbrasoft.Blog.Data.Dtos.CommentDtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Olbrasoft.Blog.Business
{
    public interface ICommentService
    {
        Task<bool> SaveAsync(int id, int postId, string text, int userId);

        Task<bool> SaveNestedCommentAsync(int id, int commentId, string text, int userId);

        Task<IEnumerable<CommentDto>> CommentsByPostIdAsync(int postId);

        Task<string> TextEditComment(int id, int creatorId = 0);

        Task<string> TextEditNestedComment(int id, int creatorId = 0);

        Task<bool> DeleteNestedComment(int id, int creatorId);

        Task<bool> DeleteComment(int id, int creatorId);
    }
}