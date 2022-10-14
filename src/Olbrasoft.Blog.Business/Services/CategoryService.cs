﻿using Olbrasoft.Blog.Data.Commands;
using Olbrasoft.Blog.Data.Dtos.CategoryDtos;
using Olbrasoft.Blog.Data.Queries.CategoryQueries;
using Olbrasoft.Data.Cqrs;
using Olbrasoft.Data.Paging;
using Olbrasoft.Data.Sorting;
using Olbrasoft.Dispatching;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Olbrasoft.Blog.Business.Services
{
    public class CategoryService : Service, ICategoryService
    {
        private readonly IDispatcher Dispatcher;
        private readonly ICommandExecutor _executor;

        public CategoryService(IDispatcher dispatcher, IQueryProcessor processor, ICommandExecutor executor) : base(processor)
        {
            Dispatcher = dispatcher;
            _executor = executor;
        }

        public async Task<IEnumerable<CategorySmallDto>> CategoriesAsync(CancellationToken token = default)
        {
            var query = new CategoriesQuery(Dispatcher);

            return await query.ToResultAsync(token);
        }

        public async Task<IPagedResult<CategoryOfUsersDto>> CategoriesByExceptUserIdAsync(int exceptUserId,
                                                                                          IPageInfo paging,
                                                                                          string column,
                                                                                          OrderDirection direction,
                                                                                          string search,
                                                                                          CancellationToken token = default)
        {
            return await new CategoriesByExceptUserIdQuery(Dispatcher)
            {
                ExceptUserId = exceptUserId,
                Paging = paging,
                OrderByColumnName = column,
                OrderByDirection = direction,
                Search = search

            }.ToResultAsync(token);

        }

        public async Task<IPagedResult<CategoryOfUserDto>> CategoriesByUserIdAsync(int userId,
                                                                                   IPageInfo paging,
                                                                                   string column,
                                                                                   OrderDirection direction,
                                                                                   string search,
                                                                                   CancellationToken token = default)
        {
            return await new CategoriesByUserIdQuery(Dispatcher)
            {
                UserId = userId,
                Paging = paging,
                OrderByColumnName = column,
                OrderByDirection = direction,
                Search = search

            }.ToResultAsync(token);
        }

        public async Task<CategoryOfUserDto> CategoryAsync(int id, CancellationToken token = default)
        {
            return await new CategoryQuery(Dispatcher) { Id = id }.ToResultAsync(token);
        }

        public async Task<bool> ExistsAsync(int ExceptId = 0, string name = "")
        {
            var query = new CategoryExistsQuery(Processor) { ExceptId = ExceptId, Name = name };
            return await query.ToResultAsync();
        }

        public async Task<bool> SaveAsync(int Id, string name, string tooltip, int userId)
        {
            var command = new CategorySaveCommand(_executor)
            {
                Id = Id,
                Name = name,
                Tooltip = tooltip,
                CreatorId = userId
            };
            return await command.ToResultAsync();
        }
    }
}