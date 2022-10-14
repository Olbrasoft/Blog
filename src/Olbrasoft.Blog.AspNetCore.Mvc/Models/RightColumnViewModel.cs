namespace Olbrasoft.Blog.AspNetCore.Mvc.Models;

public class RightColumnViewModel
{
    public Tuple<IEnumerable<CategorySmallDto>, IEnumerable<CategorySmallDto>> Categories { get; set; }

    public Tuple<IEnumerable<TagSmallDto>, IEnumerable<TagSmallDto>> Tags { get; set; }

    public string CurrentQuery { get; set; }
}