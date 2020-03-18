using MediatR;

namespace Olbrasoft.Data.Cqrs
{
    public abstract class Query<TResult> : IRequest<TResult>
    {
    }
}