namespace Olbrasoft.Blog.Business.Services
{
    public abstract class Service(IMediator mediator)
    {
        protected IMediator Mediator { get; } = mediator;
    }
}