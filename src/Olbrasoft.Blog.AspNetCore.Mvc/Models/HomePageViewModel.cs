using Olbrasoft.Blog.Data.Dtos.PostDtos;
using Olbrasoft.Data.Paging.X.PagedList.AspNetCore.Mvc;
using X.PagedList;

namespace Olbrasoft.Blog.AspNetCore.Mvc.Models
{
    public class HomePageViewModel : HomeAndPostModel
    {
        public IPagedList<PostDto> Posts { get; set; }

        public PagedListRenderOptions Options { get; set; }
    }
}