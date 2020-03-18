using Olbrasoft.Blog.Data.Commands;
using Olbrasoft.Blog.Data.Dtos;
using Olbrasoft.Blog.Data.Queries.TagQueries;
using Olbrasoft.Data;
using Olbrasoft.Data.Paging;
using Olbrasoft.Dispatching;
using Olbrasoft.Paging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Olbrasoft.Blog.Business.Services
{
    public class TagService : Service, ITagService
    {
        public TagService(IDispatcher dispatcher) : base(dispatcher)
        {
        }

        public async Task<bool> ExistsAsync()
        {
            var query = new TagExistsQuery(Dispatcher);
            return await query.ExecuteAsync();
        }

        public Task<bool> ExistsAsync(string label)
        {
            var query = new TagExistsQuery(Dispatcher) { Label = label };
            return query.ExecuteAsync();
        }

        public Task<bool> ExistsAsync(int ExceptId, string label)
        {
            var query = new TagExistsQuery(Dispatcher) { ExceptId = ExceptId, Label = label };
            return query.ExecuteAsync();
        }

        public async Task<bool> SaveAsync(int Id, string label, int userId)
        {
            var command = new TagSaveCommand(Dispatcher)
            {
                Id = Id,
                Label = label,
                UserId = userId
            };
            return await command.ExecuteAsync();
        }

        public async Task<IPagedResult<TagDto>> UserTagsAsync(int userId, IPageInfo paging, string column, OrderDirection direction, string search)
        {
            var query = new TagsByUserIdQuery(Dispatcher)
            {
                UserId = userId,
                Paging = paging,
                OrderByColumnName = column,
                OrderByDirection = direction,
                Search = search
            };

            return await query.ExecuteAsync();
        }

        public async Task<TagDto> UserTagAsync(int id, int userId)
        {
            var query = new TagByIdAndUserIdQuery(Dispatcher) { Id = id, UserId = userId };
            return await query.ExecuteAsync();
        }

        public async Task<IPagedResult<TagDto>> OtherUsersTags(int exceptUserId, IPageInfo paging, string column, OrderDirection direction, string search)
        {
            var query = new TagsExceptUserIdQuery(Dispatcher)
            {
                ExceptUserId = exceptUserId,
                Paging = paging,
                OrderByColumnName = column,
                OrderByDirection = direction,
                Search = search
            };
            return await query.ExecuteAsync();
        }

        public async Task<IEnumerable<TagDto>> Find(string term, IEnumerable<int> exceptTagIds)
        {
            var query = new TagsWhereLabelContainsTextQuery(Dispatcher) { Text = term, ExceptTagIds = exceptTagIds };

            return await query.ExecuteAsync();
        }

        public async Task<IEnumerable<TagBasicDto>> TagsByIds(IEnumerable<int> ids)
        {
            var query = new TagsByIdsQuery(Dispatcher) { Ids = ids };

            return await query.ExecuteAsync();
        }
    }
}