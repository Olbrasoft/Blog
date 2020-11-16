using Olbrasoft.Dispatching.Common;

namespace Olbrasoft.Blog.Business.Services
{
    public abstract class Service
    {
        protected IDispatcher Dispatcher { get; }

        public Service(IDispatcher dispatcher)
        {
            Dispatcher = dispatcher;
        }
    }
}