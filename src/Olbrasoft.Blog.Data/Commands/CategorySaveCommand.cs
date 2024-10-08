﻿namespace Olbrasoft.Blog.Data.Commands;

public class CategorySaveCommand : BlogCommand
{
    public CategorySaveCommand(ICommandExecutor executor) : base(executor)
    {
    }

    public CategorySaveCommand(IMediator mediator) : base(mediator)
    {
    }

    public string Name { get; set; } = string.Empty;
    public string Tooltip { get; set; } = string.Empty;
}