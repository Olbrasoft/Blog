namespace Olbrasoft.Blog.Data.EntityFrameworkCore.Configurations
{
    public class NestedCommentConfiguration : BlogTypeConfiguration<NestedComment>
    {
        public NestedCommentConfiguration() : base("NestedComments")
        {
        }

        public override void TypeConfigure(EntityTypeBuilder<NestedComment> builder)
        {
        }
    }
}