namespace Olbrasoft.Blog.Data.Dtos.NestedCommentDtos
{
    public class NestedCommentDto : SmallDto
    {
        public string Text { get; set; }

        public string Creator { get; set; }

        public int CreatorId { get; set; }
    }
}