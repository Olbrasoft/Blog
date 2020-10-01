using Olbrasoft.Dispatching;

namespace Olbrasoft.Blog.Data.Commands.CommentCommands
{
    public class CommentSaveCommand : CreatorSaveCommand
    {
        public CommentSaveCommand(IDispatcher dispatcher) : base(dispatcher)
        {
        }

        public int PostId { get; set; }

        public string Text { get; set; }
    }
}