using System;

namespace Olbrasoft.Blog.Data.Dtos
{
    public class TagDto 
    {
        public int Id { get; set; }

        public string Label { get; set; }

        public string Creator { get; set; }

        public DateTime Created { get; set; }

        public int PostCount { get; set; }
    }
}