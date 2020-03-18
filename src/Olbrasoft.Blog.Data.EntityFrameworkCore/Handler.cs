using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Olbrasoft.Blog.Data.EntityFrameworkCore
{
    public abstract class Handler<TCommand, TResult> : IRequestHandler<TCommand, TResult> where TCommand : IRequest<TResult>
    {
        protected readonly BlogDbContext Ctx;

        protected Handler(BlogDbContext haveSet)
        {
            Ctx = haveSet;
        }

        public abstract Task<TResult> Handle(TCommand request , CancellationToken cancellationToken);
    }
}