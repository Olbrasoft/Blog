using Olbrasoft.Dispatching;

namespace Olbrasoft.Blog.Data.Commands
{
    public class TagSaveCommand : Request<bool>
    {
        public TagSaveCommand(IDispatcher dispatcher) : base(dispatcher)
        {
        }

        public int Id { get; set; }
        public string Label { get; set; } = string.Empty;
        public int UserId { get; set; }
    }
}