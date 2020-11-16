using Olbrasoft.Dispatching.Common;
using Olbrasoft.Mapping;
using System.Threading;
using System.Threading.Tasks;

namespace Olbrasoft.Data.Cqrs
{
    public abstract class CommandHandler<TCommand, TResult> : IRequestHandler<TCommand, TResult> where TCommand : Request<TResult>
    {
        private readonly IMapper _mapper;

        protected CommandHandler(IMapper mapper) => _mapper = mapper;

        public abstract Task<TResult> HandleAsync(TCommand command, CancellationToken token);

        protected TDestination MapTo<TDestination>(object source) => _mapper.MapTo<TDestination>(source);
    }

    public abstract class CommandHandler<TCommand> : CommandHandler<TCommand, bool> where TCommand : Request<bool>
    {
        protected CommandHandler(IMapper mapper) : base(mapper)
        {
        }
    }
}