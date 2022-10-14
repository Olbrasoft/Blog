using Olbrasoft.Blog.Data.Commands;
using Olbrasoft.Blog.Data.Dtos.TagDtos;
using Olbrasoft.Blog.Data.Queries.TagQueries;
using Olbrasoft.Data.Cqrs;
using Olbrasoft.Data.Paging;
using Olbrasoft.Data.Sorting;
using Olbrasoft.Dispatching;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Olbrasoft.Blog.Business.Services
{
    public class TagService : Service, ITagService
    {
        private readonly IDispatcher Dispatcher;
        private readonly ICommandExecutor _executor;

        public TagService(IDispatcher dispatcher, IQueryProcessor processor, ICommandExecutor executor) : base(processor)
        {
            Dispatcher = dispatcher;
            _executor = executor;
        }

        public async Task<bool> ExistsAsync() => await new TagExistsQuery(Processor).ToResultAsync();

        public async Task<bool> ExistsAsync(string label) => await new TagExistsQuery(Processor) { Label = label }.ToResultAsync();

        public async Task<bool> ExistsAsync(int ExceptId, string label)
        {
            return await new TagExistsQuery(Processor) { ExceptId = ExceptId, Label = label }.ToResultAsync();
        }

        public async Task<bool> SaveAsync(int Id, string label, int userId)
        {
            var command = new TagSaveCommand(_executor)
            {
                Id = Id,
                Label = label,
                CreatorId = userId
            };
            return await command.ToResultAsync();
        }

        public async Task<IPagedResult<TagOfUserDto>> TagsByUserIdAsync(int userId,
                                                                        IPageInfo paging,
                                                                        string column,
                                                                        OrderDirection direction,
                                                                        string search,
                                                                        CancellationToken token = default)
        { return await new TagsByUserIdQuery(Dispatcher)
        {
            UserId = userId,
            Paging = paging,
            OrderByColumnName = column,
            OrderByDirection = direction,
            Search = search
        }.ToResultAsync(token); }

        public async Task<TagSmallDto> UserTagAsync(int id, int userId, CancellationToken token = default)
        { return await new TagByIdAndUserIdQuery(Dispatcher) { Id = id, UserId = userId }.ToResultAsync(token); }

        public async Task<IPagedResult<TagOfUsersDto>> TagsByExceptUserIdAsync(int exceptUserId,
                                                                               IPageInfo paging,
                                                                               string column,
                                                                               OrderDirection direction,
                                                                               string search,
                                                                               CancellationToken token)
            => await new TagsByExceptUserIdQuery(Dispatcher)
            {
                ExceptUserId = exceptUserId,
                Paging = paging,
                OrderByColumnName = column,
                OrderByDirection = direction,
                Search = search
            }
            .ToResultAsync(token);

        public async Task<IEnumerable<TagSmallDto>> FindAsync(string term, IEnumerable<int> exceptTagIds)
        { return await new TagsByLabelContainsQuery(Dispatcher) { Text = term, ExceptTagIds = exceptTagIds }.ToResultAsync(); }

        public async Task<IEnumerable<TagSmallDto>> TagsByIds(IEnumerable<int> ids)
        {
            return await new TagsByIdsQuery(Processor) { Ids = ids }.ToResultAsync();
        }

        public async Task<IEnumerable<TagSmallDto>> TagsAsync(CancellationToken token = default)
            => await new TagsQuery(Dispatcher).ToResultAsync(token);

        public async Task<IEnumerable<TagSmallDto>> TagsByPostIdAsync(int postId, CancellationToken token)
            => await new TagsByPostIdQuery(Dispatcher) { PostId = postId }.ToResultAsync(token);
    }
}