using Olbrasoft.Blog.Data.Commands;
using Olbrasoft.Blog.Data.Dtos.PostDtos;
using Olbrasoft.Blog.Data.Queries.PostQueries;
using Olbrasoft.Data.Cqrs;
using Olbrasoft.Data.Paging;
using Olbrasoft.Data.Sorting;
using Olbrasoft.Dispatching;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Olbrasoft.Blog.Business.Services;

public class PostService : Service, IPostService
{
    private readonly IDispatcher Dispatcher;
    private readonly ICommandExecutor _executor;

    public PostService(IDispatcher dispatcher, IQueryProcessor processor, ICommandExecutor executor) : base(processor)
    {
        Dispatcher = dispatcher;
        _executor = executor;
    }

    public async Task<PostDetailDto> PostAsync(int id, CancellationToken token = default)
    {
        return await new PostDetailByIdQuery(Processor) { Id = id }.ToResultAsync(token);
    }

    public async Task<PostEditDto> PostForEditingByIdAsync(int id, CancellationToken token) 
        => await new PostByIdQuery(Dispatcher) { Id = id }.ToResultAsync(token);

    public async Task<IPagedEnumerable<PostDto>> PostsAsync(string search, IPageInfo paging, CancellationToken cancellationToken)
    {
        return await new PostsPagedQuery(Processor) { Search = search, Paging = paging }.ToResultAsync(cancellationToken);
    }

    public async Task<IPagedResult<PostOfUserDto>> PostsByUserIdAsync(int userId, IPageInfo paging, string column, OrderDirection direction, string search, CancellationToken token = default)
    {
        var query = new PostsByUserIdQuery(Dispatcher)
        {
            UserId = userId,
            Paging = paging,
            OrderByColumnName = column,
            OrderByDirection = direction,
            Search = search
        };

        return await query.ToResultAsync(token);
    }

    public async Task<bool> SaveAsync(string title, string content, int categoryId, int userId = 0, IEnumerable<int> tagIds = null, int id = 0)
    {
        var command = new PostSaveCommand(_executor)
        {
            Id = id,
            CategoryId = categoryId,
            Content = content,
            TagIds = tagIds,
            Title = title,
            CreatorId = userId
        };

        return await command.ToResultAsync();
    }
}