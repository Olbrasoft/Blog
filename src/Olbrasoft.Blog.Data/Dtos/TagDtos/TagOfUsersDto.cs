namespace Olbrasoft.Blog.Data.Dtos.TagDtos;

public class TagOfUsersDto : TagOfUserDto
{
    public int CreatorId { get; set; }

    public string Creator { get; set; } = string.Empty;
}