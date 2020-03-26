using System;

namespace Olbrasoft.Blog.Data.Dtos.PostDtos
{
    public class PostDto : SmallDto
    {
        public string Title { get; set; }
        public DateTimeOffset Created { get; set; }
        public string Content { get; set; }
        public int CreatorId { get; set; }
        public string Creator { get; set; }
    }
}