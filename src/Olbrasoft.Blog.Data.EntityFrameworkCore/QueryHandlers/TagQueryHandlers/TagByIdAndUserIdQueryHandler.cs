using Microsoft.EntityFrameworkCore;
using Olbrasoft.Blog.Data.Dtos.TagDtos;
using Olbrasoft.Blog.Data.Entities;
using Olbrasoft.Blog.Data.Queries.TagQueries;
using Olbrasoft.Mapping;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Olbrasoft.Blog.Data.EntityFrameworkCore.QueryHandlers.TagQueryHandlers
{
    public class TagByIdAndUserIdQueryHandler : BlogDbQueryHandler<Tag, TagByIdAndUserIdQuery, TagSmallDto>
    {
        public TagByIdAndUserIdQueryHandler(IProjector projector, IDbContextFactory<BlogDbContext> factory) : base(projector, factory)
        {
        }

        public override async Task<TagSmallDto> HandleAsync(TagByIdAndUserIdQuery query, CancellationToken token)
        {
            return await ProjectTo<TagSmallDto>(Entities.Where(p => p.CreatorId == query.UserId && p.Id == query.Id)).FirstOrDefaultAsync(token);
        }
    }
}