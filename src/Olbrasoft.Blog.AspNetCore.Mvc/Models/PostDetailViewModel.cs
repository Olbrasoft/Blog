using Olbrasoft.Blog.Data.Dtos;

namespace Olbrasoft.Blog.AspNetCore.Mvc.Models
{
    public class PostDetailViewModel : HomeAndPostModel
    {
        public PostDto Post { get; set; }
    }
}