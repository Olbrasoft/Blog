using Olbrasoft.Dispatching;
using System.Collections.Generic;

namespace Olbrasoft.Blog.Data.Commands
{
    public class PostSaveCommand : Request<bool>
    {
        public PostSaveCommand(IDispatcher dispatcher) : base(dispatcher)
        {
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public int CategoryId { get; set; }

        public IEnumerable<int> TagIds { get; set; }

        public int UserId { get; set; }
    }
}