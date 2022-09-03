namespace Olbrasoft.Blog.Data.Dtos.CommentDtos;

public class CommentDto : NestedCommentDto
{
    public IEnumerable<NestedCommentDto> NestedComments { get; set; } = Enumerable.Empty<NestedCommentDto>();
}