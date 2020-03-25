using Olbrasoft.Data.Cqrs;
using Olbrasoft.Dispatching;

namespace Olbrasoft.Blog.Data.Commands
{
    public class TagSaveCommand : SaveCommand
    {
        public TagSaveCommand(IDispatcher dispatcher) : base(dispatcher)
        {
        }

        public string Label { get; set; } = string.Empty;
        public int CreatorId { get; set; }
    }
}