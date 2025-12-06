using Olbrasoft.Blog.Data.Commands.TagCommands;
using Olbrasoft.Blog.Data.Dtos.TagDtos;
using Olbrasoft.Blog.Data.Queries.TagQueries;
using Olbrasoft.Data.Paging;
using Olbrasoft.Data.Sorting;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Olbrasoft.Blog.Business.Services
{
    public class TagService(IMediator mediator) : Service(mediator), ITagService
    {


        public async Task<bool> ExistsAsync(int ExceptId, string label, CancellationToken token = default)
            => await new TagExistsQuery(Mediator) { ExceptId = ExceptId, Label = label }.ToResultAsync(token);


        public async Task<bool> SaveAsync(int Id, string label, int userId, CancellationToken token)

            => await new TagSaveCommand(Mediator)
            {
                Id = Id,
                Label = label,
                CreatorId = userId

            }.ToResultAsync(token);


        public async Task<IPagedResult<TagOfUserDto>> TagsByUserIdAsync(int userId,
                                                                        IPageInfo paging,
                                                                        string column,
                                                                        OrderDirection direction,
                                                                        string search,
                                                                        CancellationToken token = default)
            => await new TagsByUserIdQuery(Mediator)
            {
                UserId = userId,
                Paging = paging,
                OrderByColumnName = column,
                OrderByDirection = direction,
                Search = search

            }.ToResultAsync(token);


        public async Task<TagSmallDto> UserTagAsync(int id, int userId, CancellationToken token = default)
            => await new TagByIdAndUserIdQuery(Mediator) { Id = id, UserId = userId }.ToResultAsync(token);


        public async Task<IPagedResult<TagOfUsersDto>> TagsByExceptUserIdAsync(int exceptUserId,
                                                                               IPageInfo paging,
                                                                               string column,
                                                                               OrderDirection direction,
                                                                               string search,
                                                                               CancellationToken token)
            => await new TagsByExceptUserIdQuery(Mediator)
            {
                ExceptUserId = exceptUserId,
                Paging = paging,
                OrderByColumnName = column,
                OrderByDirection = direction,
                Search = search
            }
            .ToResultAsync(token);


        public async Task<IEnumerable<TagSmallDto>> FindAsync(string term, IEnumerable<int> exceptTagIds, CancellationToken token)
            => await new TagsByLabelContainsQuery(Mediator) { Text = term, ExceptTagIds = exceptTagIds }.ToResultAsync(token);


        public async Task<IEnumerable<TagSmallDto>> TagsByIds(IEnumerable<int> ids, CancellationToken token)
            => await new TagsByIdsQuery(Mediator) { Ids = ids }.ToResultAsync(token);


        public async Task<IEnumerable<TagSmallDto>> TagsAsync(CancellationToken token = default)
            => await new TagsQuery(Mediator).ToResultAsync(token);


        public async Task<IEnumerable<TagSmallDto>> TagsByPostIdAsync(int postId, CancellationToken token)
            => await new TagsByPostIdQuery(Mediator) { PostId = postId }.ToResultAsync(token);

        public async Task<bool> DeleteAsync(int tagId, int userId, CancellationToken token = default)
            => await new TagDeleteCommand(Mediator)
            {
                Id = tagId,
                CreatorId = userId,
            }
            .ToResultAsync(token);
    }
}