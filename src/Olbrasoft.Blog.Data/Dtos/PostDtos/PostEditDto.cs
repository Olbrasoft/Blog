namespace Olbrasoft.Blog.Data.Dtos.PostDtos;

public class PostEditDto : SmallDto
{
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;

    public string DefaultImageNameAndExtension { get; set; } = string.Empty;

    public int CategoryId { get; set; }
    public IEnumerable<TagSmallDto> Tags { get; set; } = Enumerable.Empty<TagSmallDto>();
}