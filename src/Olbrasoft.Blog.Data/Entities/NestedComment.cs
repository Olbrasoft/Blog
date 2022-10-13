using System.ComponentModel.DataAnnotations;

namespace Olbrasoft.Blog.Data.Entities;

public class NestedComment : CreationInfo
{
    private Comment? _comment;

    [Required]
    [StringLength(500)]
    public string Text { get; set; } = string.Empty;

    public int CommentId { get; set; }

    public Comment Comment { get => _comment ?? throw new InvalidOperationException(nameof(Comment)); set => _comment = value; }

}