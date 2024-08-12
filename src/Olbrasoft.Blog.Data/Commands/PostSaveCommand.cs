﻿namespace Olbrasoft.Blog.Data.Commands;

public class PostSaveCommand : BlogCommand
{
    public PostSaveCommand(ICommandExecutor executor) : base(executor)
    {
    }

    public PostSaveCommand(IMediator mediator) : base(mediator)
    {
    }

    public string Title { get; set; } = string.Empty;

    public string Content { get; set; } = string.Empty;

    public int CategoryId { get; set; }

    public IEnumerable<int> TagIds { get; set; } = Enumerable.Empty<int>();
}