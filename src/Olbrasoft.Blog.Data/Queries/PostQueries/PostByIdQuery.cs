﻿namespace Olbrasoft.Blog.Data.Queries.PostQueries;

public class PostByIdQuery : ByIdQuery<PostEditDto>
{
    public PostByIdQuery(IQueryProcessor processor) : base(processor)
    {
    }

    public PostByIdQuery(IDispatcher dispatcher) : base(dispatcher)
    {
    }
}