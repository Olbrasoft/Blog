namespace Olbrasoft.Blog.Data.EntityFrameworkCore.Configurations
{
    public class BlogPostConfiguration : BlogTypeConfiguration<Post>
    {
        public BlogPostConfiguration() : base("","Posts")
        {
            
        }

        public override void TypeConfigure(EntityTypeBuilder<Post> builder)
        {
            builder.HasMany(p => p.Comments).WithOne(p => p.Post).HasForeignKey(p => p.PostId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(p => p.Category).WithMany(p => p.Posts).HasForeignKey(p => p.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);

        //    builder.HasMany(p => p.Tags).WithMany(t => t.Posts).UsingEntity<PostToTag>(j => j
        //    .HasOne<Tag>()
        //    .WithMany()
        //    .HasForeignKey(p => p.ToId)
        //    .HasConstraintName("FK_PostTags_Tags_ToId")
        //    ,
        //j => j
        //    .HasOne<Post>()
        //    .WithMany()
        //    .HasForeignKey(p => p.Id)
        //    .HasConstraintName("FK_PostTags_Posts_Id")
        //    ).ToTable("PostTags").HasKey(p=> new { p.Id,p.ToId });




        }
            


            //.OnDelete(DeleteBehavior.ClientCascade)
        
    }
}