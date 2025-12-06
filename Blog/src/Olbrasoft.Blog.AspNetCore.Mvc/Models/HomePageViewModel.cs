using Olbrasoft.Data.Paging.X.PagedList.AspNetCore.Mvc;

namespace Olbrasoft.Blog.AspNetCore.Mvc.Models;

public class HomePageViewModel : HomeAndPostModel
{
    public IPagedList<PostDto> Posts { get; set; } = new PagedList<PostDto>(Enumerable.Empty<PostDto>(),1,1);

    public PagedListRenderOptions Options { get; set; } = new PagedListRenderOptions();
}