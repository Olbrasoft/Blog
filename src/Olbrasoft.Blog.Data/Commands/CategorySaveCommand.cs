using Olbrasoft.Data.Cqrs;
using Olbrasoft.Dispatching;

namespace Olbrasoft.Blog.Data.Commands
{
    public class CategorySaveCommand : SaveCommand
    {
        public CategorySaveCommand(IDispatcher dispatcher) : base(dispatcher)
        {
        }

        public string Name { get; set; } = string.Empty;
        public string Tooltip { get; set; } = string.Empty;
        public int CreatorId { get; set; }
    }
}