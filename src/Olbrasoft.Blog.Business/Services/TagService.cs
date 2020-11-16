using Olbrasoft.Blog.Data.Commands;
using Olbrasoft.Blog.Data.Dtos.TagDtos;
using Olbrasoft.Blog.Data.Queries.TagQueries;
using Olbrasoft.Data;
using Olbrasoft.Data.Paging;
using Olbrasoft.Dispatching.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Olbrasoft.Blog.Business.Services
{
    public class TagService : Service, ITagService
    {
        public TagService(IDispatcher dispatcher) : base(dispatcher)
        {
        }

        public async Task<bool> ExistsAsync() => await new TagExistsQuery(Dispatcher).ExecuteAsync();

        public async Task<bool> ExistsAsync(string label) => await new TagExistsQuery(Dispatcher) { Label = label }.ExecuteAsync();

        public async Task<bool> ExistsAsync(int ExceptId, string label)
        {
            return await new TagExistsQuery(Dispatcher) { ExceptId = ExceptId, Label = label }.ExecuteAsync();
        }

        public async Task<bool> SaveAsync(int Id, string label, int userId)
        {
            var command = new TagSaveCommand(Dispatcher)
            {
                Id = Id,
                Label = label,
                CreatorId = userId
            };
            return await command.ExecuteAsync();
        }

        public async Task<IPagedResult<TagOfUserDto>> TagsByUserIdAsync(int userId, IPageInfo paging, string column, OrderDirection direction, string search)
        { return await new TagsByUserIdQuery(Dispatcher) { UserId = userId, Paging = paging, OrderByColumnName = column, OrderByDirection = direction, Search = search }.ExecuteAsync(); }

        public async Task<TagSmallDto> UserTagAsync(int id, int userId)
        { return await new TagByIdAndUserIdQuery(Dispatcher) { Id = id, UserId = userId }.ExecuteAsync(); }

        public async Task<IPagedResult<TagOfUsersDto>> TagsByExceptUserIdAsync(int exceptUserId, IPageInfo paging, string column, OrderDirection direction, string search)
        { return await new TagsByExceptUserIdQuery(Dispatcher) { ExceptUserId = exceptUserId, Paging = paging, OrderByColumnName = column, OrderByDirection = direction, Search = search }.ExecuteAsync(); }

        public async Task<IEnumerable<TagSmallDto>> FindAsync(string term, IEnumerable<int> exceptTagIds)
        { return await new TagsWhereLabelContainsTextQuery(Dispatcher) { Text = term, ExceptTagIds = exceptTagIds }.ExecuteAsync(); }

        public async Task<IEnumerable<TagSmallDto>> TagsByIds(IEnumerable<int> ids)
        {
            return await new TagsByIdsQuery(Dispatcher) { Ids = ids }.ExecuteAsync();
        }

        public async Task<IEnumerable<TagSmallDto>> TagsAsync()
        {
            return await new TagsQuery(Dispatcher).ExecuteAsync();
        }
    }
}