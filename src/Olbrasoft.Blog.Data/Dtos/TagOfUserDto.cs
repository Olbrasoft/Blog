using System;

namespace Olbrasoft.Blog.Data.Dtos
{
    public class TagOfUserDto : TagSmallDto
    {
        public int PostCount { get; set; }
        public DateTimeOffset Created { get; set; }
    }
}