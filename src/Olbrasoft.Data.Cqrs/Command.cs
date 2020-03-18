using MediatR;

namespace Olbrasoft.Data.Cqrs
{
    public abstract class Command<TResult> : IRequest<TResult>
    {

    }
}