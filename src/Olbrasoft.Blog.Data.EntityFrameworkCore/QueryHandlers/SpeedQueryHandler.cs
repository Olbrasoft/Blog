﻿using Olbrasoft.Blog.Data.Queries;

namespace Olbrasoft.Blog.Data.EntityFrameworkCore.QueryHandlers;
public class SpeedQueryHandler : BlogDbQueryHandler<Tag, SpeedQuery, string>
{
    public SpeedQueryHandler(IProjector projector, BlogDbContext context) : base(projector, context)
    {

    }

    protected override Task<string> GetResultToHandleAsync(SpeedQuery request, CancellationToken token)
    {
        return Task.FromResult("I am Speed query Hello world ");
    }
}