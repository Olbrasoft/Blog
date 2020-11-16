using Olbrasoft.Dispatching.Common;

namespace Olbrasoft.Blog.Data.Commands
{
    public class CategorySaveCommand : CreatorSaveCommand
    {
        public CategorySaveCommand(IDispatcher dispatcher) : base(dispatcher)
        {
        }

        public string Name { get; set; } = string.Empty;
        public string Tooltip { get; set; } = string.Empty;
    }
}