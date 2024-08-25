using FluentStorage.Blobs;
using Microsoft.AspNetCore.Http;
using Olbrasoft.Blog.Data.Commands;
using Olbrasoft.Blog.Data.Dtos.PostDtos;
using Olbrasoft.Blog.Data.Queries.PostQueries;
using Olbrasoft.Data.Paging;
using Olbrasoft.Data.Sorting;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Olbrasoft.Blog.Business.Services;

public class PostService(IMediator mediator, IFileExtensionProvider provider, IBlobStorage storage) : Service(mediator), IPostService
{
    private readonly IFileExtensionProvider _provider = provider ?? throw new System.ArgumentNullException(nameof(provider));
    private readonly IBlobStorage _storage = storage ?? throw new System.ArgumentNullException(nameof(storage));


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

    public async Task<bool> SaveAsync(IFormFile? image, string title, string content, int categoryId, int userId, IEnumerable<int> tagIds, int id)
    {
        var extension = string.Empty;

        if (image is not null)
        {
            _provider.TryGetExtension(image.ContentType, out extension);

        }

        var command = new PostSaveCommand(Mediator)
        {
            Id = id,
            CategoryId = categoryId,
            Content = content,
            TagIds = tagIds,
            Title = title,
            CreatorId = userId,
            ImageExtension = extension
        };

        id = await command.ToResultAsync();

        if (image is not null)
        {
            using var stream = image.OpenReadStream();
            await _storage.WriteAsync($"{id}/0{extension}", stream);
        }

        return true;
    }

    public async Task<BlogImage> GetDefaultImageAsync(int blogId, string extension, CancellationToken token)
    {

        var blogImage = new BlogImage();

        if (_provider.TryGetContentType(extension, out var contentType))
        {
            blogImage.ImageContentType = contentType;

            var path = $"{blogId}/0{extension}";

            blogImage.ImageContent = await _storage.ReadBytesAsync(path, token);
        }

        return blogImage;

    }
}