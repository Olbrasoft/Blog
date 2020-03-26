using Olbrasoft.Blog.Data.Dtos.TagDtos;
using Olbrasoft.Dispatching;

namespace Olbrasoft.Blog.Data.Queries.TagQueries
{
    public class TagByIdAndUserIdQuery : Request<TagSmallDto>
    {
        public TagByIdAndUserIdQuery(IDispatcher dispatcher) : base(dispatcher)
        {
        }

        public int Id { get; set; }
        public int UserId { get; set; }
    }
}