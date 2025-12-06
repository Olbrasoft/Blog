namespace Olbrasoft.Blog.Data.Entities
{
    public class Image : CreationInfo
    {
        public int PostId { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Extension { get; set; } = string.Empty;

        public string MimeType { get; set; } = string.Empty;

        public string? Alt { get; set; }

        public bool Default { get; set; }

        public Post Post { get; set; } = null!;
    }
}
