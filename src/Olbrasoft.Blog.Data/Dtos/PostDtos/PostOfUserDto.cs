using System;

namespace Olbrasoft.Blog.Data.Dtos.PostDtos
{
    public class PostOfUserDto : SmallDto
    {
        public string Title { get; set; }
        public string CategoryName { get; set; }
        public int CategoryId { get; set; }
        public DateTimeOffset Created { get; set; }
    }
}