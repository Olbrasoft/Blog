namespace Olbrasoft.Blog.Data.Dtos.TagDtos;

public class TagOfUserDto : TagSmallDto
{
    public int PostCount { get; set; }
    public DateTimeOffset Created { get; set; }
}