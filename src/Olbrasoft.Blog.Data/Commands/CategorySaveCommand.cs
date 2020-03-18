using Olbrasoft.Dispatching;

namespace Olbrasoft.Blog.Data.Commands
{
    public class CategorySaveCommand : Request<bool>
    {
        public CategorySaveCommand(IDispatcher dispatcher) : base(dispatcher)
        {
        }

        public int? Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Tooltip { get; set; } = string.Empty;
        public int UserId { get; set; }
    }
}