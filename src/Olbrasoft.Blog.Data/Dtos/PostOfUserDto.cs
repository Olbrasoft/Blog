using System;

namespace Olbrasoft.Blog.Data.Dtos
{
    public class PostOfUserDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string CategoryName { get; set; }
        public int CategoryId { get; set; }
        public DateTimeOffset Created { get; set; }
    }
}