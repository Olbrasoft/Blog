using Olbrasoft.Blog.Data.Commands.CommentCommands;
using Olbrasoft.Blog.Data.Dtos.CommentDtos;
using Olbrasoft.Blog.Data.Queries.CommentQueries;
using Olbrasoft.Blog.Data.Queries.NestedCommentQueries;
using Olbrasoft.Data.Cqrs;
using Olbrasoft.Dispatching;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Olbrasoft.Blog.Business.Services;

public class CommentService : Service, ICommentService
{
   
    private readonly ICommandExecutor _executor;

    public CommentService(IDispatcher dispatcher, IQueryProcessor processor, ICommandExecutor executor) : base(dispatcher)
    {
        
        _executor = executor;
    }

    public async Task<IEnumerable<CommentDto>> CommentsByPostIdAsync(int postId, CancellationToken token = default) 
        => await new CommentsByPostIdQuery(Dispatcher) { PostId = postId }.ToResultAsync(token);

    public async Task<bool> SaveAsync(int id, int postId, string text, int userId)
    {
        return await new CommentSaveCommand(_executor)
        {
            Id = id,
            PostId = postId,
            Text = text,
            CreatorId = userId
        
        }.ToResultAsync();
    }

    public async Task<bool> SaveNestedCommentAsync(int id, int commentId, string text, int userId)
    {
        return await new NestedCommentSaveCommand(_executor)
        {
            Id = id,
            CommentId = commentId,
            Text = text,
            CreatorId = userId
        }.ToResultAsync();
    }

    public async Task<string> TextEditComment(int id, int creatorId, CancellationToken token = default) 
        => await new CommentTextForEditingQuery(Dispatcher) { Id = id, CreatorId = creatorId }.ToResultAsync(token);

    public async Task<string> TextEditNestedComment(int id, int creatorId, CancellationToken token = default) 
        => await new NestedCommentTextForEditingQuery(Dispatcher) { Id = id, CreatorId = creatorId }.ToResultAsync(token);

    public async Task<bool> DeleteNestedComment(int id, int creatorId)
    {
        return await new NestedCommentDeleteCommand(_executor) { Id = id, CreatorId = creatorId }.ToResultAsync();
    }

    public async Task<bool> DeleteComment(int id, int creatorId)
    {
        return await new CommentDeleteCommand(_executor) { Id = id, CreatorId = creatorId }.ToResultAsync();
    }
}