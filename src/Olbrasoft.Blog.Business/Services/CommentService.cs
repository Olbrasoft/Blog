using Olbrasoft.Blog.Data.Commands.CommentCommands;
using Olbrasoft.Blog.Data.Commands.NestedCommentCommands;
using Olbrasoft.Blog.Data.Dtos.CommentDtos;
using Olbrasoft.Blog.Data.Queries.CommentQueries;
using Olbrasoft.Blog.Data.Queries.NestedCommentQueries;
using Olbrasoft.Dispatching;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Olbrasoft.Blog.Business.Services
{
    public class CommentService : Service, ICommentService
    {
        public CommentService(IDispatcher dispatcher) : base(dispatcher)
        {
        }

        public async Task<IEnumerable<CommentDto>> CommentsByPostIdAsync(int postId)
        {
            return await new CommentsByPostIdQuery(Dispatcher) { PostId = postId }.ExecuteAsync();
        }

        public async Task<bool> SaveAsync(int id, int postId, string text, int userId)
        {
            return await new CommentSaveCommand(Dispatcher)
            {
                Id = id,
                PostId = postId,
                Text = text,
                CreatorId = userId
            }.ExecuteAsync();
        }

        public async Task<bool> SaveNestedCommentAsync(int id, int commentId, string text, int userId)
        {
            return await new NestedCommentSaveCommand(Dispatcher)
            {
                Id = id,
                CommentId = commentId,
                Text = text,
                CreatorId = userId
            }.ExecuteAsync();
        }

        public async Task<string> TextEditComment(int id, int creatorId)
        {
            return await new CommentTextForEditingQuery(Dispatcher) { Id = id, CreatorId = creatorId }.ExecuteAsync();
        }

        public async Task<string> TextEditNestedComment(int id, int creatorId)
        {
            return await new NestedCommentTextForEditingQuery(Dispatcher) { Id = id, CreatorId = creatorId }.ExecuteAsync();
        }

        public async Task<bool> DeleteNestedComment(int id, int creatorId)
        {
            return await new NestedCommentDeleteCommand(Dispatcher) { Id = id, CreatorId = creatorId }.ExecuteAsync();
        }

        public async Task<bool> DeleteComment(int id, int creatorId)
        {
            return await new CommentDeleteCommand(Dispatcher) { Id = id, CreatorId = creatorId }.ExecuteAsync();
        }
    }
}