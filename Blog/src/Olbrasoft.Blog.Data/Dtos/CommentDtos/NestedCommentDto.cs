namespace Olbrasoft.Blog.Data.Dtos.CommentDtos;

public class NestedCommentDto : SmallDto
{
    public string Text { get; set; } = string.Empty;

    public string Creator { get; set; } = string.Empty;

    public int CreatorId { get; set; }
}