using System.Collections.Generic;

namespace Olbrasoft.Blog.Data.Dtos.PostDtos
{
    public class PostEditDto : SmallDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public int CategoryId { get; set; }
        public IEnumerable<int> TagIds { get; set; }
    }
}