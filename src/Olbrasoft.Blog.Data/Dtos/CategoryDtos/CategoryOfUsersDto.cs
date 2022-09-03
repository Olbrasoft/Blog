namespace Olbrasoft.Blog.Data.Dtos.CategoryDtos;

public class CategoryOfUsersDto : CategoryOfUserDto
{
    public int CreatorId { get; set; }

    public string Creator { get; set; } = string.Empty; 
}