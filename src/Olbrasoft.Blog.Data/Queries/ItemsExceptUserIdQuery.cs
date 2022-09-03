namespace Olbrasoft.Blog.Data.Queries;

public abstract class ItemsExceptUserIdQuery<TResult> : DataTablesPagedQuery<TResult>
{
    protected ItemsExceptUserIdQuery(IDispatcher dispatcher) : base(dispatcher)
    {
    }

    public int ExceptUserId { get; set; }
}