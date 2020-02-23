using System;

namespace Olbrasoft.Blog.AspNetCore.Mvc.Models
{
    public class PostModel
    {
        public string Title { get; set; } = "";
        public string Body { get; set; } = "";
        public DateTime Created { get; set; } = DateTime.Now;
    }
}