namespace Olbrasoft.Blog.Data.Dtos.PostDtos;

public class PostOfUserDto : SmallDto
{
    public string Title { get; set; }= string.Empty;
    public string CategoryName { get; set; } = string.Empty;
    public int CategoryId { get; set; }
    public DateTimeOffset Created { get; set; }
}