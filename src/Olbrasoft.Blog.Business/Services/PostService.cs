using Olbrasoft.Blog.Data.Commands;
using Olbrasoft.Blog.Data.Dtos.PostDtos;
using Olbrasoft.Blog.Data.Queries.PostQueries;
using Olbrasoft.Data.Paging;
using Olbrasoft.Data.Sorting;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Olbrasoft.Blog.Business.Services;

public class PostService : Service, IPostService
{
    public PostService(IMediator mediator) : base(mediator)
    {


    }

    public async Task<PostDetailDto> PostAsync(int id, CancellationToken token = default)
    {
        return await new PostDetailByIdQuery(Mediator) { Id = id }.ToResultAsync(token);
    }

    public async Task<PostEditDto> PostForEditingByIdAsync(int id, CancellationToken token)
        => await new PostByIdQuery(Mediator) { Id = id }.ToResultAsync(token);

    public async Task<IPagedEnumerable<PostDto>> PostsAsync(string search, IPageInfo paging, CancellationToken cancellationToken)
    {
        return await new PostsPagedQuery(Mediator) { Search = search, Paging = paging }.ToResultAsync(cancellationToken);
    }

    public async Task<IPagedResult<PostOfUserDto>> PostsByUserIdAsync(int userId, IPageInfo paging, string column, OrderDirection direction, string search, CancellationToken token = default)
    {
        var query = new PostsByUserIdQuery(Mediator)
        {
            UserId = userId,
            Paging = paging,
            OrderByColumnName = column,
            OrderByDirection = direction,
            Search = search
        };

        return await query.ToResultAsync(token);
    }

    public async Task<bool> SaveAsync(string title, string content, int categoryId, int userId, IEnumerable<int> tagIds, int id)
    {
        var command = new PostSaveCommand(Mediator)
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