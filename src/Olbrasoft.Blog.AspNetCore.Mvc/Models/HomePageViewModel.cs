using Olbrasoft.Blog.Data.Dtos.PostDtos;
using X.PagedList;

namespace Olbrasoft.Blog.AspNetCore.Mvc.Models
{
    public class HomePageViewModel : HomeAndPostModel
    {
        public IPagedList<PostDto> Posts { get; set; }
    }
}