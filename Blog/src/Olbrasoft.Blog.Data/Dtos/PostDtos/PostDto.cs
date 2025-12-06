namespace Olbrasoft.Blog.Data.Dtos.PostDtos;

public class PostDto : SmallDto
{
    public string Title { get; set; } = string.Empty;
    public DateTimeOffset Created { get; set; }
    public string Content { get; set; } = string.Empty;
    public int CreatorId { get; set; }
    public string Creator { get; set; } = string.Empty;
    public int CategoryId { get; set; }
    public string CategoryName { get; set; } = string.Empty;
      
    public string? Image{ get; set; }

    public ICollection<TagSmallDto> Tags { get; set; } = [];
}