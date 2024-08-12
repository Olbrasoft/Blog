namespace Olbrasoft.Blog.Data.Queries;

public abstract class ExceptUserIdQuery<TResult> : PagedQuery<TResult>
{
    public int ExceptUserId { get; set; }

    protected ExceptUserIdQuery(IQueryProcessor processor) : base(processor)
    {
    }

    protected ExceptUserIdQuery(IMediator mediator) : base(mediator)
    {
    }
}