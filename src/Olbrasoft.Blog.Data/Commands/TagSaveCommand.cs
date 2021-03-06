﻿using Olbrasoft.Data.Cqrs;
using Olbrasoft.Dispatching.Common;

namespace Olbrasoft.Blog.Data.Commands
{
    public class TagSaveCommand : CreatorSaveCommand
    {
        public TagSaveCommand(IDispatcher dispatcher) : base(dispatcher)
        {
        }

        public string Label { get; set; } = string.Empty;
    }
}