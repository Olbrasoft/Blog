using Olbrasoft.Data.Cqrs;

namespace Olbrasoft.Blog.Business.Services
{
    public abstract class Service
    {
        protected IQueryProcessor Processor { get; }

        public Service(IQueryProcessor processor)
        {
            Processor = processor;
        }
    }
}