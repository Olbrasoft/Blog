namespace Olbrasoft.Blog.Data.EntityFrameworkCore.Configurations
{
    public class CommentConfiguration : BlogTypeConfiguration<Comment>
    {
        public CommentConfiguration() : base("Comments")
        {
        }

        public override void TypeConfigure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasMany(p => p.NestedComments).WithOne(p => p.Comment).HasForeignKey(p => p.CommentId).OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Cascade);
        }
    }
}