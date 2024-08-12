namespace Olbrasoft.Blog.Business.Services
{
    public abstract class Service
    {
        protected IMediator Mediator { get; }

        public Service(IMediator mediator)
        {
            Mediator = mediator;
        }
    }
}