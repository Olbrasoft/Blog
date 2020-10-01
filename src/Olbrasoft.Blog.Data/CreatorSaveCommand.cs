using Olbrasoft.Data.Cqrs;
using Olbrasoft.Dispatching;

namespace Olbrasoft.Blog.Data
{
    public abstract class CreatorSaveCommand : SaveCommand
    {
        public CreatorSaveCommand(IDispatcher dispatcher) : base(dispatcher)
        {
        }

        public int CreatorId { get; set; }
    }
}