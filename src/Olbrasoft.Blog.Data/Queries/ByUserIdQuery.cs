namespace Olbrasoft.Blog.Data.Queries;

public abstract class ByUserIdQuery<TResult> : PagedQuery<TResult>
{
  
    protected ByUserIdQuery(IQueryProcessor processor) : base(processor)
    {
    }

    protected ByUserIdQuery(IDispatcher dispatcher) : base(dispatcher)
    {
    }
}