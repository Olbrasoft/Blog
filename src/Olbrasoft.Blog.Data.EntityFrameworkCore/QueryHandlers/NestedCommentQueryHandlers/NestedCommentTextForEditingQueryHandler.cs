using Microsoft.EntityFrameworkCore;
using Olbrasoft.Blog.Data.Entities;
using Olbrasoft.Blog.Data.Queries.NestedCommentQueries;
using Olbrasoft.Data.Cqrs.EntityFrameworkCore;
using Olbrasoft.Mapping;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Olbrasoft.Blog.Data.EntityFrameworkCore.QueryHandlers.NestedCommentQueryHandlers
{
    public class NestedCommentTextForEditingQueryHandler : DbQueryHandler<NestedComment, NestedCommentTextForEditingQuery, string>
    {
        public NestedCommentTextForEditingQueryHandler(IProjector projector, DbContext context) : base(projector, context)
        {
        }

        public override async Task<string> HandleAsync(NestedCommentTextForEditingQuery query, CancellationToken token)
        {
            return await Entities.Where(p => p.Id == query.Id && (p.CreatorId == query.CreatorId || query.CreatorId == 0)).Select(p => p.Text).FirstOrDefaultAsync(token);
        }
    }
}