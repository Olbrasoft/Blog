using Olbrasoft.Dispatching;

namespace Olbrasoft.Blog.Data.Commands.NestedCommentCommands
{
    public class NestedCommentSaveCommand : CreatorSaveCommand
    {
        public NestedCommentSaveCommand(IDispatcher dispatcher) : base(dispatcher)
        {
        }

        public int CommentId { get; set; }

        public string Text { get; set; }
    }
}