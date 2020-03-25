using System;

namespace Olbrasoft.Blog.Data.Dtos
{
    public class CategoryOfUserDto : CategorySmallDto
    {
        public int PostCount { get; set; }

        public string Tooltip { get; set; } = string.Empty;

        public DateTimeOffset Created { get; set; }
    }
}