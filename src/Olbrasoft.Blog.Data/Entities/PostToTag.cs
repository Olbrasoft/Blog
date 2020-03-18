namespace Olbrasoft.Blog.Data.Entities
{
    public class PostToTag : CreationInfo
    {
        public int ToId { get; set; }
        public Post Post { get; set; }
        public Tag Tag { get; set; }
    }
}