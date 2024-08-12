namespace Olbrasoft.Blog.AspNetCore.Mvc.Models;

public class RightColumnViewModel
{
    public Tuple<IEnumerable<CategorySmallDto>, IEnumerable<CategorySmallDto>> Categories { get; set; }
    = Tuple.Create(Enumerable.Empty<CategorySmallDto>(), Enumerable.Empty<CategorySmallDto>());


    public Tuple<IEnumerable<TagSmallDto>, IEnumerable<TagSmallDto>> Tags { get; set; }
        = Tuple.Create(Enumerable.Empty<TagSmallDto>(), Enumerable.Empty<TagSmallDto>());

    public string CurrentQuery { get; set; } = string.Empty;
}