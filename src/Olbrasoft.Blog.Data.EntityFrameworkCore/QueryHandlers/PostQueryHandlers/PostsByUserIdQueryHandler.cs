﻿namespace Olbrasoft.Blog.Data.EntityFrameworkCore.QueryHandlers.PostQueryHandlers;

public class PostsByUserIdQueryHandler : BlogDbQueryHandler<Post, PostsByUserIdQuery, IPagedResult<PostOfUserDto>>
{
    public PostsByUserIdQueryHandler(IProjector projector, BlogDbContext context) : base(projector, context)
    {
    }

    protected override async Task<IPagedResult<PostOfUserDto>> GetResultToHandleAsync(PostsByUserIdQuery query, CancellationToken token)
    {
        var filteredPosts = Queryable.Where(p => p.CreatorId == query.UserId);

        if (!string.IsNullOrEmpty(query.Search))
        {
            filteredPosts = filteredPosts.Where(p => p.Title.ToLower().Contains(query.Search.ToLower()) || p.Content.ToLower().Contains(query.Search.ToLower()));
        }

        var posts = ProjectTo<PostOfUserDto>(filteredPosts.OrderBy(query.OrderByColumnName, query.OrderByDirection))
             .Skip(query.Paging.CalculateSkip())
             .Take(query.Paging.PageSize);

        return (await posts.ToArrayAsync(token)).AsPagedResult(await Queryable.Where(p => p.CreatorId == query.UserId).CountAsync(), await filteredPosts.CountAsync());
    }
}