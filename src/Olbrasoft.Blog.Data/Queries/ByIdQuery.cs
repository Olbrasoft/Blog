namespace Olbrasoft.Blog.Data.Queries;

public abstract class ByIdQuery<TResult> : BaseQuery<TResult>
{
    protected ByIdQuery(IQueryProcessor processor) : base(processor)
    {
    }

    protected ByIdQuery(IDispatcher dispatcher) : base(dispatcher)
    {
    }

    public int Id { get; set; }
}