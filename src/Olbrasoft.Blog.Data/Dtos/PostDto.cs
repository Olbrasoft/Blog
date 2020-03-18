using System;

namespace Olbrasoft.Blog.Data.Dtos
{
    public class PostDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public DateTimeOffset Created { get; set; }

        public int CreatorId { get; set; }
    }
}