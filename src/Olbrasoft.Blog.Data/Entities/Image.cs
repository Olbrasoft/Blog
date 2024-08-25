namespace Olbrasoft.Blog.Data.Entities
{
    public class Image : CreationInfo
    {
        public int PostId { get; set; }

        public string Path { get; set; } = string.Empty;

        public string? Alt { get; set; }

        public bool Default { get; set; }

        public Post Post { get; set; } = null!;
    }
}
